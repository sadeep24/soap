using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class WsConnections
    {
        public string WcApp { get; set; }
        public string WcConnCode { get; set; }
        public string WcConnDesc { get; set; }
        public string WcSvrClnt { get; set; }
        public string WcRi { get; set; }
        public string WcRp { get; set; }
        public string WcLi { get; set; }
        public string WcLp { get; set; }
        public string WcTransmitPhNos { get; set; }
        public string WcExclusions1 { get; set; }
        public string WcExclusions2 { get; set; }
        public string WcActive { get; set; }
        public string WsHbSend { get; set; }
        public string WcQsmaMno { get; set; }
    }
}
