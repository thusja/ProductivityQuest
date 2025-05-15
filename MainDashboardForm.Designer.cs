namespace ProductivityQuest
{
    partial class MainDashboardForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSetGoals = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.dataGridStats = new System.Windows.Forms.DataGridView();
            this.colAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsageTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnPreset = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblExp = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.lblUsageStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStats)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTitle.Location = new System.Drawing.Point(233, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Productivity Quest";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(10, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "▶️ 감시 시작";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightPink;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Location = new System.Drawing.Point(120, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "⏹️ 감시 중지";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSetGoals
            // 
            this.btnSetGoals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(156)))));
            this.btnSetGoals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetGoals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGoals.ForeColor = System.Drawing.Color.Black;
            this.btnSetGoals.Location = new System.Drawing.Point(400, 50);
            this.btnSetGoals.Name = "btnSetGoals";
            this.btnSetGoals.Size = new System.Drawing.Size(100, 30);
            this.btnSetGoals.TabIndex = 3;
            this.btnSetGoals.Text = "🎯 목표 설정";
            this.btnSetGoals.UseVisualStyleBackColor = false;
            this.btnSetGoals.Click += new System.EventHandler(this.btnSetGoals_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Location = new System.Drawing.Point(510, 50);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 30);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "📁 리포트 보기";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblStatus.Location = new System.Drawing.Point(112, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 17);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "상태 : 대기 중";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblLevel.Location = new System.Drawing.Point(379, 19);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(53, 17);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "레벨 : 1";
            // 
            // dataGridStats
            // 
            this.dataGridStats.AllowUserToAddRows = false;
            this.dataGridStats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray;
            this.dataGridStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridStats.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppName,
            this.colUsageTime,
            this.colGoal,
            this.colStatus});
            this.dataGridStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStats.GridColor = System.Drawing.Color.LightGray;
            this.dataGridStats.Location = new System.Drawing.Point(0, 0);
            this.dataGridStats.Name = "dataGridStats";
            this.dataGridStats.ReadOnly = true;
            this.dataGridStats.RowHeadersVisible = false;
            this.dataGridStats.RowTemplate.Height = 23;
            this.dataGridStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridStats.Size = new System.Drawing.Size(624, 252);
            this.dataGridStats.TabIndex = 7;
            // 
            // colAppName
            // 
            this.colAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAppName.HeaderText = "앱 이름";
            this.colAppName.Name = "colAppName";
            this.colAppName.ReadOnly = true;
            // 
            // colUsageTime
            // 
            this.colUsageTime.HeaderText = "사용 시간";
            this.colUsageTime.Name = "colUsageTime";
            this.colUsageTime.ReadOnly = true;
            // 
            // colGoal
            // 
            this.colGoal.HeaderText = "목표 시간";
            this.colGoal.Name = "colGoal";
            this.colGoal.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "상태";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnPreset);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnStart);
            this.panelHeader.Controls.Add(this.btnReport);
            this.panelHeader.Controls.Add(this.btnStop);
            this.panelHeader.Controls.Add(this.btnSetGoals);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(624, 100);
            this.panelHeader.TabIndex = 8;
            this.panelHeader.Click += new System.EventHandler(this.panelHeader_Click);
            // 
            // btnPreset
            // 
            this.btnPreset.BackColor = System.Drawing.Color.LightBlue;
            this.btnPreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset.ForeColor = System.Drawing.Color.Black;
            this.btnPreset.Location = new System.Drawing.Point(510, 9);
            this.btnPreset.Name = "btnPreset";
            this.btnPreset.Size = new System.Drawing.Size(100, 30);
            this.btnPreset.TabIndex = 5;
            this.btnPreset.Text = "💨 프리셋";
            this.btnPreset.UseVisualStyleBackColor = false;
            this.btnPreset.Click += new System.EventHandler(this.btnPreset_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblExp);
            this.panelFooter.Controls.Add(this.lblStatus);
            this.panelFooter.Controls.Add(this.lblLevel);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 400);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(624, 50);
            this.panelFooter.TabIndex = 9;
            this.panelFooter.Click += new System.EventHandler(this.panelFooter_Click);
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExp.Location = new System.Drawing.Point(438, 20);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(44, 15);
            this.lblExp.TabIndex = 7;
            this.lblExp.Text = "EXP : 0";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.panel2);
            this.panelBody.Controls.Add(this.panelMiddle);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 100);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(624, 300);
            this.panelBody.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridStats);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 252);
            this.panel2.TabIndex = 9;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.lblUsageStatus);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(624, 48);
            this.panelMiddle.TabIndex = 8;
            this.panelMiddle.Click += new System.EventHandler(this.panelMiddle_Click);
            // 
            // lblUsageStatus
            // 
            this.lblUsageStatus.AutoSize = true;
            this.lblUsageStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblUsageStatus.Location = new System.Drawing.Point(233, 15);
            this.lblUsageStatus.Name = "lblUsageStatus";
            this.lblUsageStatus.Size = new System.Drawing.Size(140, 17);
            this.lblUsageStatus.TabIndex = 0;
            this.lblUsageStatus.Text = "📋 프로그램 사용 현황";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productivity Quest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDashboardForm_FormClosing);
            this.Load += new System.EventHandler(this.MainDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStats)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSetGoals;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.DataGridView dataGridStats;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUsageStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsageTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnPreset;
    }
}

