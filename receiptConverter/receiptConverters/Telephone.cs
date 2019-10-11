using System;
using System.Collections.Generic;

namespace receiptConverters
{
    public class Telephone
    {

        private List<string> areaCode;

        public List<string> AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }

        private List<string> localNumber;

        public List<string> LocalNumber
        {
            get { return localNumber; }
            set { localNumber = value; }
        }

        private List<string> telDescription;

        public List<string> TelDescription
        {
            get { return telDescription; }
            set { telDescription = value; }
        }

    }
}

