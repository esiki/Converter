using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace receiptConverters
{
    [XmlRootAttribute("ReceiptMessage", Namespace = "http://www.cpandl.com",IsNullable = false)]
    public class ReceiptMessage
    {
        public StoreInfo Store { get; set; }
        public string ReceiptDate { get; set; }
        public Address StoreAddress { get; set; }

        public Telephone Phone { get; set; }

        [XmlArrayAttribute("Items")]
        public OrderedItem[] OrderedItems { get; set; }

        private List<string> description;

        public List<string> ReceiptDescription
        {
            get { return description; }
            set { description = value; }
        }

        public decimal SubTotalRec { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string Currency { get; set; }

        public PaymentTerminal PaymentTerminal { get; set; }

        public Tax Tax { get; set; }

    }
}
