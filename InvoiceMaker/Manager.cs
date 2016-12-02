﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class Manager
    {

        public Company CreateNewCompany(string Name, string Info)
        {
            if (Name == null)
                Name = string.Empty;
            if (Info == null)
                Info = string.Empty;

            return new Company { CompanyName = Name, CompanyInfo = Info };
        }

        public Service CreateNewService(string label, string amount, decimal price)
        {
            return new Service(label, amount, price);
        }

        public string ReportMessageBox(decimal total, decimal vatAmount, decimal totalMinusVat)
        {
            return String.Format("Totalt: {0}\nMoms: {1}\nUtan moms: {2}", total.ToString("N1",
                  CultureInfo.CreateSpecificCulture("sv-SE")),  vatAmount.ToString("N1",
                  CultureInfo.CreateSpecificCulture("sv-SE")), totalMinusVat.ToString("N1",
                  CultureInfo.CreateSpecificCulture("sv-SE")));
        }
    }
}