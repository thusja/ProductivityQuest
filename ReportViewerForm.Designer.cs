namespace ProductivityQuest
{
    partial class ReportViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBord = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridTotalStats = new System.Windows.Forms.DataGridView();
            this.colAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalUsageTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalGoalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummaryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblGetLevel = new System.Windows.Forms.Label();
            this.lblGetExp = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnBarChart = new System.Windows.Forms.Button();
            this.btnLineChart = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTotalStats)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 32);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblBord
            // 
            this.lblBord.AutoSize = true;
            this.lblBord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBord.Location = new System.Drawing.Point(230, 9);
            this.lblBord.Name = "lblBord";
            this.lblBord.Size = new System.Drawing.Size(179, 17);
            this.lblBord.TabIndex = 0;
            this.lblBord.Text = "📅 7일 요약 리포트 대시보드";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridTotalStats);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 300);
            this.panel2.TabIndex = 1;
            // 
            // dataGridTotalStats
            // 
            this.dataGridTotalStats.AllowUserToAddRows = false;
            this.dataGridTotalStats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGray;
            this.dataGridTotalStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridTotalStats.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTotalStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridTotalStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTotalStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppName,
            this.colTotalUsageTime,
            this.colTotalGoalTime,
            this.colSummaryStatus});
            this.dataGridTotalStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTotalStats.GridColor = System.Drawing.Color.LightGray;
            this.dataGridTotalStats.Location = new System.Drawing.Point(0, 37);
            this.dataGridTotalStats.Name = "dataGridTotalStats";
            this.dataGridTotalStats.ReadOnly = true;
            this.dataGridTotalStats.RowHeadersVisible = false;
            this.dataGridTotalStats.RowTemplate.Height = 23;
            this.dataGridTotalStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTotalStats.Size = new System.Drawing.Size(649, 263);
            this.dataGridTotalStats.TabIndex = 0;
            this.dataGridTotalStats.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridTotalStats_RowPrePaint);
            // 
            // colAppName
            // 
            this.colAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAppName.DataPropertyName = "AppName";
            this.colAppName.HeaderText = "앱 이름";
            this.colAppName.Name = "colAppName";
            this.colAppName.ReadOnly = true;
            // 
            // colTotalUsageTime
            // 
            this.colTotalUsageTime.DataPropertyName = "UsageTime";
            this.colTotalUsageTime.HeaderText = "총 사용 시간";
            this.colTotalUsageTime.Name = "colTotalUsageTime";
            this.colTotalUsageTime.ReadOnly = true;
            // 
            // colTotalGoalTime
            // 
            this.colTotalGoalTime.DataPropertyName = "GoalTime";
            this.colTotalGoalTime.HeaderText = "총 목표 시간";
            this.colTotalGoalTime.Name = "colTotalGoalTime";
            this.colTotalGoalTime.ReadOnly = true;
            // 
            // colSummaryStatus
            // 
            this.colSummaryStatus.DataPropertyName = "SummaryStatus";
            this.colSummaryStatus.HeaderText = "상태";
            this.colSummaryStatus.Name = "colSummaryStatus";
            this.colSummaryStatus.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblRecord);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(649, 37);
            this.panel7.TabIndex = 1;
            this.panel7.Click += new System.EventHandler(this.panel7_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(244, 8);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(144, 17);
            this.lblRecord.TabIndex = 0;
            this.lblRecord.Text = "📋 앱별 상세 사용 기록";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(55, 9);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(176, 23);
            this.dateTimePickerStart.TabIndex = 1;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(509, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 새로고침";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblGetLevel
            // 
            this.lblGetLevel.AutoSize = true;
            this.lblGetLevel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetLevel.Location = new System.Drawing.Point(420, 3);
            this.lblGetLevel.Name = "lblGetLevel";
            this.lblGetLevel.Size = new System.Drawing.Size(72, 17);
            this.lblGetLevel.TabIndex = 0;
            this.lblGetLevel.Text = "획득 레벨 :";
            // 
            // lblGetExp
            // 
            this.lblGetExp.AutoSize = true;
            this.lblGetExp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetExp.Location = new System.Drawing.Point(505, 3);
            this.lblGetExp.Name = "lblGetExp";
            this.lblGetExp.Size = new System.Drawing.Size(70, 17);
            this.lblGetExp.TabIndex = 1;
            this.lblGetExp.Text = "획득 EXP :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 153);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnBarChart);
            this.panel6.Controls.Add(this.btnLineChart);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(649, 83);
            this.panel6.TabIndex = 2;
            this.panel6.Click += new System.EventHandler(this.panel6_Click);
            // 
            // btnBarChart
            // 
            this.btnBarChart.BackColor = System.Drawing.Color.Lavender;
            this.btnBarChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarChart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarChart.Location = new System.Drawing.Point(36, 50);
            this.btnBarChart.Name = "btnBarChart";
            this.btnBarChart.Size = new System.Drawing.Size(573, 30);
            this.btnBarChart.TabIndex = 1;
            this.btnBarChart.Text = "📊 달성 앱 수 / 패널티 앱 수 (BarChart)";
            this.btnBarChart.UseVisualStyleBackColor = false;
            this.btnBarChart.Click += new System.EventHandler(this.btnBarChart_Click);
            // 
            // btnLineChart
            // 
            this.btnLineChart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLineChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineChart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineChart.Location = new System.Drawing.Point(36, 10);
            this.btnLineChart.Name = "btnLineChart";
            this.btnLineChart.Size = new System.Drawing.Size(573, 30);
            this.btnLineChart.TabIndex = 0;
            this.btnLineChart.Text = "📈 총 사용 시간 추이 (LineChart)";
            this.btnLineChart.UseVisualStyleBackColor = false;
            this.btnLineChart.Click += new System.EventHandler(this.btnLineChart_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblGetExp);
            this.panel5.Controls.Add(this.lblGetLevel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 128);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 25);
            this.panel5.TabIndex = 1;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.dateTimePickerEnd);
            this.panel4.Controls.Add(this.dateTimePickerStart);
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(649, 45);
            this.panel4.TabIndex = 0;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "종료 일";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "시작 일";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(289, 9);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(176, 23);
            this.dateTimePickerEnd.TabIndex = 2;
            this.dateTimePickerEnd.Value = new System.DateTime(2025, 5, 14, 0, 0, 0, 0);
            // 
            // ReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 485);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportViewerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTotalStats)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label lblGetLevel;
        private System.Windows.Forms.Label lblGetExp;
        private System.Windows.Forms.DataGridView dataGridTotalStats;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnBarChart;
        private System.Windows.Forms.Button btnLineChart;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalUsageTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalGoalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummaryStatus;
    }
}