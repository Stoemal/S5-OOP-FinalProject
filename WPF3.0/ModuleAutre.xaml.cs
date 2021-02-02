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
    /// Logique d'interaction pour ModuleAutre.xaml
    /// </summary>
    public partial class ModuleAutre : Page
    {
        Pizzeria pizzAlpha;
        public ModuleAutre(Pizzeria pizzAlpha)
        {
            this.pizzAlpha = pizzAlpha;
            InitializeComponent();
        }

        private void AfficheClientHasard(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pizzAlpha.RandomPizza());
            InitializeComponent();
        }

        private void AfficheMeilleurClient(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pizzAlpha.BestCustomer());
            InitializeComponent();
        }

        private void NomDuJour(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pizzAlpha.FirstNameDay());
        }

        private void BackToTheFuture(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pizzAlpha.BackToTheFuture());
            

        }


    }
}
