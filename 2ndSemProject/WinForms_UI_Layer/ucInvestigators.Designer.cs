using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    partial class ucInvestigators
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
            this.lblTabTitle = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnRegisterInvestigator = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnAssignCase = new System.Windows.Forms.Button();
            this.btnWorkloadReport = new System.Windows.Forms.Button();
            this.btnDeactivateCredentials = new System.Windows.Forms.Button();
            this.pnlButtonGrid = new System.Windows.Forms.Panel();
            this.pnlButtonGrid.SuspendLayout();
            this.SuspendLayout();

            // -----------------------------------------------------------------
            // lblTabTitle (Investigators Panel Header)
            // -----------------------------------------------------------------
            this.lblTabTitle.AutoSize = true;
            this.lblTabTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTabTitle.ForeColor = System.Drawing.Color.White;
            this.lblTabTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTabTitle.Name = "lblTabTitle";
            this.lblTabTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTabTitle.Text = "LAW ENFORCEMENT PERSONNEL CORE";

            // lblInstructions
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblInstructions.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInstructions.Location = new System.Drawing.Point(33, 60);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Text = "Manage detective rosters, handle case distribution mappings, review active workloads, or adjust access levels.";

            // -----------------------------------------------------------------
            // pnlButtonGrid (Container to hold and center our function grid)
            // -----------------------------------------------------------------
            this.pnlButtonGrid.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlButtonGrid.Controls.Add(this.btnRegisterInvestigator);
            this.pnlButtonGrid.Controls.Add(this.btnViewAll);
            this.pnlButtonGrid.Controls.Add(this.btnAssignCase);
            this.pnlButtonGrid.Controls.Add(this.btnWorkloadReport);
            this.pnlButtonGrid.Controls.Add(this.btnDeactivateCredentials);
            this.pnlButtonGrid.Location = new System.Drawing.Point(35, 110);
            this.pnlButtonGrid.Name = "pnlButtonGrid";
            this.pnlButtonGrid.Size = new System.Drawing.Size(900, 450);

            // Grouping array to build the grid map dynamically
            System.Windows.Forms.Button[] actionButtons = {
                this.btnRegisterInvestigator,
                this.btnViewAll,
                this.btnAssignCase,
                this.btnWorkloadReport,
                this.btnDeactivateCredentials
            };

            int posX = 20;
            int posY = 20;
            int count = 0;

            foreach (System.Windows.Forms.Button btn in actionButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); // Slate card color
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon Blue Outline
                btn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Size = new System.Drawing.Size(260, 100); // Chunky professional aspect ratio
                btn.Location = new System.Drawing.Point(posX, posY);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;

                btn.MouseEnter += new System.EventHandler(this.ActionButton_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.ActionButton_MouseLeave);

                count++;
                if (count % 3 == 0)
                {
                    posX = 20;
                    posY += 130; // Shift down row line
                }
                else
                {
                    posX += 290; // Shift right column index
                }
            }

            // -----------------------------------------------------------------
            // 🛠️ BUTTON ACTION EVENT MAPPINGS (FIXED COUPLING CLOSURES)
            // -----------------------------------------------------------------
            this.btnRegisterInvestigator.Text = "➕  Register Investigator";
            this.btnRegisterInvestigator.Click += new System.EventHandler(this.btnRegisterInvestigator_Click);

            // ✅ FIXED: Now binds explicitly to btnViewAll instead of duplicating onto the registration handle!
            this.btnViewAll.Text = "📋  View Officer Directory";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewOfficerDirectory_Click);

            this.btnAssignCase.Text = "💼  Assign Case File";
            this.btnAssignCase.Click += new System.EventHandler(this.btnAssignCase_Click);

            this.btnWorkloadReport.Text = "📊  Load Workload Report";
            this.btnWorkloadReport.Click += new System.EventHandler(this.btnWorkloadReport_Click);

            this.btnDeactivateCredentials.Text = "⚠️  Revoke Credentials";
            this.btnDeactivateCredentials.Click += new System.EventHandler(this.btnDeactivateCredentials_Click);

            // -----------------------------------------------------------------
            // ucInvestigators Core Configuration Properties
            // -----------------------------------------------------------------
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24); // Matches obsidian canvas
            this.Controls.Add(this.pnlButtonGrid);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblTabTitle);
            this.Name = "ucInvestigators";
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlButtonGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTabTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Panel pnlButtonGrid;
        private System.Windows.Forms.Button btnRegisterInvestigator;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnAssignCase;
        private System.Windows.Forms.Button btnWorkloadReport;
        private System.Windows.Forms.Button btnDeactivateCredentials;
    }
}