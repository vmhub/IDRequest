using System;

namespace IDTaotlus.Helpers
{
    /* Mapper class to hold data from DOCUMENTS table.
     * Hoiab andmeid DOCUMENTS table'ist.
     */
    public class Documents
    {
        public UInt32 docid { get; set; }
        public UInt32 isikukood { get; set; }
        public string docNumber { get; set; }
        public string expDate { get; set; }
        public string issDate { get; set; }
    }
}
