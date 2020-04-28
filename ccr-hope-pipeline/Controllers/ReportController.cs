using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Reports;
using CsvHelper;


namespace HopePipeline.Controllers
{
    public class ReportController : Controller
    {
        public string connectionString = "Server=tcp:hopes-sqlserver.database.windows.net,1433;Initial Catalog=hopes-sqldb;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //This doesn't actually generate reports! This just calls the form
        public IActionResult GenerateReports()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ViewReports(ReportForm genReport)
        {
            var results = new List<ReportRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            List<string> fields = new List<string>();
            List<string> text = new List<string>();

            //there must be a more practical way of dong this
            if (genReport.field1 == null)
            {
                return View("Index");
            }
            else
            {
                fields.Add(genReport.field1);
                text.Add(genReport.text1);
            }
            if (genReport.field2 != null)
            {
                fields.Add(genReport.field2);
                text.Add(genReport.text2);
            }
            if (genReport.field3 != null)
            {
                fields.Add(genReport.field3);
                text.Add(genReport.text3);
            }
            if (genReport.field4 != null)
            {
                fields.Add(genReport.field4);
                text.Add(genReport.text4);
            }
            if (genReport.field5 != null)
            {
                fields.Add(genReport.field5);
                text.Add(genReport.text5);
            }

            int count = 0;
            foreach (var field in fields)
            {
                if (text[count] != null)
                {
                    string query = "SELECT clientLast, clientFirst FROM ??? WHERE " + field + " = " + text[count];
                    command = new SqlCommand(query, cnn);
                    SqlDataReader reader = command.ExecuteReader();



                    while (reader.Read())
                    {
                        ReportRow row = new ReportRow { fName = reader.GetString(0), lName = reader.GetString(1) };

                        results.Add(row);
                    }
                    reader.Close();
                }



            }
            return View("ViewReports", results);


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