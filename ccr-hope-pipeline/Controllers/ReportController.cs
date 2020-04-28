using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ccr_hope_pipeline.Models;
using System.Data.SqlClient;
using ccr_hope_pipeline.Models.DbEntities.Reports;

namespace ccr_hope_pipeline.Controllers
{
    public class ReportController : Controller
    {
        public string connectionString = "Server=tcp:hopes-sqlserver.database.windows.net,1433;Initial Catalog=hopes-sqldb;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
    public (List<string>, List<int>) GetData(SqlConnection cnn, string query)
        {
            // make a SqlCommand called command
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            // make thick lists
            List<string> xList = new List<string>();
            List<int> yList = new List<int>();

            // loop through reader
            while (reader.Read())
            {
                // variables from the query
                string xValue = reader.GetString(0);
                int yValue = reader.GetInt32(1);

                // append to the results arrays
                xList.Add(xValue);
                yList.Add(yValue);
            }
            reader.Close();

            return (xList, yList);
        }

        public IActionResult GenerateReports()
        {
            // make a new SqlConnection called cnn
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            // gender (client and referral)*
            string genderQuery = "SELECT A.genderIdentity, COUNT (A.genderIdentity) FROM client A GROUP BY A.genderIdentity;";
            (List<string> genderIdResults, List<int> genderCntResults) = GetData(cnn, genderQuery);
            ViewData["GenderIdentities"] = genderIdResults;
            ViewData["GenderCounts"] = genderCntResults;
            
            string refGenQuery = "SELECT B.gender, COUNT (B.gender) FROM refform B GROUP BY  B.gender HAVING B.gender IS NOT NULL";
            (List<string> refGenResults, List<int> refGenCntResults) = GetData(cnn, refGenQuery);
            ViewData["RefGenResults"] = refGenResults;
            ViewData["RefGenCntResults"] = refGenCntResults;

            // race (client)
            string raceQuery = "SELECT C.ethnicity, COUNT (C.ethnicity) FROM client C GROUP BY C.ethnicity";
            (List<string> raceResults, List<int> raceCntResults) = GetData(cnn, raceQuery);
            ViewData["Ethnicities"] = raceResults;
            ViewData["EthnicityCounts"] = raceCntResults;

            //ref. educational issue: failed a grade (failed), alternative school, baker acted (health table), suspended 3 times in a year (suspension), not in school, iep/504 (iep)
            //  SELECT D.issues, COUNT (D.issues) FROM refform D GROUP BY D.issues


            // adverse childhood experience (client and referral)*: femme led household, domestic violence, baker act, adoption, relative caretaker, eviction
            //SELECT COUNT (E.femLed) AS total, SUM (E.femLed) AS femLed, SUM (E.domVio) AS domVio, SUM (E.adopted) AS adopted, SUM (E.evicted) AS evicted, SUM (F.bakerActed) AS bakerActed
            //FROM household E
            // INNER JOIN health F
            //  ON E.clientCode = F.clientCode
            //SELECT G.genderIdentity, COUNT (G.genderIdentity) FROM caregiver G GROUP BY G.genderIdentity (can be fed through getdata)

            // advo outcome: add. behavioral support, add. learning support, re-renrolled, grade adjustment, inital eligibility determination, pending elig. determ., complete re-evaulation, updated iep, placement change, graduated, direct referral for litigation, information

            return View("GenerateReports");
        }

        public static bool checkifBool(string field)
        {
            //type up every element that should be a boolean (tinyint) here
            return false;
        }

        public FileResult ExportDB()
        {

            byte[] excelSheet = System.IO.File.ReadAllBytes("../HopePipeline/wwwroot/lib/hopetracking.xlsx");
            string fileName = "hopetracking.xlsx";
            return File(excelSheet, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}