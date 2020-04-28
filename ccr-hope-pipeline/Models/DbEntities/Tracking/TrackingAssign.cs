using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models.DbEntities.Tracking
{
    public class TrackingAssign
    {
        public List<TrackingRow> list { get; set; }
        public Guid referralClientCode { get; set; }

    }
}