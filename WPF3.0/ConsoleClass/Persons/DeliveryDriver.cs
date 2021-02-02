using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF3._0
{
    /// <summary>
    /// Class du Livreur héritant de la Class Employee et implémentant IDisplay
    /// C'est une feuille terminale de l'arbre d'héritage
    /// </summary>
    sealed public class DeliveryDriver : Employee, IDisplay
    {
        private string meanOfTransport;
        private int orderCount;
        public DeliveryDriver(string firstName, string lastName, string address, string phoneNumber, string position, string meanOfTransport, int orderCount) : base(firstName, lastName, address, phoneNumber, position)
        {
            this.meanOfTransport = meanOfTransport;
            this.orderCount = orderCount;
        }

        #region Accesseurs
        public string MeanOfTransport
        {
            get { return this.meanOfTransport; }
        }
        public int OrderCount
        {
            get { return this.orderCount; }
            set { this.orderCount = value; }
        }
        #endregion Accesseurs

        #region FONCTIONS
        public override string ToString()
        {
            ///Renvoie les informations concernant ce livreur
            string chain = "\nMoyen de transport : ";
            if (meanOfTransport != null) chain = chain + meanOfTransport;
            else chain = chain + "inconnue";
            chain = chain + "\nNombre de commande(s) : " + orderCount;
            return base.ToString() + chain;
        }

        public void Display()
        {
            /// Permet d'afficher le nombre de commandes livrées par ce livreur
            Console.WriteLine("Nombre de commandes prises en charge : " + this.orderCount);
        }
        #endregion
    }
}
