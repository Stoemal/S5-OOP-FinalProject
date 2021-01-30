using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S5_OOP_FinalProject
{
    /// <summary>
    /// Class Pizzeria controlant les commandes des clients, le travail des employés 
    /// ainsi que le reste des caractéristiques reliées à la gestion de l'argent
    /// </summary>
    class Pizzeria
    {
        private List<Officer> listOfficer;
        private List<DeliveryDriver> listDeliveryDriver;
        private List<Customer> listCustomer;
        private List<Order> globalOrderList;

        public Pizzeria()
        {
            listOfficer = new List<Officer>();
            listDeliveryDriver = new List<DeliveryDriver>();
            listCustomer = new List<Customer>();
            globalOrderList = new List<Order>();
        }


        #region Accesseurs
        public List<Officer> ListOfficer
        {
            get { return this.listOfficer; }
            set { listOfficer = value; }
        }
        public List<DeliveryDriver> ListDeliveryDriver
        {
            get { return this.listDeliveryDriver; }
            set { listDeliveryDriver = value; }
        }
        public List<Customer> ListCustomer
        {
            get { return this.listCustomer; }
            set { listCustomer = value; }
        }
        public List<Order> GlobalOrderList
        {
            get { return this.globalOrderList; }
            set { this.globalOrderList = value; }
        }
        #endregion Accesseurs


        /// <summary>
        /// Permet de lire les fichiers Clients, Commis, Livreur et Commande
        /// </summary>
        /// <param name="file">Emplacement du fichier</param>
        public delegate void ReadFiles(string file);

        public void AddFilesData(ReadFiles n, string file)
        {
            n(file);
        }

        /*
        Fonctions de lecture de fichiers du module client
        Elles sont toutes construites avec la même structure
        On l'explique une fois dans ReadCustomers
        Notons aussi qu'on ne lit que des fichiers csv pour chaque individu
        */
        #region Module Client
        /// <summary>
        /// Lit un fichier Client et ajoute les clients du fichier dans listCustomer
        /// </summary>
        /// <param name="file">chemin du fichier Client</param>
        public void ReadCustomers(string file)
        {
            StreamReader lecteur = new StreamReader(file); //On crée un StreamReader pour lire un fichier csv
            string lu; // On initialise une chain de caractère provenant du fichier
            string[] datas;
            /*
            Les cases du fichier csv sont séparées par des ";" lorsque on transforme
            les lignes en chaîne de caractères dans lu
            On utilise alors un tableau de string pour avoir chacun des cases du
            fichier séparément dans datas
            */

            try   //On essaye de trouver le fichier
            {
                while (lecteur.Peek() > 0) //Tant que toutes les lignes n'ont pas été étudiées
                {   //On effectue les commandes ci-dessous
                    lu = lecteur.ReadLine();    //On lit une ligne
                    datas = lu.Split(';');      //On sépare les chaînes de caractères lorsqu'il y 
                                                // a un ; dans le tableau datas

                    //Onajoute ci-dessousl'individu dans sa liste
                    listCustomer.Add(new Customer(datas[1], datas[0], datas[2], datas[3])); 
                }

                //On réinitialise lu et datas à null
                lu = null;
                datas = null;
            }
            catch (FileNotFoundException okay)
            {  //On affiche un message d'erreur si le fichier n'a pas été trouvé
                Console.WriteLine("Document non trouvé");
                Console.WriteLine(okay.Message);
            }
            catch (IOException e) { Console.WriteLine(e.Message); }   //On vérifie encore les erreurs
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally  //On ferme le StremReader une fois que tout a été effectué
            { if (lecteur != null) lecteur.Close(); }
        }

        /// <summary>
        /// Lit un fichier Commis et ajoute les clients du fichier dans listOfficer
        /// </summary>
        /// <param name="file">chemin du fichier Commis</param>
        public void ReadOfficer(string file)
        {
            StreamReader lecteur = new StreamReader(file);
            string lu;
            string[] datas;
            string[] temp;
            try
            {
                while (lecteur.Peek() > 0)
                {
                    lu = lecteur.ReadLine();
                    datas = lu.Split(';');
                    temp = datas[5].Split('/');
                    listOfficer.Add(new Officer(datas[1], datas[0], datas[2], datas[3], datas[4], 
                        new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0])), 0));
                }
                lu = null;
                datas = null;
                temp = null;
            }
            catch (FileNotFoundException okay)
            {
                Console.WriteLine("Document non trouvé");
                Console.WriteLine(okay.Message);
            }
            catch (IOException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            { if (lecteur != null) lecteur.Close(); }
        }

        /// <summary>
        /// Lit un fichier Livreur et ajoute les clients du fichier dans listDeliveryDriver
        /// </summary>
        /// <param name="file">chemin du fichier Livreur</param>
        public void ReadDeliveryDriver(string file)
        {
            StreamReader lecteur = new StreamReader(file);
            string lu;
            string[] datas;         
            try
            {
                while (lecteur.Peek() > 0)
                {
                    lu = lecteur.ReadLine();
                    datas = lu.Split(';');               
                    listDeliveryDriver.Add(new DeliveryDriver(datas[1], datas[0], datas[2], datas[3], datas[4], datas[5], 0));
                }
                lu = null;
                datas = null;
            }
            catch (FileNotFoundException okay)
            {
                Console.WriteLine("Document non trouvé");
                Console.WriteLine(okay.Message);
            }
            catch (IOException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            { if (lecteur != null) lecteur.Close(); }
        }
        #endregion Module Client


        /*
        Fonctions de lecture de fichiers du module commande
        Elles sont toutes construites avec la même structure que pour celles
        du module client
        On l'explique une fois dans ReadCustomers
        Notons aussi qu'on ne lit que des fichiers csv pour chaque commande
        */
        #region Module Commande
        /// <summary>
        /// Lit les caractéristiques d'une commande dans un fichier Commande et 
        /// ajoute les commandes du fichiers dans listOrder
        /// Les produits de la commande n'y sont pas ajoutés
        /// </summary>
        /// <param name="file">cehmin du fichier Commande</param>
        public void ReadOrder(string file)
        {
            StreamReader lecteur = new StreamReader(file);           
            string lu;
            string[] datas;
            string[] temp;
            Customer c = null;
            Officer o = null;
            DeliveryDriver d = null;

            if(listCustomer == null || listOfficer == null || listDeliveryDriver == null)
            {
                Console.WriteLine("Veuillez intialiser les listes de clients, commis et livreur svp.");
            }
            else
            {
                if(listCustomer.Count() == 0 || listOfficer.Count() == 0 || listDeliveryDriver.Count() == 0)
                {
                    Console.WriteLine("Veuillez mettre des individus dans les listes de clients, commis et livreur svp.");
                }
                else
                {
                    try
                    {
                        while (lecteur.Peek() > 0)
                        {
                            lu = lecteur.ReadLine();
                            datas = lu.Split(';');
                            temp = datas[2].Split('/');

                            #region Attribution du nom du client et des employés à une commande
                            c = null;
                            if (listCustomer == null || listCustomer.Count() == 0) ;
                            else
                            {
                                for (int i = 0; i < listCustomer.Count() && c == null; i++)
                                {
                                    if (datas[3] == listCustomer[i].PhoneNumber) c = listCustomer[i];
                                }
                            }

                            o = null;
                            if (listOfficer == null || listOfficer.Count() == 0) ;
                            else
                            {
                                for (int i = 0; i < listOfficer.Count() && o == null; i++)
                                {
                                    if (datas[4].ToUpper() == listOfficer[i].LastName.ToUpper()) o = listOfficer[i];
                                }
                            }

                            d = null;
                            if (listDeliveryDriver == null || listDeliveryDriver.Count() == 0) ;
                            else
                            {
                                for (int i = 0; i < listDeliveryDriver.Count() && d == null; i++)
                                {
                                    if (datas[5].ToUpper() == listDeliveryDriver[i].LastName.ToUpper()) d = listDeliveryDriver[i];

                                }
                            }
                            #endregion

                            //On ajoute la commande dans la liste de commandes
                            globalOrderList.Add(new Order(datas[0],
                                new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]),
                                Convert.ToInt32(datas[1]), 0, 0), c, o, d, datas[6], datas[7]));
                            //listDeliveryDriver.Add(new DeliveryDriver(datas[0], d4atas[1], datas[2], datas[3], datas[4], datas[5], 0));
                        }

                        lu = null;
                        datas = null;
                        temp = null;

                    }
                    catch (FileNotFoundException okay)
                    {
                        Console.WriteLine("Document non trouvé");
                        Console.WriteLine(okay.Message);
                    }
                    catch (IOException e) { Console.WriteLine(e.Message); }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    finally
                    {
                        if (lecteur != null) lecteur.Close();
                    }
                }
            }           
        }

        /// <summary>
        /// Lit un fichier DetailsCommande pour ajouter les produits à mettre dans la commande
        /// La fonction ne peut être appelée qu'après ReadOrder
        /// Affiche un message d'erreur si jamais globalOrderList est vide
        /// </summary>
        /// <param name="file">chemin du fichier DetailsCommande</param>
        public void ReadDetailsOrder(string file)
        {
            if (globalOrderList != null && globalOrderList.Count() != 0)
            {
                StreamReader lecteur = new StreamReader(file);
                string lu;
                string[] datas;
                int qty = 0;   //la quantité du produit acheté
                try
                {
                    while (lecteur.Peek() > 0)
                    {
                        lu = lecteur.ReadLine();
                        datas = lu.Split(';');

                        for(int i = 0; i < globalOrderList.Count(); i++)
                        {
                            if(globalOrderList[i].OrderNumber == datas[0])
                            {
                                if(datas[1].ToUpper() == "PIZZA")
                                {
                                    qty = Convert.ToInt32(datas[6]);
                                    for(int n = 0; n < qty; n++)
                                    {
                                        globalOrderList[i].ListPizza.Add(new Pizza(datas[4], datas[3], float.Parse(datas[2])));
                                        globalOrderList[i].Bill = globalOrderList[i].Bill + float.Parse(datas[2]);
                                    }                                  
                                }
                                else
                                {
                                    qty = Convert.ToInt32(datas[6]);
                                    for (int n = 0; n < qty; n++)
                                    {
                                        globalOrderList[i].ListBeverage.Add(new Beverage(datas[1], float.Parse(datas[5]), Convert.ToInt32(datas[2])));
                                        globalOrderList[i].Bill = globalOrderList[i].Bill + float.Parse(datas[2]);
                                    }
                                }
                                
                            }
                        }                      
                    }
                    lu = null;
                    datas = null;
                }
                catch (FileNotFoundException okay)
                {
                    Console.WriteLine("Document non trouvé");
                    Console.WriteLine(okay.Message);
                }
                catch (IOException e) { Console.WriteLine(e.Message); }
                catch (Exception e) { Console.WriteLine(e.Message); }
                finally
                {
                    if (lecteur != null) lecteur.Close();
                }
            }
            else Console.WriteLine("Liste de Commande vide => Etude des détails impossible");           
        }
        #endregion Module Commande


        #region Module Statistiques
        public void OrderTime(DateTime date1, DateTime date2)
        { // Pour afficher les commandes sur une certaine période
            foreach (Order purchase in globalOrderList)
            {
                if ((purchase.Date > date1) && (purchase.Date < date2))
                {
                    Console.WriteLine(purchase.ToString());
                }
            }
        }
        public void OrderMean()
        {
            float sum = 0;
            foreach (Order purchase in globalOrderList)
            {
                sum = sum + purchase.Bill;
            }
            Console.WriteLine(sum / globalOrderList.Count());
        }
        #endregion Module Statistiques
    }
}
