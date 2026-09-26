using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Core_OOP_Layer
{
    public class Investigator : Person
    {
        private int _investigatorID;
        private string _badgeNo;
        private string _rank;

        public Investigator(int id, string name, int age, string badgeNo, string rank)
            : base(name, age)
        {
            this.SetInvestigatorID(id);
            this.SetBadgeNo(badgeNo);
            this.SetRank(rank);
        }

        public int GetInvestigatorID()
        {
            return _investigatorID;
        }
        public void SetInvestigatorID(int id)
        {
            _investigatorID = id;
        }

        public string GetBadgeNo()
        {
            return _badgeNo;
        }
        public void SetBadgeNo(string badgeNo)
        {
            _badgeNo = badgeNo;
        }

        public string GetRank()
        {
            return _rank;
        }
        public void SetRank(string rank)
        {
            _rank = rank;
        }

        public override string GetDetails()
        {
            // Replaced string interpolation with standard student-style concatenation
            // Using GetName() from the base Person class
            return "Rank: " + this.GetRank() + " | Investigator: " + this.GetName() + " (Badge: #" + this.GetBadgeNo() + ")";
        }
    }
}
