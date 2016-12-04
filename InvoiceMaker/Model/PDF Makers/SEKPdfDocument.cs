using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace InvoiceMaker
{
    class SEKPdfDocument
    {
        public Invoice Model { get; set; }
        public string LogoPath { get; set; }
        public SEKPdfDocument(Invoice Model, string LogoPath)
        {
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



            //define page size in user units
            //Rectangle pageSize = new Rectangle(216.0f, 720.0f);
            // create a document object
            var doc = new Document(PageSize.A4);
            //get the current directory
            string path = Environment.CurrentDirectory;
            //get PdfWriter object
            PdfWriter.GetInstance(doc, new FileStream(path + "/pdfdoc.pdf", FileMode.Create));
            //open the document for writing
            doc.Open();
            
         
            PdfPTable logoTable = new PdfPTable(1);
            logoTable.DefaultCell.FixedHeight = 85;
            logoTable.HorizontalAlignment = 1;
            logoTable.DefaultCell.HorizontalAlignment = 1;
            logoTable.DefaultCell.BorderWidth = 0;
            // logoTable.AddCell(new Phrase("JD", helveticaBold42));
            Image logo;
            if (LogoPath != null)
            {
                logo = Image.GetInstance(LogoPath);
                logoTable.AddCell(logo);
            }
            else
                logoTable.AddCell("");

            logoTable.SpacingAfter = 30;

            //PdfPTable topTable = new PdfPTable(2);
            //topTable.WidthPercentage = 100;
            //topTable.TotalWidth = PageSize.A4.Width / 2;
            ////topTable.LockedWidth = true;
            //topTable.SpacingAfter = 5;
            //topTable.SpacingBefore = 5;
            //PdfPCell cell1 = new PdfPCell(new Phrase("", courier));
            //cell1.BorderWidth = 0;
            //PdfPCell cell2 = new PdfPCell(new Phrase("Datum: " + Model.Date + Environment.NewLine + "Faktura #", helvetica7));
            //cell2.HorizontalAlignment = 2;
            //cell2.VerticalAlignment = 0;
            //cell2.BorderWidth = 0;
            //topTable.AddCell(cell1);
            //topTable.AddCell(cell2);


            //table with customer in upper right corner
            PdfPTable customerTable = new PdfPTable(1);
            customerTable.WidthPercentage = 100;
            PdfPCell customerCell = new PdfPCell(new Phrase(Model.Customer.Adress.ToString()));
            customerCell.BorderWidth = 0;
            customerCell.HorizontalAlignment = 2;
            customerTable.AddCell(customerCell);

            //table with only text "Faktura" and number
            PdfPTable inVoiceNumber = new PdfPTable(1);
            inVoiceNumber.WidthPercentage = 100;
            PdfPCell inVoiceCell = new PdfPCell(new Phrase("Faktura " + Model.InvoiceNumber, helveticaBold16));
            inVoiceCell.BorderWidth = 0;
            inVoiceCell.VerticalAlignment = 0;
            inVoiceCell.BorderWidthBottom = 1;
            inVoiceCell.FixedHeight = 30;
            inVoiceNumber.AddCell(inVoiceCell);

            //Table with invoicenumber and dates
            PdfPTable invoiceInformation = new PdfPTable(2);
            float[] invoiceInformationWidths = new float[] { 1f, 2f }; //Sets the width to culumns in relation to eachother
            invoiceInformation.SetWidths(invoiceInformationWidths);
            invoiceInformation.SpacingBefore = 20;
            invoiceInformation.WidthPercentage = 100;
            invoiceInformation.DefaultCell.BorderWidth = 0;
            invoiceInformation.AddCell(new Phrase("Fakturanummer", helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.InvoiceNumber.ToString(), helvetica12));
            invoiceInformation.AddCell(new Phrase("Datum", helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.Date.ToShortDateString(), helvetica12));
            invoiceInformation.AddCell(new Phrase("Förfallodatum", helvetica12));
            invoiceInformation.AddCell(new Phrase(Model.Date.AddDays(Model.PaymentPeriod).ToShortDateString(), helvetica12));
            invoiceInformation.SpacingAfter = 50;

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
            PdfPCell servicesDescription = new PdfPCell(new Phrase("Specifikation", helveticaBold16));
            servicesDescription.BorderWidth = 0;
            servicesDescription.BorderWidthBottom = 1;
            servicesDescription.FixedHeight = 30;
            PdfPCell amountOfHours = new PdfPCell(new Phrase("Antal", helvetica12));
            amountOfHours.BorderWidth = 0;
            amountOfHours.BorderWidthBottom = 1;
            PdfPCell pricePerHour = new PdfPCell(new Phrase("Pris", helvetica12));
            pricePerHour.BorderWidth = 0;
            pricePerHour.BorderWidthBottom = 1;
            PdfPCell subTotal = new PdfPCell(new Phrase("Summa", helvetica12));
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
                //servicesDescription.FixedHeight = 30;
                amountOfHours = new PdfPCell(new Phrase(service.Amount.ToString(), helvetica12));
                amountOfHours.BorderWidth = 0;
                pricePerHour = new PdfPCell(new Phrase(service.Price.ToString("C",
                  CultureInfo.CreateSpecificCulture("se-SE")), helvetica12));
                pricePerHour.BorderWidth = 0;
                subTotal = new PdfPCell(new Phrase(service.ServiceTotalWithoutVAT.ToString("C",
                  CultureInfo.CreateSpecificCulture("se-SE")), helvetica12));
                subTotal.BorderWidth = 0;
                servicesTable.AddCell(servicesDescription);
                servicesTable.AddCell(amountOfHours);
                servicesTable.AddCell(pricePerHour);
                servicesTable.AddCell(subTotal);
            }
            MasterServiceTable.AddCell(servicesTable);

            //Table with totals and the bank account information
            PdfPTable accountInfoAndtotalTable = new PdfPTable(2);
            accountInfoAndtotalTable.SpacingBefore = 80;
            accountInfoAndtotalTable.SpacingAfter = 20;
            accountInfoAndtotalTable.WidthPercentage = 100;
            accountInfoAndtotalTable.DefaultCell.BorderWidth = 0;
            accountInfoAndtotalTable.DefaultCell.FixedHeight = 130;
            // float[] widths2 = new float[] { 5f, 1f };
            //accountInfoAndtotalTable.SetWidths(widths2);

            PdfPTable subTableLeft = new PdfPTable(2);
            subTableLeft.DefaultCell.BorderWidth = 0;
            float[] subTableLeftWidths = new float[] { 2f, 5f };
            subTableLeft.SetWidths(subTableLeftWidths);
            subTableLeft.AddCell(new Phrase("\n\n\nBankgiro", helvetica11));
            subTableLeft.AddCell(new Phrase("\n\n\n" + Model.MyCompany.Giro, helvetica11));
            subTableLeft.AddCell(new Phrase("Bankkonto", helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.BankAccount, helvetica11));
            subTableLeft.AddCell(new Phrase("IBAN", helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.IBAN, helvetica11));
            subTableLeft.AddCell(new Phrase("BIC/SWIFT", helvetica11));
            subTableLeft.AddCell(new Phrase(Model.MyCompany.BicSwift, helvetica11));


            PdfPTable subTableRight = new PdfPTable(2);


            subTableRight.DefaultCell.BackgroundColor = new BaseColor(229, 229, 229);
            subTableRight.DefaultCell.BorderWidth = 0;
            subTableRight.DefaultCell.HorizontalAlignment = 0;
            subTableRight.AddCell((new Phrase("\n    NETTO", helvetica12)));
            subTableRight.AddCell(new Phrase("\n" + Model.ServicesTotal().ToString("C",
                  CultureInfo.CreateSpecificCulture("se-SE")), helvetica12));
            subTableRight.AddCell(new Phrase("    MOMS", helvetica12));
            subTableRight.AddCell(new Phrase(Model.VATAmount.ToString("C",
                  CultureInfo.CreateSpecificCulture("se-SE")), helvetica12));
            subTableRight.AddCell(new Phrase("    ÖRESUTJÄMNING", helvetica12));
            subTableRight.AddCell("");
            subTableRight.AddCell(new Phrase("\n   ATT BETALA", helveticaBold16));
            subTableRight.AddCell(new Phrase("\n" + Model.TotalPriceIncludingVAT.ToString("C",
                  CultureInfo.CreateSpecificCulture("se-SE")), helveticaBold16));



            accountInfoAndtotalTable.AddCell(subTableLeft);
            accountInfoAndtotalTable.AddCell(subTableRight);

            //The bottom border with contact information
            PdfPTable bottomBorder = new PdfPTable(3);
            bottomBorder.DefaultCell.BorderWidth = 0;
            bottomBorder.DefaultCell.BorderWidthTop = 1;
            bottomBorder.WidthPercentage = 100;

            //bottomBorder.AddCell(new Phrase("\nJonathan Dahl\nJakobsdalsvägen 10\n126 54 Stockholm\n SWEDEN", helvetica12));
            bottomBorder.AddCell(new Phrase("\n" + Model.MyCompany.Adress, helvetica12));

            bottomBorder.AddCell(new Phrase("\n" + Model.MyCompany.ContactInfo, helvetica12));
            bottomBorder.AddCell(new Phrase("\n" + Model.MyCompany.MyCompanyInfo, helvetica12));





           // doc.Add(topTable);
            doc.Add(logoTable);
            doc.Add(customerTable);
            doc.Add(inVoiceNumber);
            doc.Add(invoiceInformation);
            doc.Add(MasterServiceTable);
            doc.Add(accountInfoAndtotalTable);
            doc.Add(bottomBorder);




            //write a paragraph to the document


            //doc.Add(new Paragraph(Environment.NewLine));
            //doc.Add(new Paragraph(Environment.NewLine));


            //close the document
            doc.Close();
            //view the result pdf file
            System.Diagnostics.Process.Start(path + "/pdfdoc.pdf");
        }

    }
}
