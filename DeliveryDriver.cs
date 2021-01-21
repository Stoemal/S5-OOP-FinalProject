using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    sealed class DeliveryDriver : Employee
    {
        private string meanOfTransport;
        private int orderCount;
        public DeliveryDriver(string firstName, string lastName, string address, string phoneNumber, string position, string meanOfTransport, int orderCount) : base (firstName, lastName, address, phoneNumber, position)
        {
            this.meanOfTransport = meanOfTransport;
            this.orderCount = orderCount;
        }


    }
}
