using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF3._0
{
    /// Class du Client héritant de la Class Person 
    /// C'est une feuille terminale de l'arbre d'héritage
    public sealed class Customer : Person, ICalculus
    {
        private DateTime firstOrder;
        private List<Order> listOrder;
        private float cumulativeOrder;
     

        #region CONSTRUCTEURS
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
        #endregion

        #region Accesseurs
        public DateTime FirstOrder
        {
            get { return this.firstOrder; }
            set { this.firstOrder = value; OnPropertyChanged("FirstOrder"); }
        }
        public List<Order> ListOrder
        {
            get { return this.listOrder; }
        }
        public float CumulativeOrder
        {
            get { return this.cumulativeOrder; }
            set { this.cumulativeOrder = value; OnPropertyChanged("CumulativeOrder"); }
        }
        #endregion Accesseurs

   


        #region FONCTIONS
        public void Calculation()
        {
            /// Implémentation de ICalculus permettant d'obtenir le prix 
            /// cumulé de toutes les commandes d'un client
            cumulativeOrder = 0;
           
            listOrder.ForEach((Order n) => { cumulativeOrder = cumulativeOrder + n.Bill; });
        }

        public string PartialToStringCumulativeOrder()
        {
            /// Retourne la chaîne de caractère de base de la 
            /// classe Person en y ajoutant le montant cumulé
            return base.ToString() + "\nMontant cumulé : " + cumulativeOrder;
        }

        public string PartialToStringListOrder()
        {
            string chain = "Liste de commande :";
            if (listOrder == null || listOrder.Count() == 0)
            {
                chain = chain + " Vide";
            }
            else
            {
                chain = chain + "\n";
                if (listOrder.Count() > 0)
                {
                    listOrder.ForEach(delegate (Order n)
                    {
                        if (n.Achievement.ToUpper() == "PERDUE") chain = chain + "Commande perdue";
                        else chain = chain + "\n" + n.PartialToString() + "\n\n" + n.FoodToString();
                    });
                }
            }
            return base.ToString() + "\n\n" + chain;
        }

        public override string ToString()
        {
            /// Retourne une chaîne de caractère avec toutes les informations du client
            string chain = "";
            if (firstOrder != new DateTime()) chain = chain + "\n1ère commande : " + firstOrder.ToString();
            return base.ToString() + chain;
        }

        public bool PassedAnOrder()
        {
            ///Fonction qui vérifie si un client à passé commande aujourd'hui
            ///On parcourt toutes les commandes
            ///Si la date de l'une d'entre elle correspond à la date d'ujourd'hui on revoie true sinon false
            foreach (Order commande in listOrder)
            {
                /// Bien faire attention au ToShortDateString qui transforme la date en string
                /// Mais sans compter les heure, minutes et secondes.
                /// Sinon la comparaison se fait entre 2 instants et non 2 dates
                if (commande.Date.ToShortDateString() == DateTime.Today.ToShortDateString())
                {
                    return true;
                }
            }
            return false;
        }

        public float CustomerAccount()
        {
            float sum = 0;

            foreach (Order commande in listOrder)
            {
                sum = sum + commande.Bill;
            }

            return sum / listOrder.Count();
            sum = 0;

        }

        #endregion
    }
}