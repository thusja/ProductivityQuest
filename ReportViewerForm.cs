using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using ProductivityQuest.Models;
using ProductivityQuest.Services;

namespace ProductivityQuest
{
    public partial class ReportViewerForm: Form
    {
        private readonly UserProfile userProfile = new UserProfile();
        private readonly List<AppUsage> appUsages = new List<AppUsage>();
        private List<RawReportEntry> latestEntriesPerDay = new List<RawReportEntry>();

        public ReportViewerForm()
        {
            InitializeComponent();
            InitializeDatePickers();
            LoadWeeklySummary();

        }

        private void InitializeDatePickers()
        {
            // 시작일 초기값 : 오늘
            dateTimePickerStart.Value = DateTime.Today;

            // 종료일 초기 설정 및 비활성화
            UpdateEndDate();
            dateTimePickerEnd.Enabled = false;

            // 시작일 변경 이벤트 핸들러 연결
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;

        }

        private void UpdateEndDate()
        {
            dateTimePickerEnd.Value = dateTimePickerStart.Value.AddDays(7);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
            LoadWeeklySummary();
        }

        private void LoadWeeklySummary()
        {
            appUsages.Clear();
            string reportFolder = Path.Combine(Application.StartupPath, "Reports");

            if (!Directory.Exists(reportFolder))
            {
                MessageBox.Show("리포트 폴더가 존재하지 않습니다.");
                return;
            }

            var startDate = dateTimePickerStart.Value.Date;
            var endDate = dateTimePickerEnd.Value.Date;

            var files = Directory.GetFiles(reportFolder, "*.json");
            List<RawReportEntry> allEntries = new List<RawReportEntry>();

            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var entries = JsonConvert.DeserializeObject<List<RawReportEntry>>(json);
                if (entries != null)
                    allEntries.AddRange(entries);
            }

            // 날짜별 가장 마지막 entry만 추출
            latestEntriesPerDay = allEntries
                .Where(e => e.timestamp.Date >= startDate && e.timestamp.Date <= endDate)
                .GroupBy(e => e.timestamp.Date)
                .Select(g => g.OrderByDescending(e => e.timestamp).First())
                .OrderBy(e => e.timestamp)
                .ToList();

            int totalExp = 0;
            int? prevExp = null;

            foreach (var entry in latestEntriesPerDay)
            {
                // exp 증가량 계산
                if (prevExp.HasValue)
                    totalExp += (entry.exp - prevExp.Value);
                prevExp = entry.exp;

                // 마지막 entry의 앱 정보만 사용
                if (entry.apps == null) continue;

                foreach (var app in entry.apps)
                {
                    var found = appUsages.FirstOrDefault(x => x.AppName == app.name);
                    if (found == null)
                    {
                        found = new AppUsage(app.name);
                        appUsages.Add(found);
                    }

                    if(TimeSpan.TryParse(app.usage, out var usageTime))
                    {
                        found.UsageTime += usageTime;
                    }
                        
                    if(TimeSpan.TryParse(app.goal, out var goalTime))
                    {
                        found.GoalTime += goalTime;
                    }
                }
            }

            userProfile.Exp = totalExp;
            userProfile.Level = LevelCalculator.CalculateLevel(totalExp, out int expInLevel, out int nextLevelExp);

            // 데이터 바인딩
            dataGridTotalStats.AutoGenerateColumns = false;
            dataGridTotalStats.DataSource = null;
            dataGridTotalStats.DataSource = appUsages;

            lblGetLevel.Text = $"획득 레벨 : {userProfile.Level}";
            lblGetExp.Text = $"획득 EXP : {expInLevel}";
        }

        // 상태별 배경색 처리
        private void dataGridTotalStats_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridTotalStats.Rows[e.RowIndex];

            if (row.DataBoundItem is AppUsage app)
            {
                string status = app.SummaryStatus;

                switch (status)
                {
                    case "달성":
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DFFFE0");
                        break;
                    case "미달성":
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EEEEEE");
                        break;
                    case "패널티":
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE0E0");
                        break;
                }
            }
        }

        private void btnLineChart_Click(object sender, EventArgs e)
        {
            var form = new LineChartForm(latestEntriesPerDay); // 리스트 넘겨주기
            form.ShowDialog();
        }

        private void btnBarChart_Click(object sender, EventArgs e)
        {
            var form = new BarChartForm(latestEntriesPerDay);
            form.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = DateTime.Today;
        }

        private void ClearDataGridFocus()
        {
            dataGridTotalStats.ClearSelection();
        }

        private void panel1_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panel4_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panel6_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panel5_Click(object sender, EventArgs e) => ClearDataGridFocus();
        private void panel7_Click(object sender, EventArgs e) => ClearDataGridFocus();
    }
}
