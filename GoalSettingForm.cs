using ProductivityQuest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductivityQuest.Forms
{
    public partial class GoalSettingForm: Form
    {
        public string AppName { get; private set; }
        public TimeSpan GoalTime { get; private set; }
        public List<RawAppInfo> ConfiguredApps { get; private set; }

        public GoalSettingForm()
        {
            InitializeComponent();

            // 시간, 분 comboBox 초기화
            for (int h = 0; h <= 12; h++)
                cmbHour.Items.Add(h.ToString("D2")); // 00 ~ 12 시간

            for (int m = 0; m <= 59; m++)
                cmbMinute.Items.Add(m.ToString("D2")); // 00 ~ 59 분

            cmbHour.SelectedIndex = 0;
            cmbMinute.SelectedIndex = 0;
        }

        private void GoalSettingForm_Load(object sender, EventArgs e)
        {
            HashSet<string> processNames = new HashSet<string>();

            foreach(var proc in Process.GetProcesses())
            {
                try
                {
                    string name = proc.ProcessName;

                    if (!string.IsNullOrWhiteSpace(name)) // null 또는 공백 방지
                    {
                        name += ".exe";

                        if (!name.ToLower().Contains("system") && !processNames.Contains(name))
                        {
                            processNames.Add(name);
                            cmbAppName.Items.Add(name);
                        }
                    }
                }
                catch
                {
                    // 액세스 거부된 프로세스 등 무시
                }
            }

            if (cmbAppName.Items.Count > 0)
            {
                cmbAppName.SelectedIndex = 0; // 안정적인 기본 값
            }
        }

        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            if(cmbAppName.SelectedItem == null)
            {
                MessageBox.Show("앱을 선택해주세요.");
                return;
            }

            // 시간, 분 comboBox에서 TimeSpan 생성
            int h = int.Parse(cmbHour.SelectedItem.ToString());
            int m = int.Parse(cmbMinute.SelectedItem.ToString());

            TimeSpan goal = new TimeSpan(h, m, 0);

            if (h == 0 && m < 1)
            {
                MessageBox.Show("목표 시간은 최소 1분 이상이어야 합니다.");
                return;
            }

            AppName = cmbAppName.SelectedItem.ToString();
            GoalTime = goal;

            // 결과 리스트 구성
            ConfiguredApps = new List<RawAppInfo>
            {
                new RawAppInfo
                {
                    name = cmbAppName.SelectedItem.ToString(),
                    usage = "00:00:00",
                    goal = goal.ToString(@"hh\:mm\:ss"),
                    status = "진행중",
                    penalty = false
                }
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
