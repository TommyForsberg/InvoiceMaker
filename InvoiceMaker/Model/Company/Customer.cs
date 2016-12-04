using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Customer : Company
    {
        public Customer(string Name, string Adress) : base(Name, Adress)
        {
        }
    }
}
