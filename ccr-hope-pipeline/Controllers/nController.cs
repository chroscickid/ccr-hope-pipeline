using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Referrals;

namespace HopePipeline.Controllers
{
    public class nController:Controller
    {
        public string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IActionResult formReferralM()
        {

        SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = cnn.CreateCommand();
            object value = new SqlCommand("SELECT MAX(clientCode) FROM refform", cnn).ExecuteScalar();
            //value = Convert.ToString(value);
            int i = 0;
            if (Convert.IsDBNull(value))
            { 
                i = 0;
                ViewBag.Tessage = i;
            }
            if (!Convert.IsDBNull(value))
            { i = Convert.ToInt32(value);
                ViewBag.Tessage = i + 1;
            }

            ViewBag.Bessage = DateTime.Now;

            //SELECT MAX(Price) AS LargestPrice
            //FROM Products;

            cnn.Close();
            return View();
          
        }
        [HttpPost]
        public IActionResult submitform(referralBrandi form)
        {
            string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "INSERT INTO dbo.refform VALUES ('" + form.fName + "', '" + form.lName + "', '" + form.dOB + "', '" + form.clientCode + "', '" + form.guardianName + "', '" + form.guardianRelationship + "', '" + form.address + "', '" + form.gender + "', '" + form.guardianEmail + "', '" + form.guardianPhone + "', '" + form.meeting + "', '" + form.youthInDuvalSchool + "', '" + form.youthInSchool + "', '" + form.issues + "', '" + form.currentSchool + "', '" + form.zip + "', '" + form.grade + "', 'Pending', '" + form.arrest + "', '" + form.school + "', '" + form.dateInput + "', '" + form.date + "', '" + form.email + "', '" + form.Reach + "', '" + form.moreInfo + "', '" + form.reason +"', '" + form.referralfname + "', '" + form.referrallname + "')";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            //COnnect to the DB
              
           
      
            return RedirectToAction("Index","Home");

        }
        public IActionResult confirmationM()
        {
            return View();

        }
        public IActionResult contactInfoM(int clientCode)
        {
            string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //var client= new Contact();
            List<Contact> clientl = new List<Contact>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT fname, lname, guardianName, guardianRelationship, guardianPhone, guardianEmail, strAddress, zip, reach, referrallname, referralfname, email FROM refform WHERE clientCode= " + clientCode + ";";

            command = new SqlCommand(query, cnn);

            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                   Contact client = new Contact();
                    client.fname = Convert.ToString(dataReader["fname"]);
                    
                        
                    
                    client.lname = Convert.ToString(dataReader["lname"]);
                    if (client.lname == " " || client.lname == "null" || client.lname == "")
                    { client.lname = "N/A"; }
                    client.guardianName = Convert.ToString(dataReader["guardianName"]);
                    if (client.guardianName == " " || client.guardianName == "null" || client.guardianName == "")
                    { client.guardianName = "N/A"; }
                    client.relationship = Convert.ToString(dataReader["guardianRelationship"]);
                    if (client.relationship == " " || client.relationship == "null" || client.relationship == "")
                    { client.relationship = "N/A"; }
                    client.phone = Convert.ToString(dataReader["guardianPhone"]);
                    if (client.phone == " " || client.phone == "null" || client.phone == "" )
                    { client.phone = "N/A"; }
                    client.address = Convert.ToString(dataReader["strAddress"]);
                    if (client.address == " " || client.address == "null" || client.address == "")
                    { client.address =  "N/A"; }
                    client.email = Convert.ToString(dataReader["guardianEmail"]);
                    if (client.email == " " || client.email == "null" || client.email == "")
                    { client.email = "N/A"; }
                    client.zip = Convert.ToString(dataReader["zip"]);
                    if (client.zip == " " || client.zip == "null" || client.zip == "")
                    { client.zip = "N/A"; }
                    client.reach = Convert.ToString(dataReader["reach"]);
                    if (client.reach == " " || client.reach== "null" || client.reach == "")
                    { client.reach = "N/A"; }
                    client.rlname = Convert.ToString(dataReader["referrallname"]);
                    if (client.rlname == " " || client.rlname == "null" || client.rlname == "")
                    { client.rlname = "N/A"; }
                    client.rfname = Convert.ToString(dataReader["referralfname"]);
                    if (client.rfname == " " || client.rfname == "null" || client.rfname == "")
                    { client.rfname = "N/A"; }
                    client.remail = Convert.ToString(dataReader["email"]);
                    if (client.remail == " " || client.remail == "null" || client.remail == "")
                    { client.remail = "N/A"; }
                    clientl.Add(client);

                }
            }

