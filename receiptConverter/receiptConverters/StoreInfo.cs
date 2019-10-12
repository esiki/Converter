
using System.Xml.Serialization;

namespace receiptConverters
{
    public class StoreInfo
    {
        public StoreInfo(){}

        public StoreInfo(string name, string orgNr, string OperatorId,
                         string cashier,string recId, string email,string regId, string deskNr)
        {
            //this.Title = title;
            this.StoreName = name;
            this.OrgNr = orgNr;
            this.OperatorId = OperatorId;
            this.Cashier = cashier;
            this.ReceiptId = recId;
            this.Email = email;
            this.REGID = regId;
            this.DeskNr = deskNr;
        }

        //[XmlElementAttribute(IsNullable = false)]
        //public string Title { get; set; }

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

        [XmlElementAttribute(IsNullable = false)]
        public string DeskNr { get; set; }
    }
}
