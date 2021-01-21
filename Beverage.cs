using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_OOP_FinalProject
{
    public class Beverage
    {
        private string type;
        private float volume;
        private float price;

        public Beverage(string type, float volume, float price)
        {
            this.type = type;
            this.volume = volume;
            this.price = price;
        }

        #region Accesseurs
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public float Volume
        {
            get { return this.volume; }
            set { this.volume = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        #endregion Accesseurs

        public override string ToString()
        {
            return "Type : " + type + "\nVolume :" + volume + "\nPrix : " + price;
        }

    }
}
