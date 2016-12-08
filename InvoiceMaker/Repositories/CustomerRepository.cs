using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace InvoiceMaker
{
    
    class CustomerRepository
    {
        public static string LogoPath { get; private set; }
        string logoPathHolder;
        string directory;
        string customerDatabase;
        string myCompanyDataBase;
        private List<Customer> Customers { get; set; }
        public MyCompany CurrentCompany { get; private set; }

        public CustomerRepository() //Reads from database or creates a new one.
        {
           
            directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data";
            customerDatabase = String.Format("{0}{1}{2}", directory,Path.DirectorySeparatorChar, "customers.json");
            logoPathHolder = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "LogoPath.json");
            InitializeCustomersDataBase();
            InitializeMyCompanyProperties();
            InitializeLogoPath();
        }
        internal void Add(Customer newCustomer) //Checks if new customer exists in list and edits the same if present.
        {                                      //If not present, the new customer is added to list.
            var singleCust = Customers.SingleOrDefault(single => single.Name.Contains(newCustomer.Name));
            if(singleCust != null)
                singleCust.Adress = newCustomer.Adress;
            else
                Customers.Add(newCustomer);

            UpdateDataBase();
        }

        internal string[] GetStringNames() //Returns all Customer names as string array.
        {
            return Customers.Select(x => x.Name).ToArray();
        }

        internal Company GetCustomer(int selectedIndex) //Returns indexed customer.
        {
            return Customers[selectedIndex];
        }

        void UpdateDataBase() //Writes to file.
        {
        string serializedCustomers = JsonConvert.SerializeObject(Customers);
        File.WriteAllText(customerDatabase, serializedCustomers);
        }

        internal void DeleteCustomer(int selectedIndex) //Removes the customer with index from list.
        {
            Customers.RemoveAt(selectedIndex);
            UpdateDataBase();
        }

        internal void SaveMyCompany(MyCompany updatedMyCompany) //Writes to file
        {
            string mySerializedCompany = JsonConvert.SerializeObject(updatedMyCompany);
            File.WriteAllText(myCompanyDataBase, mySerializedCompany);
        }

        internal void SaveMyLogo(string newLogoPath)
        {
            LogoPath = newLogoPath;
            string serializedLogoPath = JsonConvert.SerializeObject(newLogoPath);
            File.WriteAllText(logoPathHolder, serializedLogoPath);
        }

        void InitializeLogoPath()
        {
            try
            {
                string toBeDeSerialized = File.ReadAllText(logoPathHolder);
                LogoPath = JsonConvert.DeserializeObject<string>(toBeDeSerialized);
            }
            catch (FileNotFoundException)
            {
                File.Create(logoPathHolder).Close();
                LogoPath = null;
            }
        }

        void InitializeMyCompanyProperties() //Reads from file to CurrentCompany-propertie.
        {
            try
            {
                myCompanyDataBase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "MyCompany.json");
                string toBeDeSerialized = File.ReadAllText(myCompanyDataBase);
                CurrentCompany = JsonConvert.DeserializeObject<MyCompany>(toBeDeSerialized);
            }
            catch (FileNotFoundException)
            {
                File.Create(myCompanyDataBase).Close();
                CurrentCompany = new MyCompany("Namn", "Adressfält","Bolagsinformation","Tele och mail","Giro","Bankkonto", "Iban", "bic/Swift");
            }
        } 

        void InitializeCustomersDataBase() //Reads from file to List of Customers.
        {
            try
            {
                string toBeDeSerialized = File.ReadAllText(customerDatabase);
                Customers = JsonConvert.DeserializeObject<List<Customer>>(toBeDeSerialized);
            }
            catch
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (!File.Exists(customerDatabase))
                {
                    File.Create(customerDatabase).Close();
                    if (Customers == null)
                    {
                        Customers = new List<Customer> { new Customer("DefaultCompany", "DefaultCompany") };
                    }
                    UpdateDataBase();
                }
            }
        }
    }
}
