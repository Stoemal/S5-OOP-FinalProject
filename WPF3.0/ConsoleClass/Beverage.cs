using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF3._0
{
    /// <summary>
    /// Class des Boissons
    /// </summary>
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
        }
        public float Volume
        {
            get { return this.volume; }
        }
        public float Price
        {
            get { return this.price; }
        }
        #endregion Accesseurs

        public override string ToString()
        {
            return "Type : " + type + "\nVolume : " + volume + "\nPrix : " + price;
        }

    }
}
