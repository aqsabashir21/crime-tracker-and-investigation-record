using System;
using System.Data;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class frmAddInvestigator : Form
    {
        public frmAddInvestigator()
        {
            InitializeComponent();
            if (cmbRank.Items.Count > 0) cmbRank.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string badgeNo = txtBadge.Text.Trim();
            int age = Convert.ToInt32(numAge.Value);
            string rank = cmbRank.SelectedItem != null ? cmbRank.SelectedItem.ToString() : "Junior Detective";

            // 1. Mandatory Data Completeness Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(badgeNo))
            {
                MessageBox.Show("All configuration fields are mandatory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Strict Username Length Boundary Check
            if (username.Length < 4)
            {
                MessageBox.Show("Operational Halt: Login Username must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();

                // 3. UNIQUE USERNAME ENFORCEMENT: Check if the handle is claimed before calling SQL
                string checkQuery = $"SELECT COUNT(*) FROM Users WHERE Username = '{username.Replace("'", "''")}'";
                DataTable checkTable = dbHelper.ExecuteQuery(checkQuery);

                if (checkTable != null && checkTable.Rows.Count > 0 && Convert.ToInt32(checkTable.Rows[0][0]) > 0)
                {
                    MessageBox.Show($"The login username '{username}' is already claimed. Please designate a unique identifier.", "Credentials Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Fire the updated method, passing all values down to the database
                AuthRepository authRepo = new AuthRepository();
                bool success = authRepo.ProvisionInvestigatorAccount(username, password, fullName, age, badgeNo, rank);

                if (success)
                {
                    MessageBox.Show("Investigator profile and active badge metrics securely generated directly through the application!", "Onboarding Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Data rejects structural check constraints.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pipeline error processing personnel onboarding stream: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}