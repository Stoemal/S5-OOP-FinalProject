using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF3._0
{
    /// <summary>
    /// Class abstract mère de Employee et de Customer
    /// Elle permet de définir une personne et est aussi la
    /// racine de l'arbre d'héritage des Class des employées et de celle des clients
    /// </summary>
    abstract public class Person : INotifyPropertyChanged
    {
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string phoneNumber;

        public event PropertyChangedEventHandler PropertyChanged;

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
            set { this.firstName = value; OnPropertyChanged("FirstName"); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName= value; OnPropertyChanged("LastName"); }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; OnPropertyChanged("Address"); }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; OnPropertyChanged("PhoneNumber"); }

        }
        #endregion Accesseurs

        public override string ToString()
        {
            return "Nom : " + lastName + "\nPrénom : " + firstName + "\nAdresse : " + address + "\nTéléphone : " + phoneNumber;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
