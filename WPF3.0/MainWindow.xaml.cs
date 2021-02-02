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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Module_Client(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleClient();
        }

        private void ModuleCommande(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleCommande();

        }

        private void ModuleStatistiques(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleStatistiques();

        }

        private void ModuleAutre(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModuleAutre();

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
