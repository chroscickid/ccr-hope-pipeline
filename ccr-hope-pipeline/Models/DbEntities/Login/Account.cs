using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models.DbEntities.Login
{
    public class Account
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string Roles { get; set; }
    }
}