namespace _2ndSemProject
{
    partial class frmViewDiary
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbCases = new System.Windows.Forms.ComboBox();
            this.dgvDiaryHistory = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaryHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(25, 25);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(200, 23);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Target Case File:";
            // 
            // cmbCases
            // 
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.ForeColor = System.Drawing.Color.White;
            this.cmbCases.Location = new System.Drawing.Point(225, 25);
            this.cmbCases.Name = "cmbCases";
            this.cmbCases.Size = new System.Drawing.Size(782, 29);
            this.cmbCases.TabIndex = 1;
            this.cmbCases.SelectedIndexChanged += new System.EventHandler(this.cmbCases_SelectedIndexChanged);
            // 
            // dgvDiaryHistory
            // 
            this.dgvDiaryHistory.AllowUserToAddRows = false;
            this.dgvDiaryHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiaryHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvDiaryHistory.ColumnHeadersHeight = 29;
            this.dgvDiaryHistory.Location = new System.Drawing.Point(29, 73);
            this.dgvDiaryHistory.Name = "dgvDiaryHistory";
            this.dgvDiaryHistory.ReadOnly = true;
            this.dgvDiaryHistory.RowHeadersWidth = 51;
            this.dgvDiaryHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiaryHistory.Size = new System.Drawing.Size(1041, 355);
            this.dgvDiaryHistory.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblStatus.Location = new System.Drawing.Point(12, 448);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(600, 23);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: Initializing index trackers...";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(412, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close Timeline Window";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmViewDiary
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1104, 585);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbCases);
            this.Controls.Add(this.dgvDiaryHistory);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewDiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Investigative Case Progress Timeline Manifest";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaryHistory)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblSelect, lblStatus;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.DataGridView dgvDiaryHistory;
        private System.Windows.Forms.Button btnClose;
    }
}