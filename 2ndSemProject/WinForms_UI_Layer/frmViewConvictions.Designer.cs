namespace _2ndSemProject
{
    partial class frmViewConvictions
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
            this.cmbCriminals = new System.Windows.Forms.ComboBox();
            this.dgvConvictions = new System.Windows.Forms.DataGridView();
            this.lblRecordStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewConviction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvictions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(25, 37);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(179, 23);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Suspect Profile:";
            // 
            // cmbCriminals
            // 
            this.cmbCriminals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbCriminals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriminals.ForeColor = System.Drawing.Color.White;
            this.cmbCriminals.Location = new System.Drawing.Point(210, 31);
            this.cmbCriminals.Name = "cmbCriminals";
            this.cmbCriminals.Size = new System.Drawing.Size(602, 29);
            this.cmbCriminals.TabIndex = 1;
            this.cmbCriminals.SelectedIndexChanged += new System.EventHandler(this.cmbCriminals_SelectedIndexChanged);
            // 
            // dgvConvictions
            // 
            this.dgvConvictions.AllowUserToAddRows = false;
            this.dgvConvictions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConvictions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvConvictions.ColumnHeadersHeight = 29;
            this.dgvConvictions.Location = new System.Drawing.Point(29, 91);
            this.dgvConvictions.Name = "dgvConvictions";
            this.dgvConvictions.ReadOnly = true;
            this.dgvConvictions.RowHeadersWidth = 51;
            this.dgvConvictions.Size = new System.Drawing.Size(909, 278);
            this.dgvConvictions.TabIndex = 2;
            // 
            // lblRecordStatus
            // 
            this.lblRecordStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblRecordStatus.Location = new System.Drawing.Point(25, 330);
            this.lblRecordStatus.Name = "lblRecordStatus";
            this.lblRecordStatus.Size = new System.Drawing.Size(545, 23);
            this.lblRecordStatus.TabIndex = 3;
            this.lblRecordStatus.Text = "Status: Fetching parameters...";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(484, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(206, 49);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close Registry Panel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewConviction
            // 
            this.btnNewConviction.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnNewConviction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewConviction.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnNewConviction.Location = new System.Drawing.Point(245, 403);
            this.btnNewConviction.Name = "btnNewConviction";
            this.btnNewConviction.Size = new System.Drawing.Size(174, 49);
            this.btnNewConviction.TabIndex = 5;
            this.btnNewConviction.Text = "+ Add Prior Offense";
            this.btnNewConviction.Click += new System.EventHandler(this.btnNewConviction_Click);
            // 
            // frmViewConvictions
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(966, 520);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbCriminals);
            this.Controls.Add(this.dgvConvictions);
            this.Controls.Add(this.lblRecordStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewConviction);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewConvictions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prior Convictions Archive Manifest";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvictions)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnNewConviction;
        private System.Windows.Forms.Label lblSelect, lblRecordStatus;
        private System.Windows.Forms.ComboBox cmbCriminals;
        private System.Windows.Forms.DataGridView dgvConvictions;
        private System.Windows.Forms.Button btnClose;
    }
}