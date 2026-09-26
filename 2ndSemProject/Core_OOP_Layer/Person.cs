using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndSemProject.Core_OOP_Layer
{
    public abstract class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public virtual string GetDetails()
        {
            return "Name: " + _name + ", Age: " + _age;
        }
    }
}
