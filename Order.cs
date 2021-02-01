using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    /// Class des Commandes
    

    public delegate float CorrectedPrice(float bill);
    /// Delegation permettant de faire une pondération de l'addition

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

        #region ANCIEN CONSTRUCTEURS
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
        #endregion

        #region CONSTRUCTEURS
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
            this.officerInCharge.OrderCount++;
            this.deliveryDriverInCharge.OrderCount++;

            this.state = state;
            this.achievement = achievement;

            listPizza = new List<Pizza>();
            listBeverage = new List<Beverage>();

        }
        #endregion

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

        #region FONCTIONS
        public void Calculation()
        {
            /// Implémentation de ICalculus permettant d'obtenir le montant
            /// de l'addition de la commande 
            bill = 0;
            //L'addition est la somme des prix des pizzas et des boissons
            listPizza.ForEach((Pizza n) => { bill = bill + n.Price; });
            listBeverage.ForEach((Beverage n) => { bill = bill + n.Price; });

        }

        public void Ponderation(CorrectedPrice a)
        {
            ///Fonction qui calcule le prix de la commande selon plusieurs tarifs
            bill = 0;
            ///L'addition est la somme des prix des pizzas et des boissons
            listPizza.ForEach((Pizza n) => { bill = bill + n.Price; });
            listBeverage.ForEach((Beverage n) => { bill = bill + n.Price; });
            /// Ici on applique la pondération voulue pour corriger la note
            /// Les pondérations sont définies tout en haut du programm principal
            bill = a(this.bill);
        }

        public string PartialToString()
        {
            /// Retourne une chaîne de caractères avec toutes les informations d'une commande
            /// en retirant le nom du client
            return "Numéro de commande : " + orderNumber + ", date : " + Convert.ToString(date) + ", localisation : " + state +
                ", état : " + achievement + ", addition : " + bill + " e" + 
                "\nCommis : " + this.officerInCharge.FirstName + " " + this.officerInCharge.LastName +
                "\nLivreur : " + this.deliveryDriverInCharge.FirstName + " " + this.deliveryDriverInCharge.LastName;
        }
     
        public static float Note()
        {
            float prix = 0;

            return prix;
        }

        public override string ToString()
        {
            /// Retourne une chaîne de caractères avec toutes les informations d'une commande
            return "Numéro de commande : " + orderNumber + ", date : " + Convert.ToString(date) + ", localisation : " + state + 
                ", état : " + achievement + ", addition : " + bill + " e" + 
                "\nClient : " + this.customerToServe.FirstName + " " + this.customerToServe.LastName + 
                "\nCommis : " + this.officerInCharge.FirstName + " " + this.officerInCharge.LastName + 
                "\nLivreur : " + this.deliveryDriverInCharge.FirstName + " " + this.deliveryDriverInCharge.LastName + "\n";
        }

        public string FoodToString()
        {
            /// Retourne une chaîne de caracère contenant tous les produits d'une commande
            string text = null;

            if(listPizza != null)
            {
                if(listPizza.Count() > 0)
                {
                    text = "Liste pizza : \n";
                    foreach (Pizza pizz in listPizza)
                    {
                        text = text + pizz.Type + " " + pizz.Size + " " + pizz.Price + " e\n";
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
                        text = text + boisson.Type + " " + boisson.Volume + "cL " + boisson.Price + " e\n";
                    }
                }               
            }
            if (text == null) return "Vide";
            else return text;
        }
        #endregion
    }
}
