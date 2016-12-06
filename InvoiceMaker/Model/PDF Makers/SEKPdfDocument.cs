﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace InvoiceMaker
{
    class SEKPdfDocument : IPdfDocument
    {
        public string CultureType { get; set; }
        public string invoiceGloss { get; set; }
        public string invoiceNumberGloss { get; set; }
        public string dateGloss { get; set; }
        public string expirationDateGloss { get; set; }
        public string specifictionGloss { get; set; }
        public string amountGloss { get; set; }
        public string priceGloss { get; set; }
        public string sumGloss { get; set; }
        public string giroGloss { get; set; }
        public string bankAccountGloss { get; set; }
        public string ibanGloss { get; set; }
        public string bicSwiftGloss { get; set; }
        public  string netGloss { get; set; }
        public  string vatGloss { get; set; }
        public string totalGloss { get; set; }
        public Invoice Model { get; set; }
        public string LogoPath { get; set; }
        public SEKPdfDocument(Invoice Model, string LogoPath)
        {
            SetAllStrings();
            #region Fonts
            this.Model = Model;
            this.LogoPath = LogoPath;
            Font helveticaBold16 = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD);
            Font helveticaBold42 = new Font(Font.FontFamily.HELVETICA, 42, Font.BOLD);
            Font helvetica11 = new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL);
            Font helvetica7 = new Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL);
            Font helveticaBold12 = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
            Font helvetica12 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            Font courier = new Font(Font.FontFamily.COURIER, 38, Font.NORMAL, new BaseColor(119, 136, 153));
            Font courierBold = new Font(Font.FontFamily.COURIER, 11, Font.BOLD);
            #endregion
            #region Initialize document and filepath
            // create a document object
            var doc = new Document(PageSize.A4); //define page size
            string path = Environment.CurrentDirectory; //get the current directory
            //get PdfWriter object
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(path + Path.DirectorySeparatorChar + "faktura_" + Model.InvoiceNumber + ".pdf", FileMode.Create));
            }
            catch(SystemException e)
            {
                MessageBox.Show(e.Message);
            }
            #endregion
            #region Opening document for writing and creation of upper table
            doc.Open(); //open the document for writing
            PdfPTable logoTable = new PdfPTable(1); //Upper table with logo.
            logoTable.DefaultCell.FixedHeight = 85;
            logoTable.HorizontalAlignment = 1;
            logoTable.DefaultCell.HorizontalAlignment = 1;
            logoTable.DefaultCell.BorderWidth = 0;

            Image logo;
            if (LogoPath != null)
            {
                logo = Image.GetInstance(LogoPath);
                logoTable.AddCell(logo);
            }
            else
                logoTable.AddCell("");

            logoTable.SpacingAfter = 30;
            #endregion
            #region Second table with customer specifications
            //table with customer in upper right corner
            PdfPTable customerTable = new PdfPTable(1);
            customerTable.WidthPercentage = 100;
            PdfPCell customerCell = new PdfPCell(new Phrase(Model.Customer.Adress.ToString()));
            customerCell.BorderWidth = 0;
            customerCell.HorizontalAlignment = 2;
            customerTable.AddCell(customerCell);
            #endregion
            #region third table with headlined invoice number
            //table with text headline and invoice number
            PdfPTable inVoiceNumber = new PdfPTable(1);
            inVoiceNumber.WidthPercentage = 100;
            PdfPCell inVoiceCell = new PdfPCell(new Phrase(invoiceGloss + " " + Model.InvoiceNumber, helveticaBold16));
            inVoiceCell.BorderWidth = 0;
            inVoiceCell.VerticalAlignment = 0;
            inVoiceCell.BorderWidthBottom = 1;
            inVoiceCell.FixedHeight = 30;
            inVoiceNumber.AddCell(inVoiceCell);
            #endregion
            #region table with invoicenumbers and dates
            //Table with invoicenumber and dates
            PdfPTable invoiceInformation = new PdfPTable(2);
            float[] invoiceInformationWidths = new float[] { 1f, 2f }; //Sets the width to culumns in relation to eachother
            invoiceInformation.SetWidths(invoiceInformationWidths);
            invoiceInformation.SpacingBefore = 20;
            invoiceInformation.WidthPercentage = 100;
            invoiceInformation.DefaultCell.BorderWidth = 0;
            invoiceInformation.AddCell(new Phrase(invoiceNumberGloss, helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.InvoiceNumber.ToString(), helvetica12));
            invoiceInformation.AddCell(new Phrase(dateGloss, helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.Date.ToShortDateString(), helvetica12));
            invoiceInformation.AddCell(new Phrase(expirationDateGloss, helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.Date.AddDays(Model.PaymentPeriod).ToShortDateString(), helvetica12));
            invoiceInformation.SpacingAfter = 50;
            #endregion
            #region Table with services specifications headlines and the specifications
            //Table with the specifcations of services and cost
            PdfPTable MasterServiceTable = new PdfPTable(1); //Servicetables goes in this to be fixed size.
            MasterServiceTable.DefaultCell.MinimumHeight = 80;
            MasterServiceTable.WidthPercentage = 100;
            MasterServiceTable.DefaultCell.FixedHeight = 160;
            MasterServiceTable.DefaultCell.VerticalAlignment = 2;
            MasterServiceTable.DefaultCell.BorderWidth = 0;
            PdfPTable servicesTable = new PdfPTable(4);

            servicesTable.SpacingBefore = 5;

            servicesTable.WidthPercentage = 100;
            float[] widths = new float[] { 3f, 1f, 1f, 1f }; //Sets the width to culumns in relation to eachother
            servicesTable.SetWidths(widths);
            servicesTable.DefaultCell.BorderWidth = 0;
            PdfPCell servicesDescription = new PdfPCell(new Phrase(specifictionGloss, helveticaBold16));
            servicesDescription.BorderWidth = 0;
            servicesDescription.BorderWidthBottom = 1;
            servicesDescription.FixedHeight = 30;
            PdfPCell amountOfHours = new PdfPCell(new Phrase(amountGloss, helvetica12));
            amountOfHours.BorderWidth = 0;
            amountOfHours.BorderWidthBottom = 1;
            PdfPCell pricePerHour = new PdfPCell(new Phrase(priceGloss, helvetica12));
            pricePerHour.BorderWidth = 0;
            pricePerHour.BorderWidthBottom = 1;
            PdfPCell subTotal = new PdfPCell(new Phrase(sumGloss, helvetica12));
            subTotal.BorderWidth = 0; ;
            subTotal.BorderWidthBottom = 1;

            servicesTable.AddCell(servicesDescription);
            servicesTable.AddCell(amountOfHours);
            servicesTable.AddCell(pricePerHour);
            servicesTable.AddCell(subTotal);

            foreach (var service in Model.Services)
            {
                servicesDescription = new PdfPCell(new Phrase(service.Label, helvetica12));
                servicesDescription.BorderWidth = 0;
                amountOfHours = new PdfPCell(new Phrase(service.Amount.ToString(), helvetica12));
                amountOfHours.BorderWidth = 0;
                pricePerHour = new PdfPCell(new Phrase(service.Price.ToString("C",
                  CultureInfo.CreateSpecificCulture(CultureType)), helvetica12));
                pricePerHour.BorderWidth = 0;
                subTotal = new PdfPCell(new Phrase(service.ServiceTotalWithoutVAT.ToString("C",
                  CultureInfo.CreateSpecificCulture(CultureType)), helvetica12));
                subTotal.BorderWidth = 0;
                servicesTable.AddCell(servicesDescription);
                servicesTable.AddCell(amountOfHours);
                servicesTable.AddCell(pricePerHour);
                servicesTable.AddCell(subTotal);
            }
            MasterServiceTable.AddCell(servicesTable);
            #endregion
            #region Table with totals and bank info.
            //Table with totals and the bank account information
            PdfPTable accountInfoAndtotalTable = new PdfPTable(2);
            accountInfoAndtotalTable.SpacingBefore = 80;
            accountInfoAndtotalTable.SpacingAfter = 20;
            accountInfoAndtotalTable.WidthPercentage = 100;
            accountInfoAndtotalTable.DefaultCell.BorderWidth = 0;
            accountInfoAndtotalTable.DefaultCell.FixedHeight = 120;
           

            PdfPTable subTableLeft = new PdfPTable(2);
            subTableLeft.DefaultCell.BorderWidth = 0;
            float[] subTableLeftWidths = new float[] { 2f, 5f };
            subTableLeft.SetWidths(subTableLeftWidths);
            subTableLeft.AddCell(new Phrase(
                Environment.NewLine + Environment.NewLine +Environment.NewLine + giroGloss, helvetica11));
            subTableLeft.AddCell(new Phrase(
                 Environment.NewLine + Environment.NewLine + Environment.NewLine 
                 + Model.MyCompany.Giro, helvetica11));
            subTableLeft.AddCell(new Phrase(bankAccountGloss, helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.BankAccount, helvetica11));
            subTableLeft.AddCell(new Phrase(ibanGloss, helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.IBAN, helvetica11));
            subTableLeft.AddCell(new Phrase(bicSwiftGloss, helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.BicSwift, helvetica11));


            PdfPTable subTableRight = new PdfPTable(2);
            subTableRight.DefaultCell.BackgroundColor = new BaseColor(229, 229, 229);
            subTableRight.DefaultCell.BorderWidth = 0;
            subTableRight.DefaultCell.HorizontalAlignment = 0;
            subTableRight.AddCell((new Phrase(
                Environment.NewLine + Environment.NewLine + "    "+netGloss, helvetica12)));
            subTableRight.AddCell(new Phrase(
                 Environment.NewLine + Environment.NewLine + Model.ServicesTotal().ToString("C",
                  CultureInfo.CreateSpecificCulture(CultureType)), helvetica12));//högerställ dessa fält?
            subTableRight.AddCell(new Phrase("    "+ vatGloss, helvetica12));
            subTableRight.AddCell(new Phrase(Model.VATAmount.ToString("C",
                  CultureInfo.CreateSpecificCulture(CultureType)), helvetica12));
            subTableRight.AddCell(new Phrase(
                Environment.NewLine + "   " + totalGloss, helveticaBold16));
            subTableRight.AddCell(new Phrase(Environment.NewLine + Model.TotalPriceIncludingVAT.ToString("C",
                  CultureInfo.CreateSpecificCulture(CultureType)), helveticaBold16));
            accountInfoAndtotalTable.AddCell(subTableLeft);
            accountInfoAndtotalTable.AddCell(subTableRight);
            #endregion
            #region Table with bottom border, different company info.
            //The bottom border with contact information
            PdfPTable bottomBorder = new PdfPTable(3);
            bottomBorder.DefaultCell.BorderWidth = 0;
            bottomBorder.DefaultCell.BorderWidthTop = 1;
            bottomBorder.WidthPercentage = 100;
            bottomBorder.AddCell(new Phrase(Environment.NewLine + Model.MyCompany.Adress, helvetica12));
            bottomBorder.AddCell(new Phrase(Environment.NewLine + Model.MyCompany.ContactInfo, helvetica12));
            bottomBorder.AddCell(new Phrase(Environment.NewLine + Model.MyCompany.MyCompanyInfo, helvetica12));
            #endregion
            #region Assembly of document and closure,
            //Assembly of tables on document
            doc.Add(logoTable);
            doc.Add(customerTable);
            doc.Add(inVoiceNumber);
            doc.Add(invoiceInformation);
            doc.Add(MasterServiceTable);
            doc.Add(accountInfoAndtotalTable);
            doc.Add(bottomBorder);

            //close the document
            doc.Close();
            //view the result pdf file
            System.Diagnostics.Process.Start(path + Path.DirectorySeparatorChar + "faktura_" + Model.InvoiceNumber + ".pdf");
            #endregion
        }
        public virtual void SetAllStrings()
        {
            CultureType = "se-SE";
             invoiceGloss = "Faktura";
             invoiceNumberGloss = "Fakturanummer";
             dateGloss = "Datum";
             expirationDateGloss = "Förfallodatum";
             specifictionGloss = "Specifikation";
             amountGloss = "Antal";
             priceGloss = "Pris";
             sumGloss = "Summa";
             giroGloss = "Bankgiro";
             bankAccountGloss = "Bankkonto";
             ibanGloss = "IBAN";
             bicSwiftGloss = "BIC/SWIFT";
             netGloss = "NETTO";
             vatGloss = "MOMS";
             totalGloss = "ATT BETALA";
        }

    }
}
