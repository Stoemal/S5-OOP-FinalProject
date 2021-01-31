using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    /// <summary>
    /// Class des Commandes
    /// </summary>
    public class Order : ICalculus
    {
        private string orderNumber;
        private DateTime date;

        private Customer customerToServe;
        private Officer officerInCharge;
        private DeliveryDriver deliveryDriverInCharge;

        private List<Pizza> listPizza;      
        private List<Beverage> listBeverage;        

        private string state;
        private string achievement;
        private float bill;     


        public Order(string orderNumber, DateTime date,
            Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,            
            string state, string achievement)
        {
            this.orderNumber = orderNumber;
            this.date = date;

            this.customerToServe = customerToServe;
            this.officerInCharge = officerInCharge;
            this.deliveryDriverInCharge = deliveryDriverInCharge;

            this.state = state;
            this.achievement = achievement;

            this.listPizza = new List<Pizza>();
            this.listBeverage = new List<Beverage>();
            this.bill = 0;
        }

        public Order(string orderNumber, DateTime date,
            Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,
            List<Pizza> listPizza, List<Beverage> listBeverage, 
            string state, string achievement, float bill)
        {
            this.orderNumber = orderNumber;
            this.date = date;

            this.customerToServe = customerToServe;
            this.officerInCharge = officerInCharge;
            this.deliveryDriverInCharge = deliveryDriverInCharge;

            this.listPizza = listPizza;
            this.listBeverage = listBeverage;

            this.state = state;
            this.achievement = achievement;
            this.bill = bill;
        }

        #region Accesseurs
        public string OrderNumber
        {
            get { return this.orderNumber; }
        }
        public DateTime Date
        {
            get { return this.date; }
        }

        public Customer CustomerToServer
        {
            get { return this.customerToServe; }
        }
        public Officer OfficerInCharge
        {
            get { return this.officerInCharge; }
        }
        public DeliveryDriver DeliveryDriverInCharge
        {
            get { return this.deliveryDriverInCharge; }
        }

        public List<Pizza> ListPizza
        {
            get { return this.listPizza; }
            set { this.listPizza = value; }
        }
        public List<Beverage> ListBeverage
        {
            get { return this.listBeverage; }
            set { this.listBeverage = value; }
        }

        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public string Achievement
        {
            get { return this.achievement; }
            set { this.achievement = value; }
        }
        public float Bill
        {
            get { return this.bill; }
            set { this.bill = value; }
        }
        #endregion Accesseurs

        /// <summary>
        /// Implémentation de ICalculus permettant d'obtenir le montant
        /// de l'addition de la commande      
        public void Calculation()
        {
            bill = 0;
            //L'addition est la somme des prix des pizzas et des boissons
            listPizza.ForEach((Pizza n) => { bill = bill + n.Price; });
            listBeverage.ForEach((Beverage n) => { bill = bill + n.Price; });           
        }

        /// <summary>
        /// Retourne une chaîne de caractères avec toutes les informations d'une commande
        /// en retirant le nom du client
        /// </summary>
        /// <returns>chaîne de caractères avec toutes les informations d'une commande
        /// sans le nom du client</returns>
        public string PartialToString()
        {
            return "Numéro de commande : " + orderNumber + ", date : " + Convert.ToString(date) + ", localisation : " + state +
                ", état : " + achievement + ", addition : " + bill + " €" + 
                "\nCommis : " + this.officerInCharge.FirstName + " " + this.officerInCharge.LastName +
                "\nLivreur : " + this.deliveryDriverInCharge.FirstName + " " + this.deliveryDriverInCharge.LastName;
        }

        /// <summary>
        /// Retourne une chaîne de caractères avec toutes les informations d'une commande
        /// </summary>
        /// <returns>chaîne de caractères avec toutes les informations d'une commande</returns>
        public override string ToString()
        {
            return "Numéro de commande : " + orderNumber + ", date : " + Convert.ToString(date) + ", localisation : " + state + 
                ", état : " + achievement + ", addition : " + bill + " €" + 
                "\nClient : " + this.customerToServe.FirstName + " " + this.customerToServe.LastName + 
                "\nCommis : " + this.officerInCharge.FirstName + " " + this.officerInCharge.LastName + 
                "\nLivreur : " + this.deliveryDriverInCharge.FirstName + " " + this.deliveryDriverInCharge.LastName ;
        }
    }
}
