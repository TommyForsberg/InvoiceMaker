using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Report
    {
       
        public List<Invoice> SelectedInvoices { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalWithVat { get; private set; }
        public decimal VATAmount { get; private set; }
        public decimal TotalWithoutVAT { get; private set; }
        public decimal TaxesToBePaid { get; private set; }
        public decimal TotalWithVATAndTaxes { get; private set; }

        public Report(List<Invoice> SelectedInvoices, DateTime StartDate, DateTime EndDate)
        {
          
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.SelectedInvoices = SelectedInvoices;
            this.TotalWithVat = ReportEngine(invoice => invoice.TotalPriceIncludingVAT, invoice => invoice.Date >= StartDate && invoice.Date <= EndDate);//
            this.VATAmount = ReportEngine(invoice => invoice.VATAmount, invoice => invoice.Date >= StartDate && invoice.Date <= EndDate);//
            this.TotalWithoutVAT = ReportEngine(invoice => invoice.ServicesTotal(), invoice => invoice.Date >= StartDate && invoice.Date <= EndDate);
            this.TaxesToBePaid = CalculateTaxes();
            this.TotalWithVATAndTaxes = TotalWithVat + TaxesToBePaid;
        }

        decimal ReportEngine(FilterDelegate calculationFilter, Func<Invoice, bool> dateFilter) //Reportfiltering is made with func and delegate
        {
            //int invoiceCount = 0;
            //int usdInvoiceCount = 0;
            //int eurInvoiceCount = 0;
            decimal sum = 0;
            foreach (var invoice in SelectedInvoices)
            {
                if(dateFilter(invoice)) 
                {
                  
                    if (invoice is USDInvoice)
                    {
                        sum += calculationFilter(invoice) * ((USDInvoice)invoice).ExchangeRate;
                    }
                    else if (invoice is EURInvoice)
                    {
                        sum += calculationFilter(invoice) * ((EURInvoice)invoice).ExchangeRate;
                    }
                    else
                        sum += calculationFilter(invoice);
                }
            }
            return sum;
        }


        public decimal CalculateTaxes()
        {
            return TotalWithoutVAT * 0.40M;
        }

        public string ReportMessage()
        {
            return String.Format("Totalt: {0}" + 
                Environment.NewLine + "Moms: {1}"+
                Environment.NewLine +"Totalt + moms: {2}" + Environment.NewLine+
                Environment.NewLine + "Preliminär skatt:(40%) {3}" + Environment.NewLine+
                "Totalt + moms + skatt: {4}", TotalWithoutVAT.ToString("C",
                CultureInfo.CreateSpecificCulture("sv-SE")), VATAmount.ToString("C",
                CultureInfo.CreateSpecificCulture("sv-SE")), TotalWithVat.ToString("C",
                CultureInfo.CreateSpecificCulture("sv-SE")), TaxesToBePaid.ToString("C",
                CultureInfo.CreateSpecificCulture("sv-SE")), TotalWithVATAndTaxes.ToString("C",
                CultureInfo.CreateSpecificCulture("sv-SE")));
            
        }
    }
}
