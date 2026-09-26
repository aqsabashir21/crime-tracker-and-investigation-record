using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Core_OOP_Layer
{
    public class CaseLog
    {
        private int _logID;
        private string _updateTxt;
        private DateTime _updateDate;
        private int _crimeID;

        public int GetLogID()
        {
            return _logID;
        }
        public void SetLogID(int id)
        {
            _logID = id;
        }

        public string GetUpdateTxt()
        {
            return _updateTxt;
        }
        public void SetUpdateTxt(string updateTxt)
        {
            _updateTxt = updateTxt;
        }

        public DateTime GetUpdateDate()
        {
            return _updateDate;
        }
        public void SetUpdateDate(DateTime updateDate)
        {
            _updateDate = updateDate;
        }

        public int GetCrimeID()
        {
            return _crimeID;
        }
        public void SetCrimeID(int crimeId)
        {
            _crimeID = crimeId;
        }
    }

    public class Evidence
    {
        private int _evidenceID;
        private string _type;
        private string _description;
        private DateTime _collectedDate;
        private int _crimeID;

        public int GetEvidenceID()
        {
            return _evidenceID;
        }
        public void SetEvidenceID(int id)
        {
            _evidenceID = id;
        }

        public string GetEvidenceType()
        {
            return _type;
        }
        public void SetEvidenceType(string type)
        {
            _type = type;
        }

        public string GetDescription()
        {
            return _description;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }

        public DateTime GetCollectedDate()
        {
            return _collectedDate;
        }
        public void SetCollectedDate(DateTime collectedDate)
        {
            _collectedDate = collectedDate;
        }

        public int GetCrimeID()
        {
            return _crimeID;
        }
        public void SetCrimeID(int crimeId)
        {
            _crimeID = crimeId;
        }
    }

    public class Crime : ISearchable
    {
        // Private fields
        private int _crimeID;
        private string _title;
        private CrimeType _type;
        private DateTime _dateReported;
        private string _location;
        private CaseStatus _status;
        private DateTime? _closureDate;
        private string _description; // 🔥 NEW: Backing field for case details

        private List<Evidence> _evidenceLocker;
        private List<CaseLog> _caseDiary;
        private List<Victim> _associatedVictims;

        public Crime()
        {
            _evidenceLocker = new List<Evidence>();
            _caseDiary = new List<CaseLog>();
            _associatedVictims = new List<Victim>();
        }

        public int GetCrimeID()
        {
            return _crimeID;
        }
        public void SetCrimeID(int id)
        {
            _crimeID = id;
        }

        public string GetTitle()
        {
            return _title;
        }
        public void SetTitle(string title)
        {
            _title = title;
        }

        public CrimeType GetCrimeType()
        {
            return _type;
        }
        public void SetCrimeType(CrimeType type)
        {
            _type = type;
        }

        public DateTime GetDateReported()
        {
            return _dateReported;
        }
        public void SetDateReported(DateTime dateReported)
        {
            _dateReported = dateReported;
        }

        public string GetLocation()
        {
            return _location;
        }
        public void SetLocation(string location)
        {
            _location = location;
        }

        public CaseStatus GetStatus()
        {
            return _status;
        }
        public void SetStatus(CaseStatus status)
        {
            _status = status;
        }

        public DateTime? GetClosureDate()
        {
            return _closureDate;
        }
        public void SetClosureDate(DateTime? closureDate)
        {
            _closureDate = closureDate;
        }

        // Getters and Setters for the Lists (Composition)
        public List<Evidence> GetEvidenceLocker()
        {
            return _evidenceLocker;
        }
        public void SetEvidenceLocker(List<Evidence> locker)
        {
            _evidenceLocker = locker;
        }

        public List<CaseLog> GetCaseDiary()
        {
            return _caseDiary;
        }
        public void SetCaseDiary(List<CaseLog> diary)
        {
            _caseDiary = diary;
        }

        public List<Victim> GetAssociatedVictims()
        {
            return _associatedVictims;
        }
        public void SetAssociatedVictims(List<Victim> victims)
        {
            _associatedVictims = victims;
        }
        public void SetDescription(string description)
        {
            this._description = description;
        }

        // 🔥 NEW: Getter Method so your repository layer can read it later
        public string GetDescription()
        {
            return this._description;
        }
        public bool MatchesSearchTerm(string searchTerm)
        {
            if (searchTerm == "" || searchTerm == null)
            {
                return false;
            }

            string lowerSearch = searchTerm.ToLower();
            string lowerTitle = this.GetTitle().ToLower();
            string lowerType = this.GetCrimeType().ToString().ToLower();
            string lowerLocation = this.GetLocation().ToLower();
            string lowerStatus = this.GetStatus().ToString().ToLower();


            if (lowerTitle.Contains(lowerSearch) || lowerType.Contains(lowerSearch) || lowerLocation.Contains(lowerSearch))
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
