using System;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class Address
    {
        [XmlElementAttribute(IsNullable = false)]
        public string Name { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string City { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string State { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string Street { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string PostalCode { get; set; }

    
    }
}
