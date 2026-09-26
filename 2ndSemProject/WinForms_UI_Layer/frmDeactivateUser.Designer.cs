using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    partial class frmDeactivateUser
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbInvestigators = new System.Windows.Forms.ComboBox();
            this.pnlInfoCard = new System.Windows.Forms.Panel();
            this.lblDisplayID = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblDisplayBadge = new System.Windows.Forms.Label();
            this.lblDisplayRank = new System.Windows.Forms.Label();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // -----------------------------------------------------------------
            // NEW REINSTATE / UN-REVOKE CONTROL FIELDS
            // -----------------------------------------------------------------
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblRestoreTitle = new System.Windows.Forms.Label();
            this.lblSelectRevoked = new System.Windows.Forms.Label();
            this.cmbRevoked = new System.Windows.Forms.ComboBox();
            this.btnUnRevoke = new System.Windows.Forms.Button();

            this.pnlInfoCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 30);
            this.lblTitle.Text = "🚨 PERSONNEL ACCESS TERMINATION STATION";
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(30, 80);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(140, 25);
            this.lblSelect.Text = "Active User:";
            // 
            // cmbInvestigators
            // 
            this.cmbInvestigators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbInvestigators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvestigators.ForeColor = System.Drawing.Color.White;
            this.cmbInvestigators.Location = new System.Drawing.Point(170, 77);
            this.cmbInvestigators.Name = "cmbInvestigators";
            this.cmbInvestigators.Size = new System.Drawing.Size(280, 29);
            this.cmbInvestigators.SelectedIndexChanged += new System.EventHandler(this.cmbInvestigators_SelectedIndexChanged);
            // 
            // pnlInfoCard
            // 
            this.pnlInfoCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.pnlInfoCard.Controls.Add(this.lblDisplayID);
            this.pnlInfoCard.Controls.Add(this.lblDisplayName);
            this.pnlInfoCard.Controls.Add(this.lblDisplayBadge);
            this.pnlInfoCard.Controls.Add(this.lblDisplayRank);
            this.pnlInfoCard.Location = new System.Drawing.Point(34, 135);
            this.pnlInfoCard.Name = "pnlInfoCard";
            this.pnlInfoCard.Size = new System.Drawing.Size(416, 150);
            // 
            // lblDisplayID
            // 
            this.lblDisplayID.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDisplayID.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDisplayID.Location = new System.Drawing.Point(15, 15);
            this.lblDisplayID.Size = new System.Drawing.Size(390, 22);
            this.lblDisplayID.Text = "INVESTIGATOR ID : SELECT USER";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.ForeColor = System.Drawing.Color.White;
            this.lblDisplayName.Location = new System.Drawing.Point(15, 47);
            this.lblDisplayName.Size = new System.Drawing.Size(390, 22);
            this.lblDisplayName.Text = "OFFICIAL NAME  : SELECT USER";
            // 
            // lblDisplayBadge
            // 
            this.lblDisplayBadge.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDisplayBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblDisplayBadge.Location = new System.Drawing.Point(15, 79);
            this.lblDisplayBadge.Size = new System.Drawing.Size(390, 22);
            this.lblDisplayBadge.Text = "BADGE NO       : SELECT USER";
            // 
            // lblDisplayRank
            // 
            this.lblDisplayRank.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDisplayRank.ForeColor = System.Drawing.Color.Gold;
            this.lblDisplayRank.Location = new System.Drawing.Point(15, 111);
            this.lblDisplayRank.Size = new System.Drawing.Size(390, 22);
            this.lblDisplayRank.Text = "CURRENT RANK   : SELECT USER";
            // 
            // btnRevoke
            // 
            this.btnRevoke.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevoke.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRevoke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRevoke.Location = new System.Drawing.Point(130, 315);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(200, 40);
            this.btnRevoke.Text = "⚠️ Revoke Access";
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            this.pnlDivider.Location = new System.Drawing.Point(485, 25);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(2, 330);
            // 
            // lblRestoreTitle
            // 
            this.lblRestoreTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRestoreTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lblRestoreTitle.Location = new System.Drawing.Point(515, 25);
            this.lblRestoreTitle.Name = "lblRestoreTitle";
            this.lblRestoreTitle.Size = new System.Drawing.Size(350, 30);
            this.lblRestoreTitle.Text = "🔄 REINSTATE RECOVERY CONSOLE";
            // 
            // lblSelectRevoked
            // 
            this.lblSelectRevoked.Location = new System.Drawing.Point(515, 80);
            this.lblSelectRevoked.Name = "lblSelectRevoked";
            this.lblSelectRevoked.Size = new System.Drawing.Size(140, 25);
            this.lblSelectRevoked.Text = "Archived Token:";
            // 
            // cmbRevoked
            // 
            this.cmbRevoked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.cmbRevoked.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRevoked.ForeColor = System.Drawing.Color.White;
            this.cmbRevoked.Location = new System.Drawing.Point(519, 115);
            this.cmbRevoked.Name = "cmbRevoked";
            this.cmbRevoked.Size = new System.Drawing.Size(320, 29);
            // 
            // btnUnRevoke
            // 
            this.btnUnRevoke.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.btnUnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnRevoke.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUnRevoke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.btnUnRevoke.Location = new System.Drawing.Point(519, 170);
            this.btnUnRevoke.Name = "btnUnRevoke";
            this.btnUnRevoke.Size = new System.Drawing.Size(320, 40);
            this.btnUnRevoke.Text = "🛡️ Restore & Un-Revoke Access";
            this.btnUnRevoke.Click += new System.EventHandler(this.btnUnRevoke_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Location = new System.Drawing.Point(519, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(320, 40);
            this.btnCancel.Text = "Exit Security Management Form";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDeactivateUser
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(880, 395);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbInvestigators);
            this.Controls.Add(this.pnlInfoCard);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblRestoreTitle);
            this.Controls.Add(this.lblSelectRevoked);
            this.Controls.Add(this.cmbRevoked);
            this.Controls.Add(this.btnUnRevoke);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDeactivateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Main Terminal - Dual Security Command Station";
            this.pnlInfoCard.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblSelect, lblDisplayID, lblDisplayName, lblDisplayBadge, lblDisplayRank;
        private System.Windows.Forms.ComboBox cmbInvestigators;
        private System.Windows.Forms.Panel pnlInfoCard;
        private System.Windows.Forms.Button btnRevoke, btnCancel;

        // Custom split panel components declared inside the class metadata signature
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblRestoreTitle, lblSelectRevoked;
        private System.Windows.Forms.ComboBox cmbRevoked;
        private System.Windows.Forms.Button btnUnRevoke;
    }
}