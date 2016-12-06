using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class MyCompany : Company 
    {
        public string MyCompanyInfo { get; private set; }
        public string ContactInfo { get; private set; }
        public string Giro { get; private set; }
        public string BankAccount { get; private set; }
        public string IBAN { get; private set; }
        public string BicSwift { get; private set; }
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
