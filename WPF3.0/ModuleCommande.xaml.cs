﻿using System;
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
        public ModuleCommande()
        {
            InitializeComponent();
        }

        private void NouveauClient(object sender, RoutedEventArgs e)
        {
            CommandeMain.Content = new ModuleClient();
        }

        private void TrieAlphabetique(object sender, RoutedEventArgs e)
        {

        }

        private void TrieVille(object sender, RoutedEventArgs e)
        {

        }

        private void TrieMontant(object sender, RoutedEventArgs e)
        {

        }

        private void AjoutCommande(object sender, RoutedEventArgs e)
        {

        }
    }
}