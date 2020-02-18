using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Models.DbEntities.Reports;

namespace HopePipeline.Models.DbEntities.Reports
{
    public class ReportResults
    {
        public List<Reports.ReportRow> ResultsList {get; set;}
        public string[] field { get; set; }
    }
}
