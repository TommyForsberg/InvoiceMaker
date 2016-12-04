using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

using System.Net.Http;
using System.Xml;
using System.Globalization;

namespace InvoiceMaker
{
    public class USDInvoice : Invoice
    {
        public decimal ExchangeRate { get; set; }
        public USDInvoice(Customer Customer, decimal VAT, List<Service> Services, MyCompany MyCompany, int InvoiceNumber, int PaymentPeriod) : base(Customer, VAT, Services, MyCompany, InvoiceNumber, PaymentPeriod)
        {
            ExchangeRate = GetCurrencyInformation();
        }

        public decimal GetCurrencyInformation() //Downloads latest currency in xml file and harvest the value.
        {
            try
            {
                string getString;
                WebClient Wc = new WebClient();
                getString = Wc.DownloadString("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22USDSEK%22)&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(getString);

                XmlNodeList elemList = xml.GetElementsByTagName("Rate");
                string exchangeRate = elemList[0].InnerXml;

                return System.Convert.ToDecimal(exchangeRate, new CultureInfo("en-US"));
            }
            catch (WebException e) 
            {
                MessageBox.Show(e.Message);
                return 9M;
            }



        }
    }
}
