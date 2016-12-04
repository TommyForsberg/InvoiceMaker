using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class MyCompany : Company //ska ha alla properties som det finns textrutor i form.
    {
        public string MyCompanyInfo { get; set; }
        public string ContactInfo { get; set; }
        public string Giro { get; set; }
        public string BankAccount { get; set; }
        public string IBAN { get; set; }
        public string BicSwift { get; set; }
        public MyCompany(
            string Name, string Adress, string MyCompanyInfo, string ContactInfo, 
            string Giro, string BankAccount, string IBAN, string BicSwift) : base(Name, Adress)
        {
            this.MyCompanyInfo = MyCompanyInfo;
            this.ContactInfo = ContactInfo;
            this.Giro = Giro;
            this.BankAccount = BankAccount;
            this.IBAN = IBAN;
            this.BicSwift = BicSwift;
        }

    }

    
}
