using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
   public class Invoice
    {
       public DateTime Date { get; set; }
       public MyCompany MyCompany { get; set; }
       public Customer Customer { get; set; }
       public List<Service> Services { get; set; }
       public  decimal VATPercentage { get; set; }
       public decimal VATAmount { get; set; }
       public int InvoiceNumber { get; set; }
        public int PaymentPeriod { get; set; }
        public decimal TotalPriceIncludingVAT { get; set; }
       public bool ControllCalculation { get; set; }


        public Invoice(Customer Customer,decimal VAT, List<Service> Services, MyCompany MyCompany, int InvoiceNumber, int PaymentPeriod)
        {
            this.MyCompany = MyCompany;
            this.VATPercentage = VAT;
            this.InvoiceNumber = InvoiceNumber;
            this.Services = Services;
            this.TotalPriceIncludingVAT = (ServicesTotal() * VATPercentage)+ServicesTotal();
            this.Date = DateTime.Today.Date;
            this.Customer = Customer;
            this.VATAmount = VATCalculator();
            this.ControllCalculation = Controll();
            this.PaymentPeriod = PaymentPeriod;
            
        }

        public decimal ServicesTotal()
        {
            decimal ServicesTotal = 0;
            foreach(var service in Services)
            {
                ServicesTotal += service.ServiceTotalWithoutVAT;
            }
            return ServicesTotal;
        }

        protected decimal VATCalculator()
        {
            return ServicesTotal() * VATPercentage;
        }

        protected bool Controll()
        {
            if (TotalPriceIncludingVAT == ServicesTotal() + VATAmount && TotalPriceIncludingVAT - VATAmount == ServicesTotal() && ServicesTotal() * VATPercentage == VATAmount)
                return true;
            else
                return false;
        }
    }


}
