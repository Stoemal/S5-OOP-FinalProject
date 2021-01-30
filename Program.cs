using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S5_OOP_FinalProject
{
    class Program
    {
        List<Order> globalOrderList = new List<Order> { };// liste regroupant la totalité des commandes
        
        
        
        public void OrderTime(DateTime date1, DateTime date2)
        { // Pour afficher les commandes sur une certaine période
            foreach(Order purchase in globalOrderList)
            {
                if((purchase.Date > date1 ) && (purchase.Date < date2))
                {
                    Console.WriteLine(purchase.ToString());
                }
            }
        }
        public void OrderMean()
        {
            float sum = 0;
            foreach(Order purchase in globalOrderList)
            {
                sum = sum + purchase.Bill;
            }
            Console.WriteLine(sum/globalOrderList.Count());
        }




        static void Main(string[] args)
        {      
            #region TEST MEHDI
            /*
            Pizzeria pizzAlpha = new Pizzeria();

            string file = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Clients.csv";
            string file1 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commis.csv";

            pizzAlpha.AddFilesData(pizzAlpha.ReadCustomers, file);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOfficer, file1);

            foreach(Officer elt in pizzAlpha.ListOfficer)
            {
                Console.WriteLine(elt);
            }
            */
            #endregion

            Pizzeria pizzBeta = new Pizzeria();

            Pizza paa = new Pizza("moyenne","calzonne",10);
            Pizza pab = new Pizza("moyenne","regina",10);
            Pizza pac = new Pizza("moyenne","royale",10);
            Pizza pad = new Pizza("moyenne","saumon",10);
            List<Pizza> pla = new List<Pizza>{paa,pab};
            List<Pizza> plb = new List<Pizza>{pac,pad};

            Beverage baa = new Beverage("Coca",33,3);
            Beverage bab = new Beverage("Fanta",33,3);
            Beverage bac = new Beverage("Dr.Pepper",33,3);
            Beverage bad = new Beverage("Orangina",33,3);
            List<Beverage> bla = new List<Beverage>{baa,bab};
            List<Beverage> blb = new List<Beverage>{bac,bad};


            Customer caa = new Customer("Jean","Pichon","30_Bvd_Voltaire","0630569127");
            Customer cab = new Customer("Charles","Pecor","30_Bvd_Voltaire","0630569127");
            Customer cac = new Customer("Anissa","Miel","30_Bvd_Voltaire","0630569127");
            Customer cad = new Customer("Perle","DuMont","30_Bvd_Voltaire","0630569127");

            Officer oaa = new Officer("Thierry", "Poignon","14_rue_des_tilleuls","0630569127","en congé",Convert.ToDateTime("2019-06-02"),0);
            Officer oab = new Officer("Il", "Va","14_rue_des_tilleuls","0630569127","en congé",Convert.ToDateTime("2019-06-02"),0);

            DeliveryDriver daa = new DeliveryDriver("Mark","Zuckerberg","Paris","0630569127","pas encore la","vélo",0);
            DeliveryDriver dab = new DeliveryDriver("Paul","Zuckerberg","Paris","0630569127","pas encore la","vélo",0);

            Order ooa  = new Order("000001",Convert.ToDateTime("2020-06-02"),cab,oaa,daa,pla,bla,"en preparation","en cours",12);
            Order oob  = new Order("000002",Convert.ToDateTime("2020-06-02"),cab,oaa,daa,plb,blb,"en preparation","en cours",12);
            Order ooc  = new Order("000003",Convert.ToDateTime("2020-06-02"),caa,oab,dab,pla,bla,"en preparation","en cours",12);

            Console.WriteLine(ooa.ToString());
            Console.WriteLine(oob.ToString());
            Console.WriteLine(ooc.ToString());





            Console.ReadKey();
        }
    }
}
