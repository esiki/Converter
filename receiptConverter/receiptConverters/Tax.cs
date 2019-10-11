using System;
using System.Collections.Generic;

namespace receiptConverters
{
    public class Tax
    {

        private List<decimal> taxProcent;

        public List<decimal> Procent
        {
            get { return taxProcent; }
            set { taxProcent = value; }
        }

        public decimal Net { get; set; }
        public decimal TaxAmount { get; set; }

        private List<string> taxDescription;

        public List<string> TaxDescription
        {
            get { return taxDescription; }
            set { taxDescription = value; }
        }

        public decimal SubTotal { get; set; }

        public void CalculateTaxAmount()
        {
            TaxAmount = SubTotal * Procent[0];
        }

        public void CalculateNet()
        {
            Net = SubTotal - TaxAmount;
        }
    }
}
