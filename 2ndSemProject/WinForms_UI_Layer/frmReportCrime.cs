using System;
using System.Windows.Forms;
using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class frmReportCrime : Form
    {
        private readonly CrimeRepository _crimeRepo = new CrimeRepository();
        // Add this backing field to track who is filling the case file
        private int _reportingInvestigatorID = 0;

        // Update this constructor signature to accept an incoming investigator ID
        public frmReportCrime(int investigatorID = 0)
        {
            InitializeComponent();
            this._reportingInvestigatorID = investigatorID; // Assign it to your backing field
            cmbType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show("Case File Title and Incident Location are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a strongly-typed Crime entity using parameters expected by your repository
                Crime newCrime = new Crime();
                newCrime.SetTitle(txtTitle.Text.Trim());
                newCrime.SetLocation(txtLocation.Text.Trim());
                newCrime.SetDescription(txtDescription.Text.Trim());

                // Parse the dropdown text cleanly into your backend domain's CrimeType Enum data mapping structures
                CrimeType chosenType = (CrimeType)Enum.Parse(typeof(CrimeType), cmbType.SelectedItem.ToString());
                newCrime.SetCrimeType(chosenType);

                // 🔄 FIXED: Passes the tracking ID field into your updated repository method context!
                int registeredCrimeID = _crimeRepo.ReportCrime(newCrime, this._reportingInvestigatorID);

                if (registeredCrimeID > 0)
                {
                    MessageBox.Show($"Incident successfully registered! Generated Case Reference Token ID is: #{registeredCrimeID}", "Case File Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The system repository database layer could not generate a primary file entry loop key.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error translating business tier object models: " + ex.Message, "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }
    }
}