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





        #region Module Client

        /*
        Fonctions de lecture de fichiers du module client
        Elles sont toutes construites avec la même structure
        On l'explique une fois dans ReadCustomers
        Notons aussi qu'on ne lit que des fichiers csv pour chaque individu
        */
        #region Lire Fichiers

        /// <summary>
        /// Permet de lire les fichiers Clients, Commis, Livreur et Commande
        /// </summary>
        /// <param name="file">Emplacement du fichier</param>
        public delegate void ReadFiles(string file);

        public void AddFilesData(ReadFiles n, string file)
        {
            n(file);
        }

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
        #endregion Lire Fichiers

        #region Affichage Clients
        /// <summary>
        /// On définit une délégation pour Afficher les clients de trois manières
        /// comme demandé pour le module Client
        /// </summary>
        /// <param name="lcustomer">liste de clients à afficher</param>
        public delegate void DisplayCustomer(List<Customer> lcustomer);

        /// <summary>
        /// Méthode appelée pour afficher les clients
        /// </summary>
        /// <param name="n">délégation DisplayCustomer prenant listCustomer en paramètre</param>
        public void DisplayCustomerShape(DisplayCustomer n)
        {
            n(listCustomer);
        }

        /// <summary>
        /// Affiche les clients par ordre alphabétique des noms en 
        /// triant la liste des clients
        /// </summary>
        /// <param name="temp">paramètre correspondant à listCustomer</param>
        public void DisplayCustomerAlphabet(List<Customer> temp)
        {          
            //On trie la liste avec un sort et une délégation
            temp.Sort(delegate (Customer a, Customer b)
            {
                return a.LastName.CompareTo(b.LastName);              
            });

            //On affiche la liste avec un ForEach et une délégation
            temp.ForEach((Customer n) => { Console.WriteLine(n + "\n"); });            
            temp = null;
        }

        /// <summary>
        /// Affiche les clients par ordre alphabétique des villes
        /// sans trier la liste des clients
        /// </summary>
        /// <param name="temp">paramètre correspondant à listCustomer</param>
        public void DisplayCustomerCity(List<Customer> temp)
        {
            string[] datas = new string[temp.Count()];  //Le tableau où on mettra le nom des villes en plusieurs exemplaires si elles le sont
            string[] pass = null;                       //Un tableau séparant chaque mots composant l'adresse
            List<string> cities = new List<string>();   //Un tableau des villes

            //On récupère d'abord tous les noms de ville dans datas
            for(int i = 0; i < datas.Length; i++)
            {
                pass = temp[i].Address.Split(' ');
                datas[i] = pass[pass.Length - 1];             
            }

            cities.Add(datas[0]); //On ajoute la première ville

            //Puis on regarde s'il y a d'autres villes portant le même nom
            //Dans le cas échéant on retire tous les noms de villes similaires pour créer la liste
            for(int i = 1; i < datas.Length; i++)
            {
                if (!cities.Exists((string d) => { return d == datas[i]; })) //Si le nom de la ville n'existe pas dans cities on 
                                                                             //ajoute le nom dans la liste
                {
                    cities.Add(datas[i]);
                }
            }
           
            //On affiche tous les clients vivant dans une ville répertoriée dans 
            //la liste de ville : cities
            cities.ForEach((string elt) =>
            {
                Console.WriteLine(elt + " :\n");
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (datas[i] == elt) Console.WriteLine(temp[i] + "\n");
                }
                Console.WriteLine();
            });
        }

        public void DisplayCustomerCumulativeOrder(List<Customer> temp)
        {
            for(int i = 0; i < temp.Count(); i++)
            {
                temp[i].Calculation();
                Console.WriteLine(temp[i].PartialToStringCumulativeOrder() + "\n");
            }
        }

        #endregion Affichage Clients

        #endregion Module Client
        ////////////////////////////////////////////////////////
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
                            for (int i = 0; i < listCustomer.Count() && c == null; i++)
                            {
                                if (datas[3] == listCustomer[i].PhoneNumber) c = listCustomer[i];
                            }                        

                            o = null;
                            for (int i = 0; i < listOfficer.Count() && o == null; i++)
                            {
                                if (datas[4].ToUpper() == listOfficer[i].LastName.ToUpper()) o = listOfficer[i];
                            }                        

                            d = null;
                            for (int i = 0; i < listDeliveryDriver.Count() && d == null; i++)
                            {
                                if (datas[5].ToUpper() == listDeliveryDriver[i].LastName.ToUpper()) d = listDeliveryDriver[i];
                            }
                            #endregion

                            //On ajoute la commande dans la liste de commandes
                            Order add = new Order(datas[0],
                                new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]),
                                Convert.ToInt32(datas[1]), 0, 0), c, o, d, datas[6], datas[7]);

                            globalOrderList.Add(add);
                            if(c.FirstOrder == new DateTime())
                            {
                                c.FirstOrder = new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]));
                            }
                            c.ListOrder.Add(add);
                            o.OrderCount++;
                            d.OrderCount++;
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
        ////////////////////////////////////////////////////////
        #region Module Statistiques

        public void OrderTime(DateTime date1, DateTime date2)
        { // Pour afficher les commandes sur une certaine période
            Console.WriteLine("Commandes passées entre le :  " + Convert.ToString(date1) + "  et le  " + Convert.ToString(date2) + "\n");
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
            Console.WriteLine("Moyenne montant commandes : " + sum / globalOrderList.Count());
        }
        public void CustomerAccount()
        {// [STATISTIQUES] cette fonction affiche la moyenne des comptes clients
         // on parcourt la liste de clients 
         // puis pour chaque client on parcourt la liste de commandes et on y ajoute
         // on somme donc les notes de chaques commandes que l'on divise par la longueur de la liste de commande
         // on termine par afficher le nom du client et la moyenne des dépenses de son compte
            float sum = 0;
            foreach (Customer client in listCustomer)
            {
                foreach (Order commande in client.ListOrder)
                {
                    sum = sum + commande.Bill;
                }
                Console.WriteLine(client.LastName + "  " + sum / client.ListOrder.Count() + " e");
                sum = 0;
            }
        }

        #endregion Module Statistiques
        ////////////////////////////////////////////////////////
        #region Module Autre

        public void RandomPizza()
        {
            // Cette fonction fait partie du module autre, elle offre une grande 
            //  pizza de la chance ainsi qu'un litre de bière au beurre à un client de façon aléatoire

            Random rnd = new Random(); //On définit un variable aléatoire
            int index = rnd.Next(listCustomer.Count());//cela nous retourne l'index dans la liste de clients du client chanceux
            Customer luckyCustomer = listCustomer[index];// on associe le client à son index
            Pizza luckyPizza = new Pizza("Grande", "Chance", 0);//On crée la pizza qui sera offerte (on ne peut l'avoir que via cette fonction)
            Beverage luckyBeverage = new Beverage("Bière au Beurre", 100, 0);//On crée la bière au beurre
            List<Pizza> luckyPList = new List<Pizza> { luckyPizza };//On crée nos listes de pizza et boissons (le constructeur de commande à besoin de list pour fonctionner)
            List<Beverage> luckyBList = new List<Beverage> { luckyBeverage };
            Officer a = new Officer("Tom", "Cruise", "LosAngeles", "0101010101", "ISS", Convert.ToDateTime("2019-06-02"), 2);
            DeliveryDriver b = new DeliveryDriver("Chuck", "Norris", "Las Vegas", "0123456789", "Il vous trouvera", "Monocycle", 0);
            Order luckyOrder = new Order(Convert.ToString(globalOrderList.Count() + 1), DateTime.Now, luckyCustomer, a, b, luckyPList, luckyBList, "en préparation", "en préparation", 0);
            //On construit notre commande avec les arguments précédents
            luckyCustomer.ListOrder.Add(luckyOrder);// On ajoute la commande à la liste de commande de notre client
            //Console.WriteLine(luckyOrder);
            // Permet de vérifier que la commande se soit bien executée
        }





        #endregion



    }
}
