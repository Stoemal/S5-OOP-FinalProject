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
        #region Attributs
        private int orderNumber;
        private static int increment = 0;
        private DateTime date;

        private Customer customerToServe;
        private Officer officerInCharge;
        private DeliveryDriver deliveryDriverInCharge;

        private List<Pizza> listPizza;      
        private List<Beverage> listBeverage;        

        private string state;
        private string achievement;
        private float bill = 0;
        #endregion

        //Anciens constructeurs avec increment et orderNumber en string
        /*
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
            increment++;
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
            increment++;
        }

        public Order(Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,
            string state, string achievement)
        {
            this.orderNumber = Convert.ToString(increment);
            this.date = DateTime.Now;

            this.customerToServe = customerToServe;
            this.officerInCharge = officerInCharge;
            this.deliveryDriverInCharge = deliveryDriverInCharge;
            this.OfficerInCharge.OrderCount++;
            this.DeliveryDriverInCharge.OrderCount++;

            this.state = state;
            this.achievement = achievement;

            this.listPizza = new List<Pizza>();
            this.listBeverage = new List<Beverage>();


            foreach (Pizza pizz in listPizza)
            {
                this.bill = bill + pizz.Price;
            }
            foreach (Beverage drink in listBeverage)
            {
                this.bill = bill + drink.Price;
            }
            increment++;
        }
        */


        public Order(DateTime date,
        Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,
        string state, string achievement)
        {
            orderNumber = increment;
            increment++;

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

        public Order(DateTime date,
            Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,
            List<Pizza> listPizza, List<Beverage> listBeverage,
            string state, string achievement, float bill)
        {
            orderNumber = increment;
            increment++;

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

        public Order(Customer customerToServe, Officer officerInCharge, DeliveryDriver deliveryDriverInCharge,
            string state, string achievement)
        {
            orderNumber = increment;
            increment++;

            this.date = DateTime.Now;

            this.customerToServe = customerToServe;
            this.officerInCharge = officerInCharge;
            this.deliveryDriverInCharge = deliveryDriverInCharge;
            this.OfficerInCharge.OrderCount++;
            this.DeliveryDriverInCharge.OrderCount++;

            this.state = state;
            this.achievement = achievement;

            this.listPizza = new List<Pizza>();
            this.listBeverage = new List<Beverage>();


            foreach (Pizza pizz in listPizza)
            {
                this.bill = bill + pizz.Price;
            }
            foreach (Beverage drink in listBeverage)
            {
                this.bill = bill + drink.Price;
            }
        }

        #region Accesseurs
        public int OrderNumber
        {
            get { return orderNumber; }
            set
            {
                orderNumber = value;
            }
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

        
        public static float Note()
        {
            float prix = 0;

            return prix;
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
                "\nLivreur : " + this.deliveryDriverInCharge.FirstName + " " + this.deliveryDriverInCharge.LastName + "\n";
        }

        /// <summary>
        /// Retourne une chaîne de caracère contenant tout les 
        /// produits d'une commande
        /// </summary>
        /// <returns>haîne de caracère contenant tout les produits d'une commande</returns>
        public string FoodToString()
        {
            string text = null;

            if(listPizza != null)
            {
                if(listPizza.Count() > 0)
                {
                    text = "Liste pizza : \n";
                    foreach (Pizza pizz in listPizza)
                    {
                        text = text + pizz.Type + " " + pizz.Size + " " + pizz.Price + " euros\n";
                    }
                    text = text + "\n";
                }
            }            
            if(listBeverage != null)
            {
                if(listBeverage.Count() > 0)
                {
                    text = text + "Liste boissons : \n";
                    foreach (Beverage boisson in listBeverage)
                    {
                        text = text + boisson.Type + " " + boisson.Volume + "cL " + boisson.Price + " euros\n";
                    }
                }               
            }
            if (text == null) return "Vide";
            else return text;
        }
    }
}
