using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker 
{
    class USDPdfDocument : SEKPdfDocument, IPdfDocument
    {
        public USDPdfDocument(Invoice Model, string LogoPath) : base(Model, LogoPath)
        {
        }
        public override void SetAllStrings()
        {
            CultureType = "en-US";
            invoiceGloss = "Invoice";
            invoiceNumberGloss = "Invoice number";
            dateGloss = "Date";
            expirationDateGloss = "Expiration date";
            specifictionGloss = "Specification";
            amountGloss = "Amount";
            priceGloss = "Price";
            sumGloss = "Sum";
            giroGloss = "Giro";
            bankAccountGloss = "Bank account";
            ibanGloss = "IBAN";
            bicSwiftGloss = "BIC/SWIFT";
            netGloss = "NET";
            vatGloss = "VAT";
            totalGloss = "TOTAL";
        }
    }
}
