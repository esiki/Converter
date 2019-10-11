using System;
using System.Collections.Generic;
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
        public string Pant { get; set; }

        [XmlElementAttribute(IsNullable = false)]
        public decimal TotalAmount { get; set; }

        public void Calculate()
        {
            TotalAmount = UnitPrice * Quantity;
        }

        public void CalculateKgPrice()
        {
            TotalAmount = UnitPrice * Weight;
        }


    }
}
