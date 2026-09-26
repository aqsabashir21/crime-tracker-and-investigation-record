namespace _2ndSemProject
{
    partial class ucViewOfficers
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
            this.dgvOfficers = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 30);
            this.lblTitle.Text = "ACTIVE LAW ENFORCEMENT PERSONNEL DIRECTORY ROSTER";
            // 
            // dgvOfficers
            // 
            this.dgvOfficers.AllowUserToAddRows = false;
            this.dgvOfficers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOfficers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfficers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvOfficers.ColumnHeadersHeight = 35;

            // HIGH-CONTRAST READABILITY CORRECTION: Enforces clear dark text visibility inside rows
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            cellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvOfficers.DefaultCellStyle = cellStyle;

            this.dgvOfficers.EnableHeadersVisualStyles = false;
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvOfficers.ColumnHeadersDefaultCellStyle = headerStyle;

            this.dgvOfficers.Location = new System.Drawing.Point(30, 75);
            this.dgvOfficers.Name = "dgvOfficers";
            this.dgvOfficers.ReadOnly = true;
            this.dgvOfficers.RowHeadersWidth = 51;
            this.dgvOfficers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficers.Size = new System.Drawing.Size(940, 480);
            this.dgvOfficers.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(30, 570);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(600, 25);
            this.lblStatus.Text = "Synchronizing system data sheets...";
            // 
            // ucViewOfficers
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvOfficers);
            this.Controls.Add(this.lblStatus);
            this.Name = "ucViewOfficers";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvOfficers;
        private System.Windows.Forms.Label lblStatus;
    }
}