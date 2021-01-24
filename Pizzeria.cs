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
