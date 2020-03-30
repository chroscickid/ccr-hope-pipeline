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
        public string connectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public ViewResult RefList()
        {
            var results = new List<RefRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            cnn.Open();

            string query = "select fname, lname, dob, clientCode from dbo.refform WHERE assignRef = 0;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow
                {
                    fname = reader.GetString(reader.GetOrdinal("fname")),
                    lname = reader.GetString(1),
                    dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"),
                    clientCode = reader.GetGuid(3)
                };
                results.Add(row);
            }
            reader.Close();
            cnn.Close();

            return View("RefList", results);
        }

        public IActionResult Delete(int pk)
        {
            // Super straight-forward, I think
            //We simply push a SQL command for deleting the primary key
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
        [HttpPost]
        public IActionResult Search(string term)
        {

            var results = new List<RefRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            //Two SQL queries that check the search term in both the first and last name column
            string q1 = "SELECT fname, lname, dob, clientCode from refform where fname = '" + term + "';";
            string q2 = "SELECT fname, lname, dob, clientCode from refform where lname = '" + term + "';";
            command = new SqlCommand(q1, cnn);
            SqlDataReader reader = command.ExecuteReader();
            //check first name
            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow
                {
                    fname = reader.GetString(reader.GetOrdinal("fname")),
                    lname = reader.GetString(1),
                    dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"),
                    clientCode = reader.GetGuid(3)
                };
                results.Add(row);
            }
            reader.Close();

            //check last name
            command = new SqlCommand(q2, cnn);
            SqlDataReader reader2 = command.ExecuteReader();
            while (reader2.Read())
            {
                RefRow row = new RefRow
                {
                    fname = reader.GetString(reader.GetOrdinal("fname")),
                    lname = reader.GetString(1),
                    dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"),
                    clientCode = reader.GetGuid(3)
                };
                results.Add(row);

            }
            reader2.Close();
            return View("RefList", results);
        }

        public ViewResult SeeAssigned()
        {
            //This method is used to see any referrals that have already been assigned to a tracking form
            //Basically, the same exact thing as the regular RefList, just only shows "Closed" forms
            var results = new List<RefRow>();

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            cnn.Open();

            string query = "select fname, lname, dob, clientCode from dbo.refform WHERE assignRef = 1;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow
                {
                    fname = reader.GetString(reader.GetOrdinal("fname")),
                    lname = reader.GetString(1),
                    dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"),
                    clientCode = reader.GetGuid(3)
                };
                results.Add(row);
            }
            reader.Close();
            cnn.Close();

            return View("AssignedList", results);
        }









    }
}