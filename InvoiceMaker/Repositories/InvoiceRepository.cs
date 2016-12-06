using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;


namespace InvoiceMaker
{
    class InvoiceRepository
    {
        private string directory;
        private string invoicesDatabase;
        private List<Invoice> Invoices { get; set; }
        public InvoiceRepository() //Sets path for database and initialize.
        {
            directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar +"data";
            invoicesDatabase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "invoices.json");
            InitializeInvoiceDataBase();
        }

        private void Update() //Writes to file
        {
            string serializedInvoices = JsonConvert.SerializeObject(Invoices);
            File.WriteAllText(invoicesDatabase, serializedInvoices);
        }

        internal void Add(Invoice newInvoice) //Adds invoice to list in case it doesnt allready exist. 
        {
            var singleInvoice = Invoices.SingleOrDefault(single => single.InvoiceNumber.Equals(newInvoice.InvoiceNumber));
            if (singleInvoice != null)
            {
                var confirmOverwrite = MessageBox.Show("Fakturanumret finns redan i arkivet. \nErsätt befintlig?", "Faktura: " + newInvoice.InvoiceNumber, MessageBoxButtons.YesNo);
                if (confirmOverwrite == DialogResult.Yes)
                {
                    Invoices.Remove(singleInvoice);
                    Invoices.Add(newInvoice);
                }
            }
            else { Invoices.Add(newInvoice); }
            Update();
            if (newInvoice is USDInvoice)
                MessageBox.Show("Fakturan har arkiverats. Dollarvärdet sattes till: " + ((USDInvoice)newInvoice).ExchangeRate.ToString());
            else if(newInvoice is EURInvoice)
                MessageBox.Show("Fakturan har arkiverats. Eurovärdet sattes till: " + ((EURInvoice)newInvoice).ExchangeRate.ToString());
            else
                MessageBox.Show("Fakturan har arkiverats");
        }

       internal int GetNextInvoiceNumber() //Checks invoice number in last invoice of list and adds 1.
        {
            return Invoices[Invoices.Count -1].InvoiceNumber + 1;
        }

        internal int[] GetAllInvoiceNumbers() //Returns all invoice numbers as int-array
        {
            return Invoices.Select(x => x.InvoiceNumber).ToArray();
        }
        protected internal List<Invoice> FetchAllInvoices(bool fetchAllInvoices, string customer)
        {
            return fetchAllInvoices == true ? Invoices : Invoices
                .FindAll(invoice => invoice.Customer.Name.Equals(customer));
        }
       private void InitializeInvoiceDataBase() //Populates list from file
        {
            try
            {
                string toBeDeSerialized = File.ReadAllText(invoicesDatabase);
                Invoices = JsonConvert.DeserializeObject<List<Invoice>>(toBeDeSerialized);
            }
            catch
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (!File.Exists(invoicesDatabase))
                {
                    File.Create(invoicesDatabase).Close();
                    if (Invoices == null)
                    {
                        Invoices = new List<Invoice> { new Invoice(new Customer("default", "default" ), 0.0M, new List<Service>(), new MyCompany("default", "default","","","","","",""), 1,14)
                    };
                        Update();
                        MessageBox.Show("Hittade ingen databas för fakturor. En ny har skapats.");
                    }
                }
            }
        }
    }
}
