using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S5_OOP_FinalProject
{
    class Pizzeria
    {
        private List<Officer> listOfficer;
        private List<DeliveryDriver> listDeliveryDriver;
        private List<Customer> listCustomer;
        private List<Order> globalOrderList;
        private float dayResult;

        public Pizzeria()
        {
            listOfficer = new List<Officer>();
            listDeliveryDriver = new List<DeliveryDriver>();
            listCustomer = new List<Customer>();
            globalOrderList = new List<Order>();
            dayResult = 0;
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
        #endregion Accesseurs


        /// <summary>
        /// Permet de lire les fi
        /// </summary>
        /// <param name="file"> Emplacement du fichier </param>
        public delegate void ReadFiles(string file);

        public void AddFilesData(ReadFiles n, string file) 
        {
            n(file);
        }

        public void CustomerAccount()
        {// [STATISTIQUES] cette fonction affiche la moyenne des comptes clients
         // on parcourt la liste de clients 
         // puis pour chaque client on parcourt la liste de commandes et on y ajoute
         // on somme donc les notes de chaques commandes que l'on divise par la longueur de la liste de commande
         // on termine par afficher le nom du client et la moyenne des dépenses de son compte
            float sum =0;
           /* foreach(Customer client in listCustomer)
            {
                foreach (Order commande in client.ListOrder)
                {
                    sum = sum + commande.Bill;
                }
                Console.WriteLine(client.LastName + "  " + sum/client.ListOrder.Count() + " €");
            }*/
            for(int i = 0; i< listCustomer.Count(); i++)
            {
                for(int j = 0; j<listCustomer[i].ListOrder.Count(); j++)
                {
                    sum = sum + listCustomer[i].ListOrder[j].Bill;
                }
                Console.WriteLine(listCustomer[i].LastName + " " + sum/listCustomer[i].ListOrder.Count() + "€");
            }
        }

        public void RandomPizza()
        {
            // Cette fonction fait partie du module autre, elle offre une grande 
            //  pizza de la chance ainsi qu'un litre de bière au beurre à un client de façon aléatoire

            Random rnd = new Random(); //On définit un variable aléatoire
            int index = rnd.Next(listCustomer.Count());//cela nous retourne l'index dans la liste de clients du client chanceux
            Customer luckyCustomer = listCustomer[index] ;// on associe le client à son index
            Pizza luckyPizza = new Pizza("Grande","Chance",0);//On crée la pizza qui sera offerte (on ne peut l'avoir que via cette fonction)
            Beverage luckyBeverage = new Beverage("Bière au Beurre",100, 0);//On crée la bière au beurre
            List<Pizza> luckyPList = new List<Pizza>{luckyPizza};//On crée nos listes de pizza et boissons (le constructeur de commande à besoin de list pour fonctionner)
            List<Beverage> luckyBList = new List<Beverage>{luckyBeverage};
            Officer a = new Officer("Tom", "Cruise", "LosAngeles", "0101010101", "ISS", Convert.ToDateTime("2019-06-02"), 2);
            DeliveryDriver b = new DeliveryDriver("Chuck", "Norris", "Las Vegas", "0123456789", "Il vous trouvera", "Monocycle", 0);
            Order luckyOrder = new Order(Convert.ToString(globalOrderList.Count() + 1), DateTime.Now,luckyCustomer,a,b,luckyPList,luckyBList,"en préparation","en préparation",0);
            //On construit notre commande avec les arguments précédents
            luckyCustomer.ListOrder.Add(luckyOrder);// On ajoute la commande à la liste de commande de notre client
        }




        public void ReadCustomers(string file)
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
                    listCustomer.Add(new Customer(datas[0], datas[1], datas[2], datas[3]));
                }
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
                    listOfficer.Add(new Officer(datas[0], datas[1], datas[2], datas[3], datas[4], 
                        new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0])), 0));
                }
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
    }
}
