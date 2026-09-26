using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    partial class ucMyCases
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
            System.Windows.Forms.DataGridViewCellStyle gridStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTabTitle = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.dgvMyCases = new System.Windows.Forms.DataGridView();
            this.pnlButtonContainer = new System.Windows.Forms.Panel();
            this.btnViewCaseDetails = new System.Windows.Forms.Button();
            this.btnLogProgress = new System.Windows.Forms.Button();
            this.btnManageEvidence = new System.Windows.Forms.Button();
            this.btnViewTimeline = new System.Windows.Forms.Button();
            this.btnViewCaseAssets = new System.Windows.Forms.Button();
            this.pnlDetailWorkspace = new System.Windows.Forms.Panel();
            this.lblDetailSectionTitle = new System.Windows.Forms.Label();
            this.dgvSecondaryDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyCases)).BeginInit();
            this.pnlButtonContainer.SuspendLayout();
            this.pnlDetailWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondaryDetail)).BeginInit();
            this.SuspendLayout();

            // -----------------------------------------------------------------
            // 🌌 PREMIUM DARK GRID STYLER DESIGNS
            // -----------------------------------------------------------------
            // Standard data row grid body styling
            gridStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            gridStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            gridStyle.ForeColor = System.Drawing.Color.White;
            gridStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon Electric Blue
            gridStyle.SelectionForeColor = System.Drawing.Color.FromArgb(18, 18, 24);   // Dark Slate text pop

            // High-contrast header style configurations
            headerStyle.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);       // Obsidian Background
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);       // Electric Blue Labels
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 150, 255);

            // lblTabTitle
            this.lblTabTitle.AutoSize = true;
            this.lblTabTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTabTitle.ForeColor = System.Drawing.Color.White;
            this.lblTabTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTabTitle.Text = "FIELD OPERATIONS WORKSPACE";

            // lblInstructions
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblInstructions.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInstructions.Location = new System.Drawing.Point(33, 60);
            this.lblInstructions.Text = "Select an assigned case file row from your active roster to run updates, attach forensic tokens, or review diary charts.";

            // -----------------------------------------------------------------
            // 📊 dgvMyCases (Master Active Assignment Roster Grid)
            // -----------------------------------------------------------------
            this.dgvMyCases.EnableHeadersVisualStyles = false; // 🔓 CRITICAL: Bypasses native Windows 95 white styling!
            this.dgvMyCases.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvMyCases.DefaultCellStyle = gridStyle;
            this.dgvMyCases.GridColor = System.Drawing.Color.FromArgb(38, 38, 52); // Modern layout border stroke
            this.dgvMyCases.RowHeadersVisible = false; // 🚫 Hides the blank leftmost column margin
            this.dgvMyCases.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.dgvMyCases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyCases.Location = new System.Drawing.Point(35, 100);
            this.dgvMyCases.Name = "dgvMyCases";
            this.dgvMyCases.ReadOnly = true;
            this.dgvMyCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyCases.Size = new System.Drawing.Size(950, 160);

            // -----------------------------------------------------------------
            // 🎛️ pnlButtonContainer (Horizontal Sub-Command Operations bar)
            // -----------------------------------------------------------------
            this.pnlButtonContainer.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlButtonContainer.Controls.Add(this.btnViewCaseDetails);
            this.pnlButtonContainer.Controls.Add(this.btnLogProgress);
            this.pnlButtonContainer.Controls.Add(this.btnManageEvidence);
            this.pnlButtonContainer.Controls.Add(this.btnViewTimeline);
            this.pnlButtonContainer.Controls.Add(this.btnViewCaseAssets);
            this.pnlButtonContainer.Location = new System.Drawing.Point(35, 275);
            this.pnlButtonContainer.Size = new System.Drawing.Size(950, 55);

            System.Windows.Forms.Button[] opsButtons = {
                this.btnViewCaseDetails, this.btnLogProgress,
                this.btnManageEvidence, this.btnViewTimeline, this.btnViewCaseAssets
            };

            int nextX = 0;
            foreach (System.Windows.Forms.Button btn in opsButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Size = new System.Drawing.Size(180, 45);
                btn.Location = new System.Drawing.Point(nextX, 5);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;

                btn.MouseEnter += new System.EventHandler(this.ActionButton_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.ActionButton_MouseLeave);

                nextX += 192;
            }

            this.btnViewCaseDetails.Text = "📁 Explore Dossier";
            this.btnViewCaseDetails.Click += new System.EventHandler(this.btnViewCaseDetails_Click);

            this.btnLogProgress.Text = "✍️ Append Progress";
            this.btnLogProgress.Click += new System.EventHandler(this.btnLogProgress_Click);

            this.btnManageEvidence.Text = "🧪 Log Evidence";
            this.btnManageEvidence.Click += new System.EventHandler(this.btnManageEvidence_Click);

            this.btnViewTimeline.Text = "📜 Read Timeline";
            this.btnViewTimeline.Click += new System.EventHandler(this.btnViewTimeline_Click);

            this.btnViewCaseAssets.Text = "🧬 Inspect Assets";
            this.btnViewCaseAssets.Click += new System.EventHandler(this.btnViewCaseAssets_Click);

            // -----------------------------------------------------------------
            // 📜 pnlDetailWorkspace (Secondary Details Area Grid Container)
            // -----------------------------------------------------------------
            this.pnlDetailWorkspace.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.pnlDetailWorkspace.Controls.Add(this.lblDetailSectionTitle);
            this.pnlDetailWorkspace.Controls.Add(this.dgvSecondaryDetail);
            this.pnlDetailWorkspace.Location = new System.Drawing.Point(35, 345);
            this.pnlDetailWorkspace.Size = new System.Drawing.Size(950, 225);

            // lblDetailSectionTitle
            this.lblDetailSectionTitle.AutoSize = true;
            this.lblDetailSectionTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailSectionTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDetailSectionTitle.Location = new System.Drawing.Point(15, 12);
            this.lblDetailSectionTitle.Text = "🔍 CHRONOLOGICAL TRACKING ANALYSIS (SELECT AN OPERATION COMMAND)";

            // dgvSecondaryDetail
            this.dgvSecondaryDetail.EnableHeadersVisualStyles = false; // 🔓 CRITICAL: Bypasses native Windows 95 white styling!
            this.dgvSecondaryDetail.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvSecondaryDetail.DefaultCellStyle = gridStyle;
            this.dgvSecondaryDetail.GridColor = System.Drawing.Color.FromArgb(38, 38, 52); // Modern layout border stroke
            this.dgvSecondaryDetail.RowHeadersVisible = false; // 🚫 Hides the blank leftmost column margin
            this.dgvSecondaryDetail.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.dgvSecondaryDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSecondaryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecondaryDetail.Location = new System.Drawing.Point(18, 40);
            this.dgvSecondaryDetail.ReadOnly = true;
            this.dgvSecondaryDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSecondaryDetail.Size = new System.Drawing.Size(915, 165);

            // -----------------------------------------------------------------
            // Control Settings
            // -----------------------------------------------------------------
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.Controls.Add(this.pnlDetailWorkspace);
            this.Controls.Add(this.pnlButtonContainer);
            this.Controls.Add(this.dgvMyCases);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblTabTitle);
            this.Size = new System.Drawing.Size(1020, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyCases)).EndInit();
            this.pnlButtonContainer.ResumeLayout(false);
            this.pnlDetailWorkspace.ResumeLayout(false);
            this.pnlDetailWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondaryDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTabTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.DataGridView dgvMyCases;
        private System.Windows.Forms.Panel pnlButtonContainer;
        private System.Windows.Forms.Button btnViewCaseDetails;
        private System.Windows.Forms.Button btnLogProgress;
        private System.Windows.Forms.Button btnManageEvidence;
        private System.Windows.Forms.Button btnViewTimeline;
        private System.Windows.Forms.Button btnViewCaseAssets;
        private System.Windows.Forms.Panel pnlDetailWorkspace;
        private System.Windows.Forms.Label lblDetailSectionTitle;
        private System.Windows.Forms.DataGridView dgvSecondaryDetail;
    }
}