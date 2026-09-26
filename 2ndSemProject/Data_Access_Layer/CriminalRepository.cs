using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2ndSemProject.Data_Access_Layer
{
    public class CriminalRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // =====================================================================
        // 1. ADMIN: Register a new criminal profile
        // =====================================================================
        // =====================================================================
        // 1. ADMIN: Register a new criminal profile
        // =====================================================================
        // =====================================================================
        // 1. ADMIN: Register a new criminal profile
        // =====================================================================
        public bool RegisterCriminal(Criminal criminal)
        {
            // 🔥 UNBREAKABLE HARDCODED CONNECTION CONNECTION FOR DIRECT CHECKING
            // Uses standard connection string configuration parameters
            string connectionString = "Server=(local);Database=CRIME_TRACKER_DB;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(1) FROM Criminals WHERE CNIC = @CheckCNIC";

                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@CheckCNIC", criminal.GetCNIC());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("CRITICAL VALIDATION ERROR:\n\nA criminal profile with this CNIC identity code already exists in the system database index.",
                                            "Duplicate Record Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false; // 🛑 HARD BLOCK! Stops right here.
                        }
                    }
                }

                // If count is 0, safely proceed to run the insert operation
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", criminal.GetName()), //
                    new SqlParameter("@CNIC", criminal.GetCNIC()), //
                    new SqlParameter("@Age", criminal.GetAge()), //
                    new SqlParameter("@Gender", criminal.GetGender()), //
                    new SqlParameter("@Status", criminal.GetStatus()), //
                    new SqlParameter("@PhotoPath", criminal.GetPhotoPath() ?? (object)DBNull.Value), //
                    new SqlParameter("@CriminalHistory", criminal.GetCriminalHistory() ?? (object)DBNull.Value) //
                };

                _dbHelper.ExecuteNonQuery("sp_RegisterCriminal", parameters); //
                return true; //
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Pipeline Error: " + ex.Message, "Repository Failure", MessageBoxButtons.OK, MessageBoxIcon.Error); //
                return false; //
            }
        }

        // =====================================================================
        // 2. ADMIN: Update a criminal's status (Arrested, Released, etc.)
        // =====================================================================
        public bool UpdateCriminalStatus(int criminalID, string newStatus)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CriminalID", criminalID),
                    new SqlParameter("@Status", newStatus)
                };

                // Execute the command directly
                _dbHelper.ExecuteNonQuery("sp_UpdateCriminalStatus", parameters);

                // 🔥 FIX: Since SET NOCOUNT ON returns -1, if no exception occurs, the transaction succeeded!
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating criminal status: " + ex.Message); //
                MessageBox.Show("REAL DB ERROR: " + ex.Message, "Database Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; //
            }
        }
        public bool LinkCriminalToCrime(int criminalID, int crimeID)
        {
            try
            {
                // 🔥 Direct raw query using your helper's explicit Text command router
                string rawInsertQuery = $"INSERT INTO CrimeCriminal (CriminalID, CrimeID) VALUES ({criminalID}, {crimeID})";

                // ExecuteQuery returns a DataTable, but running an INSERT statement here 
                // will successfully commit the row to the database disks!
                _dbHelper.ExecuteQuery(rawInsertQuery); //[cite: 2]

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to establish history bridge connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataTable GetMostWantedCriminals()
        {
            try
            {
                // SQL query filtering profiles explicitly by the high-priority tracking flag
                string query = "SELECT CriminalID, Name, CNIC, Age, Gender, Status FROM Criminals WHERE IsMostWanted = 1";

                // Using your helper's raw text command router to pull the table securely
                return _dbHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve high-priority intelligence ledger: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public bool SetMostWantedStatus(int criminalID, bool isMostWanted)
        {
            try
            {
                // Convert the boolean state to a safe SQL bit value (1 or 0)
                int bitValue = isMostWanted ? 1 : 0;
                string query = $"UPDATE Criminals SET IsMostWanted = {bitValue} WHERE CriminalID = {criminalID}";

                // Fire the query using your text query execution block
                _dbHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update high-priority threat level flag: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =====================================================================
        // 3. ADMIN + INVESTIGATOR: Search criminals by Name or CNIC
        // =====================================================================
        public List<Criminal> SearchCriminals(string searchTerm)
        {
            List<Criminal> results = new List<Criminal>();

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchTerm", searchTerm)
                };

                DataTable table = _dbHelper.ExecuteReader("sp_SearchCriminal", parameters);

                foreach (DataRow row in table.Rows)
                {
                    Criminal criminal = new Criminal(
                        Convert.ToInt32(row["CriminalID"]),
                        row["Name"].ToString(),
                        row["CNIC"].ToString(),
                        Convert.ToInt32(row["Age"]),
                        row["Gender"].ToString(),
                        row["Status"].ToString(),
                        row["PhotoPath"] == DBNull.Value ? "" : row["PhotoPath"].ToString(),
                        row["CriminalHistory"] == DBNull.Value ? "" : row["CriminalHistory"].ToString()
                    );
                    results.Add(criminal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching criminals: " + ex.Message);
            }

            return results;
        }

        // =====================================================================
        // 4. ADMIN + INVESTIGATOR: Get all crimes linked to a criminal
        // =====================================================================
        // =====================================================================
        // CORE: Retrieve historical conviction records for a profile grid
        // =====================================================================
        public DataTable GetCrimeHistory(int criminalID)
        {
            try
            {
                // 🔥 RAW EXPLICIT SQL: Directly inner-joining your junction tables
                // We use your exact schema names: CrimeID, Title, Type, DateReported, Location, Status
                string rawSqlQuery = $@"
                    SELECT 
                        c.CrimeID, 
                        c.Title, 
                        c.Type, 
                        c.DateReported, 
                        c.Location, 
                        c.Status
                    FROM Crimes c
                    INNER JOIN CrimeCriminal cc ON c.CrimeID = cc.CrimeID
                    WHERE cc.CriminalID = {criminalID}";

                // Utilizing your helper's text query block which bypasses the SP restriction
                return _dbHelper.ExecuteQuery(rawSqlQuery); //
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching crime history data stream: " + ex.Message); //
                return new DataTable(); //
            }
        }

        // =====================================================================
        // 5. ADMIN DASHBOARD: Get most wanted list from view
        // =====================================================================
        public List<Criminal> GetMostWanted()
        {
            List<Criminal> results = new List<Criminal>();

            try
            {
                DataTable table = _dbHelper.ExecuteQuery("SELECT * FROM vw_MostWanted");

                foreach (DataRow row in table.Rows)
                {
                    Criminal criminal = new Criminal(
                        Convert.ToInt32(row["CriminalID"]),
                        row["Name"].ToString(),
                        row["CNIC"].ToString(),
                        Convert.ToInt32(row["Age"]),
                        row["Gender"].ToString(),
                        row["Status"].ToString(),
                        "",
                        ""
                    );
                    results.Add(criminal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching most wanted list: " + ex.Message);
            }

            return results;
        }
    }
}
