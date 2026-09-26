using _2ndSemProject.Data_Access_Layer;
using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmDeactivateUser : Form
    {
        private readonly InvestigatorRepository _investigatorRepo = new InvestigatorRepository();
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        private readonly string _connString = "Data Source=.;Initial Catalog=CRIME_TRACKER_DB;Integrated Security=True;";

        public frmDeactivateUser()
        {
            InitializeComponent();
            CreateArchiveTableIfMissing();
            LoadActiveInvestigators();
            LoadRevokedInvestigators();
        }

        // =====================================================================
        // 1. DATABASE COMPATIBILITY BACKUP LAYER
        // =====================================================================
        private void CreateArchiveTableIfMissing()
        {
            try
            {
                string checkQuery = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RevokedInvestigators')
                                      CREATE TABLE RevokedInvestigators (
                                          InvestigatorID INT,
                                          Name VARCHAR(100),
                                          BadgeNo VARCHAR(30),
                                          Rank VARCHAR(50),
                                          Username VARCHAR(50),
                                          PasswordHash VARCHAR(255),
                                          Role VARCHAR(20),
                                          IsActive BIT
                                      );";
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* Stable UI startup initialization safeguard */ }
        }

        // =====================================================================
        // 2. DATA BINDING AND POPULATION CONTROLLERS
        // =====================================================================
        private void LoadActiveInvestigators()
        {
            try
            {
                List<Investigator> officers = _investigatorRepo.GetAllInvestigators();
                DataTable officerTable = new DataTable();
                officerTable.Columns.Add("InvestigatorID", typeof(int));
                officerTable.Columns.Add("FullName", typeof(string));

                if (officers != null)
                {
                    foreach (Investigator officer in officers)
                    {
                        officerTable.Rows.Add(officer.GetInvestigatorID(), officer.GetName());
                    }
                }

                cmbInvestigators.SelectedIndexChanged -= cmbInvestigators_SelectedIndexChanged;
                cmbInvestigators.DataSource = officerTable;
                cmbInvestigators.DisplayMember = "FullName";
                cmbInvestigators.ValueMember = "InvestigatorID";
                cmbInvestigators.SelectedIndexChanged += cmbInvestigators_SelectedIndexChanged;

                UpdatePersonnelProfileCard();
            }
            catch (Exception ex) { MessageBox.Show("Error loading active list: " + ex.Message); }
        }

        private void LoadRevokedInvestigators()
        {
            try
            {
                DataTable dt = _dbHelper.ExecuteQuery("SELECT InvestigatorID, Name FROM RevokedInvestigators");
                cmbRevoked.DataSource = dt;
                cmbRevoked.DisplayMember = "Name";
                cmbRevoked.ValueMember = "InvestigatorID";
            }
            catch { /* Silent fallback routing */ }
        }

        private void cmbInvestigators_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePersonnelProfileCard();
        }

        private void UpdatePersonnelProfileCard()
        {
            if (cmbInvestigators.SelectedValue == null || cmbInvestigators.SelectedValue is DataRowView) return;
            int id = Convert.ToInt32(cmbInvestigators.SelectedValue);

            try
            {
                DataTable dt = _dbHelper.ExecuteQuery($"SELECT * FROM Investigators WHERE InvestigatorID = {id}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblDisplayID.Text = $"INVESTIGATOR REFERENCE NODE ID : {dt.Rows[0]["InvestigatorID"]}";
                    lblDisplayName.Text = $"OFFICIAL NAME REGISTRY ENTRY : {dt.Rows[0]["Name"]}";
                    lblDisplayBadge.Text = $"UNIQUE BADGE IDENTIFIER TOKEN : {dt.Rows[0]["BadgeNo"]}";
                    lblDisplayRank.Text = $"OPERATIONAL DEPARTMENT RANK  : {dt.Rows[0]["Rank"]}";
                }
            }
            catch { /* Protection fallback handler */ }
        }

        // =====================================================================
        // 3. EXPLICIT TERMINATION ROUTINE (Wipes Profile AND System User Account)
        // =====================================================================
        private void btnRevoke_Click(object sender, EventArgs e)
        {
            if (cmbInvestigators.SelectedValue == null) return;
            int id = Convert.ToInt32(cmbInvestigators.SelectedValue);
            string selectedName = cmbInvestigators.Text;

            DialogResult res = MessageBox.Show($"Are you sure you want to completely revoke credentials and login access for {selectedName}?", "Confirm Revocation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();

                    string targetName = "";
                    string targetBadge = "";
                    string targetRank = "";
                    int targetUserID = 0;

                    using (SqlCommand getCmd = new SqlCommand($"SELECT Name, BadgeNo, Rank, UserID FROM Investigators WHERE InvestigatorID = {id}", conn))
                    {
                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                targetName = reader["Name"].ToString();
                                targetBadge = reader["BadgeNo"].ToString();
                                targetRank = reader["Rank"].ToString();
                                targetUserID = Convert.ToInt32(reader["UserID"]);
                            }
                        }
                    }

                    string originalUsername = "";
                    string passwordHash = "";
                    string role = "Investigator";
                    int isActiveValue = 1;

                    using (SqlCommand userCmd = new SqlCommand($"SELECT Username, PasswordHash, Role, IsActive FROM Users WHERE UserID = {targetUserID}", conn))
                    {
                        using (SqlDataReader userReader = userCmd.ExecuteReader())
                        {
                            if (userReader.Read())
                            {
                                originalUsername = userReader["Username"].ToString();
                                passwordHash = userReader["PasswordHash"].ToString();
                                role = userReader["Role"].ToString();
                                isActiveValue = userReader["IsActive"] != DBNull.Value ? Convert.ToInt32(userReader["IsActive"]) : 1;
                            }
                        }
                    }

                    string archiveQuery = $@"INSERT INTO RevokedInvestigators (InvestigatorID, Name, BadgeNo, Rank, Username, PasswordHash, Role, IsActive)
                                             VALUES ({id}, '{targetName.Replace("'", "''")}', '{targetBadge.Replace("'", "''")}', '{targetRank.Replace("'", "''")}', '{originalUsername.Replace("'", "''")}', '{passwordHash}', '{role}', {isActiveValue});";

                    using (SqlCommand cmdArchive = new SqlCommand(archiveQuery, conn))
                        cmdArchive.ExecuteNonQuery();

                    string deleteProfileQuery = $"DELETE FROM Investigators WHERE InvestigatorID = {id}";
                    string deleteUserQuery = $"DELETE FROM Users WHERE UserID = {targetUserID}";

                    using (SqlCommand cmd1 = new SqlCommand(deleteProfileQuery, conn)) cmd1.ExecuteNonQuery();
                    using (SqlCommand cmd2 = new SqlCommand(deleteUserQuery, conn)) cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Credentials and system login access successfully terminated!", "Access Revoked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveInvestigators();
                LoadRevokedInvestigators();
            }
            catch (Exception ex) { MessageBox.Show("Revocation failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // =====================================================================
        // 4. REINSTATE RECOVERY ROUTINE (Restores original profile and username)
        // =====================================================================
        private void btnUnRevoke_Click(object sender, EventArgs e)
        {
            if (cmbRevoked.SelectedValue == null) return;
            int id = Convert.ToInt32(cmbRevoked.SelectedValue);
            string selectedName = cmbRevoked.Text;

            DialogResult res = MessageBox.Show($"Do you want to fully restore system access and login credentials for {selectedName}?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            // ✅ SCOPE FIX: Declared out here at the top level of the method
            string origUsername = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();

                    string passHash = "123";
                    string role = "Investigator";
                    string targetBadge = "";
                    string targetRank = "";
                    int originalIsActive = 1;

                    using (SqlCommand getArchive = new SqlCommand($"SELECT BadgeNo, Rank, Username, PasswordHash, Role, IsActive FROM RevokedInvestigators WHERE InvestigatorID = {id}", conn))
                    {
                        using (SqlDataReader reader = getArchive.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                targetBadge = reader["BadgeNo"].ToString();
                                targetRank = reader["Rank"].ToString();
                                origUsername = reader["Username"].ToString(); // Assigned safely here
                                passHash = reader["PasswordHash"].ToString();
                                role = reader["Role"].ToString();
                                originalIsActive = Convert.ToInt32(reader["IsActive"]);
                            }
                        }
                    }

                    string userInsert = $@"INSERT INTO Users (Username, PasswordHash, Role, IsActive) 
                                           VALUES ('{origUsername.Replace("'", "''")}', '{passHash}', '{role}', {originalIsActive});
                                           SELECT SCOPE_IDENTITY();";

                    int newGeneratedUserID = 0;
                    using (SqlCommand cmdUser = new SqlCommand(userInsert, conn))
                    {
                        newGeneratedUserID = Convert.ToInt32(cmdUser.ExecuteScalar());
                    }

                    string restoreProfileQuery = $@"SET IDENTITY_INSERT Investigators ON;
                                                    INSERT INTO Investigators (InvestigatorID, Name, BadgeNo, Rank, UserID)
                                                    VALUES ({id}, '{selectedName.Replace("'", "''")}', '{targetBadge.Replace("'", "''")}', '{targetRank.Replace("'", "''")}', {newGeneratedUserID});
                                                    SET IDENTITY_INSERT Investigators OFF;";

                    using (SqlCommand cmd1 = new SqlCommand(restoreProfileQuery, conn)) cmd1.ExecuteNonQuery();

                    using (SqlCommand cmd3 = new SqlCommand($"DELETE FROM RevokedInvestigators WHERE InvestigatorID = {id}", conn)) cmd3.ExecuteNonQuery();
                }

                // ✅ SAFE ACCESS: Can now be cleanly evaluated outside the SQL block on line 260!
                MessageBox.Show($"Investigator successfully reinstated to duty!\n\nLogin Username: {origUsername}\nPassword: Use their original password.", "Access Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveInvestigators();
                LoadRevokedInvestigators();
            }
            catch (Exception ex) { MessageBox.Show("Restore failed: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}