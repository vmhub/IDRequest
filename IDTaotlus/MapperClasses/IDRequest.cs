using System;

namespace IDTaotlus.Helpers
{
    public class IDRequest
    {   /* Mapper class to hold data from IDREQUEST table.
        * Hoiab andmeid IDREQUEST table'ist.
        */
        public IDRequest() { }
        public UInt32 reqId { get; set; }
        public UInt32 owner { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public UInt32 isikukood { get; set; }
        public byte gender { get; set; }
        public string nationality { get; set; }
        public string bDay { get; set; }
        public byte[] photo { get; set; }
        public string address { get; set; }
        public string representative { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public UInt32 pin { get; set; }
        public Documents prevDoc { get; set; }
        public UInt16 delivery { get; set; }
        public byte reqState { get; set; }

    }
}
