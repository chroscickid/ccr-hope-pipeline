using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccr_hope_pipeline.Models.DbEntities.Reports;

namespace ccr_hope_pipeline.Models.DbEntities.Reports
{
    public class ReportResults
    {
        public List<Reports.ReportRow> ResultsList { get; set; }
        public string[] field { get; set; }
    }
}