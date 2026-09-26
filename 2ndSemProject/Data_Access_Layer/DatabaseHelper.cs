using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Data_Access_Layer
{
    public class DatabaseHelper
    {
        // Connection string pointing to your local SQL Server instance and database
        private readonly string _connectionString = "Server=.;Database=CRIME_TRACKER_DB;Trusted_Connection=True;";

        // Generates an active SQL Connection for reading database streams
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    // Custom user print to track live connection states
                    Console.WriteLine("Hello! Connection is successfully made to the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to database: " + ex.Message);
            }

            return connection;
        }

        // Executes commands like Insert, Update, Delete via Stored Procedures
        public DataTable GetAdminDashboardMetrics()
        {
            DataTable dt = new DataTable();
            // ✅ CHANGED: Pointed explicitly to the true 'Crimes' table structure name!
            string query = @"
        SELECT 
            (SELECT COUNT(*) FROM Investigators) AS TotalInvestigators,
            (SELECT COUNT(*) FROM Criminals) AS TotalCriminals,
            (SELECT COUNT(*) FROM Crimes WHERE Status = 'Open' OR Status = 'Active') AS OpenCases,
            (SELECT COUNT(*) FROM RevokedInvestigators) AS RevokedTokens";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CRIME_TRACKER_DB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch { /* Safeguard fallback routing */ }
            return dt;
        }
        public DataTable GetInvestigatorDashboardMetrics(int investigatorID)
        {
            DataTable dt = new DataTable();

            // Now using your true database columns (CrimeID, Status) along with the new InvestigatorID link!
            string query = @"
        SELECT 
            (SELECT COUNT(*) FROM Crimes WHERE InvestigatorID = @InvID AND (Status = 'Open' OR Status = 'Active')) AS MyActiveCases,
            (SELECT COUNT(*) FROM Crimes WHERE InvestigatorID IS NULL) AS UnassignedCases,
            (SELECT COUNT(*) FROM Crimes WHERE InvestigatorID = @InvID AND Status = 'Closed') AS MyClosedCases";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CRIME_TRACKER_DB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InvID", investigatorID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch { /* Safeguard fallback routing */ }
            return dt;
        }
        public DataTable GetGlobalHubMetrics()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            (SELECT COUNT(*) FROM Investigators) AS TotalStaff,
            (SELECT COUNT(*) FROM Criminals) AS TotalCriminals,
            (SELECT COUNT(*) FROM Crimes) AS TotalCrimes";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CRIME_TRACKER_DB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch { /* Safeguard fallback */ }
            return dt;
        }
        public int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                conn.Open();
                // Printing confirmation when manually calling this execution path
                Console.WriteLine("Hello! Connection is successfully made to the database for NonQuery.");

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error during NonQuery execution: " + ex.Message);
                return 0;
            }
            finally
            {
                // Explicitly disposing and closing database objects to safeguard system memory
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        // Reads multiple rows from the database into a standard DataTable structure
        public DataTable ExecuteReader(string procedureName, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                // Printing confirmation when data adapter runs
                Console.WriteLine("Hello! Connection is successfully made to the database for Reader.");

                adapter.Fill(dataTable);
                adapter.Dispose(); // Cleans up the adapter engine
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error during Reader execution: " + ex.Message);
                return dataTable;
            }
            finally
            {
                // Clean teardown sequence
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataTable ExecuteQuery(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = CommandType.Text; // Plain SQL, not a stored procedure

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Console.WriteLine("Hello! Connection successfully made for View Query.");
                adapter.Fill(dataTable);
                adapter.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error during View Query: " + ex.Message);
                return dataTable;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
