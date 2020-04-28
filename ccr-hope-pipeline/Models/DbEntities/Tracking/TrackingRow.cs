using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models.DbEntities.Tracking
{
    public class TrackingRow
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string phoneNumber { get; set; }
        public string lastMeeting { get; set; }
        public Guid clientCode { get; set; }


    }
}
