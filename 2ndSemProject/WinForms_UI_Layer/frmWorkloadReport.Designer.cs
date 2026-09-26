namespace _2ndSemProject
{
    partial class frmWorkloadReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbInvestigators = new System.Windows.Forms.ComboBox();
            this.lblCasesTitle = new System.Windows.Forms.Label();
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.lblLogsTitle = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 30);
            this.lblTitle.Text = "INVESTIGATOR WORKLOAD PROGRESS & LOG AUDITOR";
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(25, 68);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(180, 25);
            this.lblSelect.Text = "Select Officer to Audit:";
            // 
            // cmbInvestigators
            // 
            this.cmbInvestigators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbInvestigators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvestigators.ForeColor = System.Drawing.Color.White;
            this.cmbInvestigators.Location = new System.Drawing.Point(210, 65);
            this.cmbInvestigators.Name = "cmbInvestigators";
            this.cmbInvestigators.Size = new System.Drawing.Size(300, 29);
            this.cmbInvestigators.SelectedIndexChanged += new System.EventHandler(this.cmbInvestigators_SelectedIndexChanged);
            // 
            // lblCasesTitle
            // 
            this.lblCasesTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCasesTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblCasesTitle.Location = new System.Drawing.Point(25, 115);
            this.lblCasesTitle.Name = "lblCasesTitle";
            this.lblCasesTitle.Size = new System.Drawing.Size(300, 20);
            this.lblCasesTitle.Text = "📋 Currently Assigned Active Case Files:";
            // 
            // dgvCases
            // 
            this.dgvCases.AllowUserToAddRows = false;
            this.dgvCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCases.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvCases.ColumnHeadersHeight = 30;

            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.dgvCases.DefaultCellStyle = cellStyle;
            this.dgvCases.EnableHeadersVisualStyles = false;

            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCases.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCases.Location = new System.Drawing.Point(25, 140);
            this.dgvCases.Name = "dgvCases";
            this.dgvCases.ReadOnly = true;
            this.dgvCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCases.Size = new System.Drawing.Size(830, 160);
            this.dgvCases.SelectionChanged += new System.EventHandler(this.dgvCases_SelectionChanged);

            // 
            // lblLogsTitle
            // 
            this.lblLogsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLogsTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblLogsTitle.Location = new System.Drawing.Point(25, 315);
            this.lblLogsTitle.Name = "lblLogsTitle";
            this.lblLogsTitle.Size = new System.Drawing.Size(400, 20);
            this.lblLogsTitle.Text = "📜 Case Operational Progress Log History:";
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvLogs.ColumnHeadersHeight = 30;
            this.dgvLogs.DefaultCellStyle = cellStyle;
            this.dgvLogs.EnableHeadersVisualStyles = false;
            this.dgvLogs.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvLogs.Location = new System.Drawing.Point(25, 340);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(830, 160);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(25, 515);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 25);
            this.lblStatus.Text = "Selecting officer data matrices...";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(340, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 38);
            this.btnClose.Text = "Close Auditor View";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWorkloadReport
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(880, 610);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbInvestigators);
            this.Controls.Add(this.lblCasesTitle);
            this.Controls.Add(this.dgvCases);
            this.Controls.Add(this.lblLogsTitle);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWorkloadReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Auditor Console - Live Progress Tracking Station";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblSelect, lblCasesTitle, lblLogsTitle, lblStatus;
        private System.Windows.Forms.ComboBox cmbInvestigators;
        private System.Windows.Forms.DataGridView dgvCases, dgvLogs;
        private System.Windows.Forms.Button btnClose;
    }
}