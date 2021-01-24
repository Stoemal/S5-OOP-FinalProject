using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S5_OOP_FinalProject
{
    /// <summary>
    /// Ancienne classe Program renommée Pizzeria
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {           
            Pizzeria pizzAlpha = new Pizzeria();

            string file = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Clients.csv";
            string file1 = "C:\\Users\\Mehdi\\Documents\\Z - Activités Mehdi\\1. Ecole\\ESILV\\Année 3\\S5\\POO avancées\\Problème POO\\Commis.csv";

            pizzAlpha.AddFilesData(pizzAlpha.ReadCustomers, file);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOfficer, file1);

            foreach(Officer elt in pizzAlpha.ListOfficer)
            {
                Console.WriteLine(elt);
            }

            Console.ReadKey();
        }
    }
}
