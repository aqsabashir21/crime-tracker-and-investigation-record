using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Core_OOP_Layer
{
    public class Victim : Person
    {
        private int _victimID;
        private string _contact;
        private int _crimeID;

        public Victim(int id, string name, int age, string contact, int crimeId)
            : base(name, age)
        {
            this.SetVictimID(id);
            this.SetContact(contact);
            this.SetCrimeID(crimeId);
        }

        public int GetVictimID()
        {
            return _victimID;
        }
        public void SetVictimID(int id)
        {
            _victimID = id;
        }

        public string GetContact()
        {
            return _contact;
        }
        public void SetContact(string contact)
        {
            _contact = contact;
        }

        public int GetCrimeID()
        {
            return _crimeID;
        }
        public void SetCrimeID(int crimeId)
        {
            _crimeID = crimeId;
        }

        public override string GetDetails()
        {
            // Replaced string interpolation with standard student-style concatenation
            // Using GetName() from the base Person class
            return "Victim: " + this.GetName() + ", Contact: " + this.GetContact();
        }
    }
}
