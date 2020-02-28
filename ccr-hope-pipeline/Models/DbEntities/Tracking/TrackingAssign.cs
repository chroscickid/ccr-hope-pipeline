using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Tracking
{
    public class TrackingAssign
    {
        public List<TrackingRow> list { get; set; }
        public int referralClientCode { get; set; }
    }
}