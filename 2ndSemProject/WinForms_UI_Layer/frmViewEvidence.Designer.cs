namespace _2ndSemProject
{
    partial class frmViewEvidence
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
            this.dgvEvidenceGrid = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidenceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(12, 25);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(177, 23);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Target Case File:";
            // 
            // cmbCases
            // 
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.ForeColor = System.Drawing.Color.White;
            this.cmbCases.Location = new System.Drawing.Point(195, 22);
            this.cmbCases.Name = "cmbCases";
            this.cmbCases.Size = new System.Drawing.Size(925, 29);
            this.cmbCases.TabIndex = 1;
            this.cmbCases.SelectedIndexChanged += new System.EventHandler(this.cmbCases_SelectedIndexChanged);
            // 
            // dgvEvidenceGrid
            // 
            this.dgvEvidenceGrid.AllowUserToAddRows = false;
            this.dgvEvidenceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvidenceGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvEvidenceGrid.ColumnHeadersHeight = 29;
            this.dgvEvidenceGrid.Location = new System.Drawing.Point(29, 78);
            this.dgvEvidenceGrid.Name = "dgvEvidenceGrid";
            this.dgvEvidenceGrid.ReadOnly = true;
            this.dgvEvidenceGrid.RowHeadersWidth = 51;
            this.dgvEvidenceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvidenceGrid.Size = new System.Drawing.Size(1091, 284);
            this.dgvEvidenceGrid.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblStatus.Location = new System.Drawing.Point(25, 376);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(630, 32);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: Querying vault locker nodes...";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(455, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Acknowledge and Exit Manifest";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmViewEvidence
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1157, 516);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbCases);
            this.Controls.Add(this.dgvEvidenceGrid);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewEvidence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Evidence Vault Locker Secure Manifest Index";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidenceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblSelect, lblStatus;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.DataGridView dgvEvidenceGrid;
        private System.Windows.Forms.Button btnClose;
    }
}