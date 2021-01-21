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
        public Customer(string firstName, string lastName, string address, string phoneNumber, DateTime firstOrder, List<Order> listOrder, float cumulativeOrder) : base(firstName, lastName, address, phoneNumber)
        {
            this.firstOrder = firstOrder;
            this.listOrder = listOrder;
            this.cumulativeOrder = cumulativeOrder;
        }
    }
}
