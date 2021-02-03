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
        bool check; //Pour vérifier si un lient est bien dans la liste
        string tel; //Pour prendre le téléphone d'un client ui est bien dans la liste      
       

        public ModuleClient(Pizzeria pizzAlpha)
        {
            this.pizzAlpha = pizzAlpha;
            this.check = false;
            
            InitializeComponent();
        }

        private void TrieAlphabetique(object sender, RoutedEventArgs e)
        {           
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerAlphabet);
            listViewCustomer.ItemsSource = null;
            listViewCustomer.ItemsSource = pizzAlpha.ListCustomer;                   
            InitializeComponent();
        }

        private void TrieVille(object sender, RoutedEventArgs e)
        {
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerCity);
            listViewCustomer.ItemsSource = null;
            listViewCustomer.ItemsSource = pizzAlpha.ListCustomer;
            InitializeComponent();
        }

        private void TrieMontant(object sender, RoutedEventArgs e)
        {          
            pizzAlpha.DisplayCustomerShape(pizzAlpha.DisplayCustomerCumulativeOrder);
            listViewCustomer.ItemsSource = null;
            listViewCustomer.ItemsSource = pizzAlpha.ListCustomer;                
            InitializeComponent();         
        }

        private void AjoutClient(object sender, RoutedEventArgs e)
        {
            string[] datas = new string[4];

            datas[0] = Prenom.Text;
            datas[1] = Nom.Text;
            datas[2] = Adresse.Text;
            datas[3] = Telephone.Text;

            pizzAlpha.ManipulateEntries(pizzAlpha.CreateCustomer, datas);
        }

        private void SuppressionClient(object sender, RoutedEventArgs e)
        {
            string[] datas = new string[1];
            datas[0] = TelephoneSupprimer.Text;
            pizzAlpha.ManipulateEntries(pizzAlpha.DeleteCustomer, datas);
        }

        private void Verifier(object sender, RoutedEventArgs e)
        {
            this.tel = TelephoneAChercher.Text;

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

        private void ModifierClient(object sender, RoutedEventArgs e)
        {
            if(check == true)
            {
                string[] datas = new string[5];

                datas[0] = PrenomModifier.Text;
                datas[1] = NomModifier.Text;
                datas[2] = AdresseModifier.Text;
                datas[3] = TelephoneModifier.Text;
                datas[4] = tel; //Téléphone du client à modifier

                /*
                bool test = false;
                
                if (datas[0] == "Nom à modifier")
                {
                    MessageBox.Show("Entrer un nouveau nom ou l'ancien nom");
                }
                else if (datas[1] == "Prénom à modifier") MessageBox.Show("Entrer un nouveau prénom ou l'ancien");
                else if (datas[2] == "Adresse à modifier") MessageBox.Show("Entrer une nouvelle adresse ou l'ancienne");
                else if (datas[3] == "Adresse à modifier") MessageBox.Show("Entrer un nouveau téléphone ou l'ancien");
                else test = true;

                while (test == false)
                {
                    datas[0] = PrenomModifier.Text;
                    datas[1] = NomModifier.Text;
                    datas[2] = AdresseModifier.Text;
                    datas[3] = TelephoneModifier.Text;
                    datas[4] = tel;

                    if (datas[0] == "Nom à modifier")
                    {
                        MessageBox.Show("Entrer un nouveau nom ou l'ancien nom");
                    }
                    else if (datas[1] == "Prénom à modifier") MessageBox.Show("Entrer un nouveau prénom ou l'ancien");
                    else if (datas[2] == "Adresse à modifier") MessageBox.Show("Entrer une nouvelle adresse ou l'ancienne");
                    else if (datas[3] == "Adresse à modifier") MessageBox.Show("Entrer un nouveau téléphone ou l'ancien");
                    else test = true;
                }
                */

                pizzAlpha.ManipulateEntries(pizzAlpha.ModifyCustomer, datas);
                tel = null;
                check = false;
            }           
        }
    }
}
