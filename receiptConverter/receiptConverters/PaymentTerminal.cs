using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class PaymentTerminal
    {
        [XmlElementAttribute(IsNullable = false)]
        public string PaymentMode { get; set; }
        [XmlElementAttribute(IsNullable = false)]
        public string StoreID { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string CardCompany { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string CardNo { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string AID { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string REF { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string TVR { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string TSI { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string TerminalID { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string Amount { get; set; }
        
        private List<string> paymentDescription;

        public List<string> PaymentDescription
        {
            get { return paymentDescription; }
            set { paymentDescription = value; }
        }
    }
}

  