using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2ndSemProject.Core_OOP_Layer
{

    public class Criminal : Person, ISearchable
    {
       private int _criminalID;
        private string _cnic;
        private string _gender;
        private string _status;
        private string _photoPath;
        private string _criminalHistory;

       public Criminal(int id, string name, string cnic, int age, string gender, string status, string photoPath, string history)
            : base(name, age)
        {
            this.SetCriminalID(id);
            this.SetCNIC(cnic);
            this.SetGender(gender);
            this.SetStatus(status);
            this.SetPhotoPath(photoPath);
            this.SetCriminalHistory(history);
        }

        public int GetCriminalID()
        {
            return _criminalID;
        }
        public void SetCriminalID(int id)
        {
            _criminalID = id;
        }

        public string GetCNIC()
        {
            return _cnic;
        }
        public void SetCNIC(string cnic)
        {
            _cnic = cnic;
        }

        public string GetGender()
        {
            return _gender;
        }
        public void SetGender(string gender)
        {
            _gender = gender;
        }

        public string GetStatus()
        {
            return _status;
        }
        public void SetStatus(string status)
        {
            _status = status;
        }

        public string GetPhotoPath()
        {
            return _photoPath;
        }
        public void SetPhotoPath(string photoPath)
        {
            _photoPath = photoPath;
        }

        public string GetCriminalHistory()
        {
            return _criminalHistory;
        }
        public void SetCriminalHistory(string history)
        {
            _criminalHistory = history;
        }

        public override string GetDetails()
        {
            // Replaced string interpolation with basic student-style concatenation
            return base.GetDetails() + ", CNIC: " + this.GetCNIC() + ", Status: " + this.GetStatus();
        }

        // REQUIRED INTERFACE METHOD - Fulfills the ISearchable contract
        public bool MatchesSearchTerm(string searchTerm)
        {
            // Using basic string validation instead of string.IsNullOrWhiteSpace
            if (searchTerm == "" || searchTerm == null)
            {
                return false;
            }

            // Classic student approach for case-insensitive matching
            string lowerSearch = searchTerm.ToLower();
            string lowerName = this.GetName().ToLower();
            string lowerCnic = this.GetCNIC().ToLower();

            if (lowerName.Contains(lowerSearch) || lowerCnic == lowerSearch)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

