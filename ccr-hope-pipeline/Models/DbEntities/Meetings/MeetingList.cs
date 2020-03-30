using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Meetings
{
    public class Meeting
    {
        public DateTime MeetingDate { get; set; }
        public string MeetingPurpose { get; set; }
        public string MeetingNotes { get; set; }
        public Guid clientCode { get; set; }

    }

    public class MeetingList
    {
        public List<Meeting> list = new List<Meeting>();
        public string fname { get; set; }
        public string lname { get; set; }
        public Guid clientCode { get; set; }

    }
}