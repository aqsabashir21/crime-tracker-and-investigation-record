using _2ndSemProject.Data_Access_Layer;
using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class ucViewOfficers : UserControl
    {
        private readonly InvestigatorRepository _investigatorRepo = new InvestigatorRepository();

        public ucViewOfficers()
        {
            InitializeComponent();
            LoadOfficersDirectory();
        }

        private void LoadOfficersDirectory()
        {
            try
            {
                dgvOfficers.DataSource = null;

                // Fetch the strongly-typed List of Investigators from your repository layer
                List<Investigator> officerList = _investigatorRepo.GetAllInvestigators();

                // Convert the OOP List objects cleanly into a structural DataTable for DataGridView binding
                DataTable directoryTable = new DataTable();
                directoryTable.Columns.Add("ID", typeof(int));
                directoryTable.Columns.Add("Official Name", typeof(string));
                directoryTable.Columns.Add("Badge Identifier", typeof(string));
                directoryTable.Columns.Add("Operational Rank", typeof(string));
                directoryTable.Columns.Add("Age", typeof(int));

                if (officerList != null && officerList.Count > 0)
                {
                    foreach (Investigator officer in officerList)
                    {
                        directoryTable.Rows.Add(
                            officer.GetInvestigatorID(),
                            officer.GetName(),
                            officer.GetBadgeNo(),
                            officer.GetRank(),
                            officer.GetAge()
                        );
                    }

                    lblStatus.Text = $"DIRECTORY ACTIVE: Successfully indexed {officerList.Count} active law enforcement profiles.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); // Electric Blue Accent
                }
                else
                {
                    lblStatus.Text = "Status: Directory clear. No officer profiles parsed from system registry nodes.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
                }

                dgvOfficers.DataSource = directoryTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to synchronize law enforcement directory matrix: " + ex.Message, "System Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}