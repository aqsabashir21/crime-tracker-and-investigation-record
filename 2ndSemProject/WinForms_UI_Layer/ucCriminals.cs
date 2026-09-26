using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class ucCriminals : UserControl
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();
        private bool _isMostWantedViewMode = false;

        public ucCriminals()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 🔥 NATIVE C# INPUT PROMPT BOX (Replaces VisualBasic Interaction dependency)
        // =====================================================================
        private string PromptForInput(string text, string caption, string defaultResult = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(18, 18, 24),
                ForeColor = System.Drawing.Color.White
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text, Font = new System.Drawing.Font("Segoe UI", 9F) };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 344, Text = defaultResult, BackColor = System.Drawing.Color.FromArgb(28, 28, 38), ForeColor = System.Drawing.Color.White, BorderStyle = BorderStyle.FixedSingle };

            Button confirmation = new Button() { Text = "Submit", Left = 214, Width = 150, Top = 90, Height = 30, DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat };
            confirmation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            confirmation.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void btnRegisterCriminal_Click(object sender, EventArgs e)
        {
            using (frmRegisterCriminal form = new frmRegisterCriminal())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (pnlDataViewWorkspace.Visible && !_isMostWantedViewMode)
                    {
                        ExecuteCriminalSearchQuery();
                    }
                }
            }
        }

        private void btnSearchCriminals_Click(object sender, EventArgs e)
        {
            _isMostWantedViewMode = false;
            lblTabTitle.Text = "CRIMINAL RECORDS INDEX MATRIX";
            lblInstructions.Text = "Enter full target name or exact numeric CNIC passport identity parameters to isolate target suspect profiles.";

            txtSearchInput.Visible = true;
            btnExecuteSearch.Visible = true;
            txtSearchInput.Text = ""; // 🔄 FIXED: Removed placeholder assignment lines completely to clear CS1061!

            ToggleWorkspaceView(showGridData: true);
            ExecuteCriminalSearchQuery();
        }

        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            ExecuteCriminalSearchQuery();
        }

        private void ExecuteCriminalSearchQuery()
        {
            try
            {
                string criteria = txtSearchInput.Text.Trim();
                List<Criminal> records = _criminalRepo.SearchCriminals(criteria);

                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("ID", typeof(int));
                displayTable.Columns.Add("Suspect Name", typeof(string));
                displayTable.Columns.Add("Identity CNIC No", typeof(string));
                displayTable.Columns.Add("Age Metric", typeof(int));
                displayTable.Columns.Add("Gender Profile", typeof(string));
                displayTable.Columns.Add("Custody Status State", typeof(string));

                foreach (Criminal c in records)
                {
                    displayTable.Rows.Add(c.GetCriminalID(), c.GetName(), c.GetCNIC(), c.GetAge(), c.GetGender(), c.GetStatus());
                }

                dgvCriminalsResult.DataSource = displayTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error compiling database search collection: " + ex.Message, "Query Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadMostWantedTile_Click(object sender, EventArgs e) //
        {
            // Initialize and display the filtered threat matrix pop-up overlay window
            using (frmMostWanted radarWizard = new frmMostWanted())
            {
                radarWizard.ShowDialog();
            }
        }

        private void LoadMostWantedRosterData()
        {
            try
            {
                List<Criminal> fugitivesList = _criminalRepo.GetMostWanted();

                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("Fugitive ID", typeof(int));
                displayTable.Columns.Add("Subject Full Name", typeof(string));
                displayTable.Columns.Add("CNIC Identity Token", typeof(string));
                displayTable.Columns.Add("Recorded Age", typeof(int));
                displayTable.Columns.Add("Gender Flag", typeof(string));
                displayTable.Columns.Add("System Warning Status", typeof(string));

                foreach (Criminal f in fugitivesList)
                {
                    displayTable.Rows.Add(f.GetCriminalID(), f.GetName(), f.GetCNIC(), f.GetAge(), f.GetGender(), f.GetStatus());
                }

                dgvCriminalsResult.DataSource = displayTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rendering system critical fugitives view: " + ex.Message, "Query Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            lblTabTitle.Text = "CRIMINALS MANAGEMENT CORE";
            lblInstructions.Text = "Select an operational command option below to execute database profile tasks.";
            ToggleWorkspaceView(showGridData: false);
        }

        private void ToggleWorkspaceView(bool showGridData)
        {
            pnlButtonGrid.Visible = !showGridData;
            pnlDataViewWorkspace.Visible = showGridData;
        }

        private void btnUpdateCustodyStatusTile_Click(object sender, EventArgs e)
        {
            // Launches our custom modal selector console window directly on top of the active shell panel view!
            using (frmUpdateStatus updateWizard = new frmUpdateStatus())
            {
                if (updateWizard.ShowDialog() == DialogResult.OK)
                {
                    // This automatically reloads your master grid table live if you are currently looking at it!
                    ExecuteCriminalSearchQuery(); //
                }
            }
        }

        private void btnViewPriorConvictionsTile_Click(object sender, EventArgs e) //
        {
            // Launch the lookup console dialog box as a focused overlay view window
            using (frmViewConvictions convictionsWizard = new frmViewConvictions())
            {
                convictionsWizard.ShowDialog();
            }
        }

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