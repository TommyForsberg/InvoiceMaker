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
        public List<Invoice> Invoices { get; set; }

        public InvoiceRepository()
        {
            var directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar +"data";
            var invoicesDatabase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "invoices.json");

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
                        string serializedInvoices = JsonConvert.SerializeObject(Invoices);
                        File.WriteAllText(invoicesDatabase, serializedInvoices);
                        string toBeDeSerialized = File.ReadAllText(invoicesDatabase);
                        Invoices = JsonConvert.DeserializeObject<List<Invoice>>(toBeDeSerialized);
                        MessageBox.Show("Hittade ingen databas för fakturor. En ny har skapats.");
                    }
                }
            }
        }

        public void Update()
        {
            string serializedInvoices = JsonConvert.SerializeObject(Invoices);
            var directory = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data";
            var invoicesDatabase = String.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, "invoices.json");
            File.WriteAllText(invoicesDatabase, serializedInvoices);
        }

        public void Add(Invoice newInvoice) //lägger till faktura i lista om den inte redan finns
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
            if(newInvoice is EURInvoice)
                MessageBox.Show("Fakturan har arkiverats. Dollarvärdet sattes till: " + ((EURInvoice)newInvoice).ExchangeRate.ToString());
            else
                MessageBox.Show("Fakturan har arkiverats");
        }

        public int GetNextInvoiceNumber() //Checks invoice number in last invoice of list and adds 1.
        {
            return Invoices[Invoices.Count -1].InvoiceNumber + 1;
        }

        public int[] GetAllInvoiceNumbers()
        {
           // var numbers = Invoices.Select(x => x.InvoiceNumber).ToList();
            var numbers = Invoices.Select(x => x.InvoiceNumber).ToArray();
            return numbers;

        }

        public decimal ReportEngine(FilterDelegate calculationFilter, Func<Invoice, bool> dateFilter)
        {
            decimal sum = 0;
            foreach (var invoice in Invoices)
            {
                if(dateFilter(invoice))
                sum += calculationFilter(invoice);
            }
            return sum;
             
        }
        public List<Invoice> FetchAllInvoices()
        {
            return Invoices;
        }
    }

    
}
