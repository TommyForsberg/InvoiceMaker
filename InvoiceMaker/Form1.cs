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
        CustomerRepository customerRepository = new CustomerRepository();
        InvoiceRepository invoiceRepository = new InvoiceRepository();
        string selectedLogo;
        public Form1()
        {
            InitializeComponent();
            UpdateDataSources();
            InitializeMyCompanyTextBoxes();
        }

        private void InitializeMyCompanyTextBoxes()
        {
            this.myAdressTextBox.Text = customerRepository.CurrentCompany.Adress;
            this.myCompanyTextBox.Text = customerRepository.CurrentCompany.MyCompanyInfo;
            this.contactTextBox.Text = customerRepository.CurrentCompany.ContactInfo;
            this.giroTextBox.Text = customerRepository.CurrentCompany.Giro;
            this.bankAccountTextBox.Text = customerRepository.CurrentCompany.BankAccount;
            this.ibanTextBox.Text = customerRepository.CurrentCompany.IBAN;
            this.bicSwiftTextBox.Text = customerRepository.CurrentCompany.BicSwift;
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
            IPdfDocument pdfInvoice;
            if (radioButtonUSD.Checked)
                pdfInvoice = new USDPdfDocument(CompileNewInvoice(), selectedLogo);
            else if (radioButtonEUR.Checked)
                pdfInvoice = new EURPdfDocument(CompileNewInvoice(), selectedLogo);
            else
                pdfInvoice = new SEKPdfDocument(CompileNewInvoice(), selectedLogo);
             //SEKPdfDocument temp = new SEKPdfDocument(CompileNewInvoice(),selectedLogo);
        }

        private void pushCustomerToReportButton_Click(object sender, EventArgs e) //Get customer from database to Listbox.
        {
            customerFilterTextBox.Text = customerTextBox.Lines[0];
        }

        private void addCustomerButton_Click(object sender, EventArgs e) //Add customer to database.
        {
            if (String.IsNullOrEmpty(customerTextBox.Text.ToString()))
            {
                MessageBox.Show("Kundfältet får inte vara tomt!", "Kontrollera kundfält");
            }
            else
            {
                customerRepository.Add(new Customer(customerTextBox.Lines[0].ToString(), customerTextBox.Text));
            }
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
                    var newService = new Service(label, amount, price); //Sends to service-constructor.
                    services.Add(newService);
             }
            return services;
        }
        private Customer CreateCustomerFromTextBox()
        {
            try
            {
                return new Customer(customerTextBox.Lines[0], customerTextBox.Text);
            }
            catch (IndexOutOfRangeException)
            {
                return new Customer(null, null);
            }
        }

        private MyCompany CreateMyCompanyFromTextBox()
        {
                return new MyCompany(
                    myAdressTextBox.Lines[0], myAdressTextBox.Text, myCompanyTextBox.Text, 
                    contactTextBox.Text, giroTextBox.Text, bankAccountTextBox.Text,ibanTextBox.Text,
                    bicSwiftTextBox.Text  );
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
            customerTextBox.Text = customerRepository.GetCustomer(listBox1.SelectedIndex).Adress;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bool fetchAllInvoices;
            if(customerRadioButton.Checked == true)
                fetchAllInvoices = false;
            else
                fetchAllInvoices = true;

            Report report = new Report(invoiceRepository.FetchAllInvoices(fetchAllInvoices, customerFilterTextBox.Text), startDateTimePicker.Value.Date, endDateTimePicker.Value.Date);
            MessageBox.Show(report.ReportMessage(), "Rapport:");
        }

        private void buttonLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoChoice = new OpenFileDialog();
            logoChoice.Filter = "All Files (*.*)|*.*";

            if (logoChoice.ShowDialog() == DialogResult.OK)
            {
                selectedLogo = logoChoice.FileName;
                pictureBox.ImageLocation = logoChoice.FileName;
            }
            else
                selectedLogo = string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            customerRepository.SaveMyCompany(CreateMyCompanyFromTextBox());
        }
    }
    }

