using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject.Data_Access_Layer
{
    public class EvidenceRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // Commit a piece of evidence metadata to the secure archive table
        public bool SaveEvidence(int crimeID, string itemName, string evidenceType, string storageLocation, string description)
        {
            try
            {
                // Escape single quotes safely to handle any punctuation the investigator enters
                string cleanName = itemName.Replace("'", "''");
                string cleanLocation = storageLocation.Replace("'", "''");
                string cleanDesc = description.Replace("'", "''");

                string query = $@"INSERT INTO EvidenceRecords (CrimeID, ItemName, EvidenceType, StorageLocation, DateSecured, Description) 
                                 VALUES ({crimeID}, '{cleanName}', '{evidenceType}', '{cleanLocation}', GETDATE(), '{cleanDesc}')";

                _dbHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to record evidence item row: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataTable GetCaseEvidenceManifest(int crimeID)
        {
            try
            {
                // Pulling your exact columns, ordering by newest tracking additions first
                string query = $@"SELECT EvidenceID, ItemName AS [Evidence Name], EvidenceType AS [Classification], 
                                         StorageLocation AS [Vault Location], DateSecured AS [Date Secured], Description
                                  FROM EvidenceRecords 
                                  WHERE CrimeID = {crimeID} 
                                  ORDER BY EvidenceID DESC";

                return _dbHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to stream case evidence logs from nodes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}