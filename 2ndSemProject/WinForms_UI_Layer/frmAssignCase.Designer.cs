namespace _2ndSemProject
{
    partial class frmAssignCase
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
            this.lblCrime = new System.Windows.Forms.Label();
            this.cmbCrimes = new System.Windows.Forms.ComboBox();
            this.lblInvestigator = new System.Windows.Forms.Label();
            this.cmbInvestigators = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 30);
            this.lblTitle.Text = "ALLOCATE INVESTIGATOR TO CASE FILE TASK FORCE";
            // 
            // lblCrime
            // 
            this.lblCrime.Location = new System.Drawing.Point(30, 85);
            this.lblCrime.Name = "lblCrime";
            this.lblCrime.Size = new System.Drawing.Size(150, 25);
            this.lblCrime.Text = "Select Active Case:";
            // 
            // cmbCrimes
            // 
            this.cmbCrimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbCrimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrimes.ForeColor = System.Drawing.Color.White;
            this.cmbCrimes.Location = new System.Drawing.Point(200, 82);
            this.cmbCrimes.Name = "cmbCrimes";
            this.cmbCrimes.Size = new System.Drawing.Size(260, 29);
            this.cmbCrimes.TabIndex = 1;
            // 
            // lblInvestigator
            // 
            this.lblInvestigator.Location = new System.Drawing.Point(30, 145);
            this.lblInvestigator.Name = "lblInvestigator";
            this.lblInvestigator.Size = new System.Drawing.Size(150, 25);
            this.lblInvestigator.Text = "Assigning Officer:";
            // 
            // cmbInvestigators
            // 
            this.cmbInvestigators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbInvestigators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvestigators.ForeColor = System.Drawing.Color.White;
            this.cmbInvestigators.Location = new System.Drawing.Point(200, 142);
            this.cmbInvestigators.Name = "cmbInvestigators";
            this.cmbInvestigators.Size = new System.Drawing.Size(260, 29);
            this.cmbInvestigators.TabIndex = 2;
            // 
            // btnAssign
            // 
            this.btnAssign.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAssign.Location = new System.Drawing.Point(60, 220);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(160, 38);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Confirm Assignment";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Location = new System.Drawing.Point(270, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 38);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAssignCase
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCrime);
            this.Controls.Add(this.cmbCrimes);
            this.Controls.Add(this.lblInvestigator);
            this.Controls.Add(this.cmbInvestigators);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAssignCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Case Allocation Control Station";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblCrime, lblInvestigator;
        private System.Windows.Forms.ComboBox cmbCrimes, cmbInvestigators;
        private System.Windows.Forms.Button btnAssign, btnCancel;
    }
}