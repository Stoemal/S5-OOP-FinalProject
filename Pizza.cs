using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    public class Pizza
    {
        private string size;
        private string type;
        private float price;

        public Pizza(string size, string type, float price)
        {
            this.size = size;
            this.type = type;
            this.price = price;
        }

        public string Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public override string ToString()
        {
            return "Taille : " + size + "\nType : " + type + "\nPrix : " + price;
        }
    }
}
