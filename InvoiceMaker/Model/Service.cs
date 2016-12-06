using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvoiceMaker
{
     public class Service
    {
        public string Label { get; private set; }
        public string Amount { get; private set; }
        public decimal Price { get; private set; }
        public decimal ServiceTotalWithoutVAT { get; private set; }

        public Service(string Label, string Amount, decimal Price)
        {
            this.Label = Label;
            this.Amount = Amount;
            this.Price = Price;
            ServiceTotalWithoutVAT = ServiceTotalCalculator(Amount, Price);
        }
        private decimal ServiceTotalCalculator(string amount, decimal price) //Since all chars are allowed in amount, it need to be parsed.
        {
            decimal value;
            if (decimal.TryParse(amount, out value))
                return price * value;
            else
                return 1 * price;
        }
    }
}
