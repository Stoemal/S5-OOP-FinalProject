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
        
        
        static void Main(string[] args)
        {
            /// Deux delegate qui permettent de donner un tarif de prix différent selon 
            /// si on est senior, etudiant, veteran ou pas 
            CorrectedPrice normal = (float bill) => { return bill; };
            CorrectedPrice student = (float bill) => { return (3 * bill) / 4; };
            #region tests Mehdi
            Pizzeria pizzAlpha = new Pizzeria();

            //string file = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Clients.csv";
            //string file1 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commis.csv";
            //string file2 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Livreur.csv";
            //string file3 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commandes.csv";
            //string file4 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\DetailsCommandes.csv";

            string file = "Clients.csv";
            string file1 = "Commis.csv";
            string file2 = "Livreur.csv";
            string file3 = "Commandes.csv";
            string file4 = "DetailsCommandes.csv";

            pizzAlpha.AddFilesData(pizzAlpha.ReadCustomers, file);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOfficer, file1);
            pizzAlpha.AddFilesData(pizzAlpha.ReadDeliveryDriver, file2);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOrder, file3);
            pizzAlpha.AddFilesData(pizzAlpha.ReadDetailsOrder, file4);

            /*
            foreach (Customer elt in pizzAlpha.ListCustomer)
            {
                Console.WriteLine(elt + "\n");
            }
            

            foreach (Officer elt in pizzAlpha.ListOfficer)
            {
                Console.WriteLine(elt + "\n");
            }
            
          
            foreach (DeliveryDriver elt in pizzAlpha.ListDeliveryDriver)
            {
                Console.WriteLine(elt + "\n");
            }
            
            foreach (Order elt in pizzAlpha.GlobalOrderList)
            {
                Console.WriteLine(elt + "\n");
                for (int i = 0; i < elt.ListPizza.Count(); i++)
                {
                    Console.WriteLine(elt.ListPizza[i]);
                }               
                for (int i = 0; i < elt.ListBeverage.Count(); i++)
                {
                    Console.WriteLine(elt.ListBeverage[i]);
                }
                Console.WriteLine();
            }
            



                        pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);
            Console.WriteLine();
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerCity);
            Console.WriteLine();
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerCumulativeOrder);

            foreach (Customer elt in pizzAlpha.ListCustomer)
            {
                Console.WriteLine(elt.PartialToStringListOrder());
                Console.WriteLine();
            }


            */



            //pizzAlpha.Display();
            //pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);
            //pizzAlpha.ManipulateEntries(pizzAlpha.CreateCustomer, file);
            //pizzAlpha.ManipulateEntries(pizzAlpha.DeleteCustomer, file);
            //pizzAlpha.ManipulateEntries(pizzAlpha.ModifyCustomer, file);
            //pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);

            //TEST MODULE CLIENT

            //pizzAlpha.CreateCustomer(file);



            //TESTS MODULE STATISTIQUES

            //pizzAlpha.OrderTime(new DateTime(2021, 1, 2), new DateTime(2021, 1, 4));
            //pizzAlpha.OrderMean();
            //pizzAlpha.CustomerAccount();


            //TESTS MODULE AUTRE
            //pizzAlpha.RandomPizza(); marche
            //pizzAlpha.BestCustomer(); marche
            //pizzAlpha.FirstNameDay(); marche
            //pizzAlpha.BackToTheFuture(); marche
            //pizzAlpha.GlobalOrderList[1].Ponderation(student);
            //Console.WriteLine(pizzAlpha.GlobalOrderList[1].Bill);




            //pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);

            //pizzAlpha.ManipulateEntries(pizzAlpha.CreateCustomer, file);
            //pizzAlpha.ManipulateEntries(pizzAlpha.DeleteCustomer, file);
            //pizzAlpha.ManipulateEntries(pizzAlpha.ModifyCustomer, file);




            Console.ReadKey();


            #endregion tests Mehdi
            #region tests Quentin
            /*
            Pizzeria pizzBeta = new Pizzeria();

            Pizza paa = new Pizza("moyenne", "calzonne", 10);
            Pizza pab = new Pizza("moyenne", "regina", 10);
            Pizza pac = new Pizza("moyenne", "royale", 10);
            Pizza pad = new Pizza("moyenne", "saumon", 10);
            List<Pizza> pla = new List<Pizza> { paa, pab };
            List<Pizza> plb = new List<Pizza> { pac, pad };

            Beverage baa = new Beverage("Coca", 33, 3);
            Beverage bab = new Beverage("Fanta", 33, 3);
            Beverage bac = new Beverage("Dr.Pepper", 33, 3);
            Beverage bad = new Beverage("Orangina", 33, 3);
            List<Beverage> bla = new List<Beverage> { baa, bab };
            List<Beverage> blb = new List<Beverage> { bac, bad };


            Customer caa = new Customer("Jean", "Pichon", "30_Bvd_Voltaire", "0630569127");
            Customer cab = new Customer("Charles", "Pecor", "30_Bvd_Voltaire", "0630569127");
            Customer cac = new Customer("Anissa", "Miel", "30_Bvd_Voltaire", "0630569127");
            Customer cad = new Customer("Perle", "DuMont", "30_Bvd_Voltaire", "0630569127");

            Officer oaa = new Officer("Thierry", "Poignon", "14_rue_des_tilleuls", "0630569127", "en congé", Convert.ToDateTime("2019-06-02"), 0);
            Officer oab = new Officer("Il", "Va", "14_rue_des_tilleuls", "0630569127", "en congé", Convert.ToDateTime("2019-06-02"), 0);

            DeliveryDriver daa = new DeliveryDriver("Mark", "Zuckerberg", "Paris", "0630569127", "pas encore la", "vélo", 0);
            DeliveryDriver dab = new DeliveryDriver("Paul", "Zuckerberg", "Paris", "0630569127", "pas encore la", "vélo", 0);

            Order ooa = new Order("000001", Convert.ToDateTime("2020-06-02"), cab, oaa, daa, pla, bla, "en preparation", "en cours", 12);
            Order oob = new Order("000002", Convert.ToDateTime("2020-06-02"), cab, oaa, daa, plb, blb, "en preparation", "en cours", 20);
            Order ooc = new Order("000003", Convert.ToDateTime("2020-06-02"), caa, oab, dab, pla, bla, "en preparation", "en cours", 20);
            Order ood = new Order(caa, oaa, daa, "encours", "encours");
            Order ooe = new Order(caa, oaa, daa, "encours", "encours");
            Order oof = new Order(caa, oaa, daa, "encours", "encours");

            pizzBeta.GlobalOrderList.Add(ooa);
            pizzBeta.GlobalOrderList.Add(oob);
            pizzBeta.GlobalOrderList.Add(ooc);

            pizzBeta.GlobalOrderList.Add(ood);
            pizzBeta.GlobalOrderList.Add(ooe);
            pizzBeta.GlobalOrderList.Add(oof);


            ood.ListPizza.Add(paa);
            ood.ListBeverage.Add(baa);


            caa.ListOrder.Add(ooa);
            caa.ListOrder.Add(oob);





            //oaa.OrderCount = 2;

            pizzBeta.ListCustomer.Add(caa);
            pizzBeta.ListCustomer.Add(cab);
            pizzBeta.ListCustomer.Add(cac);

            pizzBeta.ListCustomer.Add(cad);




            Console.WriteLine(ooa.ToString());
            Console.WriteLine(oob.ToString());
            Console.WriteLine(ooc.ToString());
            Console.WriteLine(ood.ToString());
            Console.WriteLine(ooe.ToString());
            Console.WriteLine(oof.ToString());
            Console.WriteLine(oof);

            pizzBeta.OrderMean();
            pizzBeta.CustomerAccount();
            
            //oaa.Display();
            //pizzBeta.OrderTime(Convert.ToDateTime("2020-03-03"), Convert.ToDateTime("2021-03-03"));
            //pizzBeta.RandomPizza();

            /*
            foreach (Order elt in pizzAlpha.GlobalOrderList)
            {

                if ((purchase.Date > date1) && (purchase.Date < date2))
                {
                    Console.WriteLine(purchase.ToString());
                }
            }
            */

            #endregion tests Quentin
            Console.ReadKey();
        }            
    }
}
