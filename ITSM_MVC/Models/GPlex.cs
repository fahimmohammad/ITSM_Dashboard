using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace itsm.parser.Model
{
    public class GPlex
    {

        public long id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime stop_time { get; set; }
        public string caller_id { get; set; }
        public string did { get; set; }
        public string ivr_enter_time { get; set; }
        public string ivr { get; set; }
        public string time_in_ivr { get; set; }
        public string ivr_language { get; set; }
        public string skill_enter_time { get; set; }
        public string skill { get; set; }
        public string hold_in_queue { get; set; }
        public string agent_id { get; set; }
        public string nick_name { get; set; }
        public string status { get; set; }
        public string service_time { get; set; }
        public string total_time { get; set; }
        public string missed_call { get; set; }
        public string disc_party { get; set; }
        public string call_id { get; set; }

    }
}
