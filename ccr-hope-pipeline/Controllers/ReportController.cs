using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Reports;

namespace HopePipeline.Controllers
{
    public class ReportController : Controller
    {
        public string connectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public IActionResult GenerateReports()
        {
            // make a new SqlConnection called cnn
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            // make a string for the SQL query
            string genderQuery = "SELECT A.genderIdentity, COUNT (A.genderIdentity) FROM client A GROUP BY A.genderIdentity";

            // make a SqlCommand called command
            SqlCommand command = new SqlCommand(genderQuery, cnn);
            SqlDataReader reader = command.ExecuteReader();

            // make two thick lists
            var genderIdResults = new List<string>();
            var genderCntResults = new List<int>();
            
            // loop through reader
            while (reader.Read())
            {
                // variables from the query
                string genderIdentity = reader.GetString(0);
                int genderCount = reader.GetInt32(1);

                // append to the results arrays
                genderIdResults.Add(genderIdentity);
                genderCntResults.Add(genderCount);
            }
            reader.Close();

            ViewData["GenderIdentities"] = genderIdResults;
            ViewData["GenderCounts"] = genderCntResults;
            
            return View("GenerateReports");

            /* while (reader.Read())
             {
                 for (int i = 0; i < 5; i++)
                 {
                     string text = texts[i];
                     string field = fields[i];
                     //Since yes/no/maybe fields are represented as tinyints
                     //We wanted CCR to be able to search these in plaintext, so we convert them
                     if (checkifBool(field))
                     {
                         switch (text)
                         {
                             case "yes":
                                 text = "0";
                                 break;
                             case "no":
                                 text = "1";
                                 break;
                             case "maybe":
                                 text = "2";
                                 break;
                             default:
                                 text = null;
                                 break;
                         }
                     }
                     //We generate a SQL query using the relevant field
                     string query = "SELECT [firstname],[lastname]," + field + " FROM [TrackingTable] WHERE " + field + " = " + text;
                     command = new SqlCommand(query, cnn);
                     SqlDataReader reader = command.ExecuteReader();
                     while (reader.Read())
                     {
                         //We push information from the query into a row and onto the list of rows
                         ReportRow row = new ReportRow { fName = reader.GetString(0), lName = reader.GetString(1), releField1 = reader.GetString(2) };
                         results.Add(row);
                     }
                     reader.Close();
                 }
                 reader.Close();
             return View("TrackingList", results);
             }
             //Pushes the list and relevant field onto the results model, and sends it to the view
             ReportResults toSend = new ReportResults { ResultsList = results, field = fields};
             return View("ReportResults", toSend);
             */

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