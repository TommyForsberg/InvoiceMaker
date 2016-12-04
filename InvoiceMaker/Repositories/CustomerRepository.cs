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

        public List<Company> Customers { get; set; }


        public CustomerRepository() //Constructor mainly reads from database or creates a new one.
        {
            var directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data";
            var customersDatabase = String.Format("{0}{1}{2}", directory,Path.DirectorySeparatorChar, "customers.json");
            try
            {
                string toBeDeSerialized = File.ReadAllText(customersDatabase);
                Customers = JsonConvert.DeserializeObject<List<Company>>(toBeDeSerialized);
               
            }
           catch
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (!File.Exists(customersDatabase))
                {
                    File.Create(customersDatabase).Close();
                    if (Customers == null)
                    {
                        Customers = new List<Company> { new Company ("DefaultCompany",  "DefaultCompany" ) };
                    }

                    string serializedCustomers = JsonConvert.SerializeObject(Customers);
                    var customerDatabase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "customers.json");
                    File.WriteAllText(customerDatabase, serializedCustomers);
                    string toBeDeSerialized = File.ReadAllText(customersDatabase);
                    Customers = JsonConvert.DeserializeObject<List<Company>>(toBeDeSerialized);
                }
                    
            }

            
        }
        public Company[] GetAll()
        {
            return Customers.ToArray();
        }

        public void Add(Company newCustomer) //lägger till kund i lista om den inte redan finns
        {
            var singleCust = Customers.SingleOrDefault(single => single.Name.Contains(newCustomer.Name));
            if(singleCust != null)
            {
                singleCust.Adress = newCustomer.Adress;
            }
            else { Customers.Add(newCustomer); }
        }

        public string[] GetStringNames()
        {
            return Customers.Select(x => x.Name).ToArray();
        }

        public Company GetCustomer(int selectedIndex)
        {
            return Customers[selectedIndex];
        }

        public void Update()
        {
        string serializedCustomers = JsonConvert.SerializeObject(Customers);
        var directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data";
        var customerDatabase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar,"customers.json");
        File.WriteAllText(customerDatabase, serializedCustomers);
        }

        public void DeleteCustomer(int selectedIndex)
        {
            Customers.RemoveAt(selectedIndex);
            Update();
        }
    }
}
