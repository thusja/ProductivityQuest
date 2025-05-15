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
using ProductivityQuest.Models;

namespace ProductivityQuest
{
    public partial class LineChartForm: Form
    {
        public LineChartForm(List<RawReportEntry> entries)
        {
            InitializeComponent();
            DrawLineChart(entries);
        }

        private void DrawLineChart(List<RawReportEntry> entries)
        {
            
            chart1.Series.Clear();
            chart1.Titles.Clear();

            string yearMonth = entries.First().timestamp.ToString("yyyy-MM");
            chart1.Titles.Add(yearMonth);
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd";

            var series = new Series("EXP")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Orange,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                XValueType = ChartValueType.Date
            };

            var daily = entries
                .GroupBy(e => e.timestamp.Date)
                .Select(g => g.OrderByDescending(e => e.timestamp).First())
                .OrderBy(e => e.timestamp);

            foreach (var entry in daily)
            {
                series.Points.AddXY(entry.timestamp.Date, entry.exp);
            }

            chart1.Series.Add(series);
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
            saveFileDialog.Title = "라인 차트 이미지 저장";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 차트를 이미지로 저장
                chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                MessageBox.Show("차트 이미지가 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
