using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoiceMaker;
using System.Collections;
using System.Collections.Generic;

namespace InherentInvoiceTest
{
    [TestClass]
    public class InvoiceTesterCalculations
    {
        [TestMethod]
        public void ServicesCalculationControll()
        {
            string amount = "10";
            decimal price = 800;
            Service service = new Service("Testing service", amount, price);
            decimal expected = 8000;
            decimal actual = service.ServiceTotalWithoutVAT;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InvoiceServicesTotalControl()
        {
            
            List<Service> list = new List<Service>
            { new Service ("test1", "2", 12000), //24 000
            new Service("test2", "3", 1000 ) }; //3000
            decimal vat = 0.25M;
            var mycompany = new MyCompany("", "", "", "", "", "", "", ""); 
            var company = new Customer("default", "default");
            Invoice invoice = new Invoice(company, vat, list, mycompany, 1, 14);
            decimal expected = 27000;
            decimal actual = invoice.TotalPriceIncludingVAT - invoice.VATAmount;
            Assert.AreEqual(expected, actual);
         }

        [TestMethod]
        public void InvoiceVATCalculationsControll()
        {
            List<Service> list = new List<Service>
            { new Service ("test1", "2", 12000), //24 000
            new Service("test2", "3", 1000 ) }; //3000
            decimal vat = 0.25M;
            var company = new Customer("default", "default");
            var mycompany = new MyCompany("", "", "", "", "", "", "", "");
            Invoice invoice = new Invoice(company, vat, list, mycompany, 1, 14);
            decimal expected = 27000 * 1.25M;
            decimal actual = invoice.TotalPriceIncludingVAT;
            decimal expectedVAT = 27000 * 0.25M;
            decimal actualVAT = invoice.VATAmount;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedVAT, actualVAT);
        }
        [TestMethod]
        public void ReportEngineCalculationTestUSD()
        {
            var uSDInvoice = new USDInvoice(new Customer("",""), 0.0M,
             new List<Service> { new Service("USD", "1", 100) }, new MyCompany("","","","","","","",""), 1, 14);
            List<Invoice> TestInvoice;
            TestInvoice = new List<Invoice>();
            TestInvoice.Add(uSDInvoice);
            Report report = new Report(TestInvoice, new DateTime(2011, 6, 10), new DateTime(2100, 11, 11));
            var expected = 100 * uSDInvoice.ExchangeRate;
            var actual = report.TotalWithoutVAT;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReportEngineCalculationTestEUR()
        {
            var eURInvoice = new EURInvoice(new Customer("", ""), 0.0M,
            new List<Service> { new Service("EUR", "2", 600) }, new MyCompany("", "", "", "", "", "", "", ""), 1, 14);
            List<Invoice> TestInvoice;
            TestInvoice = new List<Invoice>
            {
                new Invoice(new Customer("",""), 0.25M,
                new List<Service> { new Service ("SEK", "1", 12000)}, new MyCompany("","","","","","","",""), 1,14)
             };
            TestInvoice.Add(eURInvoice);
            Report report = new Report(TestInvoice, new DateTime(2011, 6, 10), new DateTime(2100, 11, 11));
            var expected = 12000 + (1200 * eURInvoice.ExchangeRate);
            var actual = report.TotalWithoutVAT;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
      public void ReportEngineTestRegularInvoice()
        {
            var invoice = new Invoice(new Customer("", ""), 0.0M,
            new List<Service> { new Service("Reg", "1", 1000) }, new MyCompany("", "", "", "", "", "", "", ""), 1, 14);
            List<Invoice> TestInvoice;
            TestInvoice = new List<Invoice>();
            TestInvoice.Add(invoice);
            Report report = new Report(TestInvoice, new DateTime(2011, 6, 10), new DateTime(2100, 11, 11));
            var expected = 1000;
            var actual = report.TotalWithoutVAT;
            // report.TotalWithVat;
            //var actual = report.ReportEngine(invoice => invoice.ServicesTotal(), invoice => invoice.Date >= new DateTime(2011,6,10) && invoice.Date <= new DateTime(2100,11,11));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReportEngineTaxControll()
        {
            var invoice = new Invoice(new Customer("", ""), 0.25M,
            new List<Service> { new Service("Reg", "1", 1000) }, new MyCompany("", "", "", "", "", "", "", ""), 1, 14);
            List<Invoice> TestInvoice;
            TestInvoice = new List<Invoice>();
            TestInvoice.Add(invoice);
            Report report = new Report(TestInvoice, new DateTime(2011, 6, 10), new DateTime(2100, 11, 11));
            var expected = 1000 * 0.40M;
            var actual = report.TaxesToBePaid;
            Assert.AreEqual(expected, actual);
        }
    }
}
