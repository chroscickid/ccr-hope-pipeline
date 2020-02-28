using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Referrals
{
    public class Contact
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string rlname { get; set; }
        public string rfname { get; set; }
        public string guardianName { get; set; }
        public string guardianlName { get; set; }
        public string relationship { get; set; }
        public string remail { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string address { get; set; }

        public string zip { get; set; }
        public string reach { get; set; }
    }
}
