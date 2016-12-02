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


        public CustomerRepository()
        {
            
            var directory = Environment.CurrentDirectory;
            var customersDatabase = String.Format("{0}{1}", directory, "\\customers.json");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(customersDatabase))
                File.Create(customersDatabase);

            // Customers = new List<Company> { new Company { CompanyInfo = "Sten-Sture Andersson", CompanyName = "Sten-Sture Andersson" } };
            //string serializedProducts = JsonConvert.SerializeObject(Customers);
            // File.WriteAllText(customersDatabase, serializedProducts);
            string toBeDeSerialized = File.ReadAllText(customersDatabase);
            Customers = JsonConvert.DeserializeObject<List<Company>>(toBeDeSerialized);

            if(Customers == null)
            {
            Customers = new List<Company> { new Company { CompanyInfo = "DefaultCompany", CompanyName = "DefaultCompany" } };
            }
        }
        public Company[] GetAll()
        {
            return Customers.ToArray();
        }

        public void Add(Company newCustomer) //lägger till kund i lista om den inte redan finns
        {
            var singleCust = Customers.SingleOrDefault(single => single.CompanyName.Contains(newCustomer.CompanyName));
            if(singleCust != null)
            {
                singleCust.CompanyInfo = newCustomer.CompanyInfo;
            }
            else { Customers.Add(newCustomer); }
        }

        public string[] GetStringNames()
        {
            return Customers.Select(x => x.CompanyName).ToArray();
        }

        public Company GetCustomer(int selectedIndex)
        {
            return Customers[selectedIndex];
        }

        public void Update()
        {
        string serializedCustomers = JsonConvert.SerializeObject(Customers);
        var directory = Environment.CurrentDirectory;
        var customerDatabase = String.Format("{0}{1}", directory, "\\customers.json");
        File.WriteAllText(customerDatabase, serializedCustomers);
        }

        public void DeleteCustomer(int selectedIndex)
        {
            Customers.RemoveAt(selectedIndex);
            Update();
        }
    }
}
