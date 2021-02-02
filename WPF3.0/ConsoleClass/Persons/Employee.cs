using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF3._0
{
    /// <summary>
    /// Class abstract des employés héritant de la Class Person
    /// Un emloyé se définit directement comme étant un Commis (Officer) ou un Livreur (DeliveryDriver)
    /// </summary>
    abstract public class Employee : Person
    {
        protected string position;

        public Employee(string firstName, string lastName, string address, string phoneNumber, string position) : base(firstName, lastName, address, phoneNumber)
        {
            this.position = position;
        }

        public string Position
        {
            get { return this.position; }
        }

        public override string ToString()
        {
            string chain = "\nPosition : ";
            if (position != null) chain = chain + position;
            else chain = chain + " inconnue";
            return base.ToString() + chain;
        }

    }
}
