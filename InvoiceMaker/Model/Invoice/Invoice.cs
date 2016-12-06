using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
   public class Invoice
    {
       public DateTime Date { get; private set; }
       public MyCompany MyCompany { get; private set; }
       public Customer Customer { get; private set; }
       public List<Service> Services { get; private set; }
       public decimal VATPercentage { get; private set; }
       public decimal VATAmount { get; private set; }
       public int InvoiceNumber { get; private set; }
       public int PaymentPeriod { get; private set; }
       public decimal TotalPriceIncludingVAT { get; private set; }
       protected bool ControllCalculation { get; set; }


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

        internal decimal ServicesTotal() //Calculates all services in List of services.
        {
            decimal ServicesTotal = 0;
            foreach(var service in Services)
            {
                ServicesTotal += service.ServiceTotalWithoutVAT;
            }
            return ServicesTotal;
        }

        private decimal VATCalculator() //Returns total with VAT
        {
            return ServicesTotal() * VATPercentage;
        }

        protected bool Controll() //will be removed
        {
            if (TotalPriceIncludingVAT == ServicesTotal() + VATAmount && TotalPriceIncludingVAT - VATAmount == ServicesTotal() && ServicesTotal() * VATPercentage == VATAmount)
                return true;
            else
                return false;
        }
    }


}
