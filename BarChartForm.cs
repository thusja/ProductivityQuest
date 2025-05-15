using ProductivityQuest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProductivityQuest
{
    public partial class BarChartForm: Form
    {
        public BarChartForm(List<RawReportEntry> entries)
        {
            InitializeComponent();
            DrawBarChart(entries);
        }

        private void DrawBarChart(List<RawReportEntry> entries)
        {

            chartBar.Series.Clear();
            chartBar.Titles.Clear();

            string yearMonth = entries.First().timestamp.ToString("yyyy-MM");
            chartBar.Titles.Add(yearMonth);

            chartBar.ChartAreas[0].AxisX.LabelStyle.Format = "dd";
            chartBar.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            chartBar.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartBar.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            var seriesAchieved = new Series("달성 앱 수")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Orange
            };

            var seriesPenalty = new Series("패널티 앱 수")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.OrangeRed
            };

            var daily = entries
                .GroupBy(e => e.timestamp.Date)
                .Select(g => g.OrderByDescending(e => e.timestamp).First())
                .OrderBy(e => e.timestamp);

            foreach (var entry in daily)
            {
                string dateStr = entry.timestamp.ToString("dd");
                int achieved = entry.apps?.Count(a => a.status == "달성") ?? 0;
                int penalty = entry.apps?.Count(a => a.penalty) ?? 0;

                seriesAchieved.Points.AddXY(dateStr, achieved);
                seriesPenalty.Points.AddXY(dateStr, penalty);
            }

            chartBar.Series.Add(seriesAchieved);
            chartBar.Series.Add(seriesPenalty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownloadImage_Click(object sender, EventArgs e)
        {
            // 차트를 이미지로 저장할 경로와 파일 이름 지정
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG 파일|*.png";
            saveFileDialog.Title = "바 차트 이미지 저장";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 차트를 이미지로 저장
                chartBar.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                MessageBox.Show("차트 이미지가 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
