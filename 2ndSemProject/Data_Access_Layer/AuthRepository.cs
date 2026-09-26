using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Data_Access_Layer
{
    public class AuthRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // =====================================================================
        // Login: Validates credentials and returns user details
        // Returns null if credentials are wrong
        // =====================================================================
        public DataRow Login(string username, string password)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@PasswordHash", password)
                };

                DataTable table = _dbHelper.ExecuteReader("sp_Login", parameters);

                if (table.Rows.Count > 0)
                {
                    DataRow userRow = table.Rows[0];

                    // 🔥 NEW CHECK: Verify if the administrator has revoked this account's rights
                    if (userRow.Table.Columns.Contains("IsActive") && Convert.ToBoolean(userRow["IsActive"]) == false)
                    {
                        Console.WriteLine("Login Blocked: Credentials suspended for user: " + username);
                        return null; // Treats suspended profiles as an invalid auth attempt!
                    }

                    Console.WriteLine("Login successful for user: " + username);
                    return userRow;
                }
                else
                {
                    Console.WriteLine("Login failed: Invalid credentials for user: " + username);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return null;
            }
        }
        // =====================================================================
        // SECURITY OVERRIDE: Deactivates user login credentials by Username
        // Marks IsActive as 0 to instantly block app access without deleting records
        // =====================================================================
        public bool DeactivateUserCredentials(string username)
        {
            try
            {
                // Using parameterized strings to prevent SQL Injection vulnerabilities
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username)
                };

                // Inline SQL Update command executed safely via your DatabaseHelper engine
                int rowsAffected = _dbHelper.ExecuteNonQuery(
                    "UPDATE Users SET IsActive = 0 WHERE Username = @Username",
                    parameters
                );

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Security Action: Successfully revoked credentials for user: " + username);
                    return true;
                }

                Console.WriteLine("Deactivation Failed: Username not found: " + username);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error during credential revocation: " + ex.Message);
                return false;
            }
        }
        public bool ProvisionInvestigatorAccount(string username, string password, string realName, int age, string badgeNo, string rank)
        {
            SqlConnection conn = _dbHelper.GetConnection();

            if (conn.State != ConnectionState.Open) conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1. Insert credentials cleanly into the parent Users table - FIXED: Changed 'Password' to 'PasswordHash'
                string userQuery = @"INSERT INTO Users (Username, PasswordHash, Role, IsActive) 
                                    VALUES (@User, @Pass, 'Investigator', 1);
                                    SELECT SCOPE_IDENTITY();";

                int generatedUserID = -1;
                using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                {
                    userCmd.Parameters.AddWithValue("@User", username);
                    userCmd.Parameters.AddWithValue("@Pass", password);

                    object result = userCmd.ExecuteScalar();
                    if (result != null)
                    {
                        generatedUserID = Convert.ToInt32(result);
                    }
                }

                if (generatedUserID == -1)
                {
                    transaction.Rollback();
                    return false;
                }

                // 2. Insert straight into Investigators table with true validated parameters
                string investigatorQuery = @"INSERT INTO Investigators (Name, Age, BadgeNo, Rank, UserID) 
                                             VALUES (@Name, @Age, @Badge, @Rank, @UID);";

                using (SqlCommand invCmd = new SqlCommand(investigatorQuery, conn, transaction))
                {
                    invCmd.Parameters.AddWithValue("@Name", realName);
                    invCmd.Parameters.AddWithValue("@Age", age);
                    invCmd.Parameters.AddWithValue("@Badge", badgeNo);
                    invCmd.Parameters.AddWithValue("@Rank", rank);
                    invCmd.Parameters.AddWithValue("@UID", generatedUserID);

                    invCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                System.Windows.Forms.MessageBox.Show("Database Provisioning Exception: " + ex.Message, "SQL Insertion Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
