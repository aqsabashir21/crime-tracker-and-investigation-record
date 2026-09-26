namespace _2ndSemProject
{
    partial class frmReportCrime
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Case File Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(156, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(629, 29);
            this.txtTitle.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(20, 60);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(111, 23);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Incident Type:";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.ForeColor = System.Drawing.Color.White;
            this.cmbType.Items.AddRange(new object[] {
            "Theft",
            "Robbery",
            "Murder",
            "Fraud",
            "Assault",
            "Cybercrime"});
            this.cmbType.Location = new System.Drawing.Point(156, 57);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(240, 29);
            this.cmbType.TabIndex = 3;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(20, 100);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(130, 23);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Incident Scene:";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtLocation.ForeColor = System.Drawing.Color.White;
            this.txtLocation.Location = new System.Drawing.Point(156, 94);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(629, 29);
            this.txtLocation.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(20, 140);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Details Log:";
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(156, 137);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(629, 156);
            this.txtDescription.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(210, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 62);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Commit File Case";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Location = new System.Drawing.Point(429, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(163, 62);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReportCrime
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(883, 436);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmReportCrime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Official Law Manifest Dossier Filing Station";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle, lblType, lblLocation, lblDescription;
        private System.Windows.Forms.TextBox txtTitle, txtLocation, txtDescription;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}