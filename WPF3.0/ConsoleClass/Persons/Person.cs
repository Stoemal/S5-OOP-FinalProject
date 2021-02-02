using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF3._0
{
    /// <summary>
    /// Class abstract mère de Employee et de Customer
    /// Elle permet de définir une personne et est aussi la
    /// racine de l'arbre d'héritage des Class des employées et de celle des clients
    /// </summary>
    abstract public class Person
    {
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string phoneNumber;

        public Person(string firstName, string lastName, string address, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        #region Accesseurs
        public string FirstName
        {
            get { return this.firstName; }
        }
        public string LastName
        {
            get { return this.lastName; }
        }
        public string Address
        {
            get { return this.address; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
        }
        #endregion Accesseurs

        public override string ToString()
        {
            return "Nom : " + lastName + "\nPrénom : " + firstName + "\nAdresse : " + address + "\nTéléphone : " + phoneNumber;
        }
    }
}
