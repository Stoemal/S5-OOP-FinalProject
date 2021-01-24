using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




        }
    }
}
