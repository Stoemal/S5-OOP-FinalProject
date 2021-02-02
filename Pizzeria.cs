using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S5_OOP_FinalProject
{
    /// Class Pizzeria controlant les commandes des clients, le travail des employés 
    /// ainsi que le reste des caractéristiques reliées à la gestion de l'argent
    public class Pizzeria : IDisplay 
    {



        #region ATTRIBUTS
        private List<Officer> listOfficer;
        private List<DeliveryDriver> listDeliveryDriver;
        private List<Customer> listCustomer;
        private List<Order> globalOrderList;
        #endregion

        #region CONSTRUCTEURS
        public Pizzeria()
        {
            listOfficer = new List<Officer>();
            listDeliveryDriver = new List<DeliveryDriver>();
            listCustomer = new List<Customer>();
            globalOrderList = new List<Order>();
        }
        #endregion

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

        #region FONCTIONS GENERALES
        public delegate void ReadFiles(string file);
        /// Permet de lire les fichiers Clients, Commis, Livreur et Commande
        /// file correspond à l'emplacement des fichiers
        public void AddFilesData(ReadFiles n, string file)
        {
            n(file);
        }

        public delegate void Entries(string file);
            
        public void ManipulateEntries(Entries n, string file) { n(file); }

        public Officer AvailableOfficer()
        {
            /// Cette fonction retourne un commis disponible, s'il n'y en a pas, elle retourne le commis nul
            /// On crée le commis nul
            Officer nul = new Officer("Nobody", "Nobody", "Nowhere", "Nothing","Conge",Convert.ToDateTime("2000-02-20"),0);
            foreach(Officer officer in listOfficer)
            {
                ///On parcourt la liste des commis
                if(officer.Position == "surplace")
                {
                    /// Si un  d'entre eux est sur place, on retourne celui-la
                    return officer;
                }
                /// Sinon on retourne le commis nul
            }
            return nul;
        }
        public DeliveryDriver AvailableDriver()
        {
            /// Cette fonction retourne un livreur disponible, elle fonctionne exactement comme AvailableOfficer
            DeliveryDriver nul = new DeliveryDriver("Nobody", "Nobody", "Nowhere", "Nothing", "Conge", "Nothing", 0);
            foreach(DeliveryDriver driver in listDeliveryDriver)
            {
                if(driver.Position == "surplace")
                {
                    return driver;
                }
            }
            return nul;
        }
        #endregion

        #region Module Client


        public void CreateCustomer(string file)
        {
            Customer c;
            string[] datas = new string[4];
            Console.WriteLine("Nouveau Client : \n");
            Console.WriteLine("Nom : ");
            datas[0] = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            datas[1] = Console.ReadLine();
            Console.WriteLine("Adresse : ");
            datas[2] = Console.ReadLine();
            Console.WriteLine("Téléphone : ");
            datas[3] = Console.ReadLine();

            c = new Customer(datas[0], datas[1], datas[2], datas[3]);
            listCustomer.Add(c);

            StreamWriter writeFile = new StreamWriter(file, true);
            writeFile.WriteLine(datas[0] + ";" + datas[1] + ";" + datas[2] + ";" + datas[3]);
            writeFile.Close();
        }

        public void DeleteCustomer(string file)
        {            
            string tel;
            bool check = false;
            Console.WriteLine("Modifier un client : \nEntrer son numéro de téléphone :");
            tel = Console.ReadLine();

            for(int i = 0; i < listCustomer.Count() && check == false; i++)
            {
                if (listCustomer[i].PhoneNumber == tel)
                {
                    listCustomer.Remove(listCustomer[i]);
                    check = true;
                }
            }
            if(check == true)
            {
                List<String> fichier = File.ReadAllLines(file).ToList();
                for (int i = 0; i < fichier.Count(); i++)
                {
                    if ((fichier[i].Split(';'))[3] == tel)
                    {
                        fichier.RemoveAt(i);
                        break;
                    }
                }
                File.WriteAllLines(file, fichier.ToArray());
            }
            else Console.WriteLine("Téléphone non trouvé\n");
        }

        public void ModifyCustomer(string file)
        {
            string tel;
            bool check = false;
            int inc = -1;
            Console.WriteLine("Modifier un client : \nEntrer son numéro de téléphone :");
            tel = Console.ReadLine();

            for (int i = 0; i < listCustomer.Count() && check == false; i++)
            {
                if (listCustomer[i].PhoneNumber == tel)
                {
                    inc = i;
                    check = true;
                }
            }
            if (check == true && inc > -1)
            {
                string[] datas = new string[4];
                bool t;
                Console.WriteLine(listCustomer[inc]);
                Console.WriteLine("\nEntrer 1 pour modifier le client et 0 sinon :\n");

                #region Modifications du client en brut
                Console.WriteLine("Nom ?");
                t = Int32.TryParse(Console.ReadLine(), out int res);
                while(t == false || res > 1 || res < 0)
                {
                    Console.WriteLine("Entrer 0 ou 1");
                    t = Int32.TryParse(Console.ReadLine(), out res);
                }
                if (res == 1)
                {
                    Console.WriteLine("Nouveau nom : ");
                    datas[0] = Console.ReadLine();
                }
                else datas[0] = listCustomer[inc].LastName;

                Console.WriteLine("\nPrénom ?");
                t = Int32.TryParse(Console.ReadLine(), out res);
                while (t == false || res > 1 || res < 0)
                {
                    Console.WriteLine("Entrer 0 ou 1");
                    t = Int32.TryParse(Console.ReadLine(), out res);
                }
                if (res == 1)
                {
                    Console.WriteLine("Nouveau prénom : ");
                    datas[1] = Console.ReadLine();
                }
                else datas[1] = listCustomer[inc].FirstName;

                Console.WriteLine("\nAdresse ?");
                t = Int32.TryParse(Console.ReadLine(), out res);
                while (t == false || res > 1 || res < 0)
                {
                    Console.WriteLine("Entrer 0 ou 1");
                    t = Int32.TryParse(Console.ReadLine(), out res);
                }
                if (res == 1)
                {
                    Console.WriteLine("Nouvelle adresse : ");
                    datas[2] = Console.ReadLine();
                }
                else datas[2] = listCustomer[inc].Address;

                Console.WriteLine("\nNuméro de téléphone ?");
                t = Int32.TryParse(Console.ReadLine(), out res);
                while (t == false || res > 1 || res < 0)
                {
                    Console.WriteLine("Entrer 0 ou 1");
                    t = Int32.TryParse(Console.ReadLine(), out res);
                }
                if (res == 1)
                {
                    Console.WriteLine("Nouveau téléphone : ");
                    datas[1] = Console.ReadLine();
                }
                else datas[3] = listCustomer[inc].PhoneNumber;
                #endregion Modifications du client en brut

                listCustomer[inc] = new Customer(datas[0], datas[1], datas[2], datas[3]);

                List<String> fichier = File.ReadAllLines(file).ToList();
                for (int i = 0; i < fichier.Count(); i++)
                {
                    if ((fichier[i].Split(';'))[3] == tel)
                    {
                        fichier[i] = datas[0] + ";" + datas[1] + ";" + datas[2] + ";" + datas[3];
                        break;
                    }
                }
                File.WriteAllLines(file, fichier.ToArray());
            }
            else Console.WriteLine("Téléphone non trouvé\n");
        }


        /*
        Fonctions de lecture de fichiers du module client
        Elles sont toutes construites avec la même structure
        On l'explique une fois dans ReadCustomers
        Notons aussi qu'on ne lit que des fichiers csv pour chaque individu
        */
        #region Lire Fichiers

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
            //temp.ForEach((Customer n) => { Console.WriteLine(n + "\n"); });            
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
            //la liste de ville : cities par ordre alphabétique des villes
            cities.Sort(delegate (string a, string b) { return a.CompareTo(b); });
            
            /*
            cities.ForEach((string elt) =>
            {
                Console.WriteLine(elt + " :\n");
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (datas[i] == elt) Console.WriteLine(temp[i] + "\n");
                }
                Console.WriteLine();
            });
            */
        }

        public void DisplayCustomerCumulativeOrder(List<Customer> temp)
        {
            for (int i = 0; i < temp.Count(); i++)
            {
                temp[i].Calculation();
                //Console.WriteLine(temp[i].PartialToStringCumulativeOrder() + "\n");
            }
            temp.Sort(delegate (Customer a, Customer b)
            {
                return a.CumulativeOrder.CompareTo(b.CumulativeOrder);
            });
        }

        #endregion Affichage Clients

        #endregion Module Client

        #region Module Commande
        /*
        Les fonctions de lecture de fichiers du module commande
        sont toutes construites avec la même structure que celles
        du module client
        On l'explique une fois dans ReadCustomers
        Notons aussi qu'on ne lit que des fichiers csv pour chaque commande
        */
        public void CreateOrder(string file)
        {
            Customer c;
            string[] datas = new string[4];
            Console.WriteLine("Nouveau Client : \n");
            Console.WriteLine("Nom : ");
            datas[0] = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            datas[1] = Console.ReadLine();
            Console.WriteLine("Adresse : ");
            datas[2] = Console.ReadLine();
            Console.WriteLine("Téléphone : ");
            datas[3] = Console.ReadLine();

            c = new Customer(datas[0], datas[1], datas[2], datas[3]);
            listCustomer.Add(c);

            StreamWriter writeFile = new StreamWriter(file, true);
            writeFile.WriteLine(datas[0] + ";" + datas[1] + ";" + datas[2] + ";" + datas[3]);
            writeFile.Close();


            Order o;

        }
            
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
                            temp = datas[1].Split('/');

                            #region Attribution du nom du client et des employés à une commande
                            c = null;
                            for (int i = 0; i < listCustomer.Count() && c == null; i++)
                            {
                                if (datas[2] == listCustomer[i].PhoneNumber) c = listCustomer[i];
                            }                        

                            o = null;
                            for (int i = 0; i < listOfficer.Count() && o == null; i++)
                            {
                                if (datas[3].ToUpper() == listOfficer[i].LastName.ToUpper()) o = listOfficer[i];
                            }                        

                            d = null;
                            for (int i = 0; i < listDeliveryDriver.Count() && d == null; i++)
                            {
                                if (datas[4].ToUpper() == listDeliveryDriver[i].LastName.ToUpper()) d = listDeliveryDriver[i];
                            }
                            #endregion

                            //On ajoute la commande dans la liste de commandes
                            Order add = new Order(new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]),
                                Convert.ToInt32(datas[0]), 0, 0), c, o, d, datas[5], datas[6]);

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
                            //Console.WriteLine(globalOrderList[i].OrderNumber);
                            //Console.WriteLine(datas[0]);
                            if(Convert.ToString(globalOrderList[i].OrderNumber) == datas[0])
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
        
        /// <summary>
        /// Implémentation de IDisplay affichant les données de chacune des commandes
        /// </summary>
        public void Display()
        {
            globalOrderList.ForEach(delegate (Order n) { Console.WriteLine(n + "\n" + n.FoodToString()); });
        }

        

        #endregion Module Commande

        #region Module Statistiques

        /// <summary>
        /// Affiche les commandes selon une période de temps
        /// </summary>
        /// <param name="date1">1ère date</param>
        /// <param name="date2">2ème date ultérieure à la 1ère</param>
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

        /// <summary>
        /// Calcul la moyenne du prix de toutes les commandes
        /// </summary>
        public void OrderMean()
        {
            float sum = 0;
            foreach (Order purchase in globalOrderList)
            {
                sum = sum + purchase.Bill;
            }
            Console.WriteLine("Moyenne montant commandes : " + sum / globalOrderList.Count());
        }

        /// <summary>
        /// Cette fonction affiche la moyenne des comptes clients
        /// on parcourt la liste de clients 
        /// puis pour chaque client on parcourt la liste de commandes et on y ajoute
        /// on somme donc les notes de chaques commandes que l'on divise par la longueur de la liste de commande
        /// on termine par afficher le nom du client et la moyenne des dépenses de son compte
        /// </summary>
        public void CustomerAccount()
        {
            float sum = 0;

            /*
            listCustomer.ForEach(delegate (Customer n)
            {
                if(n.ListOrder != null)
                {
                    if(n.ListOrder.Count() > 0)
                    {
                        n.Calculation();
                        sum = n.CumulativeOrder / n.ListOrder.Count();
                    }
                }
                Console.WriteLine(n.LastName + "  " + sum / n.ListOrder.Count() + " e");
                sum = 0;
            });
            */
            


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

        #region Module Autre
        public void RandomPizza()
        {
            /// Cette fonction fait partie du module autre, elle offre une grande 
            /// pizza de la chance ainsi qu'un litre de bière au beurre à un client de façon aléatoire
            Random rnd = new Random(); 
            //On définit un variable aléatoire
            int index = rnd.Next(listCustomer.Count());
            //Cela nous retourne l'index dans la liste de clients du client chanceux
            Customer luckyCustomer = listCustomer[index];
            //On associe le client à son index
            Pizza luckyPizza = new Pizza("Grande", "Chance", 0);
            //On crée la pizza qui sera offerte (on ne peut l'avoir que via cette fonction)
            Beverage luckyBeverage = new Beverage("Bière au Beurre", 300, 0);
            //On crée la bière au beurre
            List<Pizza> luckyPList = new List<Pizza> { luckyPizza };
            //On crée nos listes de pizza et boissons (le constructeur de commande à besoin de list pour fonctionner)
            List<Beverage> luckyBList = new List<Beverage> { luckyBeverage };
            //Officer a = new Officer("Tom", "Cruise", "LosAngeles", "0101010101", "ISS", Convert.ToDateTime("2019-06-02"), 2);
            //DeliveryDriver b = new DeliveryDriver("Chuck", "Norris", "Las Vegas", "0123456789", "Il vous trouvera", "Monocycle", 0);
            Order luckyOrder = new Order(DateTime.Now, luckyCustomer, AvailableOfficer(), AvailableDriver(), luckyPList, luckyBList, "en préparation", "en préparation", 0);
            //On construit notre commande avec les arguments précédents
            luckyCustomer.ListOrder.Add(luckyOrder);// On ajoute la commande à la liste de commande de notre client
            Console.WriteLine(luckyOrder + "\n" + luckyOrder.FoodToString());
            //Console.WriteLine();
            //Console.WriteLine(luckyCustomer);
            //Permet de vérifier que la commande se soit bien executée
        }
        public void BestCustomer()
        {
            /// Cette fonction permet de trouver le meilleur client (celui qui à dépensé le plus d'argent)
            /// et lui offre une pizza royale et une bouteille de chardonnay
            Customer bestCustomer = new Customer("", "", "", "");
            Pizza pizz = new Pizza("Grande", "Royale", 0);
            Beverage boisson = new Beverage("Chardonnay", 100, 0);
            Order commande = new Order(bestCustomer, AvailableOfficer(), AvailableDriver(), "en preparation", "en cours");
            commande.ListPizza.Add(pizz);
            commande.ListBeverage.Add(boisson);
            foreach(Customer client in listCustomer)
            {
                if(client.CumulativeOrder > bestCustomer.CumulativeOrder)
                {
                    bestCustomer = client;
                }
            }
            /// on parcourt toute la liste pour trouver le meilleur client
            /// on lui met en attente sa prochaine commande
            //bestCustomer.ListOrder.Add(commande);
            //Console.WriteLine(bestCustomer);
            Console.WriteLine(commande.ToString());
            //Console.WriteLine(commande.FoodToString());
        }
        public void FirstNameDay()
        {
            /// Cette fonction fait payer 1€ sa commande au client, 
            /// si son nom fait partie de la liste de noms suivante
            /// et qu'il commande le jour de cette promotion
            /// On crée notre liste de noms
            List<string> firstNameList = new List<string>
            {
                "Monique","Germaine","Reine","Brigitte",
                "Jacqueline","Adrienne","Xaviere",

                "Teodule","Norbert","Gervais","Casimir",
                "Raymond","Wilfried","Guy"
            };
            /// On parcourt notre list de commandes
            foreach(Order commande in globalOrderList)
            {
                /// Si la liste de prénom contient le prénom d'un des client qui a commandé aujourd'hui 
                /// Son addition est de 1€

                if (firstNameList.Contains(commande.CustomerToServer.FirstName) && commande.CustomerToServer.PassedAnOrder())
                {
                    commande.Bill = 1;
                    //Console.WriteLine(commande.CustomerToServer.ToString());
                    //Console.WriteLine(commande.ToString());
                    //Console.WriteLine(commande.FoodToString());
                }
            }

        }
        public void BackToTheFuture()
        {
            //Cette fonction vérifie si on est le 21/10/2015 que l'on a passé commande aujourd'hui
            //et si on s'appelle Marty McFly, si c'est la cas, on gagne une grande pizza voyageur du temps 
            //ainsi qu'un verre de lait, on se fait livrer par biff ! Le pied non ?
            Customer marty = new Customer("Marty", "McFly","HillValley","111111111");
            Officer doc = new Officer("Emett", "Brown", "HillValley", "0101010101", "InTheDeLorean", Convert.ToDateTime("1955-11-05"), 221);
            DeliveryDriver biff = new DeliveryDriver("Biff", "Tannen", "HillValley", "0123456789", "DansLeFumier", "HoverBoard", 0);
            Pizza pizz = new Pizza("Grande", "Voyageur Du Temps", 0);
            Beverage boisson = new Beverage("Lait", 33,0);
            Order commande = new Order(marty, doc, biff, "en preparation", "en cours");
            commande.ListPizza.Add(pizz);
            commande.ListBeverage.Add(boisson);
            //On crée tous nos objets 
            if(DateTime.Today.ToShortDateString() == "21/10/2015")
            {
                //On vérifie la date
                foreach (Customer client in listCustomer)
                {
                    if (client.FirstName == "Marty" && client.LastName == "McFly" && client.PassedAnOrder())
                    {
                        //On vérifie le client ET s'il a passé commande aujourd'hui
                        client.ListOrder.Add(commande);
                        //Console.WriteLine(client.ToString());
                        //Console.WriteLine(client.PartialToStringListOrder());
                    }
                }
            }
        }
        //La delegation pour changer la pondération d'une note fait aussi partie du module autre
        #endregion



    }
}
