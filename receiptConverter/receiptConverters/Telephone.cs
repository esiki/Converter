
using System.Collections.Generic;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class Telephone
    {
        public Telephone(){}

        public Telephone(List<string> areaCode, List<string> localNumber, List<string> telDescription)
        {
            this.AreaCode = areaCode;
            this.LocalNumber = localNumber;
            this.TelDescription = telDescription;
        }

        private List<string> areaCode;

        [XmlElementAttribute(IsNullable = false)]
        public List<string> AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }

        private List<string> localNumber;

        [XmlElementAttribute(IsNullable = false)]
        public List<string> LocalNumber
        {
            get { return localNumber; }
            set { localNumber = value; }
        }

        private List<string> telDescription;

        [XmlElementAttribute(IsNullable = false)]
        public List<string> TelDescription
        {
            get { return telDescription; }
            set { telDescription = value; }
        }

    }
}

