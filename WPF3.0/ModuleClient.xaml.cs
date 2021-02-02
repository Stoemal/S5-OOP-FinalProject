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
    /// Logique d'interaction pour ModuleClient.xaml
    /// </summary>
    public partial class ModuleClient : Page
    {
        Pizzeria pizzAlpha = new Pizzeria();
        Customer a = new Customer("dave", "dave", "dave", "dave");
        
        public ModuleClient()
        {
            InitializeComponent();
        }

        private void TrieAlphabetique(object sender, RoutedEventArgs e)
        {
            pizzAlpha.ListCustomer.Add(a);
            MessageBox.Show(pizzAlpha.ListCustomer[0].FirstName);
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);

        }

        private void TrieVille(object sender, RoutedEventArgs e)
        {

        }

        private void TrieMontant(object sender, RoutedEventArgs e)
        {

        }

        private void AjoutClient(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Succes de l'ajout");
        }

        private void SuppressionClient(object sender, RoutedEventArgs e)
        {

        }
    }
}
