using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Company
    {
       
        public string Name { get; set; }
        public string Adress { get; set;  }

        public Company(string Name, string Adress)
        {
            this.Name = Name;
            this.Adress = Adress;
        }
             
    }
}
