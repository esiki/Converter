using System;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class StoreInfo
    {
        [XmlElementAttribute(IsNullable = false)]
        public string Title { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string OrgNr { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string OperatorId { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string Cashier { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string StoreName { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string ReceiptId { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string Email { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string REGID { get; set; }
    }
}
