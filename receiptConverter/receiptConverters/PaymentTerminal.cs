
using System.Collections.Generic;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class PaymentTerminal
    {
        public PaymentTerminal(){}

        public PaymentTerminal(string cardCompany, string cardNo, string storeID,
           string terminalID, string aid, string _ref, string tvr, string tsi)
        {
            this.CardCompany = cardCompany;
            this.CardNo = cardNo;
            this.StoreID = storeID;
            this.TerminalID = terminalID;
            this.AID = aid;
            this.REF = _ref;
            this.TVR = tvr;
            this.TSI = tsi;
        }
            //this.PaymentMode = paymentMode;
            //this.Amount = amount;
            //this.PaymentDescription = paymentDescription;, List<string> paymentDescription,, string paymentMode,string amount)

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

        [XmlElementAttribute(IsNullable = false)]
        public List<string> PaymentDescription
        {
            get { return paymentDescription; }
            set { paymentDescription = value; }
        }
    }
}

  