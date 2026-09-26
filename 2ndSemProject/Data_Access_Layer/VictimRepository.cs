using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace _2ndSemProject.Data_Access_Layer
{
    public class VictimRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // 1. Get all victims associated with a specific crime ID
        public DataTable GetVictimsByCrime(int crimeID)
        {
            try
            {
                // Pulling your exact verified columns from the SSMS query window matrix view
                string query = $@"SELECT VictimID, Name, Contact AS [Primary Contact], ContactNumber AS [Identity Data Manifest], PrimaryImpact AS [Impact Category], Age 
                          FROM Victims 
                          WHERE CrimeID = {crimeID}
                          ORDER BY VictimID DESC";

                return _dbHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve victim logs: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // 2. Commit a new victim record tied directly to a crime ID


        public bool SaveVictim(int crimeID, string name, string cnic, string contact, string impactType)
        {
            // 🔥 Clean up text parameters safely
            string cleanName = name.Replace("'", "''");
            string cleanContact = contact.Replace("'", "''");
            string cleanImpact = impactType.Replace("'", "''");

            // Since CNIC doesn't exist as a separate column, let's append it to the secondary contact number tracking column cleanly!
            string contactCombined = $"CNIC: {cnic} | Ph: {cleanContact}".Replace("'", "''");

            // 🔥 MATCHING THE EXACT SCHEMA: VictimID (Identity) | Name | Age | Contact | CrimeID | ContactNumber | PrimaryImpact
            string query = $@"INSERT INTO Victims (CrimeID, Name, Contact, ContactNumber, PrimaryImpact, Age) 
                     VALUES ({crimeID}, '{cleanName}', '{cleanContact}', '{contactCombined}', '{cleanImpact}', 0)";

            // Let's route it back through your official helper engine now that we fixed the broken column string name!
            try
            {
                _dbHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Rejection: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // =====================================================================
        // SECURITY: Verify if a CNIC registration token already exists 
        // =====================================================================
        public bool IsCnicDuplicate(string cnic)
        {
            try
            {
                // Look for any existing rows where the CNIC string matches your input text parameter
                // We parse it right from the combined tracking data column field
                string query = $"SELECT COUNT(*) FROM Victims WHERE ContactNumber LIKE '%CNIC: {cnic}%'";

                DatabaseHelper dbHelper = new DatabaseHelper();
                DataTable result = dbHelper.ExecuteQuery(query);

                if (result != null && result.Rows.Count > 0)
                {
                    int matchCount = Convert.ToInt32(result.Rows[0][0]);
                    return matchCount > 0; // Returns true if a row match is found!
                }
                return false;
            }
            catch
            {
                return false; // Fallback safely on error bounds
            }
        }
    }
}