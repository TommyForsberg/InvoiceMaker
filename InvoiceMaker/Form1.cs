using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class Form1 : Form
    {
        Manager manager = new Manager();
        CustomerRepository customerRepository = new CustomerRepository();
        InvoiceRepository invoiceRepository = new InvoiceRepository();
        string selectedLogo;
        public Form1()
        {
            InitializeComponent();
            UpdateDataSources();
        }

        void UpdateDataSources() //Refresh windows form.
        {
            listBox1.DataSource = customerRepository.GetStringNames();
            label6.Text = invoiceRepository.GetNextInvoiceNumber().ToString();
            invoiceNumberNumericUpDown.Value = invoiceRepository.GetNextInvoiceNumber();
            archiveComboBox.DataSource = invoiceRepository.GetAllInvoiceNumbers();
        }

        private void createPdfButton_Click(object sender, EventArgs e) //Initialize Pdfmaker.
        {
            SEKPdfDocument temp = new SEKPdfDocument(CompileNewInvoice(),selectedLogo);
        }

        private void fetchCustomerButton_Click(object sender, EventArgs e) //Get customer from database to Listbox.
        {
            customerTextBox.Text = customerRepository.GetCustomer(listBox1.SelectedIndex).CompanyInfo;
        }

        private void addCustomerButton_Click(object sender, EventArgs e) //Add customer to database.
        {
            if (String.IsNullOrEmpty(customerTextBox.Text.ToString()))
            {
                MessageBox.Show("Kundfältet får inte vara tomt!", "Kontrollera kundfält");
            }
            else
            {
                customerRepository.Add(manager.CreateNewCompany(customerTextBox.Lines[0].ToString(), customerTextBox.Text));
            }

            customerRepository.Update();
            UpdateDataSources();
        }
        Invoice CompileNewInvoice() //Create invoice for archive or pdf
        {
            var customer = CreateCustomerFromTextBox();
            var myCompany = CreateMyCompanyFromTextBox();
            var services = CreateListOfService();
            var vatValue = GetVatValue();
            int paymentPeriod = GetPaymentPeriod();
            int invoiceNumber = int.Parse(invoiceNumberNumericUpDown.Value.ToString());
            if(radioButtonUSD.Checked)
            return new USDInvoice(customer, vatValue, services, myCompany, invoiceNumber, paymentPeriod);
            if(radioButtonEUR.Checked)
            return new EURInvoice(customer, vatValue, services, myCompany, invoiceNumber, paymentPeriod);
            else
            return new Invoice(customer, vatValue, services, myCompany, invoiceNumber,paymentPeriod);
        }

       
        private List<Service> CreateListOfService() //Collects all data from every row in gridview.
        {
            var services = new List<Service>(); //Creates temporary list.

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string label;
                string amount;
                decimal price;
               
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                    label = dataGridView1.Rows[i].Cells[0].Value.ToString(); //Reads the description column.
                else
                    label = string.Empty;
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                    amount = dataGridView1.Rows[i].Cells[1].Value.ToString(); //Reads the amount column.
                else
                    amount = string.Empty;
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                    price = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value.ToString()); //Reads the price column and converts the value.
                else
                {
                    price = 0;
                    MessageBox.Show("Prisfältet får inte lämnas tomt. Fältet har automatiskt satts till '0'.");
                }
                    var newService = manager.CreateNewService(label, amount, price); //Sends to service-constructor.
                    services.Add(newService);
             }
            return services;
        }
        private Company CreateCustomerFromTextBox()
        {
            if (string.IsNullOrEmpty(customerTextBox.Text.ToString()))
            { return manager.CreateNewCompany(null,null); }
            else
                return new Company { CompanyName = customerTextBox.Lines[0].ToString(), CompanyInfo = customerTextBox.Text };
        }

        private Company CreateMyCompanyFromTextBox()
        {
            if (string.IsNullOrEmpty(myCompanyTextBox.Text.ToString()))
            { return manager.CreateNewCompany(null, null);

            }
            else
                return new Company { CompanyName = myCompanyTextBox.Lines[0].ToString(), CompanyInfo = myCompanyTextBox.Text };
        }

        private decimal GetVatValue() //Sets Vat-value
        {

            if (radioButtonVAT25.Checked)
                return 0.25M;
            if (radioButtonVAT6.Checked)
                return 0.6M;
            if (radioButtonVAT12.Checked)
                return 0.12M;
            if (radioButtonVAT0.Checked)
                return 0;
            else return 0.25M;
        }

        private int GetPaymentPeriod()
        {
            if (radioButton14Days.Checked)
                return 14;
            else
                return 30;
        }

        private void archiveInvoiceButton_Click(object sender, EventArgs e)
        {
            invoiceRepository.Add(CompileNewInvoice());
            UpdateDataSources();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            customerRepository.DeleteCustomer(listBox1.SelectedIndex);
            UpdateDataSources();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerTextBox.Text = customerRepository.GetCustomer(listBox1.SelectedIndex).CompanyInfo;
        }

        //private void ReportCompiler() //Version1
        //{
        //   decimal total;
        //   decimal vat;
        //   decimal totalMinusVat;
        //   DateTime startDate = startDateTimePicker.Value.Date;
        //   DateTime endDate = endDateTimePicker.Value.Date;
        //    if (filtersListBox.GetItemChecked(0))
        //        total = invoiceRepository.ReportEngine(invoice => invoice.TotalPriceIncludingVAT,invoice => invoice.Date >= startDate && invoice.Date <= endDate);
        //    else
        //        total = 0;

        //    if (filtersListBox.GetItemChecked(1))
        //        vat = invoiceRepository.ReportEngine(invoice => invoice.ServicesTotal() * invoice.VATPercentage,  invoice => invoice.Date >= startDate && invoice.Date <= endDate);
        //    else
        //        vat = 0;

        //    if (filtersListBox.GetItemChecked(3))
        //        totalMinusVat = invoiceRepository.ReportEngine(invoice => invoice.ServicesTotal(), invoice => invoice.Date >= startDate && invoice.Date <= endDate);
        //    else
        //        totalMinusVat = 0;

        //        MessageBox.Show(manager.ReportMessageBox(total,vat,totalMinusVat), "Rapport ");
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            //DelegateMethod newDel = invoiceRepository.DelegateMethod2;
            //MessageBox.Show(invoiceRepository.ReportEngine(newDel).ToString());
            //ReportCompiler();
            // ReportCompiler();
            //USDInvoice test = new USDInvoice(new Company { CompanyInfo = "default", CompanyName = "default" }, 0.0M, new List<Service>(), new Company(), 1, 14);
           // test.GetCurrencyInformation();
            
           Report report = new Report(invoiceRepository.FetchAllInvoices(), startDateTimePicker.Value.Date, endDateTimePicker.Value.Date);
          MessageBox.Show(report.ReportMessage(),"Rapport:");
        }

        private void buttonLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoChoice = new OpenFileDialog();
            logoChoice.Filter = "All Files (*.*)|*.*";

            if (logoChoice.ShowDialog() == DialogResult.OK)
                selectedLogo = logoChoice.FileName;
            else
                selectedLogo = string.Empty;
        }
    }
    }

