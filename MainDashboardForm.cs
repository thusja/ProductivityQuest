using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductivityQuest.Services;
using ProductivityQuest.Models;
using ProductivityQuest.Forms;
using System.IO;

namespace ProductivityQuest
{
    public partial class MainDashboardForm: Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
        }

        private ProcessTracker tracker;
        private int totalExp = 0; // exp 전역 변수 추가
        private int level = 1; // level 전역 변수 추가

        // 현재 레벨 내 exp 및 다음 레벨까지 필요 EXP 추적
        private int expInCurrentLevel = 0;
        private int expToNextLevel = 100;

        // 마감 시각 설정(오후 11시 기준)
        private readonly TimeSpan deadlineTime = new TimeSpan(23, 0, 0);
        private bool deadlineMarked = false; // 하루 1회 마감 처리 플래그

        private double floatExp = 0; // 소수점 exp 누적용
        private const double penaltyExpPerTick = 0.14; // 5초당 차감량 (1시간 = 100exp)

        private List<RawAppInfo> currentAppList = new List<RawAppInfo>();

        // 앱별 보상 EXP 테이블
        private readonly Dictionary<string, int> appExpRewards = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "Code.exe", 20 }, // VSCode
            { "devenv.exe", 20 }, // Visual Studio
            { "POWERPNT.exe", 15 }, // PowerPoint
            { "EXCEL.exe", 15 }, // excel
            { "WINWORD.exe", 15 }, // word
            { "chrome.exe", 1 } // chrome
        };

        // 감시 중 실행되면 감점할 앱 리스트
        private readonly HashSet<string> penalizedApps = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "steam.exe", // 스팀
            "Battle.net.exe", // 배틀넷
            "RiotClientServices.exe", // 라이엇
            "STOVE.exe", // 스토브
            "NexonMessenger.exe", // 넥슨
            "upc.exe", // 유비소프트
            "EpicGamesLauncher.exe" // 에픽게임즈
        };

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            // 사용자 레벨/EXP 로드
            var profile = ProfileManager.Load();
            level = profile.Level;
            totalExp = profile.Exp;

            // 초기 로딩 시 레벨 계산 반영
            level = LevelCalculator.CalculateLevel(totalExp, out expInCurrentLevel, out expToNextLevel);

            lblLevel.Text = $"레벨 : {level}";
            lblExp.Text = $"EXP : {expInCurrentLevel} / {expToNextLevel}";

            // 트래커 초기화 + 패널티 앱 목록 전달
            tracker = new ProcessTracker(TimeSpan.FromSeconds(5), penalizedApps);

            // 저장된 앱 사용 목표 불러오기 + 오늘 날짜만 필터링
            var savedUsages = AppUsageStorage.Load()
                              .Where(a => a.CreatedDate.Date == DateTime.Today)
                              .ToList();
            foreach (var usage in savedUsages)
            {
                tracker.ForceAddApp(usage); // 목표 시간 포함 등록
            }

            // 타이머 시작
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tracker.UpdateAppUsages();

            // 현재 시간 확인
            TimeSpan now = DateTime.Now.TimeOfDay;

            // 오후 11시 도달 시 감시 중단 및 버튼 비활성화
            if (!deadlineMarked && now >= deadlineTime)
            {
                tracker.StopTracking();
                deadlineMarked = true;

                btnStart.Enabled = false;
                btnStop.Enabled = false;
                btnSetGoals.Enabled = false;

                lblStatus.Text = $"상태 : 마감 완료 ({DateTime.Now:T})";
            }

            // 자정 이후 다시 활성화 + 초기화
            if (now < new TimeSpan(1, 0, 0)) // 00 : 00 ~ 01 : 00 사이
            {
                if (deadlineMarked)
                {
                    deadlineMarked = false;

                    btnStart.Enabled = true;
                    btnStop.Enabled = true;
                    btnSetGoals.Enabled = true;

                    lblStatus.Text = "상태 : 재시작 가능 (다음 날)";
                    dataGridStats.Rows.Clear(); // 그리드 뷰 초기화
                }
            }

            var list = tracker.GetCurrentAppUsages()
                              .Where(a => a.CreatedDate.Date == DateTime.Today) // 오늘 날짜만 필터링
                              .Where(a => a.GoalTime > TimeSpan.Zero || a.Status == "패널티") // GoalTime 있는 앱만
                              .ToList();

            // 기존 행 삭제
            dataGridStats.Rows.Clear();

            // 리스트 추가
            foreach (var app in list)
            {
                int rowIndex = dataGridStats.Rows.Add(
                    app.AppName,
                    app.UsageTime.ToString(@"hh\:mm\:ss"),
                    app.GoalTime.ToString(@"hh\:mm\:ss"),
                    app.Status
                );

                // 보상 처리
                if (app.Status == "달성" && !app.IsRewarded)
                {
                    // 앱별 EXP 지급 로직
                    int reward = appExpRewards.ContainsKey(app.AppName)
                        ? appExpRewards[app.AppName]
                        : 10; // 기본 보상

                    totalExp += reward;
                    app.IsRewarded = true; // 중복 방지용 플래그

                    int prevLevel = level;
                    level = LevelCalculator.CalculateLevel(totalExp, out expInCurrentLevel, out expToNextLevel);

                    if (level > prevLevel)
                    {
                        MessageBox.Show($"🎉 레벨 {level} 달성!", "레벨업");
                    }
                }

                // 패널티 처리
                if (app.Status == "패널티" && !app.IsPenaltyApplied)
                {
                    floatExp -= penaltyExpPerTick;

                    if (floatExp <= -1)
                    {
                        totalExp += (int)floatExp; // 음수 값이므로 자동 감점
                        floatExp = 0;

                        if (totalExp < 0)
                        {
                            if (level > 1)
                            {
                                level--;
                                totalExp = 0;
                                MessageBox.Show($"⚠ {app.AppName} 과도 사용으로 레벨이 감소했습니다!", "레벨 다운");
                            }
                            else
                            {
                                totalExp = 0;
                            }
                        }
                    }
                }

                // 상태에 따른 행 색상 지정
                var row = dataGridStats.Rows[rowIndex];

                // 상태에 따른 색상 지정
                switch (app.Status)
                {
                    case "달성":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "패널티":
                        row.DefaultCellStyle.BackColor = Color.IndianRed;
                        break;
                    case "진행중":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "미달성":
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                }
            }

            dataGridStats.ClearSelection();

            // 상태 텍스트 갱신 (감시 중일 때만 시간 포함)
            if (tracker.IsTracking)
                lblStatus.Text = $"상태 : 감시 중 ({DateTime.Now:T})";
            else
                lblStatus.Text = "상태 : 중지됨";

            lblLevel.Text = $"레벨 : {level}";
            lblExp.Text = $"EXP : {expInCurrentLevel} / {expToNextLevel}";

            // 마감 시각 도달 시 1회만 처리
            if (!deadlineMarked && now >= deadlineTime)
            {
                MarkDeadlinePassed();
                deadlineMarked = true; // 중복 방지
            }

            // 자정 지나면 다시 초기화
            if (now < new TimeSpan(1, 0, 0))
            {
                deadlineMarked = false;
            }
        }

        private void btnSetGoals_Click(object sender, EventArgs e)
        {
            // 마감 상태일 경우 목표 설정 차단
            if (deadlineMarked)
            {
                MessageBox.Show("정산 중입니다. 목표 설정은 내일 다시 시도해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var goalForm = new GoalSettingForm();

            if (goalForm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(goalForm.AppName))
                {
                    MessageBox.Show("앱 이름이 유효하지 않습니다.");
                    return;
                }

                string appName = goalForm.AppName;
                TimeSpan goalTime = goalForm.GoalTime;

                var list = tracker.GetCurrentAppUsages();
                var match = list.Find(a => string.Equals(a.AppName, appName, StringComparison.OrdinalIgnoreCase));

                if(match != null)
                {
                    // 이미 목표 설정된 경우 차단
                    if (match.GoalTime > TimeSpan.Zero)
                    {
                        MessageBox.Show($"{appName}은 이미 목표가 설정된 앱입니다.\n목표를 변경할 수 없습니다.", "중복 설정 방지");
                        return;
                    }

                    match.GoalTime = goalTime;
                    MessageBox.Show($"{appName}의 목표 시간을 {goalTime}으로 설정했습니다.", "목표 저장 완료");
                }
                else
                {
                    // 앱이 아직 감시되지 않았더라도 목표만 등록
                    var newUsage = new AppUsage(appName)
                    {
                        GoalTime = goalTime
                    };
                    tracker.ForceAddApp(newUsage);

                    MessageBox.Show($"{appName}의 목표가 등록되었습니다.\n감시 시작 시 추적이 시작됩니다.", "목표 저장 완료");
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 목표 설정된 앱이 1개도 없는 경우
            var apps = tracker.GetCurrentAppUsages();
            bool hasGoal = apps.Any(a => a.GoalTime > TimeSpan.Zero);

            if (!hasGoal)
            {
                MessageBox.Show(
                    "앱 사용 목표가 설정되어 있지 않습니다.\n먼저 [목표 설정] 버튼을 눌러 앱을 등록해주세요.",
                    "감시 시작 불가",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            tracker.StartTracking();
            lblStatus.Text = $"상태 : 감시 중 ({DateTime.Now:T})";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var apps = tracker.GetCurrentAppUsages();
            bool hasGoal = apps.Any(a => a.GoalTime > TimeSpan.Zero);

            if (!hasGoal)
            {
                MessageBox.Show(
                    "앱 사용 목표가 설정되어 있지 않습니다.\n감시 중지할 대상이 없습니다.",
                    "감시 중지 불가",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            tracker.StopTracking();
            lblStatus.Text = "상태 : 중지됨";
        }
        
        // 데이터 그리드 포커스 해제 함수
        private void ClearDataGridFocus()
        {
            dataGridStats.ClearSelection();
        }

        // 판넬 클릭 시 데이터 그리드 포커스 해제
        private void panelHeader_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panelMiddle_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panelFooter_Click(object sender, EventArgs e) => ClearDataGridFocus();

        private void MarkDeadlinePassed()
        {
            var apps = tracker.GetCurrentAppUsages();

            foreach (var app in apps)
            {
                if (app.GoalTime > TimeSpan.Zero &&
                    app.UsageTime < app.GoalTime &&
                    app.UsageTime > TimeSpan.Zero)
                {
                    app.IsDeadlinePassed = true; // 상태 전환 트리거
                }
            }
            MessageBox.Show("마감 처리가 완료되었습니다.\n미달성 상태가 반영되었습니다.", "마감 완료");
        }

        private void MainDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var apps = tracker.GetCurrentAppUsages();

            // 레벨, exp 상태 저장
            ProfileManager.Save(new UserProfile
            {
                Level = level,
                Exp = totalExp
            });

            // 리포트 저장
            ReportExporter.SaveDailyReport(apps, level, totalExp);

            // AppUsage 저장
            AppUsageStorage.Save(apps);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");

            if (!Directory.Exists(dir))
            {
                MessageBox.Show("아직 저장된 리포트가 없습니다.", "리포트 없음");
                return;
            }

            ReportViewerForm reportForm = new ReportViewerForm();
            reportForm.Show();
        }

        private void btnPreset_Click(object sender, EventArgs e)
        {
            // 현재 앱 리스트를 미리 넘기고, 적용 결과도 받기 위해 PresetForm 인스턴스 생성
            var presetForm = new PresetForm();

            // 델리게이트 연결
            presetForm.OnPresetApplied += ApplyPresetToGrid;

            // 폼 띄우기
            presetForm.ShowDialog();
        }

        private void ApplyPresetToGrid(List<RawAppInfo> apps)
        {
            // 현재 등록된 앱 이름 수집
            HashSet<string> existingAppNames = new HashSet<string>();

            foreach (DataGridViewRow row in dataGridStats.Rows)
            {
                if (row.Cells[0].Value != null)
                    existingAppNames.Add(row.Cells[0].Value.ToString());
            }

            // 중복되는 앱이 있는지 확인
            var duplicate = apps.FirstOrDefault(app => existingAppNames.Contains(app.name));

            if (duplicate != null)
            {
                MessageBox.Show(
                    $"중복된 앱이 존재합니다: {duplicate.name}\n프리셋을 적용할 수 없습니다.",
                    "적용 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            // 중복 없음 → 정상 추가
            foreach (var app in apps)
            {
                // 앱이 현재 감시 리스트에 없다면 강제로 등록
                var usage = new AppUsage(app.name)
                {
                    GoalTime = TimeSpan.TryParse(app.goal, out TimeSpan goal) ? goal : TimeSpan.Zero,
                    UsageTime = TimeSpan.TryParse(app.usage, out TimeSpan use) ? use : TimeSpan.Zero
                };

                tracker.ForceAddApp(usage); // 강제 등록

                // 데이터 그리드에도 반영
                dataGridStats.Rows.Add(
                    usage.AppName,
                    usage.UsageTime.ToString(@"hh\:mm\:ss"),
                    usage.GoalTime.ToString(@"hh\:mm\:ss"),
                    usage.Status
                );
            }
        }
    }
}
