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
using System.ComponentModel;
//using [S5_OOP_FinalProject]
namespace WPF3._0
{
    
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pizzeria pizzAlpha = new Pizzeria();

        

        public MainWindow()
        {
            string file = "Clients.csv";
            string file1 = "Commis.csv";
            string file2 = "Livreur.csv";
            string file3 = "Commandes.csv";
            string file4 = "DetailsCommandes.csv";

            pizzAlpha.AddFilesData(pizzAlpha.ReadCustomers, file);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOfficer, file1);
            pizzAlpha.AddFilesData(pizzAlpha.ReadDeliveryDriver, file2);
            pizzAlpha.AddFilesData(pizzAlpha.ReadOrder, file3);
            pizzAlpha.AddFilesData(pizzAlpha.ReadDetailsOrder, file4);

            InitializeComponent();
        }
        

        private void Module_Client(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleClient(pizzAlpha);
        }

        private void ModuleCommande(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleCommande(pizzAlpha);

        }

        private void ModuleStatistiques(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleStatistiques(pizzAlpha);

        }

        private void ModuleAutre(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleAutre(pizzAlpha);

        }

        private void MenuPrincipal(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MenuPrincipal();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            //System.Environment.Exit(-1);
            //Pour fermer violemment
            this.Close();
        }

     
    }
}
