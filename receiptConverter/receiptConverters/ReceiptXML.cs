using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace receiptConverters
{
    public class ReceiptXML
    {
        List<string> receiptList;
        List<string> paymentList;
        List<decimal> procentList;
        List<string> taxList;
        List<string> telListCode;
        List<string> telListNr;
        List<string> telListDesc;

        public ReceiptXML()
        {
            this.receiptList = new List<string>();
            this.paymentList = new List<string>();
            this.procentList = new List<decimal>();
            this.taxList = new List<string>();
            this.telListCode = new List<string>();
            this.telListNr = new List<string>();
            this.telListDesc = new List<string>();
        }

        public void CreateXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReceiptMessage));

            if (filename.ToLower().Equals("w.xml"))
            {
                #region Willys XML
                using (TextWriter writer = new StreamWriter(filename))
                {
                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo = new StoreInfo();
                    storeInfo.Title = "WILLY:S Hemma";
                    storeInfo.OperatorId = "41";
                    storeInfo.Cashier = "Sofia";
                    receiptMessage.Store = storeInfo;

                    Address a = new Address();
                    a.Name = "Willys Hemma";
                    a.Street = null;
                    a.City = null;
                    a.State = "Saltsjöbaden";
                    a.PostalCode = null;
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
                    PaymentTerminal paymentTerminal = new PaymentTerminal();
                    paymentTerminal.CardCompany = "Master Card";
                    paymentTerminal.CardNo = "***********234";
                    paymentTerminal.StoreID = "12345";
                    paymentTerminal.TerminalID = "2341";
                    paymentTerminal.AID = "A00021";
                    paymentTerminal.REF = "000003256";
                    paymentTerminal.TVR = "0000048000";
                    paymentTerminal.TSI = "E800";

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
                    telListNr.Add("7480830");
                    tel.LocalNumber = telListNr;
                    telListDesc.Add("TEL");
                    tel.TelDescription = telListDesc;
                    receiptMessage.Phone = tel;

                    receiptMessage.ReceiptDate = System.DateTime.Now.ToLongDateString();

                    serializer.Serialize(writer, receiptMessage);

                }
                #endregion
            }
            else if (filename.ToLower().Equals("t.xml"))
            {
                #region Tempo XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo = new StoreInfo();
                    storeInfo.Title = "Tempo";
                    storeInfo.Cashier = "Dashti";
                    receiptMessage.Store = storeInfo;

                    Address a = new Address();
                    a.Name = null;
                    a.Street = "Jarlaberg";
                    a.City = null;
                    a.State = "Nacka";
                    a.PostalCode = null;
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

                    PaymentTerminal paymentTerminal = new PaymentTerminal();
                    paymentTerminal.CardCompany = "Debit Master Card";
                    paymentTerminal.CardNo = "***********3777";
                    paymentTerminal.StoreID = "532697";
                    paymentTerminal.TerminalID = "1 / 00004098";
                    paymentTerminal.AID = "A0000000041010";
                    paymentTerminal.REF = "000004088429";
                    paymentTerminal.TVR = "0000001000";
                    paymentTerminal.TSI = "6800";

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
            else if (filename.ToLower().Equals("e.xml"))
            {
                #region The English Bookshop XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo = new StoreInfo();
                    storeInfo.Title = "The English Bookshop";
                    storeInfo.Email = "info@bookshop.se";
                    storeInfo.OrgNr = "556162418";
                    storeInfo.REGID = "00000000000001";
                    receiptMessage.Store = storeInfo;

                    Address a = new Address();
                    a.Name = null;
                    a.Street = "SVARTBACKSGATAN 19";
                    a.City = "UPPSALA";
                    a.State = null;
                    a.PostalCode = null;
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

                    PaymentTerminal paymentTerminal = new PaymentTerminal();
                    paymentTerminal.CardCompany = null;
                    paymentTerminal.CardNo = null;
                    paymentTerminal.StoreID = null;
                    paymentTerminal.TerminalID = null;
                    paymentTerminal.AID = null;
                    paymentTerminal.REF = null;
                    paymentTerminal.TVR = null;
                    paymentTerminal.TSI = null;

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
            else if (filename.ToLower().Equals("m.xml"))
            {
                #region Matboden XML
                using (TextWriter writer = new StreamWriter(filename))
                {

                    ReceiptMessage receiptMessage = new ReceiptMessage();

                    StoreInfo storeInfo = new StoreInfo();
                    storeInfo.Title = null;
                    storeInfo.OperatorId = "121";
                    storeInfo.Cashier = "Andreas";
                    storeInfo.ReceiptId = "003-16169 [601559]";
                    storeInfo.OrgNr = "556712-8508";
                    receiptMessage.Store = storeInfo;

                    Address a = new Address();
                    a.Name = "MATBOODEN EKTORP C";
                    a.Street = "EKTORPSVÄGEN 4";
                    a.City = null;
                    a.State = "Nacka";
                    a.PostalCode = "131 47";
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
                    orderedItemOne.Pant = "1.00";
                    orderedItemOne.Calculate();

                    OrderedItem orderedItemTwo = new OrderedItem();
                    orderedItemTwo.ItemName = "RAMLÖSA CITRUS + PANT";
                    orderedItemTwo.UnitPrice = (decimal)12.95;
                    orderedItemTwo.Quantity = (decimal)1.00;
                    orderedItemTwo.OrderDescription = "F";
                    orderedItemTwo.Pant = "1.00";
                    orderedItemTwo.Calculate();

                    OrderedItem orderedItemThree = new OrderedItem();
                    orderedItemThree.ItemName = "DIGESTIVE EKO";
                    orderedItemThree.UnitPrice = (decimal)25.95;
                    orderedItemThree.Quantity = (decimal)1.00;
                    orderedItemThree.OrderDescription = null;
                    orderedItemThree.Pant = null;
                    orderedItemThree.Calculate();

                    OrderedItem orderedItemFour = new OrderedItem();
                    orderedItemFour.ItemName = "RED DEVIL";
                    orderedItemFour.UnitPrice = (decimal)14.95;
                    orderedItemFour.Quantity = (decimal)4.00;
                    orderedItemFour.OrderDescription = null;
                    orderedItemFour.Pant = null;
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

                    PaymentTerminal paymentTerminal = new PaymentTerminal();
                    paymentTerminal.CardCompany = "Debit Master Card";
                    paymentTerminal.CardNo = "***********3777";
                    paymentTerminal.StoreID = "715219";
                    paymentTerminal.TerminalID = "3 / 61203190";
                    paymentTerminal.AID = "A0000000041010";
                    paymentTerminal.REF = "612031901527";
                    paymentTerminal.TVR = "0000001000";
                    paymentTerminal.TSI = "E800";

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
