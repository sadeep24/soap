using System;
using System.Collections.Generic;

namespace Sampath.SMSB.Infrastructure.Models
{
    public class Limit
    {
        public string ProviderNo { get; set; }
        public string ProviderDesc { get; set; }
        public decimal? Minamount { get; set; }
        public decimal? Maxamount { get; set; }
        public string TfrName { get; set; }
    }
}
