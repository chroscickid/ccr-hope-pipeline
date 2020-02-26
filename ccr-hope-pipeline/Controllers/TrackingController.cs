using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Tracking;
using HopePipeline.Models.DbEntities.Meetings;
using HopePipeline.Models.Contexts;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public string connectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public ViewResult TrackingForm(int clientCode)
        {
            TrackingForm newF = new TrackingForm();
            var relRef = new referralBrandi();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            newF.ClientID = clientCode;

            string query = "select * from dbo.refform where clientCode = " + clientCode;
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            //I hate this. This is just vile 😒
            //We are basically just putting a referral in the tracking model so we
            //can autopopulate values in the tracking form
            while (reader.Read())
            {
                relRef.address = reader.GetString(reader.GetOrdinal("strAddress"));
                relRef.arrest = reader.GetInt32(reader.GetOrdinal("arrest"));
                relRef.currentSchool = reader.GetString(reader.GetOrdinal("currentSchool"));
                //relRef.date = reader.GetDateTime(reader.GetOrdinal("date"));
                //  relRef.dateInput = reader.GetDateTime(reader.GetOrdinal("dateInput"));
                relRef.dOB = reader.GetDateTime(reader.GetOrdinal("dob"));
                relRef.email = reader.GetString(reader.GetOrdinal("email"));
                relRef.fName = reader.GetString(reader.GetOrdinal("fname"));
                relRef.gender = reader.GetString(reader.GetOrdinal("gender"));
                relRef.grade = reader.GetString(reader.GetOrdinal("grade"));
                relRef.guardianEmail = reader.GetString(reader.GetOrdinal("guardianEmail"));
                relRef.guardianName = reader.GetString(reader.GetOrdinal("guardianName"));
                relRef.guardianPhone = reader.GetString(reader.GetOrdinal("guardianPhone"));
                relRef.guardianRelationship = reader.GetString(reader.GetOrdinal("guardianRelationship"));
                relRef.issues = reader.GetString(reader.GetOrdinal("issues"));
                relRef.lName = reader.GetString(reader.GetOrdinal("lname"));
                relRef.meeting = reader.GetInt32(reader.GetOrdinal("meeting"));
                relRef.moreInfo = reader.GetString(reader.GetOrdinal("moreInfo"));
                relRef.Reach = reader.GetString(reader.GetOrdinal("Reach"));
                relRef.reason = reader.GetString(reader.GetOrdinal("reason"));
                relRef.referralfname = reader.GetString(reader.GetOrdinal("referralfname"));
                relRef.referrallname = reader.GetString(reader.GetOrdinal("referrallname"));
                relRef.school = reader.GetString(reader.GetOrdinal("school"));
                relRef.status = reader.GetString(reader.GetOrdinal("currStatus"));
                relRef.youthInDuvalSchool = reader.GetInt32(reader.GetOrdinal("youthInDuvalSchool"));
                relRef.youthInSchool = reader.GetInt32(reader.GetOrdinal("youthInSchool"));
                relRef.zip = reader.GetString(reader.GetOrdinal("zip"));


            }
            reader.Close();

            //We push it into the model that gets sent to the view
            newF.referralBrandi = relRef;

            return View(newF);
        }

        [HttpPost]
        public IActionResult SubmitTracking(TrackingForm sub)
        {
            int id = sub.ClientID;
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            //Again, makes me vomit. A list of every sql command needed to 😒
            //insert a full tracking form into the database
            //Took me two weeks
            List<string> qs = new List<String>
            {
                "INSERT INTO dbo.demographics VALUES (" + id + ")",
                "INSERT INTO dbo.accomodations VALUES (" + sub.accomGained + "," + sub.compService + ",'" + sub.ifWhatServices + "'," + id + ")",
                "INSERT INTO dbo.client VALUES ('" + sub.clientLastName + "','" + sub.clientFirstName + "','" + sub.adopted + "','" + sub.clientGender + "','" + sub.clientEthnicity + "','" + sub.clientDOB + "'," + id + ",'" + sub.carePhone + "')",



                "INSERT INTO dbo.advocacy VALUES (" + sub.rearrestAdvocacy + "," + sub.courtAdvocacy + "," + sub.staffAdvocacy + "," + sub.legalAdvocacy + ",'" + sub.legalAdvoTaken + "'," + id + ")",
                "INSERT INTO dbo.altSchool VALUES (" + sub.altSchool + ",'" + sub.altSchoolName + "','" + sub.dateOfAlt + "'," + sub.timesInAlt + "," + sub.daysOwed + "," + sub.daysSinceIntake + "," + id + ")",
                "INSERT INTO dbo.bully VALUES (" + sub.bullied + "," + sub.bullyReport + ",'" + sub.dateofBully + "'," + id + ")",
                "INSERT INTO dbo.caregiver VALUES ('" + sub.careFirstName + "','" + sub.careLastName + "','" + sub.careGender + "','" + sub.careEthnicity + "'," + "'careRelationship'" + "," + id + ")",

                "INSERT dbo.ccr VALUES ('" + sub.levelOfServiceProvided + "'," + sub.caseStatus + ",'" + sub.nonEngagementReason + "'," + sub.remedyResolution + "," + sub.rearrestWhileRepresented + ",'" + sub.schoolAtClosure + "'," + id + ")",
                "INSERT INTO dbo.comp VALUES (" + sub.compService + ",'" + sub.ifWhatServices + "','" + sub.compTime + "'," + id + ")",
                //AddService?
                //Servicesgained
                "INSERT INTO dbo.currentStatus VALUES (" + sub.readingLevel + "," + sub.mathLevel + ",'" + "currentServices?" + "'," + sub.inPride + "," + sub.newFBA + "," + 0 + ",'" + "servicesGained" + "'," + id + ")",
                "INSERT INTO dbo.failed VALUES (" + sub.failedGrade + "," + sub.whichGradeFailed + "," + sub.failCount + "," + id + ")",
                "INSERT INTO dbo.health VALUES (" + sub.baker + "," + sub.marchman + "," + sub.asthma + "," + id + ")",
                "INSERT INTO dbo.household VALUES (" + sub.femHouse + "," + sub.domVio + "," + sub.adopted + "," + sub.evicted + "," + sub.incarParent + "," + sub.publicAssistance + "," + id + ")",
                //addIEP?
                "INSERT INTO dbo.iep VALUES (" + sub.iep + ",'" + sub.iepplan1 + "'','" + sub.iepplan2 + "'," + "0" + "," + id + ")",
                //otherLegal should be in the db?
                "INSERT INTO dbo.legal VALUES (" + sub.firstLegal + ",'" + sub.secondLegal + "','" + sub.justiceOutcome + "'," + id + ")",
                "INSERT INTO dbo.school (" + id + "," + sub.currentGrade + ",'" + sub.school + "','" + sub.schoolRef + "')"
            };

            //Um, this needs to be outside of that for some reason
            int totalSus = sub.iss + sub.oss;
            qs.Add("INSERT INTO dbo.suspension VALUES(" + sub.suspended + "," + sub.suspendCount + "," + totalSus + "," + sub.iss + "," + sub.oss + "," + 0 + "," + 0 + "," + id + ")");
           
            //We now just run through every string in the list, running it as a sql command
            foreach (string query in qs)
            {
                command = new SqlCommand(query, cnn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }

            cnn.Close();

            //TODO: Submitting the tracking form changes the related Referral form to closed (In the currStatus field)
            return RedirectToAction("TrackingList");
        }

        public ViewResult TrackingList()
        {
            //Very boiler-plate tracking list, just like the sql one
            var results = new List<TrackingRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode, phoneNumber FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string statusString = "";
                switch (reader.GetInt32(2))
                {
                    case 1:
                        statusString = "Open";
                        break;
                    case 0:
                        statusString = "Closed";
                        break;
                    case 2:
                        statusString = "Closed due to non-engagement";
                        break;

                }
                //We push information from the query into a row and onto the list of rows
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetInt32(3), phoneNumber = reader.GetString(4) };

                results.Add(row);
            }
            reader.Close();

            return View("TrackingList", results);
        }

        [HttpPost]
        public IActionResult AddMeeting(Meeting meet)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "INSERT INTO meetings VALUES ('" + meet.MeetingDate.ToString("yyyy-MM-dd") + "','" + meet.MeetingPurpose + "','" + meet.MeetingNotes + "'," + meet.clientCode + ")";

            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();


            return RedirectToAction("MeetingList",meet.clientCode);
        }

        public ViewResult MeetingList(int clientCode)
        {
            var results = new List<Meeting>();
            var sendme = new MeetingList();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select * from meetings where clientCode = " + clientCode;
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {               
               //We push information from the query into a row and onto the list of rows
                Meeting meet = new Meeting { MeetingDate = reader.GetDateTime(0), MeetingPurpose = reader.GetString(1), MeetingNotes = reader.GetString(2)};

                results.Add(meet);
            }
            reader.Close();

            sendme.list = results;
            query = "select clientLast, clientFirst from client where clientCode = " + clientCode;
            command = new SqlCommand(query, cnn);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                sendme.fname = reader.GetString(1);
                sendme.lname = reader.GetString(0);
                sendme.clientCode = clientCode;
               
            }
            reader.Close();



            return View("MeetingList", sendme);
        }


        [HttpPost]
        public IActionResult Search(string term)
        {

            var results = new List<TrackingRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string q1 = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode, phoneNumber FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode WHERE clientLast = '" + term + "';";
            string q2 = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode, phoneNumber FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode WHERE clientFirst = '" + term + "';";
            command = new SqlCommand(q1, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string statusString = "";
                switch (reader.GetInt32(2))
                {
                    case 1:
                        statusString = "Open";
                        break;
                    case 0:
                        statusString = "Closed";
                        break;
                    case 2:
                        statusString = "Closed due to non-engagement";
                        break;

                }
                //We push information from the query into a row and onto the list of rows
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetInt32(3), phoneNumber = reader.GetString(4) };

                results.Add(row);
            }
            reader.Close();
            command = new SqlCommand(q2, cnn);
            SqlDataReader reader2 = command.ExecuteReader();
            while (reader2.Read())
            {
                string statusString = "";
                switch (reader2.GetInt32(2))
                {
                    case 1:
                        statusString = "Open";
                        break;
                    case 0:
                        statusString = "Closed";
                        break;
                    case 2:
                        statusString = "Closed due to non-engagement";
                        break;

                }
                //We push information from the query into a row and onto the list of rows
                TrackingRow row = new TrackingRow { lname = reader2.GetString(0), fname = reader2.GetString(1), status = statusString, clientCode = reader2.GetInt32(3), phoneNumber = reader2.GetString(4) };

                results.Add(row);
            }
            reader2.Close();
            return View("TrackingList", results);
        }

        public string DeleteSqlCommand(string table, int clientCode)
        {
            string spoop = "DELETE FROM " + table + " WHERE ClientCode = " + clientCode + ";";
            return spoop;
        
        }

        public IActionResult Delete(int clientCode)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            List<string> qs = new List<String>
            {
                DeleteSqlCommand("failed", clientCode),
                DeleteSqlCommand("accomodations", clientCode),
                DeleteSqlCommand("client", clientCode),
                DeleteSqlCommand("advocacy", clientCode),
                DeleteSqlCommand("altSchool", clientCode),
                DeleteSqlCommand("bully", clientCode),
                DeleteSqlCommand("caregiver", clientCode),
                DeleteSqlCommand("ccr", clientCode),
                DeleteSqlCommand("comp", clientCode),
                DeleteSqlCommand("currentStatus", clientCode),
                DeleteSqlCommand("health", clientCode),
                DeleteSqlCommand("household", clientCode),
                DeleteSqlCommand("iep", clientCode),
                DeleteSqlCommand("legal", clientCode),
                DeleteSqlCommand("suspension", clientCode),
                DeleteSqlCommand("demographics", clientCode),

            };


            foreach (string query in qs)
            {
                command = new SqlCommand(query, cnn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }


            return RedirectToAction("TrackingList");
        }

       
        public IActionResult ChangeStatus(int clientCode, int status)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "UPDATE ccr SET ccrStatus = " + status + "WHERE clientCode = " + clientCode;
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            cnn.Close();
            return RedirectToAction("TrackingList");

        }
        public ViewResult AssignTrackingList(int clientCode)
        {
            var results = new List<TrackingRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode, phoneNumber FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string statusString = "";
                switch (reader.GetInt32(2))
                {
                    case 1:
                        statusString = "Open";
                        break;
                    case 0:
                        statusString = "Closed";
                        break;
                    case 2:
                        statusString = "Closed due to non-engagement";
                        break;

                }
                //We push information from the query into a row and onto the list of rows
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetInt32(3), phoneNumber = reader.GetString(4) };

                results.Add(row);
            }
            reader.Close();
            var mod = new TrackingAssign();
            mod.list = results;
            mod.referralClientCode = clientCode;

            return View("AssignTrackingList", mod);
        }

        public IActionResult AssignSpecific(int clientCode, int refCode)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string q1 = "INSERT INTO referral VALUES (" + refCode + "," + clientCode + ")";
            string q2 = "UPDATE refform SET currStatus = 'Closed' WHERE clientCode = " + refCode;
            command = new SqlCommand(q1, cnn);
            SqlDataReader reader = command.ExecuteReader();
            command = new SqlCommand(q2, cnn);
            reader.Close();
            reader = command.ExecuteReader();
            reader.Close();

            return RedirectToAction("RefList","Referral");

        }


        public IActionResult ViewTrackRefs(int clientCode)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            var mod = new TrackRefList();

            string q1 = "SELECT * FROM referral WHERE clientCode = " + clientCode;
            command = new SqlCommand(q1, cnn);
            SqlDataReader reader = command.ExecuteReader();
            var refCodeList = new List<int>();
            while (reader.Read())
            {
                refCodeList.Add(reader.GetInt32(0));
            }
            reader.Close();

            
            foreach(int refcode in refCodeList)
            {
                string query = "SELECT referralfname, referrallname FROM refform WHERE clientCode = " + clientCode;
                command = new SqlCommand(q1, cnn);
                SqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    var row = new TrackRefRow { firstName = reader2.GetString(0), lastName = reader2.GetString(1), refCode = reader.GetInt32(2) };
                    mod.list.Add(row);
                }
                reader2.Close();

                mod.studentName = "Placeholder";
            }

            return View("RefTrackList", mod);

        }
    }
}