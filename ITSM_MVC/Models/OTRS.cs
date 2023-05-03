using System.Net.Sockets;

namespace itsm.parser.Model
{
    public class OTRS
    {
        public long id { get; set; }
        public string ticket_number { get; set; }
        public string age { get; set; }
        public DateTime createdDate { get; set; }
        public string closed { get; set; }
        public string firstLock { get; set; }
        public string firstResponse { get; set; }
        public string state { get; set; }
        public string priority { get; set; }
        public string queue { get; set; }
        public string locks { get; set; }
        public string owner { get; set; }
        public string userFirstname { get; set; }
        public string userLastname { get; set; }
        public string customerID { get; set; }
        public string customer_name { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string accountedTime { get; set; }
        public string articleTree { get; set; }
        public string solutionInMin { get; set; }
        public string solutionDiffInMin { get; set; }
        public string firstResponseInMin { get; set; }
        public string firstResponseDiffInMin { get; set; }

    }
}
