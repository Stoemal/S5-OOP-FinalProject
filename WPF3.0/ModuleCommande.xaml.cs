using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF3._0
{
    /// <summary>
    /// Logique d'interaction pour ModuleCommande.xaml
    /// </summary>
    public partial class ModuleCommande : Page
    {
        Pizzeria pizzAlpha;
        bool check; //Pour vérifier si un lient est bien dans la liste
        string tel; //Pour prendre le téléphone d'un client ui est bien dans la liste      

        public ModuleCommande(Pizzeria pizzAlpha)
        {
            this.pizzAlpha = pizzAlpha;
            InitializeComponent();
        }

        private void NouveauClient(object sender, RoutedEventArgs e)
        {
            CommandeMain.Content = new ModuleClient(pizzAlpha);
        }
      

        private void AjoutCommande(object sender, RoutedEventArgs e)
        {
            if(this.check == true)
            {
                string[] datas = new string[1];
                datas[0] = this.tel;
                this.tel = null;
                this.check = false;
                pizzAlpha.ManipulateEntries(pizzAlpha.CreateOrder, datas);

                string[] datasPizza = new string[5];

                #region Pizza definition
                datasPizza[0] = "Pizza";
                datasPizza[2] = TypePizzas.Text;
                datasPizza[3] = TaillePizza.Text;
                datasPizza[4] = NombreDePizzas.Text;
                if (datasPizza[2] == "Margherita" || datasPizza[2] == "Calzone" || datasPizza[2] == "BBQ")
                {
                    if (datasPizza[3] == "Normale") datasPizza[1] = "9";
                    else if (datasPizza[3] == "Petite") datasPizza[1] = "7";
                    else datasPizza[1] = "11";

                }
                else if (datasPizza[2] == "Royale")
                {
                    if (datasPizza[3] == "Normale") datasPizza[1] = "12";
                    else if (datasPizza[3] == "Petite") datasPizza[1] = "10";
                    else datasPizza[1] = "15";

                }
                else if (datasPizza[2] == "4 Fromages")
                {
                    if (datasPizza[3] == "Normale") datasPizza[1] = "10";
                    else if (datasPizza[3] == "Petite") datasPizza[1] = "8";
                    else datasPizza[1] = "12";
                }
                else
                {
                    if (datasPizza[3] == "Normale") datasPizza[1] = "8";
                    else if (datasPizza[3] == "Petite") datasPizza[1] = "5";
                    else datasPizza[1] = "10";
                }
                #endregion Pizza definition

                #region Boisson definition
                string[] datasBoisson = new string[4];
                string boisson = Boissons.Text;
                datasBoisson[0] = boisson;
                datasBoisson[3] = NombreDeBoissons.Text;

                if(datasBoisson[3] != "NombreDeBoissons")
                {
                    if (boisson == "Coca-Cola" || boisson == "Fanta" || boisson == "Oasis")
                    {
                        datasBoisson[1] = "1";
                        datasBoisson[2] = "33";
                    }
                    else if (boisson == "Dr.Pepper")
                    {
                        datasBoisson[1] = "2";
                        datasBoisson[2] = "33";
                    }
                    else if (boisson == "Evian")
                    {
                        datasBoisson[1] = "3";
                        datasBoisson[2] = "100";
                    }
                    else
                    {
                        datasBoisson[1] = "3";
                        datasBoisson[2] = "33";
                    }
                }



                #endregion Boisson definition
            

                Order commande = pizzAlpha.GlobalOrderList[pizzAlpha.GlobalOrderList.Count() - 1];
                for (int i = pizzAlpha.GlobalOrderList.Count() - 1; i >= 0; i--)
                {
                    if(pizzAlpha.GlobalOrderList[i].CustomerToServer.PhoneNumber == tel)
                    {
                        commande = pizzAlpha.GlobalOrderList[i];
                        break;
                    }
                }

                pizzAlpha.CreateDetailsOrder(datasPizza, commande);
                if (datasBoisson[3] != "NombreDeBoissons") pizzAlpha.CreateDetailsOrder(datasBoisson, commande);
            }
            else MessageBox.Show("Commande impossible car Client non trouvé");
        }

        private void ChercheCommande(object sender, RoutedEventArgs e)
        {
            string text = "Aucune commande ne correspond à ce numéro";
            string orderID = cmdNumber.Text;
            foreach (Order commande in pizzAlpha.GlobalOrderList)
            {
                if ( Convert.ToString(commande.OrderNumber ) == orderID)
                {
                    text = commande + "\n\n" + commande.FoodToString();
                }
            }
            MessageBox.Show(text);
        }

        private void Verifier(object sender, RoutedEventArgs e)
        {
            this.tel = TelephoneClient.Text;

            for (int i = 0; i < pizzAlpha.ListCustomer.Count() && check == false; i++)
            {
                if (pizzAlpha.ListCustomer[i].PhoneNumber == this.tel)
                {
                    check = true;
                }
            }

            if (check == true) MessageBox.Show("Client trouvé !");
            else MessageBox.Show("Client à modifier non trouvé ...");
        }

    }
}
