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
            Pizzeria pizzAlpha = new Pizzeria();

            string file = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Clients.csv";
            string file1 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commis.csv";
            string file2 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Livreur.csv";
            string file3 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commandes.csv";
            string file4 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\DetailsCommandes.csv";


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
            */
           

            foreach (Order elt in pizzAlpha.GlobalOrderList)
            {
                Console.WriteLine(elt + "\n");
            }



            Console.ReadKey();
        }
    }
}
