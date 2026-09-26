using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Data_Access_Layer
{
    public class InvestigatorRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // =====================================================================
        // 1. ADMIN: Register a new investigator profile
        // =====================================================================
        public bool RegisterInvestigator(Investigator investigator)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", investigator.GetName()),
                    new SqlParameter("@Age", investigator.GetAge()),
                    new SqlParameter("@BadgeNo", investigator.GetBadgeNo()),
                    new SqlParameter("@Rank", investigator.GetRank())
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery("sp_RegisterInvestigator", parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registering investigator: " + ex.Message);
                return false;
            }
        }

        // =====================================================================
        // 2. ADMIN: Assign an investigator to a crime file
        // =====================================================================
        public bool AssignToCase(int crimeID, int investigatorID)
        {
            try
            {
                // We use parameterized strings to prevent injection and bypass sp_AssignInvestigator completely!
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CrimeID", crimeID),
                    new SqlParameter("@InvestigatorID", investigatorID)
                };

                // Inline direct insert statement matching your true junction table structure
                string directInsertQuery = @"INSERT INTO CrimeInvestigator (CrimeID, InvestigatorID) 
                                             VALUES (@CrimeID, @InvestigatorID)";

                int rowsAffected = _dbHelper.ExecuteNonQuery(directInsertQuery, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // If your table has an explicit column requirement like 'DateAssigned', this fallback catches it!
                try
                {
                    SqlParameter[] parametersFallback = new SqlParameter[]
                    {
                        new SqlParameter("@CrimeID", crimeID),
                        new SqlParameter("@InvestigatorID", investigatorID)
                    };

                    string fallbackQuery = @"INSERT INTO CrimeInvestigator (CrimeID, InvestigatorID, DateAssigned) 
                                             VALUES (@CrimeID, @InvestigatorID, GETDATE())";

                    int rowsAffected = _dbHelper.ExecuteNonQuery(fallbackQuery, parametersFallback);
                    return rowsAffected > 0;
                }
                catch (Exception fallbackEx)
                {
                    Console.WriteLine("Error assigning investigator to case: " + fallbackEx.Message);
                    return false;
                }
            }
        }

        // =====================================================================
        // 3. ADMIN + INVESTIGATOR: Get all investigators
        // Used to populate dropdowns and lists in the UI
        // =====================================================================
        public List<Investigator> GetAllInvestigators()
        {
            List<Investigator> results = new List<Investigator>();

            try
            {
                DataTable table = _dbHelper.ExecuteQuery("SELECT * FROM Investigators");

                foreach (DataRow row in table.Rows)
                {
                    Investigator investigator = new Investigator(
                        Convert.ToInt32(row["InvestigatorID"]),
                        row["Name"].ToString(),
                        Convert.ToInt32(row["Age"]),
                        row["BadgeNo"].ToString(),
                        row["Rank"].ToString()
                    );
                    results.Add(investigator);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching investigators: " + ex.Message);
            }

            return results;
        }

        // =====================================================================
        // 4. ADMIN DASHBOARD: Get workload report from view
        // Shows how many active cases each investigator has
        // =====================================================================
        public DataTable GetWorkloadReport()
        {
            try
            {
                return _dbHelper.ExecuteQuery("SELECT * FROM vw_InvestigatorWorkload");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching workload report: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 5. INVESTIGATOR: Get all cases assigned to a specific investigator
        // Used to populate the investigator's personal workspace
        // =====================================================================
        public DataTable GetAssignedCases(int investigatorID)
        {
            try
            {
                return _dbHelper.ExecuteQuery(
                    "SELECT c.CrimeID, c.Title, c.Type, c.DateReported, c.Location, c.Status " +
                    "FROM vw_ActiveCases c " +
                    "INNER JOIN CrimeInvestigator ci ON c.CrimeID = ci.CrimeID " +
                    "WHERE ci.InvestigatorID = " + investigatorID
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching assigned cases: " + ex.Message);
                return new DataTable();
            }
        }

        // =====================================================================
        // 6. ADMIN: Get a single investigator by their ID
        // Used when loading a profile for editing or viewing
        // =====================================================================
        public Investigator GetInvestigatorByID(int investigatorID)
        {
            try
            {
                DataTable table = _dbHelper.ExecuteQuery(
                    "SELECT * FROM Investigators WHERE InvestigatorID = " + investigatorID
                );

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    return new Investigator(
                        Convert.ToInt32(row["InvestigatorID"]),
                        row["Name"].ToString(),
                        Convert.ToInt32(row["Age"]),
                        row["BadgeNo"].ToString(),
                        row["Rank"].ToString()
                    );
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching investigator by ID: " + ex.Message);
                return null;
            }
        }
        // =====================================================================
        // SYSTEM BRIDGE: Swaps a login UserID for the matching personnel InvestigatorID
        // Returns -1 if no investigator record is linked to that user account
        // =====================================================================
        public int GetInvestigatorIDByUserID(int userID)
        {
            try
            {
                DataTable table = _dbHelper.ExecuteQuery(
                    "SELECT InvestigatorID FROM Investigators WHERE UserID = " + userID
                );

                if (table.Rows.Count > 0)
                {
                    return Convert.ToInt32(table.Rows[0]["InvestigatorID"]);
                }

                Console.WriteLine("System Warning: No Investigator profile linked to UserID: " + userID);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error translating UserID to InvestigatorID: " + ex.Message);
                return -1;
            }
        }
    }
}
