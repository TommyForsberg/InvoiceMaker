using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvoiceMaker
{
     public class Service
    {
        public string Label { get; set; }
        public string Amount { get; set; }
        public decimal Price { get; set; }
        public decimal ServiceTotalWithoutVAT { get; set; }

        public Service(string Label, string Amount, decimal Price)
        {
            this.Label = Label;
            this.Amount = Amount;
            this.Price = Price;
            ServiceTotalWithoutVAT = ServiceTotalCalculator(Amount, Price);
        }
        decimal ServiceTotalCalculator(string amount, decimal price) //Since all chars are allowed in amount
        {
            decimal value;
            if (decimal.TryParse(amount, out value))
                return price * value;
            else
                return 1 * price;
        }
    }
}
