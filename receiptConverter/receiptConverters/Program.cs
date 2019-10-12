
namespace receiptConverters
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ReceiptXML start = new ReceiptXML();

            start.CreateXML("willys.xml");
            start.CreateXML("tempo.xml");
            start.CreateXML("bookshop.xml");
            start.CreateXML("matboden.xml");
        }
    }
}
