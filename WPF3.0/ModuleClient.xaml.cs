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
        Pizzeria pizzAlpha;
       

        public ModuleClient(Pizzeria pizzAlpha)
        {
            this.pizzAlpha = pizzAlpha;
            InitializeComponent();
        }

        private void TrieAlphabetique(object sender, RoutedEventArgs e)
        {

            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);

            
            listViewCustomer.ItemsSource = pizzAlpha.ListCustomer;
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewCustomer.ItemsSource);                    

            InitializeComponent();
            //pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);
            
        }

        private void TrieVille(object sender, RoutedEventArgs e)
        {

        }

        private void TrieMontant(object sender, RoutedEventArgs e)
        {
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerCumulativeOrder);
            listViewCustomer.ItemsSource = pizzAlpha.ListCustomer;                
            InitializeComponent();
            
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
