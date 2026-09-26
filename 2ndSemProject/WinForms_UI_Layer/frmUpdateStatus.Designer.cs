namespace _2ndSemProject
{
    partial class frmUpdateStatus
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
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatusValue = new System.Windows.Forms.Label();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form Configurations (Matches your custom dark layout theme!)
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(420, 270);
            this.Text = "Status Management Console";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Criminal Selection Dropdown
            this.lblSelect.Text = "Select Suspect Profile:";
            this.lblSelect.Location = new System.Drawing.Point(20, 25); this.lblSelect.Width = 150;

            this.cmbCriminals.Location = new System.Drawing.Point(170, 22); this.cmbCriminals.Size = new System.Drawing.Size(220, 25);
            this.cmbCriminals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriminals.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCriminals.ForeColor = System.Drawing.Color.White;
            this.cmbCriminals.SelectedIndexChanged += new System.EventHandler(this.cmbCriminals_SelectedIndexChanged);

            // Current Status Visual Display
            this.lblCurrentStatus.Text = "Current Active Status:";
            this.lblCurrentStatus.Location = new System.Drawing.Point(20, 75); this.lblCurrentStatus.Width = 150;

            this.lblCurrentStatusValue.Text = "---";
            this.lblCurrentStatusValue.Location = new System.Drawing.Point(170, 75); this.lblCurrentStatusValue.Width = 220;
            this.lblCurrentStatusValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStatusValue.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon Blue

            // New Status Target Selection Dropdown
            this.lblNewStatus.Text = "Assign New Status:";
            this.lblNewStatus.Location = new System.Drawing.Point(20, 125); this.lblNewStatus.Width = 150;

            this.cmbNewStatus.Location = new System.Drawing.Point(170, 122); this.cmbNewStatus.Size = new System.Drawing.Size(220, 25);
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbNewStatus.ForeColor = System.Drawing.Color.White;
            this.cmbNewStatus.Items.AddRange(new object[] { "Under Investigation", "In Custody", "Fugitive/Wanted", "Released" });
            this.cmbNewStatus.SelectedIndex = 0;

            // Update Action Button
            this.btnUpdate.Text = "Apply Update";
            this.btnUpdate.Location = new System.Drawing.Point(40, 200); this.btnUpdate.Size = new System.Drawing.Size(150, 40);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // Cancel Action Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(230, 200); this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Render components onto layout canvas
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSelect, this.cmbCriminals, this.lblCurrentStatus, this.lblCurrentStatusValue,
                this.lblNewStatus, this.cmbNewStatus, this.btnUpdate, this.btnCancel
            });
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblSelect, lblCurrentStatus, lblCurrentStatusValue, lblNewStatus;
        private System.Windows.Forms.ComboBox cmbCriminals, cmbNewStatus;
        private System.Windows.Forms.Button btnUpdate, btnCancel;
    }
}