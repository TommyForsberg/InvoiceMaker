using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public abstract class Company
    {
        string adress;
        string name;  
       public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (value == null)
                    name = string.Empty;
                else
                    name = value;
             }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
             set
            {
                if (value == null)
                    adress = string.Empty;
                else
                    adress= value;
            }
        }

        protected Company(string Name, string Adress)
        {
            this.Name = Name;
            this.Adress = Adress;
        }
             
    }
}
