using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    abstract public class Employee : Person
    {
        protected string position;
        public Employee(string firstName, string lastName, string address, string phoneNumber, string position) : base (firstName, lastName, address, phoneNumber)
        {
            this.position = position;
        }

        public string Position
        {
            get { return this.position; }
        }

    }
}
