using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    sealed public class Officer : Employee, IDisplay
    {
        private DateTime hireDate;
        private int orderCount;

        

        public Officer(string firstName, string lastName, string address, string phoneNumber, string position, DateTime hireDate, int orderCount) : base(firstName, lastName, address, phoneNumber, position)
        {
            this.hireDate = hireDate;
            this.orderCount = orderCount;
        }

        #region Accesseurs
        public DateTime HireDate
        {
            get { return this.hireDate; }
        }
        public int OrderCount
        {
            get { return this.orderCount; }
        }
        #endregion Accesseurs
        
        public void Display()
        {
            Console.WriteLine(this.orderCount);
        }

    }
}
