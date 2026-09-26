using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _2ndSemProject.Data_Access_Layer
{
    public class ProgressRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // Save a brand new handwritten diary entry directly to a case file
        public bool SaveDiaryEntry(int crimeID, string entryText, string shortNotes)
        {
            try
            {
                // We format the text properly and push it right via your raw query executor
                // Escaping single quotes to make sure it handles any punctuation the detective types!
                string cleanText = entryText.Replace("'", "''");
                string cleanNotes = shortNotes.Replace("'", "''");

                string query = $@"INSERT INTO CaseDiaryLogs (CrimeID, LogDate, EntryText, InvestigatorNotes) 
                                 VALUES ({crimeID}, GETDATE(), '{cleanText}', '{cleanNotes}')";

                _dbHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to record diary entry row: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataTable GetCaseDiaryHistory(int crimeID)
        {
            try
            {
                // Select columns cleanly matching your database schema fields
                string query = $@"SELECT LogID, LogDate, EntryText AS [Detailed Log Entry], InvestigatorNotes AS [Activity Tag] 
                                 FROM CaseDiaryLogs 
                                 WHERE CrimeID = {crimeID} 
                                 ORDER BY LogDate DESC"; // Newest entries right at the top!

                return _dbHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve case timeline logs: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

    }
}