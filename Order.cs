using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    public class Order
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
        }
        public string Achievement
        {
            get { return this.achievement; }
        }
        public float Bill
        {
            get { return this.bill; }
            set { this.bill = value; }
        }
        #endregion Accesseurs

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
