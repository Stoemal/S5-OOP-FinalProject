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
        public List<Order> GlobalOrderList
        {
            get { return this.globalOrderList; }
            set { this.globalOrderList = value; }
        }
        #endregion Accesseurs


        /// <summary>
        /// Permet de lire les fichiers Clients, Commis, Livreur et Commande
        /// </summary>
        /// <param name="file"> Emplacement du fichier </param>
        public delegate void ReadFiles(string file);

        public void AddFilesData(ReadFiles n, string file)
        {
            n(file);
        }


        #region Module Client
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
                    listCustomer.Add(new Customer(datas[1], datas[0], datas[2], datas[3]));
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


        #region Module Commande

        public void ReadOrder(string file)
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
                    temp = datas[2].Split('/');

                    Customer c = null;                   
                    if (listCustomer == null || listCustomer.Count() == 0);
                    else
                    {
                        for(int i = 0; i < listCustomer.Count() && c == null; i++)
                        {
                            if (datas[3] == listCustomer[i].PhoneNumber) c = listCustomer[i];
                        }
                    }

                    Officer o = null;
                    if (listOfficer == null || listOfficer.Count() == 0);
                    else
                    {
                        for (int i = 0; i < listOfficer.Count() && o == null; i++)
                        {
                            if (datas[4].ToUpper() == listOfficer[i].LastName.ToUpper()) o = listOfficer[i];
                        }
                    }

                    DeliveryDriver d = null;
                    if (listDeliveryDriver == null || listDeliveryDriver.Count() == 0) ;
                    else
                    {
                        for (int i = 0; i < listDeliveryDriver.Count() && d == null; i++)
                        {
                            if (datas[5].ToUpper() == listDeliveryDriver[i].LastName.ToUpper()) d = listDeliveryDriver[i];
                           
                        }
                    }

                    
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

        public void ReadDetailsOrder(string file)
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


                    //if(datas[3] != "") Console.WriteLine(datas[3]);

                    /*
                    Customer c = null;
                    if (listCustomer == null || listCustomer.Count() == 0) ;
                    else
                    {
                        for (int i = 0; i < listCustomer.Count() && c == null; i++)
                        {
                            if (datas[3] == listCustomer[i].PhoneNumber) c = listCustomer[i];
                        }
                    }
                    */

                    //globalOrderList.Add(new Order(datas[0],
                    //    new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]),
                    //    Convert.ToInt32(datas[1]), 0, 0), c, o, d, datas[6], datas[7]));
                    //listDeliveryDriver.Add(new DeliveryDriver(datas[0], d4atas[1], datas[2], datas[3], datas[4], datas[5], 0));
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
