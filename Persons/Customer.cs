using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    public sealed class Customer : Person
    {
        private DateTime firstOrder;
        private List<Order> listOrder;
        private float cumulativeOrder;

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

        #region Accesseurs
        public DateTime FirstOrder
        {
            get { return this.firstOrder; }            
        }
        public List<Order> ListOrder
        {
            get { return this.listOrder; }
        }
        public float CumulativeOrder
        {
            get { return this.cumulativeOrder; }
        }
        #endregion Accesseurs

        public override string ToString()
        {

            string chain = "";
            if(firstOrder != null) chain = chain + "\n1ère commande : " + firstOrder.ToString();
            if(listOrder != null)
            {
                if(listOrder.Count() > 0)
                {
                    listOrder.ForEach(delegate (Order n)
                    {
                        chain = chain + "\n" + n;
                    });
                }              
            }
            return base.ToString() + chain;
        }
    }
}
