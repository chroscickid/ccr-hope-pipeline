using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Tracking
{
    public class TrackingRow
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string phoneNumber { get; set; }
        public int clientCode { get; set; }
    }
}
