namespace _2ndSemProject
{
    partial class frmRegisterCriminal
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();

            // Setup general layout style rules for form controls
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // Name Field
            this.lblName.Text = "Full Name:"; this.lblName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Location = new System.Drawing.Point(120, 18); this.txtName.Size = new System.Drawing.Size(240, 25);
            this.txtName.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtName.ForeColor = System.Drawing.Color.White;

            // CNIC Field
            this.lblCNIC.Text = "CNIC / Identity:"; this.lblCNIC.Location = new System.Drawing.Point(20, 60);
            this.txtCNIC.Location = new System.Drawing.Point(120, 58); this.txtCNIC.Size = new System.Drawing.Size(240, 25);
            this.txtCNIC.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtCNIC.ForeColor = System.Drawing.Color.White;

            // Age Field
            this.lblAge.Text = "Age:"; this.lblAge.Location = new System.Drawing.Point(20, 100);
            this.numAge.Location = new System.Drawing.Point(120, 98); this.numAge.Size = new System.Drawing.Size(80, 25);
            this.numAge.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.numAge.ForeColor = System.Drawing.Color.White;
            this.numAge.Minimum = 18; this.numAge.Maximum = 100;

            // Gender Field
            this.lblGender.Text = "Gender:";
            this.lblGender.Location = new System.Drawing.Point(20, 140);

            this.rbMale.Text = "Male";
            this.rbMale.Location = new System.Drawing.Point(120, 138);
            this.rbMale.Width = 70; // 💡 Explicitly restrict width so it doesn't overlap text

            this.rbFemale.Text = "Female";
            this.rbFemale.Location = new System.Drawing.Point(205, 138); // 💡 Nudge further right
            this.rbFemale.Width = 90; // 💡 Ensure full text renders properly

            // Status Dropdown
            this.lblStatus.Text = "Custody Status:"; this.lblStatus.Location = new System.Drawing.Point(20, 180);
            this.cmbStatus.Location = new System.Drawing.Point(120, 178); this.cmbStatus.Size = new System.Drawing.Size(240, 25);
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbStatus.ForeColor = System.Drawing.Color.White;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Under Investigation", "In Custody", "Fugitive/Wanted", "Released" });

            // Photo Path Field
            this.lblPhoto.Text = "Photo URL Token:"; this.lblPhoto.Location = new System.Drawing.Point(20, 220);
            this.txtPhotoPath.Location = new System.Drawing.Point(120, 218); this.txtPhotoPath.Size = new System.Drawing.Size(240, 25);
            this.txtPhotoPath.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtPhotoPath.ForeColor = System.Drawing.Color.White;

            // History Field
            this.lblHistory.Text = "Prior History:"; this.lblHistory.Location = new System.Drawing.Point(20, 260);
            this.txtHistory.Location = new System.Drawing.Point(120, 258); this.txtHistory.Size = new System.Drawing.Size(240, 60);
            this.txtHistory.Multiline = true;
            this.txtHistory.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtHistory.ForeColor = System.Drawing.Color.White;

            // Save Button
            this.btnSave.Text = "Register Profile"; this.btnSave.Location = new System.Drawing.Point(40, 345); this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel"; this.btnCancel.Location = new System.Drawing.Point(210, 345); this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray; this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add Controls to form layout canvas container
            this.ClientSize = new System.Drawing.Size(390, 410);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblName, this.txtName, this.lblCNIC, this.txtCNIC, this.lblAge, this.numAge,
                this.lblGender, this.rbMale, this.rbFemale, this.lblStatus, this.cmbStatus,
                this.lblHistory, this.txtHistory, this.lblPhoto, this.txtPhotoPath, this.btnSave, this.btnCancel
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criminal Index Entry Manifest";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName, lblCNIC, lblAge, lblGender, lblStatus, lblHistory, lblPhoto;
        private System.Windows.Forms.TextBox txtName, txtCNIC, txtHistory, txtPhotoPath;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.RadioButton rbMale, rbFemale;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}