            cnn.Close();
            return View(clientl);

        }

        public IActionResult detailReferralM(int clientCode)
         {
                string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                //var client= new Contact();
                List<referralDetail> clientl = new List<referralDetail>();
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn.Open();

                string query = "SELECT fname, lname, dob, guardianName, guardianRelationship, strAddress, gender, guardianEmail, guardianPhone, meeting, youthInDuvalSchool, youthInSchool, issues, currentSchool, zip, grade, currStatus, arrest, school, dateInput, meetingDate, email, reach, moreInfo, reason, referralfname, referrallname FROM refform WHERE clientCode= " + clientCode + ";";

                command = new SqlCommand(query, cnn);

                //SqlDataReader reader = command.ExecuteReader();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        referralDetail client = new referralDetail();
                        client.fName = Convert.ToString(dataReader["fname"]);
                    if (client.fName == " " || client.fName == "null" || client.fName == "")
                    { client.fName = "N/A"; }

                    client.lName = Convert.ToString(dataReader["lname"]);
                        if (client.lName == " " || client.lName == "null" || client.lName == "")
                        { client.lName = "N/A"; }


                    int space1 = Convert.ToString(dataReader["dob"]).IndexOf(' ');
                    if (Convert.ToString(dataReader["dob"]).Length > 10)
                      
                    { client.dOB = Convert.ToString(dataReader["dob"]).Substring(0, space1); }

                    if (client.dOB == " " || client.dOB == "null" || client.dOB == "" || Convert.ToString(dataReader["dob"]).Length < 10)
                    { client.dOB = "N/A"; }


                    client.guardianName = Convert.ToString(dataReader["guardianName"]);
                        if (client.guardianName == " " || client.guardianName == "null" || client.guardianName == "")
                        { client.guardianName = "N/A"; }
                        client.guardianRelationship = Convert.ToString(dataReader["guardianRelationship"]);
                        if (client.guardianRelationship == " " || client.guardianRelationship == "null" || client.guardianRelationship == "")
                        { client.guardianRelationship = "N/A"; }

                        client.address = Convert.ToString(dataReader["strAddress"]);
                        if (client.address== " " || client.address == "null" || client.address == "")
                        { client.address = "N/A"; }

                    client.gender = Convert.ToString(dataReader["gender"]);
                    if (client.gender == " " || client.gender == "null" || client.gender == "")
                    { client.gender= "N/A"; }
                    client.guardianEmail = Convert.ToString(dataReader["guardianEmail"]);
                    if (client.guardianEmail == " " || client.guardianEmail == "null" || client.guardianEmail == "")
                    { client.guardianEmail = "N/A"; }
                    client.guardianPhone = Convert.ToString(dataReader["guardianPhone"]);
                    if (client.guardianPhone == " " || client.guardianPhone == "null" || client.guardianPhone == "")
                    { client.guardianPhone = "N/A"; }
                    string meetingnull;
                    int meeting;
                    var meet = Convert.ToString(dataReader["meeting"]);

                   
                    var t = int.TryParse(meet, out meeting);
                  
                  
                    if (meeting == 1)
                    {
                        meetingnull = meeting.ToString();
                        meetingnull = "Yes";
                    }
                    if (meeting == 2)
                    {
                        meetingnull = meeting.ToString();
                        meetingnull = "Maybe";
                    }
                    else {
                        meetingnull = meeting.ToString();
                        meetingnull = "No";
                    }
                    client.meeting = meetingnull;

                    string youthInDuvalSchoolnull;
                    int youthInDuvalSchool;
                    var youth = Convert.ToString(dataReader["youthInDuvalSchool"]);


                    var g = int.TryParse(youth, out youthInDuvalSchool);


                    if (youthInDuvalSchool == 1)
                    {
                        youthInDuvalSchoolnull = youthInDuvalSchool.ToString();
                        youthInDuvalSchoolnull = "Yes";
                    }
                    if (youthInDuvalSchool == 2)
                    {
                        youthInDuvalSchoolnull = youthInDuvalSchool.ToString();
                        youthInDuvalSchoolnull = "Maybe";
                    }
                    else
                    {
                        youthInDuvalSchoolnull = youthInDuvalSchool.ToString();
                        youthInDuvalSchoolnull = "No";
                    }
                    client.youthInDuvalSchool = youthInDuvalSchoolnull;

                   // client.youthInDuvalSchool = Convert.ToInt32(dataReader["youthInDuvalSchool"]);


             
                    

                    string youthInSchoolnull;
                    int youthInSchool;
                    var youthSchool = Convert.ToString(dataReader["youthInSchool"]);


                    var f = int.TryParse(youthSchool, out youthInSchool);


                    if (youthInSchool == 1)
                    {
                        youthInSchoolnull = youthInSchool.ToString();
                        youthInSchoolnull = "Yes";
                    }
                    if (youthInSchool == 2)
                    {
                        youthInSchoolnull = youthInSchool.ToString();
                        youthInSchoolnull = "Maybe";
                    }
                    else
                    {
                        youthInSchoolnull = youthInSchool.ToString();
                        youthInSchoolnull = "No";
                    }
                    client.youthInSchool = youthInSchoolnull;
                   // client.youthInSchool = Convert.ToInt32(dataReader["youthInSchool"]);

                    client.issues = Convert.ToString(dataReader["issues"]);
                    if (client.issues == " " || client.issues == "null" || client.issues == "")
                    { client.issues = "N/A"; }


                    client.currentSchool = Convert.ToString(dataReader["currentSchool"]);
                    if (client.currentSchool == " " || client.currentSchool == "null" || client.currentSchool == "")
                    { client.currentSchool = "N/A"; }

                

                        client.zip = Convert.ToString(dataReader["zip"]);
                        if (client.zip == " " || client.zip == "null" || client.zip == "")
                        { client.zip = "N/A"; }

                    client.grade = Convert.ToString(dataReader["grade"]);
                    if (client.grade == " " || client.grade== "null" || client.grade == "")
                    { client.grade = "N/A"; }

                    client.status = Convert.ToString(dataReader["currStatus"]);
                    if (client.status == " " || client.status == "null" || client.status == "")
                    { client.status = "N/A"; }

                    string arrestnull;
                    int arrest;
                    var arrestrec = Convert.ToString(dataReader["arrest"]);


                    var r = int.TryParse(arrestrec, out arrest);


                    if (arrest == 1)
                    {
                        arrestnull = arrest.ToString();
                        arrestnull = "Yes";
                    }
                    if (arrest == 2)
                    {
                        arrestnull = arrest.ToString();
                        arrestnull = "Maybe";
                    }
                    else
                    {
                        arrestnull = arrest.ToString();
                        arrestnull = "No";
                    }
                    client.arrest = arrestnull;
                   // client.arrest = Convert.ToInt32(dataReader["arrest"]);



                    client.school= Convert.ToString(dataReader["school"]);
                    if (client.school == " " || client.school == "null" || client.school == "")
                    { client.school = "N/A"; }

                    int space2 = Convert.ToString(dataReader["dateInput"]).IndexOf(' ');
                    if (Convert.ToString(dataReader["dateInput"]).Length > 10)
                    { client.dateInput = Convert.ToString(dataReader["dateInput"]).Substring(0, space2); }
                    if (client.dateInput == " " || client.dateInput == "null" || client.dateInput == "" || Convert.ToString(dataReader["dateInput"]).Length < 10)
                    { client.dateInput = "N/A"; }

                    int space3 = Convert.ToString(dataReader["meetingDate"]).IndexOf(' ');
                    if (Convert.ToString(dataReader["meetingDate"]).Length > 10)
                    { client.date = Convert.ToString(dataReader["meetingDate"]).Substring(0, space3); }
                    if (client.date == " " || client.date == "null" || client.date == "" || Convert.ToString(dataReader["meetingDate"]).Length < 10)
                    { client.date = "N/A"; }


                    client.email = Convert.ToString(dataReader["email"]);
                        if (client.email == " " || client.email == "null" || client.email == "")
                        { client.email = "N/A"; }


                        client.Reach= Convert.ToString(dataReader["reach"]);
                        if (client.Reach == " " || client.Reach == "null" || client.Reach == "")
                        { client.Reach = "N/A"; }
                        client.moreInfo = Convert.ToString(dataReader["moreInfo"]);
                        if (client.moreInfo == " " || client.moreInfo == "null" || client.moreInfo == "")
                        { client.moreInfo = "N/A"; }
                        client.reason = Convert.ToString(dataReader["reason"]);
                        if (client.reason == " " || client.reason == "null" || client.reason == "")
                        { client.reason = "N/A"; }

                    client.referralfname = Convert.ToString(dataReader["referralfname"]);
                    if (client.referralfname == " " || client.referralfname == "null" || client.referralfname == "")
                    { client.referralfname= "N/A"; }
                    client.referrallname = Convert.ToString(dataReader["referrallname"]);
                    if (client.referrallname == " " || client.referrallname == "null" || client.referrallname == "")
                    { client.referrallname = "N/A"; }

                    clientl.Add(client);

                    }
                }

                cnn.Close();
                return View(clientl);

            }
            public IActionResult detailTrackingM()
        {

            return View();

        }
        public IActionResult EditTrackingM(int clientCode)
        {
            return View();

        }
        public IActionResult editReferrall(referralBrandi form)
        {


            string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command = cnn.CreateCommand();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //cnn.Open();
            command.CommandText = "UPDATE refform SET [fname]= '" + form.clientCode + "', [lname] = '" + form.lName + "', [dob] = '" + form.dOB + "', [guardianName]= '" + form.guardianName + "', [guardianRelationship]= '" + form.guardianRelationship +
                "'," +
                " [strAddress]= '" + form.address + "', [gender]  = '" + form.gender + "', [guardianEmail] = '" + form.guardianEmail + "', [guardianPhone]='" + form.guardianPhone + "' ," +
                " [meeting] ='" + form.meeting + ", [youthInDuvalSchool]= '" + form.youthInDuvalSchool + "', [youthInSchool] = '"
                + form.youthInSchool + "', [issues]='"+ form.issues + "', [currentSchool] ='" + form.currentSchool + "'," +
                "[zip] ='" + form.zip + "', [grade] = '" + form.grade + "', [currStatus] = '" + form.status + "', [arrest] ='" + form.arrest + "'," +
                " [school] ='"+ form.school + "', [dateInput] = '" + form.dateInput + "', [meetingDate] ='" + form.date + "', [email] ='" + form.email + "', [reach] ='" + form.Reach + "'" +
                ", [moreInfo] ='" + form.moreInfo + "', [reason] ='" + form.reason + "'," +
                " [referralfname] ='" +
            form.referralfname + "', [referrallname] ='" + form.referrallname + "')" +
                " WHERE [clientCode] = " + form.clientCode + ";";
            cnn.Open();

            command.ExecuteNonQuery();
            // SqlCommand command = new SqlCommand(query, cnn);
            cnn.Close();



            return RedirectToAction("Index", "Home");

        }
        public IActionResult editReferralM(int clientCode)
        {

            return View();



        }
    }
}
