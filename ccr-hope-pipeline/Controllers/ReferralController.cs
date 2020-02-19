using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models.DbEntities.Referrals;
using HopePipeline.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HopePipeline.Controllers
{
    public class ReferralController : Controller
    {
        public string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /* public ReferralRepository repository;
         public ReferralController(ReferralRepository repo)
         {
             repository = repo;            
         }*/

        //  public ViewResult RefList() => View(repository.Referrals);

        public ViewResult RefList()
        {
            var results = new List<RefRow>();
          //  string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            cnn.Open();

            string query = "select fname, lname, dob, clientCode from dbo.refform;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow {
                    fname = reader.GetString(reader.GetOrdinal("fname")),
                    lname = reader.GetString(1),
                    dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"),
                    clientCode = reader.GetInt32(3) };
                results.Add(row);
            }
            reader.Close();
            cnn.Close();

            return View("RefList", results);
        }

        public IActionResult Delete(int pk)
        {
           // string connectionString = "placeholder";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "DELETE from dbo.refform WHERE clientCode = " + pk + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return RedirectToAction("RefList");
        }

        


        /*public IActionResult Details(int det)
         {

             return View(pK);
         }*/
        [Route("Referral/{pK:int}")]
        public IActionResult Detail(int id)
        {
            return View();
        }

  
        
    }
}
