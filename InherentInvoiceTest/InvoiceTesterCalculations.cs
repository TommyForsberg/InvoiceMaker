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
            var company = new Company();
            Invoice invoice = new Invoice(company, vat, list, company, 1, 14);
            decimal expected = 27000;
            decimal actual = invoice.ServicesTotal();
            Assert.AreEqual(expected, actual);
         }

        [TestMethod]
        public void InvoiceVATCalculationsControll()
        {
            List<Service> list = new List<Service>
            { new Service ("test1", "2", 12000), //24 000
            new Service("test2", "3", 1000 ) }; //3000
            decimal vat = 0.25M;
            var company = new Company();
            Invoice invoice = new Invoice(company, vat, list, company, 1, 14);
            decimal expected = 27000 * 1.25M;
            decimal actual = invoice.TotalPriceIncludingVAT;
            decimal expectedVAT = 27000 * 0.25M;
            decimal actualVAT = invoice.VATAmount;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedVAT, actualVAT);
        }
        [TestMethod]
        public void ReportEngineCalculationTest()
        {
            var uSDInvoice = new USDInvoice(new Company { CompanyInfo = "default", CompanyName = "default" }, 0.0M,
             new List<Service> { new Service("USD", "2", 600) }, new Company(), 1, 14);

            List<Invoice> TestInvoice;
            TestInvoice = new List<Invoice>
            {
                new Invoice(new Company { CompanyInfo = "default", CompanyName = "default" }, 0.25M,
                new List<Service> { new Service ("SEK", "1", 12000)}, new Company(), 1,14)
             };

            TestInvoice.Add(uSDInvoice);

            Report report = new Report(TestInvoice, new DateTime(), new DateTime());
           

            var expected = 12000 + (1200 * uSDInvoice.ExchangeRate);
            var actual = report.ReportEngine(invoice => invoice.ServicesTotal(), invoice => invoice.Date >= new DateTime(2011,6,10) && invoice.Date <= new DateTime(2100,11,11));
            Assert.AreEqual(expected, actual);
        }

    }
}
