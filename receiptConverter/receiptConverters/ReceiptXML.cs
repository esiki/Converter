
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class ReceiptXML
    {
        List<string> receiptList;
        List<string> paymentList;
        List<string> taxList;
        List<string> telListCode;
        List<string> telListNr;
        List<string> telListDesc;
        List<decimal> procentList;

        public ReceiptXML()
        {
            this.receiptList = new List<string>();
            this.paymentList = new List<string>();
            this.taxList = new List<string>();
            this.telListDesc = new List<string>();
            this.telListCode = new List<string>();
            this.telListNr = new List<string>();
            this.procentList = new List<decimal>();
        }

        public void CreateXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReceiptMessage));

            if (filename.ToLower().Equals("willys.xml"))
            {
                #region Willys XML
                using (TextWriter writer = new StreamWriter(filename))
                {
                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo =
                        new StoreInfo("WILLY:S Hemma", "556163-2232"
                        , "41", "Sofia",null,null,null,"4/169");
                   
                    receiptMessage.Store = storeInfo;                  

                    Address a =
                        new Address("Willys Hemma",null, "Saltsjöbaden",null,null);
                    
                    receiptMessage.StoreAddress = a;

                    receiptList.Clear();
                    receiptList.Add("----------------");
                    receiptList.Add("SPARA KVITTOT");
                    receiptList.Add("Välkommen åter!");
                    receiptList.Add("Mån-Lör 8-21 Sön 9-21");
                    receiptList.Add("Du betjänades av");
                    receiptMessage.ReceiptDescription = receiptList;

                    // ========
                    OrderedItem orderedItemOne = new OrderedItem();
                    orderedItemOne.ItemName = "Mjölk";
                    orderedItemOne.UnitPrice = (decimal)12.00;
                    orderedItemOne.Quantity = (decimal)1.00;
                    orderedItemOne.Calculate();

                    OrderedItem orderedItemTwo = new OrderedItem();
                    orderedItemTwo.ItemName = "Ost";
                    orderedItemTwo.UnitPrice = (decimal)122.00;
                    orderedItemTwo.Quantity = (decimal)1.00;
                    orderedItemTwo.Calculate();

                    OrderedItem orderedItemThree = new OrderedItem();
                    orderedItemThree.ItemName = "Kvisttomater";
                    orderedItemThree.OrderDescription = "0,570kg*30,29kr/kg";
                    orderedItemThree.UnitPrice = (decimal)30.29;
                    orderedItemThree.Quantity = (decimal)1.00;
                    orderedItemThree.Weight = 0.570M;
                    orderedItemThree.Calculate();

                    // ========
                    OrderedItem[] items = { orderedItemOne, orderedItemTwo, orderedItemThree };
                    receiptMessage.OrderedItems = items;


                    // Calculate the total cost.
                    decimal subTotal = new decimal();
                    foreach (OrderedItem oi in items)
                    {
                        subTotal += oi.TotalAmount;
                    }
                    receiptMessage.SubTotalRec = subTotal;

                  

                    // ========
                    PaymentTerminal paymentTerminal =
                        new PaymentTerminal("Master Card", "***********234", "12345",
                        "2341", "A00021", "000003256", "0000048000", "E800");                   

                    // ========                    
                    paymentList.Clear();
                    paymentList.Add("KontantLös");
                    paymentList.Add("köp");
                    paymentList.Add("Personlig kod");
                    paymentTerminal.PaymentDescription = paymentList;
                    receiptMessage.PaymentTerminal = paymentTerminal;

                    Tax tax = new Tax();
                    procentList.Clear();
                    procentList.Add((decimal)0.107);
                    procentList.Add((decimal)0.2);
                    tax.Procent = procentList;

                    //=========
                    taxList.Clear();
                    taxList.Add("Moms%");
                    taxList.Add("Moms");
                    taxList.Add("Netto");
                    taxList.Add("Brutto");
                    tax.TaxDescription = taxList;

                    tax.SubTotal = subTotal;
                    tax.CalculateTaxAmount();
                    tax.CalculateNet();
                    receiptMessage.Tax = tax;

                    //======================
                    Telephone tel = new Telephone();
                    telListCode.Clear();
                    telListCode.Add("08");
                    tel.AreaCode = telListCode;

                    telListNr.Clear();
                    telListNr.Add("7480830");
                    tel.LocalNumber = telListNr;

                    telListDesc.Clear();
                    telListDesc.Add("TEL");
                    tel.TelDescription = telListDesc;
                    receiptMessage.Phone = tel;

                    receiptMessage.ReceiptDate = System.DateTime.Now.ToLongDateString();

                    serializer.Serialize(writer, receiptMessage);

                }
                #endregion
            }
            else if (filename.ToLower().Equals("tempo.xml"))
            {
                #region Tempo XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo =
                        new StoreInfo("Tempo", null, null,"Dashti", null, null, null,"1/186");

                    receiptMessage.Store = storeInfo;

                    Address a =
                        new Address(null, null, "Nacka", "Jarlaberg", null);

                    receiptMessage.StoreAddress = a;

                    receiptList.Clear();
                    receiptList.Add("----------------");
                    receiptList.Add("ÖPPET FÖR DIG!");
                    receiptList.Add("ALLA DAGAR");
                    receiptList.Add("9-20");
                    receiptList.Add("SPARA KVITTOT");
                    receiptList.Add("Välkommen åter");
                    receiptList.Add("Du betjänades av");
                    receiptMessage.ReceiptDescription = receiptList;

                    // ===========
                    OrderedItem orderedItemOne = new OrderedItem();
                    orderedItemOne.ItemName = "MJÖLK EKOLOGISK 3%";
                    orderedItemOne.UnitPrice = (decimal)14.95;
                    orderedItemOne.Quantity = (decimal)1.00;
                    orderedItemOne.Calculate();

                    //==========================================
                    OrderedItem[] items = { orderedItemOne };
                    receiptMessage.OrderedItems = items;


                    // Calculate the total cost.
                    decimal subTotal = new decimal();
                    foreach (OrderedItem oi in items)
                    {
                        subTotal += oi.TotalAmount;
                    }
                    receiptMessage.SubTotalRec = subTotal;

                    PaymentTerminal paymentTerminal =
                        new PaymentTerminal("Debit Master Card", "***********3777", "532697",
                        "1 / 00004098", "A0000000041010", "000004088429", "0000001000", "6800");

                    //===========
                    paymentList.Clear();
                    paymentList.Add("Personlig kod");
                    paymentList.Add("köp");
                    paymentTerminal.PaymentDescription = paymentList;
                    receiptMessage.PaymentTerminal = paymentTerminal;

                    Tax tax = new Tax();
                    procentList.Clear();
                    procentList.Add((decimal)0.107);
                    tax.Procent = procentList;
                    
                    taxList.Clear();
                    taxList.Add("Moms%");
                    taxList.Add("Moms");
                    taxList.Add("Netto");
                    taxList.Add("Brutto");
                    tax.TaxDescription = taxList;

                    tax.SubTotal = subTotal;
                    tax.CalculateTaxAmount();
                    tax.CalculateNet();
                    receiptMessage.Tax = tax;

                    Telephone tel = new Telephone();
                    telListCode.Clear();
                    telListCode.Add("08");
                    tel.AreaCode = telListCode;

                    telListNr.Clear();
                    telListNr.Add("718 46 66");
                    tel.LocalNumber = telListNr;
                    
                    telListDesc.Clear();
                    telListDesc.Add("TEL");
                    telListDesc.Add("FAX");
                    tel.TelDescription = telListDesc;
                    receiptMessage.Phone = tel;                

                    receiptMessage.ReceiptDate = System.DateTime.Now.ToLongDateString();

                    serializer.Serialize(writer, receiptMessage);

                }
                #endregion
            }
            else if (filename.ToLower().Equals("bookshop.xml"))
            {
                #region The English Bookshop XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo =
                        new StoreInfo("The English Bookshop","556162418",null,null
                        ,null, "info@bookshop.se", "00000000000001",null);

                    receiptMessage.Store = storeInfo;

                    Address a =
                        new Address(null, "UPPSALA",null, "SVARTBACKSGATAN 19",null);

                    receiptMessage.StoreAddress = a;

                    receiptList.Clear();
                    receiptList.Add("Visit us at www.bookshop.se");
                    receiptList.Add("----------------");
                    receiptList.Add("Öppet köp 14 dagar mot kvitto");
                    receiptList.Add("(gäller ej specialbeställning)");
                    receiptList.Add("The Uppsala English Bookshop");
                    receiptList.Add("THANK YOU FOR YOUR");
                    receiptList.Add("*** ORGINAL");
                    receiptMessage.ReceiptDescription = receiptList;

                    // ===========
                    OrderedItem orderedItemOne = new OrderedItem();
                    orderedItemOne.ItemName = "Books/Böcker";
                    orderedItemOne.UnitPrice = (decimal)430.00;
                    orderedItemOne.Quantity = (decimal)1.00;
                    orderedItemOne.OrderDescription = "T3";
                    orderedItemOne.Calculate();

                    //==========================================
                    OrderedItem[] items = { orderedItemOne };
                    receiptMessage.OrderedItems = items;


                    // Calculate the total cost.
                    decimal subTotal = new decimal();
                    foreach (OrderedItem oi in items)
                    {
                        subTotal += oi.TotalAmount;
                    }
                    receiptMessage.SubTotalRec = subTotal;

                    PaymentTerminal paymentTerminal =
                        new PaymentTerminal(null,null,null,null,null,null,null,null);

                    //===========
                    paymentList.Clear();
                    paymentList.Add("B5F30000000009913");
                    paymentList.Add("RUN NUMMER :");
                    paymentList.Add("0000000160882");
                    paymentTerminal.PaymentDescription = paymentList;
                    receiptMessage.PaymentTerminal = paymentTerminal;

                    Tax tax = new Tax();
                    procentList.Clear();
                    procentList.Add((decimal)0.039744);
                    tax.Procent = procentList;

                    taxList.Clear();
                    taxList.Add("1.00xITEMs");
                    taxList.Add("Moms3 KURS 6.000%");
                    taxList.Add("Moms3 BELLOP");
                    taxList.Add("MOMS TOTALT");
                    taxList.Add("KORT");
                    tax.TaxDescription = taxList;

                    tax.SubTotal = subTotal;
                    tax.CalculateTaxAmount();
                    tax.CalculateNet();
                    receiptMessage.Tax = tax;

                    Telephone tel = new Telephone();
                    telListCode.Clear();
                    telListCode.Add("018");
                    tel.AreaCode = telListCode;

                    telListNr.Clear();
                    telListNr.Add("10 05 10");
                    tel.LocalNumber = telListNr;

                    telListDesc.Clear();
                    telListDesc.Add("Phone");
                    tel.TelDescription = telListDesc;
                    receiptMessage.Phone = tel;

                    serializer.Serialize(writer, receiptMessage);

                }
                #endregion
            }
            else if (filename.ToLower().Equals("matboden.xml"))
            {
                #region Matboden XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo = 
                    new StoreInfo(null, "556712-8508", "121", "Andreas",
                     "003-16169 [601559]", null, null,null);
                    
                    receiptMessage.Store = storeInfo;                                     

                    Address a =
                        new Address("MATBODEN EKTORP C",null, "Nacka", "EKTORPSVÄGEN 4", "131 47");
                    
                    receiptMessage.StoreAddress = a;

                    receiptList.Clear();
                    receiptList.Add("----------------");
                    receiptList.Add("KORTKÖP");
                    receiptList.Add("TILLBAKA SEK");
                    receiptList.Add("Öppettider");
                    receiptList.Add("Mån-Lör 8-21");
                    receiptList.Add("Sön 8-20");
                    receiptList.Add("Tack och välkommen åter");
                    receiptMessage.ReceiptDescription = receiptList;

                    // ===========
                    OrderedItem orderedItemOne = new OrderedItem();
                    orderedItemOne.ItemName = "RUSH ANANAS + PANT";
                    orderedItemOne.UnitPrice = (decimal)13.95;
                    orderedItemOne.Quantity = (decimal)1.00;
                    orderedItemOne.OrderDescription = "F";
                    orderedItemOne.Pant = (decimal)1.00;
                    orderedItemOne.Calculate();

                    OrderedItem orderedItemTwo = new OrderedItem();
                    orderedItemTwo.ItemName = "RAMLÖSA CITRUS + PANT";
                    orderedItemTwo.UnitPrice = (decimal)12.95;
                    orderedItemTwo.Quantity = (decimal)1.00;
                    orderedItemTwo.OrderDescription = "F";
                    orderedItemTwo.Pant = (decimal)1.00;
                    orderedItemTwo.Calculate();

                    OrderedItem orderedItemThree = new OrderedItem();
                    orderedItemThree.ItemName = "DIGESTIVE EKO";
                    orderedItemThree.UnitPrice = (decimal)25.95;
                    orderedItemThree.Quantity = (decimal)1.00;
                    orderedItemThree.OrderDescription = null;
                    orderedItemThree.Pant = (decimal)0.00;
                    orderedItemThree.Calculate();

                    OrderedItem orderedItemFour = new OrderedItem();
                    orderedItemFour.ItemName = "RED DEVIL";
                    orderedItemFour.UnitPrice = (decimal)14.95;
                    orderedItemFour.Quantity = (decimal)4.00;
                    orderedItemFour.OrderDescription = null;
                    orderedItemFour.Pant = (decimal)0.00;
                    orderedItemFour.Discount = (decimal)5.85;
                    orderedItemFour.Calculate();
                    //==========================================
                    OrderedItem[] items = { orderedItemOne, orderedItemTwo, orderedItemThree, orderedItemFour };
                    receiptMessage.OrderedItems = items;


                    // Calculate the total cost.
                    decimal subTotal = new decimal();
                    foreach (OrderedItem oi in items)
                    {
                        subTotal += oi.TotalAmount;
                    }
                    receiptMessage.SubTotalRec = subTotal;

                    PaymentTerminal paymentTerminal =
                        new PaymentTerminal("Debit Master Card", "***********3777", "715219",
                        "3 / 61203190", "A0000000041010", "612031901527", "0000001000", "E800");

                    //===========
                    paymentList.Clear();
                    paymentList.Add("Personlig kod");
                    paymentList.Add("BELOPP GODKÄNT AV KUND");
                    paymentList.Add("SPARA KVITTOT, KUNDENS EXEMPLAR");
                    paymentTerminal.PaymentDescription = paymentList;
                    receiptMessage.PaymentTerminal = paymentTerminal;

                    Tax tax = new Tax();
                    procentList.Clear();
                    procentList.Add((decimal)0.107);
                    tax.Procent = procentList;

                    taxList.Clear();
                    taxList.Add("Moms");
                    taxList.Add("Beloop");
                    taxList.Add("Netto");
                    taxList.Add("Brutto");
                    tax.TaxDescription = taxList;

                    tax.SubTotal = subTotal;
                    tax.CalculateTaxAmount();
                    tax.CalculateNet();
                    receiptMessage.Tax = tax;

                    Telephone tel = new Telephone();
                    telListCode.Clear();
                    telListCode.Add("08");
                    tel.AreaCode = telListCode;

                    telListNr.Clear();
                    telListNr.Add("716 13 80");
                    tel.LocalNumber = telListNr;

                    telListDesc.Clear();
                    telListDesc.Add("Tel");
                    tel.TelDescription = telListDesc;
                    receiptMessage.Phone = tel;

                    receiptMessage.ReceiptDate = System.DateTime.Now.ToLongDateString();

                    serializer.Serialize(writer, receiptMessage);

                    }
                #endregion
                }
            }

        }    
}
