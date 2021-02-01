using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    /// <summary>
    /// Class du Commis héritant de la Class Employee et implémentant IDisplay
    /// C'est une feuille terminale de l'arbre d'héritage
    /// </summary>
    sealed public class Officer : Employee, IDisplay
    {
        private DateTime hireDate;
        private int orderCount;       

        public Officer(string firstName, string lastName, string address, string phoneNumber, string position, DateTime hireDate, int orderCount) : base(firstName, lastName, address, phoneNumber, position)
        {
            this.hireDate = hireDate;
            this.orderCount = orderCount;
        }

        #region Accesseurs
        public DateTime HireDate
        {
            get { return this.hireDate; }
        }
        public int OrderCount
        {
            get { return this.orderCount; }
            set { this.orderCount = value; }
        }
        #endregion Accesseurs

        #region FONCTIONS
        public override string ToString()
        {
            string chain = null;
            if (hireDate != null) chain = "\nDate d'embauche : " + hireDate.ToShortDateString();
            chain = chain + "\nNombre de commande(s) : " + orderCount;
            return base.ToString() + chain;
        }

        public void Display()
        {
            Console.WriteLine("Nombre de commandes prises en charge : " + this.orderCount);
        }
        #endregion
    }
}
