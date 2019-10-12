using System.Xml.Serialization;

namespace receiptConverters
{
    public class OrderedItem
    {        
        [XmlElementAttribute(IsNullable = false)]
        public string ItemName { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public string OrderDescription { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal UnitPrice { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal Quantity { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal Weight { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal Pant { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal Discount { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal TotalAmount { get; set; }

        public void Calculate()
        {
            TotalAmount = ((UnitPrice + Pant) * Quantity) - Discount;
        }

        public void CalculateKgPrice()
        {
            TotalAmount = UnitPrice * Weight;
        }


    }
}
