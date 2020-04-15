using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Tracking;
using HopePipeline.Models.DbEntities.Meetings;
using HopePipeline.Models.DbEntities.Referrals;
using HopePipeline.Models.Contexts;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public string connectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public ViewResult TrackingForm(Guid clientCode)
        {
            TrackingForm newF = new TrackingForm();
            var relRef = new referralBrandi();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            newF.ClientID = clientCode;

            string query = "select * from dbo.refform where clientCode = '" + clientCode + "'";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            //I hate this. This is just vile 😒
            //We are basically just putting a referral in the tracking model so we
            //can autopopulate values in the tracking form
          
                while (reader.Read())
                {
                   relRef.address = reader.GetString(reader.GetOrdinal("strAddress"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("moreInfo")))
                        relRef.moreInfo = reader.GetString(reader.GetOrdinal("moreInfo"));
                    
                  if(!reader.IsDBNull(reader.GetOrdinal("arrest"))) 
                    relRef.arrest = reader.GetInt32(reader.GetOrdinal("arrest"));
                   
                  if(!reader.IsDBNull(reader.GetOrdinal("currentSchool")))
                    relRef.currentSchool = reader.GetString(reader.GetOrdinal("currentSchool"));
                  if(!reader.IsDBNull(reader.GetOrdinal("dob")))
                    relRef.dOB = reader.GetDateTime(reader.GetOrdinal("dob"));
                  if(!reader.IsDBNull(reader.GetOrdinal("email")))
                    relRef.email = reader.GetString(reader.GetOrdinal("email"));
                  if(!reader.IsDBNull(reader.GetOrdinal("fname")))
                    relRef.fName = reader.GetString(reader.GetOrdinal("fname"));
                  if(!reader.IsDBNull(reader.GetOrdinal("gender")))
                    relRef.gender = reader.GetString(reader.GetOrdinal("gender"));
                  if (!reader.IsDBNull(reader.GetOrdinal("grade")))                    
                        relRef.guardianEmail = reader.GetString(reader.GetOrdinal("grade"));                    
                 if (!reader.IsDBNull(reader.GetOrdinal("guardianEmail")))
                        relRef.guardianEmail = reader.GetString(reader.GetOrdinal("guardianEmail"));
                    if (!reader.IsDBNull(reader.GetOrdinal("guardianName")))
                        relRef.guardianName = reader.GetString(reader.GetOrdinal("guardianName"));
                    if (!reader.IsDBNull(reader.GetOrdinal("guardianPhone")))
                        relRef.guardianPhone = reader.GetString(reader.GetOrdinal("guardianPhone"));
                    if(!reader.IsDBNull(reader.GetOrdinal("guardianRelationship")))
                        relRef.guardianRelationship = reader.GetString(reader.GetOrdinal("guardianRelationship"));
                    if(!reader.IsDBNull(reader.GetOrdinal("issues")))
                        relRef.issues = reader.GetString(reader.GetOrdinal("issues"));
                    if(!reader.IsDBNull(reader.GetOrdinal("lname")))
                        relRef.lName = reader.GetString(reader.GetOrdinal("lname"));
                    if(!reader.IsDBNull(reader.GetOrdinal("meeting")))
                        relRef.meeting = reader.GetInt32(reader.GetOrdinal("meeting"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Reach")))
                        relRef.reason = reader.GetString(reader.GetOrdinal("Reach"));
                    if (!reader.IsDBNull(reader.GetOrdinal("reason")))
                          relRef.reason = reader.GetString(reader.GetOrdinal("reason"));
                    if(!reader.IsDBNull(reader.GetOrdinal("referralfname")))
                        relRef.referralfname = reader.GetString(reader.GetOrdinal("referralfname"));
                    if(!reader.IsDBNull(reader.GetOrdinal("referrallname")))
                        relRef.referrallname = reader.GetString(reader.GetOrdinal("referrallname"));
                    if (!reader.IsDBNull(reader.GetOrdinal("school")))
                        relRef.school = reader.GetString(reader.GetOrdinal("school"));
                    if(!reader.IsDBNull(reader.GetOrdinal("currStatus")))                        
                        relRef.status = reader.GetString(reader.GetOrdinal("currStatus"));
                    if(!reader.IsDBNull(reader.GetOrdinal("youthInDuvalSchool")))
                        relRef.youthInDuvalSchool = reader.GetInt32(reader.GetOrdinal("youthInDuvalSchool"));
                if (!reader.IsDBNull(reader.GetOrdinal("youthInSchool")))
                    relRef.youthInSchool = reader.GetInt32(reader.GetOrdinal("youthInSchool"));
                if (!reader.IsDBNull(reader.GetOrdinal("zip")))
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
           Guid ident = Guid.NewGuid();
            string id = "'" + ident + "'";
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
                "INSERT INTO dbo.accomodations VALUES (" + sub.accomGained + "," + sub.compService + ",'" + sub.ifWhatServices + "'," + sub.addServicesGained + "," + id + ")",
                "INSERT INTO dbo.client VALUES ('" + sub.clientLastName + "','" + sub.clientFirstName + "','" + sub.adopted + "','" + sub.clientGender + "','" + sub.clientEthnicity + "','" + sub.clientDOB + "'," + id + ",'" + sub.carePhone + "')",



                "INSERT INTO dbo.advocacy VALUES (" + sub.rearrestAdvocacy + "," + sub.courtAdvocacy + "," + sub.staffAdvocacy + "," + sub.legalAdvocacy + ",'" + sub.legalAdvoTaken + "'," + id + ")",
                "INSERT INTO dbo.altSchool VALUES (" + sub.altSchool + ",'" + sub.altSchoolName + "','" + sub.dateOfAlt + "'," + sub.timesInAlt + "," + sub.daysOwed + "," + sub.daysSinceIntake + "," + id + ")",
                "INSERT INTO dbo.bully VALUES (" + sub.bullied + "," + sub.bullyReport + ",'" + sub.dateofBully + "'," + id + ")",
                "INSERT INTO dbo.caregiver VALUES ('" + sub.careFirstName + "','" + sub.careLastName + "','" + sub.careGender + "','" + sub.careEthnicity + "'," + "'careRelationship'" + "," + id + ")",

                "INSERT dbo.ccr VALUES ('" + sub.levelOfServiceProvided + "'," + sub.caseStatus + ",'" + sub.nonEngagementReason + "'," + sub.remedyResolution + "," + sub.rearrestWhileRepresented + ",'" + sub.schoolAtClosure + "'," + id + "," + sub.intakeDate + ")",
                "INSERT INTO dbo.comp VALUES (" + sub.compService + ",'" + sub.ifWhatServices + "','" + sub.compTime + "'," + id + ")",
                
                "INSERT INTO dbo.currentStatus VALUES (" + sub.readingLevel + "," + sub.mathLevel + ",'" + "currentServices?" + "'," + sub.inPride + "," + sub.newFBA + "," + 0 + ",'" + "servicesGained" + "'," + id + ")",
                "INSERT INTO dbo.failed VALUES (" + sub.failedGrade + "," + sub.whichGradeFailed + "," + sub.failCount + "," + id + ")",
                "INSERT INTO dbo.health VALUES (" + sub.baker + "," + sub.marchman + "," + sub.asthma + "," + sub.pregnantparenting + "," + id + ")",
                "INSERT INTO dbo.household VALUES (" + sub.femHouse + "," + sub.domVio + "," + sub.adopted + "," + sub.evicted + "," + sub.incarParent + "," + sub.publicAssistance + "," + id + ")",
               "INSERT INTO dbo.iep VALUES (" + sub.iep + ",'" + sub.iepplan1 + "','" + sub.iepplan2 + "'," + "0" + "," + id + ")",
                "INSERT INTO dbo.legal VALUES ('" + sub.firstLegal + "','" + sub.secondLegal + "','" + sub.justiceOutcome + "'," + id + ")",
                "INSERT INTO dbo.refinfo VALUES ('" + sub.reffname + "','" + sub.reflname + "','" + sub.referralDate + "'," + id + ",'" + sub.emailOfFirstReferralSource + "')",
                "INSERT INTO dbo.school VALUES (" + id + "," + sub.currentGrade + ",'" + sub.school + "','" + sub.schoolRef + "'," + sub.reenrolled + ")"
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
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetGuid(3), phoneNumber = reader.GetString(4) };
                string mDate = lastMeeting(row.clientCode);
                if (mDate.Equals(""))
                    mDate = "No meetings";
                row.lastMeeting = mDate;
                results.Add(row);
            }
            reader.Close();

            return View("TrackingList", results);
        }

        [HttpPost]
        public IActionResult AddMeeting(Meeting meet)
        {

            Guid g = Guid.NewGuid();

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "INSERT INTO meetings VALUES ('" + meet.MeetingDate.ToString("yyyy-MM-dd") + "','" + meet.MeetingPurpose + "','" + meet.MeetingNotes + "','" + meet.clientCode + "','" + g + "')";

            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();


            //  return RedirectToAction("MeetingList", meet.clientCode);
            return Redirect("MeetingList?clientCode=" + meet.clientCode);
        }

        public string lastMeeting(Guid clientCode)
        {
            var results = new List<DateTime>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select meetingDate from meetings where clientCode = '" + clientCode + "'";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if(!reader.IsDBNull(0))
                {
                    //We push information from the query into a row and onto the list of rows
                    results.Add(reader.GetDateTime(0));
                }
            }
            reader.Close();
            results.Sort();

            if (results.Count != 0)
                return results[0].ToString("MM-dd-yyyy");
            else
                return "";
        }

        public ViewResult MeetingList(Guid clientCode)
        {
            var results = new List<Meeting>();
            var sendme = new MeetingList();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select * from meetings where clientCode = '" + clientCode + "'";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
                Meeting meet = new Meeting { MeetingDate = reader.GetDateTime(0), MeetingPurpose = reader.GetString(1), MeetingNotes = reader.GetString(2), meetingCode = reader.GetGuid(4) };

                results.Add(meet);
            }
            reader.Close();

            sendme.list = results;
            query = "select clientLast, clientFirst from client where clientCode = '" + clientCode + "'";
            command = new SqlCommand(query, cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                sendme.fname = reader.GetString(1);
                sendme.lname = reader.GetString(0);
                sendme.clientCode = clientCode;

            }
            reader.Close();



            return View("MeetingList", sendme);
        }

        [HttpPost]
        public IActionResult DeleteMeeting(Guid meetingCode, Guid clientCode)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "DELETE from dbo.meeting WHERE meetingCode = '" + meetingCode + "';";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return RedirectToAction("MeetingList", clientCode);

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
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetGuid(3), phoneNumber = reader.GetString(4) };

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
                TrackingRow row = new TrackingRow { lname = reader2.GetString(0), fname = reader2.GetString(1), status = statusString, clientCode = reader2.GetGuid(3), phoneNumber = reader2.GetString(4) };

                results.Add(row);
            }
            reader2.Close();
            return View("TrackingList", results);
        }

        public string DeleteSqlCommand(string table, Guid clientCode)
        {
            string spoop = "DELETE FROM " + table + " WHERE ClientCode = '" + clientCode + "';";
            return spoop;

        }

        public IActionResult Delete(Guid clientCode)
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
            string q = "SELECT refCode FROM referral WHERE clientCode ='" + clientCode + "'";
            command = new SqlCommand(q, cnn);
            SqlDataReader reader = command.ExecuteReader();
            Guid refCode = new Guid();
            while (reader.Read())
            {
                refCode = reader.GetGuid(0);
            }
            reader.Close();

            qs.Add("DELETE FROM referral where clientCode = '" + clientCode + "'");
            qs.Add("UPDATE refform SET assignRef = 0 WHERE clientCode = '" + refCode + "'");



            foreach (string query in qs)
            {
                command = new SqlCommand(query, cnn);
                SqlDataReader reader2 = command.ExecuteReader();
                reader2.Close();
            }


            return RedirectToAction("TrackingList");
        }


        public IActionResult ChangeStatus(int clientCode, int status)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "UPDATE ccr SET ccrStatus = " + status + "WHERE clientCode = '" + clientCode + "'";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            cnn.Close();
            return RedirectToAction("TrackingList");

        }
        public ViewResult AssignTrackingList(Guid clientCode)
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
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = statusString, clientCode = reader.GetGuid(3), phoneNumber = reader.GetString(4) };

                results.Add(row);
            }
            reader.Close();
            var mod = new TrackingAssign();
            mod.list = results;
            mod.referralClientCode = clientCode;

            return View("AssignTrackingList", mod);
        }

        public IActionResult ViewAssignedTracking(Guid clientCode, string fname, string lname)
        {
            var results = new TrackRefList();
            results.list = new List<TrackRefRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command1;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string q1 = "SELECT * from referral where clientCode = '" + clientCode + "'";
            command1 = new SqlCommand(q1, cnn);
            SqlDataReader reader = command1.ExecuteReader();
            List<Guid> RefCodes = new List<Guid>();
            while (reader.Read())
            {
                RefCodes.Add(reader.GetGuid(0));
            }

            List<string> commands = new List<string>();
            foreach(var code in RefCodes)
            {
                commands.Add("SELECT referralfname, referrallname, dateinput, clientCode FROM refform where clientCode = '" + code + "'" );
            }
            reader.Close();

            foreach(var command in commands)
            {
                SqlCommand sqlComm;
                sqlComm = new SqlCommand(command, cnn);
                SqlDataReader reader2 = sqlComm.ExecuteReader();
                while (reader2.Read())
                {
                    //We push information from the query into a row and onto the list of rows
                    TrackRefRow row = new TrackRefRow
                    {
                        firstName = reader2.GetString(0),
                        lastName = reader2.GetString(1),
                        inputdate = reader2.GetDateTime(2),
                        refCode = reader2.GetGuid(3)
                    };
                    results.list.Add(row);

                }
                reader2.Close();
            }
            results.studentName = fname + " " + lname;


            return View("RefTrackList", results);
            }
       


        

        public IActionResult AssignSpecific(Guid clientCode, Guid refCode)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string q1 = "INSERT INTO referral VALUES ('" + refCode + "','" + clientCode + "')";
            string q2 = "UPDATE refform SET assignRef = 1 WHERE clientCode = '" + refCode + "'";
            command = new SqlCommand(q1, cnn);
            SqlDataReader reader = command.ExecuteReader();
            command = new SqlCommand(q2, cnn);
            reader.Close();
            reader = command.ExecuteReader();
            reader.Close();

            return RedirectToAction("RefList", "Referral");

        }


       

       
    }
}