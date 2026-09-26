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
    public class CrimeRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // =====================================================================
        // 1. ADMIN: Report a new crime, returns the auto-generated CrimeID
        // =====================================================================
        // Updated signature accepts an optional investigatorID token
        public int ReportCrime(Crime crime, int investigatorID = 0)
        {
            SqlConnection conn = _dbHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_ReportCrime", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", crime.GetTitle());
            cmd.Parameters.AddWithValue("@Type", crime.GetCrimeType().ToString());
            cmd.Parameters.AddWithValue("@Location", crime.GetLocation());
            cmd.Parameters.AddWithValue("@Description", (object)crime.GetDescription() ?? DBNull.Value);

            // 🔄 NEW: Passes the active officer's ID to the database parameters
            // If investigatorID is 0 (like when an Admin reports it), it passes DBNull instead
            cmd.Parameters.AddWithValue("@InvestigatorID", investigatorID > 0 ? (object)investigatorID : DBNull.Value);

            SqlParameter outputID = new SqlParameter("@CrimeID", SqlDbType.Int);
            outputID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputID);

            try
            {
                cmd.ExecuteNonQuery();
                return (int)outputID.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reporting crime: " + ex.Message);
                return -1;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        // =====================================================================
        // 2. ADMIN + INVESTIGATOR: Search crimes by type, location, or status
        // =====================================================================
        public DataTable SearchCrimes(string type, string location, string status)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Type", string.IsNullOrEmpty(type) ? (object)DBNull.Value : type),
                    new SqlParameter("@Location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location),
                    new SqlParameter("@Status", string.IsNullOrEmpty(status) ? (object)DBNull.Value : status)
                };

                return _dbHelper.ExecuteReader("sp_SearchCrime", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching crimes: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 3. INVESTIGATOR: Add a timestamped diary entry to a case
        // =====================================================================
        public bool AddCaseLog(CaseLog log)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CrimeID", log.GetCrimeID()),
                    new SqlParameter("@UpdateTxt", log.GetUpdateTxt())
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery("sp_AddCaseLog", parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding case log: " + ex.Message);
                return false;
            }
        }

        // =====================================================================
        // 4. INVESTIGATOR: Log a new evidence item linked to a case
        // =====================================================================
        public bool AddEvidence(Evidence evidence)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CrimeID", evidence.GetCrimeID()),
                    new SqlParameter("@Type", evidence.GetEvidenceType()),
                    new SqlParameter("@Description", evidence.GetDescription())
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery("sp_AddEvidence", parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding evidence: " + ex.Message);
                return false;
            }
        }

        // =====================================================================
        // 5. ADMIN: Officially close a case with a final summary
        // =====================================================================
        public bool CloseCase(int crimeID, string finalSummary)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CrimeID", crimeID),
                    new SqlParameter("@FinalSummary", finalSummary)
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery("sp_CloseCase", parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing case: " + ex.Message);
                return false;
            }
        }

        // =====================================================================
        // 6. INVESTIGATOR DASHBOARD: Get all active cases from view
        // =====================================================================
        public DataTable GetActiveCases()
        {
            try
            {
                return _dbHelper.ExecuteQuery("SELECT * FROM vw_ActiveCases");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching active cases: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 7. INVESTIGATOR: Get crimes with their evidence for a specific case
        // =====================================================================
        public DataTable GetCrimeWithEvidence(int crimeID)
        {
            try
            {
                return _dbHelper.ExecuteQuery(
                    "SELECT * FROM vw_CrimeWithEvidence WHERE CrimeID = " + crimeID
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching crime evidence: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 8. INVESTIGATOR: Get victim details linked to a specific case
        // =====================================================================
        public DataTable GetVictimDetails(int crimeID)
        {
            try
            {
                return _dbHelper.ExecuteQuery(
                    "SELECT * FROM vw_VictimCrimeDetail WHERE CrimeID = " + crimeID
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching victim details: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 9. INVESTIGATOR: Get all case log entries for a specific case
        // =====================================================================
        public DataTable GetCaseLogs(int crimeID)
        {
            try
            {
                return _dbHelper.ExecuteQuery(
                    "SELECT * FROM CaseLogs WHERE CrimeID = " + crimeID + " ORDER BY UpdateDate DESC"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching case logs: " + ex.Message);
                return new DataTable();
            }
        }
        public bool FormallyCloseCase(int crimeID, string finalStatus)
        {
            try
            {
                // We update the status to 'Solved' or 'Closed' and set ClosureDate to the current timestamp
                // matching your exact database schema constraints!
                string query = $@"UPDATE Crimes 
                                 SET Status = '{finalStatus}', 
                                     ClosureDate = GETDATE() 
                                 WHERE CrimeID = {crimeID}";

                DatabaseHelper dbHelper = new DatabaseHelper();
                dbHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to execute formal case closure transaction: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
