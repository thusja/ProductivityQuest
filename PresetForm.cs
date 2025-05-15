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
using ProductivityQuest.Forms;

namespace ProductivityQuest
{
    public partial class PresetForm: Form
    {
        private readonly string presetFolderPath = "presets";

        // GoalSettingForm에서 전달된 현재 앱들
        public List<RawAppInfo> CurrentApps { get; set; } = new List<RawAppInfo>();

        // MainDashboardForm에 연결될 프리셋 적용 이벤트
        public event Action<List<RawAppInfo>> OnPresetApplied;

        public PresetForm(List<RawAppInfo> currentApps = null)
        {
            InitializeComponent();

            CurrentApps = new List<RawAppInfo>();

            InitEvents();
            LoadPresetList();
            ShowApps(CurrentApps);

            // 텍스트박스 플레이스홀더 초기화
            textBoxPresetName.Text = "저장할 이름을 입력해주세요";
            textBoxPresetName.ForeColor = System.Drawing.Color.Gray;
        }

        private void InitEvents()
        {
            comboBoxPresets.SelectedIndexChanged += comboBoxPresets_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;
            btnApply.Click += btnApply_Click;
            btnClose.Click += (s, e) => this.Close();
            btnGoalSetting.Click += btnGoalSetting_Click;

            // !! 텍스트박스 플레이스홀더 이벤트
            textBoxPresetName.GotFocus += (s, e) =>
            {
                if (textBoxPresetName.Text == "저장할 이름을 입력해주세요")
                {
                    textBoxPresetName.Text = "";
                    textBoxPresetName.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBoxPresetName.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxPresetName.Text))
                {
                    textBoxPresetName.Text = "저장할 이름을 입력해주세요";
                    textBoxPresetName.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void LoadPresetList()
        {
            comboBoxPresets.Items.Clear();
            if (!Directory.Exists(presetFolderPath))
                Directory.CreateDirectory(presetFolderPath);

            var files = Directory.GetFiles(presetFolderPath, "*.json");
            foreach (var file in files)
                comboBoxPresets.Items.Add(Path.GetFileNameWithoutExtension(file));
        }

        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string presetName = comboBoxPresets.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(presetName)) return;

            var apps = LoadPreset(presetName);
            CurrentApps = apps;
            ShowApps(apps);
        }

        private void ShowApps(List<RawAppInfo> apps)
        {
            flowLayoutPanelApps.Controls.Clear();
            foreach (var app in apps)
            {
                flowLayoutPanelApps.Controls.Add(CreateAppBox(app));
            }
        }

        private Panel CreateAppBox(RawAppInfo app)
        {
            Panel panel = new Panel
            {
                Width = 360,
                Height = 33,
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label label = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"✓ {app.name} - {app.usage} / 목표 {app.goal}" +
                       (app.penalty ? " (패널티)" : ""),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            panel.Controls.Add(label);
            return panel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string presetName = textBoxPresetName.Text.Trim();
            if (presetName == "" || presetName == "저장할 이름을 입력해주세요")
            {
                MessageBox.Show("프리셋 이름을 입력해주세요.", "알림");
                return;
            }

            if (CurrentApps == null || CurrentApps.Count == 0)
            {
                MessageBox.Show("저장할 앱이 없습니다.", "알림");
                return;
            }

            string path = Path.Combine(presetFolderPath, $"{presetName}.json");
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(CurrentApps, Formatting.Indented));
                MessageBox.Show("프리셋 저장 완료!", "성공");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 중 오류 발생: {ex.Message}", "오류");
            }

            LoadPresetList();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (CurrentApps.Count == 0)
            {
                MessageBox.Show("적용할 앱이 없습니다.");
                return;
            }

            OnPresetApplied?.Invoke(CurrentApps);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoalSetting_Click(object sender, EventArgs e)
        {
            var goalForm = new GoalSettingForm();
            if (goalForm.ShowDialog() == DialogResult.OK)
            {
                // !! 여러 목표 누적 추가
                if (goalForm.ConfiguredApps != null && goalForm.ConfiguredApps.Count > 0)
                {
                    CurrentApps.AddRange(goalForm.ConfiguredApps); // 누적
                    ShowApps(CurrentApps);
                }
            }
        }

        private List<RawAppInfo> LoadPreset(string name)
        {
            string path = Path.Combine(presetFolderPath, $"{name}.json");
            if (!File.Exists(path)) return new List<RawAppInfo>();

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<RawAppInfo>>(json);
        }
    }
}
