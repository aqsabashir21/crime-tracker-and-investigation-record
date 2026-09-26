namespace _2ndSemProject
{
    partial class frmViewVictims
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
            this.dgvVictims = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.lblVictimName = new System.Windows.Forms.Label();
            this.txtVictimName = new System.Windows.Forms.TextBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblImpact = new System.Windows.Forms.Label();
            this.cmbImpactType = new System.Windows.Forms.ComboBox();
            this.btnAddVictim = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVictims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblSelect.Location = new System.Drawing.Point(25, 20);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(210, 23);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Filter By Case Incident File:";
            // 
            // cmbCases
            // 
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.ForeColor = System.Drawing.Color.White;
            this.cmbCases.Location = new System.Drawing.Point(264, 20);
            this.cmbCases.Name = "cmbCases";
            this.cmbCases.Size = new System.Drawing.Size(887, 29);
            this.cmbCases.TabIndex = 1;
            this.cmbCases.SelectedIndexChanged += new System.EventHandler(this.cmbCases_SelectedIndexChanged);
            // 
            // dgvVictims
            // 
            this.dgvVictims.AllowUserToAddRows = false;
            this.dgvVictims.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVictims.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dgvVictims.ColumnHeadersHeight = 29;

            // 🔥 HIGH-CONTRAST DATA WINDOW FIX: Enforcing dark slate text readability globally across rows
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            cellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvVictims.DefaultCellStyle = cellStyle;

            // Enforcing dark theme styles for header blocks to keep visual consistency
            this.dgvVictims.EnableHeadersVisualStyles = false;
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvVictims.ColumnHeadersDefaultCellStyle = headerStyle;

            this.dgvVictims.Location = new System.Drawing.Point(25, 60);
            this.dgvVictims.Name = "dgvVictims";
            this.dgvVictims.ReadOnly = true;
            this.dgvVictims.RowHeadersWidth = 51;
            this.dgvVictims.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVictims.Size = new System.Drawing.Size(1286, 180);
            this.dgvVictims.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(25, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(700, 23);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Querying database secure nodes...";
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAddTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblAddTitle.Location = new System.Drawing.Point(25, 285);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(600, 23);
            this.lblAddTitle.TabIndex = 4;
            this.lblAddTitle.Text = "APPEND NEW VICTIM DETAILS TO SELECTED INCIDENT CASE FILE";
            // 
            // lblVictimName
            // 
            this.lblVictimName.Location = new System.Drawing.Point(29, 331);
            this.lblVictimName.Name = "lblVictimName";
            this.lblVictimName.Size = new System.Drawing.Size(150, 23);
            this.lblVictimName.TabIndex = 5;
            this.lblVictimName.Text = "Full Name / Entity:";
            // 
            // txtVictimName
            // 
            this.txtVictimName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtVictimName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVictimName.ForeColor = System.Drawing.Color.White;
            this.txtVictimName.Location = new System.Drawing.Point(29, 356);
            this.txtVictimName.Name = "txtVictimName";
            this.txtVictimName.Size = new System.Drawing.Size(210, 29);
            this.txtVictimName.TabIndex = 6;
            // 
            // lblCNIC
            // 
            this.lblCNIC.Location = new System.Drawing.Point(313, 331);
            this.lblCNIC.Name = "lblCNIC";
            this.lblCNIC.Size = new System.Drawing.Size(150, 23);
            this.lblCNIC.TabIndex = 7;
            this.lblCNIC.Text = "Identification CNIC:";
            // 
            // txtCNIC
            // 
            this.txtCNIC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtCNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNIC.ForeColor = System.Drawing.Color.White;
            this.txtCNIC.Location = new System.Drawing.Point(313, 356);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(210, 29);
            this.txtCNIC.TabIndex = 8;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(33, 415);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(80, 23);
            this.lblAge.TabIndex = 15;
            this.lblAge.Text = "Age:";
            // 
            // numAge
            // 
            this.numAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.numAge.ForeColor = System.Drawing.Color.White;
            this.numAge.Location = new System.Drawing.Point(33, 440);
            this.numAge.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(100, 29);
            this.numAge.TabIndex = 16;
            this.numAge.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(610, 331);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(180, 23);
            this.lblContact.TabIndex = 9;
            this.lblContact.Text = "Contact Phone Number:";
            // 
            // txtContact
            // 
            this.txtContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.ForeColor = System.Drawing.Color.White;
            this.txtContact.Location = new System.Drawing.Point(610, 356);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(230, 29);
            this.txtContact.TabIndex = 10;
            // 
            // lblImpact
            // 
            this.lblImpact.Location = new System.Drawing.Point(313, 415);
            this.lblImpact.Name = "lblImpact";
            this.lblImpact.Size = new System.Drawing.Size(300, 23);
            this.lblImpact.TabIndex = 11;
            this.lblImpact.Text = "Primary Impact Classification Category:";
            // 
            // cmbImpactType
            // 
            this.cmbImpactType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbImpactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImpactType.ForeColor = System.Drawing.Color.White;
            this.cmbImpactType.Items.AddRange(new object[] {
            "Direct Financial Harms",
            "Corporate Data Leak Exfiltration",
            "Physical Property Harms",
            "Identity Forgery Theft Compromise",
            "Personal Aggression Harm",
            "Collateral Entity Associate"});
            this.cmbImpactType.Location = new System.Drawing.Point(313, 440);
            this.cmbImpactType.Name = "cmbImpactType";
            this.cmbImpactType.Size = new System.Drawing.Size(320, 29);
            this.cmbImpactType.TabIndex = 12;
            // 
            // btnAddVictim
            // 
            this.btnAddVictim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.btnAddVictim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVictim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.btnAddVictim.Location = new System.Drawing.Point(960, 356);
            this.btnAddVictim.Name = "btnAddVictim";
            this.btnAddVictim.Size = new System.Drawing.Size(230, 32);
            this.btnAddVictim.TabIndex = 13;
            this.btnAddVictim.Text = "+ Add Victim Record";
            this.btnAddVictim.Click += new System.EventHandler(this.btnAddVictim_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(960, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 40);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Return to Command Console Core";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmViewVictims
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1355, 520);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbCases);
            this.Controls.Add(this.dgvVictims);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblAddTitle);
            this.Controls.Add(this.lblVictimName);
            this.Controls.Add(this.txtVictimName);
            this.Controls.Add(this.lblCNIC);
            this.Controls.Add(this.txtCNIC);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblImpact);
            this.Controls.Add(this.cmbImpactType);
            this.Controls.Add(this.btnAddVictim);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.numAge);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewVictims";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Civilian and Corporate Case Victim Registry Node";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVictims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblSelect, lblStatus, lblAddTitle, lblVictimName, lblCNIC, lblContact, lblImpact;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.DataGridView dgvVictims;
        private System.Windows.Forms.TextBox txtVictimName, txtCNIC, txtContact;
        private System.Windows.Forms.ComboBox cmbImpactType;
        private System.Windows.Forms.Button btnAddVictim, btnClose;
    }
}