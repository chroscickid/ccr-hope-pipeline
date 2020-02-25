using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Tracking
{
    public class TrackRefList
    {
        public string studentName { get; set; }
        public List<TrackRefRow> list {get; set;}
        public int ClientCode { get; set; }
    }

    public class TrackRefRow
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int refCode { get; set; }

    }
}
