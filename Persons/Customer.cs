using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    /// <summary>
    /// Class du Client héritant de la Class Person 
    /// C'est une feuille terminale de l'arbre d'héritage
    /// </summary>
    public sealed class Customer : Person, ICalculus
    {
        private DateTime firstOrder;
        private List<Order> listOrder;
        private float cumulativeOrder;

        public Customer(string firstName, string lastName, string address, string phoneNumber) : base(firstName, lastName, address, phoneNumber)
        {
            firstOrder = new DateTime();
            listOrder = new List<Order>();
            cumulativeOrder = 0;
        }

        public Customer(string firstName, string lastName, string address, string phoneNumber, DateTime firstOrder, List<Order> listOrder, float cumulativeOrder) : base(firstName, lastName, address, phoneNumber)
        {
            this.firstOrder = firstOrder;
            this.listOrder = listOrder;
            this.cumulativeOrder = cumulativeOrder;
        }

        #region Accesseurs
        public DateTime FirstOrder
        {
            get { return this.firstOrder; }    
            set { this.firstOrder = value; }
        }
        public List<Order> ListOrder
        {
            get { return this.listOrder; }
        }
        public float CumulativeOrder
        {
            get { return this.cumulativeOrder; }
            set { this.cumulativeOrder = value; }
        }
        #endregion Accesseurs

        /// <summary>
        /// Implémentation de ICalculus permettant d'obtenir le prix 
        /// cumulé de toutes les commandes d'un client
        public void Calculation()
        {
            cumulativeOrder = 0;
            listOrder.ForEach((Order n) => { cumulativeOrder = cumulativeOrder + n.Bill; });
        }

        /// <summary>
        /// Retourne la chaîne de caractère de base de la 
        /// classe Person en y ajoutant le montant cumulé
        /// </summary>
        /// <returns>chaîne de caractère de base de la classe Person et montant cumulé</returns>
        public string PartialToStringCumulativeOrder()
        {
            return base.ToString() + "\nMontant cumulé : " + cumulativeOrder;
        }

        public string PartialToStringListOrder()
        {
            string chain = "Liste de commande du client : ";
            if (listOrder != null)
            {
                if (listOrder.Count() > 0)
                {
                    listOrder.ForEach(delegate (Order n)
                    {
                        chain = chain + "\n" + n.PartialToString();
                    });
                }
            }
            return base.ToString() + chain;
        }

        /// <summary>
        /// Retourne une chaîne de caractère avec toutes les informations 
        /// du client
        /// </summary>
        /// <returns>chaîne de caractère avec toutes les informations du client</returns>
        public override string ToString()
        {
            string chain = "";
            if(firstOrder != new DateTime()) chain = chain + "\n1ère commande : " + firstOrder.ToString();              
            return base.ToString() + chain;
        }
        public bool PassedAnOrder()
        {
            foreach(Order commande in listOrder)
            {  
                if (commande.Date == DateTime.Today)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
