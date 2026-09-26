namespace _2ndSemProject
{
    partial class frmAddInvestigator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblBadge = new System.Windows.Forms.Label();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.lblRank = new System.Windows.Forms.Label();
            this.cmbRank = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(30, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(150, 25);
            this.lblUser.Text = "Login Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(210, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(30, 80);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(150, 25);
            this.lblPass.Text = "Secure Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(210, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(260, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(30, 130);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(150, 25);
            this.lblFullName.Text = "Officer Real Name:";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtFullName.ForeColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Location = new System.Drawing.Point(210, 128);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(260, 29);
            this.txtFullName.TabIndex = 3;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(30, 180);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(150, 25);
            this.lblAge.Text = "Officer Age:";
            // 
            // numAge
            // 
            this.numAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.numAge.ForeColor = System.Drawing.Color.White;
            this.numAge.Location = new System.Drawing.Point(210, 178);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(100, 29);
            this.numAge.Minimum = 21;
            this.numAge.Maximum = 65;
            this.numAge.Value = 28;
            this.numAge.TabIndex = 4;
            // 
            // lblBadge
            // 
            this.lblBadge.Location = new System.Drawing.Point(30, 230);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(150, 25);
            this.lblBadge.Text = "Badge Identifier:";
            // 
            // txtBadge
            // 
            this.txtBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtBadge.ForeColor = System.Drawing.Color.White;
            this.txtBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBadge.Location = new System.Drawing.Point(210, 228);
            this.txtBadge.Name = "txtBadge";
            this.txtBadge.Size = new System.Drawing.Size(260, 29);
            this.txtBadge.TabIndex = 5;
            // 
            // lblRank
            // 
            this.lblRank.Location = new System.Drawing.Point(30, 280);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(150, 25);
            this.lblRank.Text = "Operational Rank:";
            // 
            // cmbRank
            // 
            this.cmbRank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbRank.ForeColor = System.Drawing.Color.White;
            this.cmbRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRank.Location = new System.Drawing.Point(210, 277);
            this.cmbRank.Name = "cmbRank";
            this.cmbRank.Size = new System.Drawing.Size(260, 29);
            this.cmbRank.Items.AddRange(new object[] {
                "Junior Detective",
                "Senior Inspector",
                "Cyber-Forensic Lead",
                "Assistant Commissioner",
                "Chief of Intelligence"
            });
            this.cmbRank.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(75, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Provision Account";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Location = new System.Drawing.Point(295, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 38);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddInvestigator
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(515, 420);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblBadge);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.cmbRank);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddInvestigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Onboard New Law Enforcement Officer";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUser, lblPass, lblFullName, lblAge, lblBadge, lblRank;
        private System.Windows.Forms.TextBox txtUsername, txtPassword, txtFullName, txtBadge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.ComboBox cmbRank;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}