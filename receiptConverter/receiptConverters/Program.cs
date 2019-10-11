using System;
using System.Xml;

namespace receiptConverters
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ReceiptXML start = new ReceiptXML();

            start.CreateXML("w.xml");
            //start.CreateXML("t.xml");
            //start.CreateXML("e.xml");
            //start.CreateXML("m.xml");
        }
    }
}
