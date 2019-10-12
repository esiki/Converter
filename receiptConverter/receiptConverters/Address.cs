using System.Xml.Serialization;

namespace receiptConverters
{
    public class Address
    {
        public Address(){}

        public Address(string name, string city, string state, string street, string postalCode)
        {
            this.Name = name;
            this.City = city;
            this.State = state;
            this.Street = street;
            this.PostalCode = postalCode;
        }

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
