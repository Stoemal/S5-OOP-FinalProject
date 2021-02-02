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
    /// Logique d'interaction pour ModuleStatistiques.xaml
    /// </summary>
    public partial class ModuleStatistiques : Page
    {
        Pizzeria pizzAlpha;

        public ModuleStatistiques(Pizzeria pizzAlpha)
        {
            this.pizzAlpha = pizzAlpha;

            
            InitializeComponent();
        }

        private void AfficheCommandesCommis(object sender, RoutedEventArgs e)
        {
            string commisID = numCommis.Text;
            bool check = false;
            int increment = -1;
            for (int i = 0; i < pizzAlpha.ListOfficer.Count() && check == false; i++) 
            {
                
                if (pizzAlpha.ListOfficer[i].PhoneNumber == commisID) 
                {
                    check = true;
                    increment = i;
                }
            }
            if (check == true)
            {
                MessageBox.Show("Le nombre de commandes gérées par ce commis est de : \n" +
                pizzAlpha.ListOfficer[increment].OrderCount);
            }
            else
            {
                MessageBox.Show("Aucun commis ne correspond à ce numéro");
            }
            InitializeComponent();
        }

        private void AfficheCommandesLivreur(object sender, RoutedEventArgs e)
        {
            string livreurID = numLivreur.Text;
            bool check = false;
            int increment = -1;
            for (int i = 0; i < pizzAlpha.ListDeliveryDriver.Count() && check == false; i++)
            {

                if (pizzAlpha.ListDeliveryDriver[i].PhoneNumber == livreurID)
                {
                    check = true;
                    increment = i;
                }
            }
            if (check == true)
            {
                MessageBox.Show("Le nombre de commandes livrées par ce livreur est de : \n" +
                pizzAlpha.ListDeliveryDriver[increment].OrderCount);
            }
            else
            {
                MessageBox.Show("Aucun livreur ne correspond à ce numéro");
            }
            InitializeComponent();

        }

        private void RechercheCommandesDate(object sender, RoutedEventArgs e)
        {
            DateTime Date1 = Convert.ToDateTime(date1.Text);
            DateTime Date2 = Convert.ToDateTime(date2.Text);
            MessageBox.Show(pizzAlpha.OrderTime(Date1, Date2));
            InitializeComponent();

        }

        private void MoyenneCommandes(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Le prix moyen d'une commande est de : \n" +
                "                               " + pizzAlpha.OrderMean() + " €");
            
        }

        private void MoyenneClients(object sender, RoutedEventArgs e)
        {
            listViewCustomerMean.ItemsSource = pizzAlpha.ListCustomer;

            InitializeComponent();
            float mean = 0;
            Customer client = (Customer)listViewCustomerMean.SelectedItem;

            mean = client.CustomerAccount();
            MessageBox.Show("La moyenne des dépenses de " + client.LastName + " " + client.FirstName + " est de : \n" + 
               "  " +  mean + " €" );

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            listViewCustomerMean.ItemsSource = pizzAlpha.ListCustomer;
            InitializeComponent();
        }
    }
}
