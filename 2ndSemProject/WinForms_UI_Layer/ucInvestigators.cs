using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class ucInvestigators : UserControl
    {
        public ucInvestigators()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 1. REGISTER INVESTIGATOR BUTTON CLICK HANDLER
        // =====================================================================
        private void btnRegisterInvestigator_Click(object sender, EventArgs e)
        {
            // ✅ FIX: Opens ONLY the input form, with NO extra window calls following it!
            using (frmAddInvestigator addForm = new frmAddInvestigator())
            {
                addForm.ShowDialog();
            }
        }

        // =====================================================================
        // 2. VIEW OFFICERS DIRECTORY BUTTON CLICK HANDLER
        // =====================================================================
        private void btnViewOfficerDirectory_Click(object sender, EventArgs e)
        {
            // ✅ FIX: This now explicitly launches your floating directory grid view!
            using (Form popupWindow = new Form())
            {
                ucViewOfficers directoryView = new ucViewOfficers();
                directoryView.Dock = DockStyle.Fill;

                popupWindow.Size = new System.Drawing.Size(1000, 650);
                popupWindow.Text = "Active Personnel Directory Registry Nodes";
                popupWindow.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
                popupWindow.FormBorderStyle = FormBorderStyle.FixedDialog;
                popupWindow.StartPosition = FormStartPosition.CenterParent;

                popupWindow.Controls.Add(directoryView);
                popupWindow.ShowDialog();
            }
        }

        // =====================================================================
        // BACKUP ROUTES (Ensures compatibility if your designer uses alternate names)
        // =====================================================================
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            // Redirects straight to the verified directory popup logic above
            btnViewOfficerDirectory_Click(sender, e);
        }

        private void btnAssignCase_Click(object sender, EventArgs e)
        {
            // ✅ CORRECTION: Launches your dynamic key-value case allocation interface window form!
            using (frmAssignCase allocationForm = new frmAssignCase())
            {
                allocationForm.ShowDialog();
            }
        }

        private void btnWorkloadReport_Click(object sender, EventArgs e)
        {
            // ✅ REMAPPED: Launches your live analytical workload view summary table dataset!
            using (frmWorkloadReport summaryReportForm = new frmWorkloadReport())
            {
                summaryReportForm.ShowDialog();
            }
        }

        private void btnDeactivateCredentials_Click(object sender, EventArgs e)
        {
            using (frmDeactivateUser form = new frmDeactivateUser())
            {
                form.ShowDialog(this);
            }
        }

        // =====================================================================
        // NEON HOVER STATES ANIMATION ENGINE 
        // =====================================================================
        private void ActionButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(0, 150, 255);
            btn.ForeColor = System.Drawing.Color.FromArgb(18, 18, 24);
        }

        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
        }
    }
}