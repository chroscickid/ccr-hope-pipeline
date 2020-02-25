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


                   
                    if (Convert.ToString(dataReader["dob"]).Length > 10)
                      
                    {
                        //int space1 = Convert.ToString(dataReader["dob"]).IndexOf(' ');
                        client.dOB = Convert.ToString(dataReader["dob"]).Substring(0, 10); }

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



                   client.meeting= Convert.ToString(dataReader["meeting"]);
                    var gar = Int32.TryParse(client.meeting, out int meet);
                    if (client.meeting == "1")
                    { client.meeting = "Yes"; }
                    if (client.meeting == "2")
                    {client.meeting = "Maybe"; }
                     if (client.meeting == "0")
                    { client.meeting = "No"; }
                    if (client.meeting == "")
                    { client.meeting = "N/A"; }
                    else
                    { client.meeting = client.meeting; }
                   
                  
                    client.youthInDuvalSchool = Convert.ToString(dataReader["youthInDuvalSchool"]);
                    var gart = Int32.TryParse(client.youthInDuvalSchool, out int tss);
                    if (client.youthInDuvalSchool == "1")
                    { client.youthInDuvalSchool = "Yes"; }
                    if (client.youthInDuvalSchool == "2")
                    { client.youthInDuvalSchool = "Maybe"; }
                    if (client.youthInDuvalSchool == "0")
                    { client.youthInDuvalSchool = "No"; }
                    if (client.youthInDuvalSchool == "")
                    { client.youthInDuvalSchool = "N/A"; }
                    else
                    { client.youthInDuvalSchool = client.youthInDuvalSchool; }

                    client.youthInSchool = Convert.ToString(dataReader["youthInSchool"]);
                    var garth = Int32.TryParse(client.youthInSchool, out int tsss);
                    if (client.youthInSchool == "1")
                    { client.youthInSchool = "Yes"; }
                    if (client.youthInSchool == "2")
                    { client.youthInSchool = "Maybe"; }
                    if (client.youthInSchool == "0")
                    { client.youthInSchool = "No"; }
                    if (client.youthInSchool == "")
                    { client.youthInSchool = "N/A"; }
                    else
                    { client.youthInSchool = client.youthInSchool; }

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

                   
                    client.arrest = Convert.ToString(dataReader["arrest"]);
                    var garthy = Int32.TryParse(client.arrest, out int tssss);
                    if (client.arrest == "1")
                    { client.arrest = "Yes"; }
                    if (client.arrest == "2")
                    { client.arrest = "Maybe"; }
                    if (client.arrest == "0")
                    { client.arrest = "No"; }
                    if (client.arrest == "")
                    { client.arrest = "N/A"; }
                    else
                    { client.arrest = client.arrest; }


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
        


        [HttpPost]///////////////////////////////////////////////////////////edit=========================================================================
        public IActionResult editReferralForm(referralBrandi form)
        {


            string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
           
          //  SqlCommand command;
          //  SqlDataAdapter adapter = new SqlDataAdapter();
          //  cnn.Open();
         //   string query = "UPDATE refform SET [fname]= '" + form.fName + "', [lname] = '" + form.lName + "', [dob] = '" + form.dOB + "', [guardianName]= '" + form.guardianName + "', [guardianRelationship]= '" + form.guardianRelationship +
         //       "'," +
         //       " [strAddress]= '" + form.address + "', [gender]  = '" + form.gender + "', [guardianEmail] = '" + form.guardianEmail + "', [guardianPhone]='" + form.guardianPhone + "' ," +
         //       " [meeting] ='" + form.meeting + ", [youthInDuvalSchool]= '" + form.youthInDuvalSchool + "', [youthInSchool] = '"
         //       + form.youthInSchool + "', [issues]='" + form.issues + "', [school] ='" + form.school + "'," +
         //       "[zip] ='" + form.zip + "', [grade] = '" + form.grade + "', [currStatus] = '" + form.status + "', [arrest] ='" + form.arrest + "'," +
         //       " [school] ='" + form.school + "', [dateInput] = '" + form.dateInput + "', [meetingDate] ='" + form.date + "', [email] ='" + form.email + "', [reach] ='" + form.Reach + "'" +
          //      ", [moreInfo] ='" + form.moreInfo + "', [reason] ='" + form.reason + "'," +
          //      " [referralfname] ='" +
         //   form.referralfname + "', [referrallname] ='" + form.referrallname + "')" +
          //      " WHERE [clientCode] = " + form.clientCode + ";";

         
         //   command = new SqlCommand(query, cnn);
         //   SqlDataReader reader = command.ExecuteReader();
            // SqlCommand command = new SqlCommand(query, cnn);
            //cnn.Close();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "UPDATE dbo.refform " +
                    "SET " +
                    "fname = @fName, lname = @lName, dob = @dOB, guardianName = @guardianName, guardianRelationship = @guardianRelationship, strAddress = @strAddress, gender = @gender, guardianEmail = @guardianEmail, guardianPhone = @guardianPhone, meeting = @meeting, youthInDuvalSchool = @youthInDuvalSchool, youthInSchool = @youthInSchool, issues = @issues, zip = @zip, grade = @grade, currStatus = @currStatus, arrest = @arrest, school = @school, dateInput = @dateInput, meetingDate = @meetingDate, email =@email, reach = @reach,moreInfo = @moreInfo, reason = @reason, referralfname = @referralfname, referrallname = @referrallname WHERE clientCode = @clientCode;";

               command.Parameters.AddWithValue("@clientCode", form.clientCode);
              
                SqlParameter fNameCodeParam = command.Parameters.AddWithValue("@fName", form.fName);
                if (form.fName == null)
                {
                    fNameCodeParam.Value = DBNull.Value;
                }
                SqlParameter lNameCodeParam = command.Parameters.AddWithValue("@lName", form.lName);
                if (form.lName == null)
                {
                    lNameCodeParam.Value = DBNull.Value;
                }
                SqlParameter dOBCodeParam = command.Parameters.AddWithValue("@dOB", form.dOB);
                if (form.dOB == null)
                {
                    dOBCodeParam.Value = DBNull.Value;
                }
                SqlParameter guardianNameCodeParam = command.Parameters.AddWithValue("@guardianName", form.guardianName);
                if (form.guardianName == null)
                {
                    guardianNameCodeParam.Value = DBNull.Value;
                }
                SqlParameter guardianRelationshipCodeParam = command.Parameters.AddWithValue("@guardianRelationship", form.guardianRelationship);
                if (form.guardianRelationship == null)
                {
                    guardianRelationshipCodeParam.Value = DBNull.Value;
                }
                SqlParameter guardianPhoneCodeParam = command.Parameters.AddWithValue("@guardianPhone", form.guardianPhone);
                if (form.guardianPhone == null)
                {
                    guardianPhoneCodeParam.Value = DBNull.Value;
                }
                SqlParameter guardianEmailCodeParam = command.Parameters.AddWithValue("@guardianEmail", form.guardianEmail);
                if (form.guardianEmail == null)
                {
                    guardianEmailCodeParam.Value = DBNull.Value;
                }
                SqlParameter youthInDuvalSchoolCodeParam = command.Parameters.AddWithValue("@youthInDuvalSchool", form.youthInDuvalSchool);
                if (form.youthInDuvalSchool != 1 && form.youthInDuvalSchool != 2 && form.youthInDuvalSchool != 0)
                {
                    youthInDuvalSchoolCodeParam.Value = DBNull.Value;
                }
                SqlParameter youthInSchoolp =command.Parameters.AddWithValue("@youthInSchool", form.youthInSchool);
                if (form.youthInSchool != 1 && form.youthInSchool != 2 && form.youthInSchool != 0)
                {
                    youthInSchoolp.Value = DBNull.Value;
                }
                SqlParameter y =command.Parameters.AddWithValue("@zip", form.zip);
                if (form.zip == null)
                {
                    y.Value = DBNull.Value;
                }
                SqlParameter yy =command.Parameters.AddWithValue("@strAddress", form.address);
                if (form.address == null)
                {
                    yy.Value = DBNull.Value;
                }
                SqlParameter gin = command.Parameters.AddWithValue("@gender", form.gender);
                if (form.gender == null)
                {
                    gin.Value = DBNull.Value;
                }
                SqlParameter tok= command.Parameters.AddWithValue("@meeting", form.meeting);
                if (form.meeting != 0 && form.meeting != 1&& form.meeting != 2)
                {
                    tok.Value = DBNull.Value;
                }
                SqlParameter issu = command.Parameters.AddWithValue("@issues", form.issues);
                if (form.issues == null)
                {
                    issu.Value = DBNull.Value;
                }
                SqlParameter arr = command.Parameters.AddWithValue("@arrest", form.arrest);
                if (form.arrest != 0 && form.arrest != 1 && form.arrest != 2)
                {
                   arr.Value = DBNull.Value;
                }
                SqlParameter sc= command.Parameters.AddWithValue("@school", form.school);
                if (form.school == null)
                {
                    sc.Value = DBNull.Value;
                }
                SqlParameter stat =command.Parameters.AddWithValue("@currStatus", form.status);
                if (form.status == null)
                {
                    stat.Value = DBNull.Value;
                }
                SqlParameter dateii = command.Parameters.AddWithValue("@dateInput", form.dateInput);
                if (form.dateInput == null)
                {
                    dateii.Value = DBNull.Value;
                }
                SqlParameter dates =command.Parameters.AddWithValue("@meetingDate", form.date);
                if (form.date == null)
                {
                   dates.Value = DBNull.Value;
                }
                SqlParameter ema = command.Parameters.AddWithValue("@email", form.email);
                if (form.email == null)
                {
                   ema.Value = DBNull.Value;
                }
                SqlParameter reac = command.Parameters.AddWithValue("@reach", form.Reach);
                if (form.Reach == null)
                {
                    reac.Value = DBNull.Value;
                }
                SqlParameter morei = command.Parameters.AddWithValue("@moreInfo", form.moreInfo);
                if (form.moreInfo == null)
                {
                   morei.Value = DBNull.Value;
                }
                SqlParameter reas = command.Parameters.AddWithValue("@reason", form.reason);
                if (form.reason== null)
                {
                    reas.Value = DBNull.Value;
                }
                SqlParameter rfn = command.Parameters.AddWithValue("@referralfname", form.referralfname);
                if (form.referralfname == null)
                {
                    rfn.Value = DBNull.Value;
                }
                SqlParameter rln = command.Parameters.AddWithValue("@referrallname", form.referrallname);
                if (form.referrallname == null)
                {
                    rln.Value = DBNull.Value;
                }
                SqlParameter gra = command.Parameters.AddWithValue("@grade", form.grade);
                if (form.grade == null)
                {
                   gra.Value = DBNull.Value;
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            int message = form.clientCode;
            //return RedirectToAction("detailReferralM?clientCode="+ message +"", "n");
            return RedirectToAction("RefList", "Referral");
        }




        public IActionResult editReferralM(int clientCode)
        {//this method will display the values from the sql code
            //get the values from specific sql
            //display
            string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //var client= new Contact();
          
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientCode, fname, lname, dob, guardianName, guardianRelationship, strAddress, gender, guardianEmail, guardianPhone, meeting, youthInDuvalSchool, youthInSchool, issues, currentSchool, zip, grade, currStatus, arrest, school, dateInput, meetingDate, email, reach, moreInfo, reason, referralfname, referrallname FROM refform WHERE clientCode= " + clientCode + ";";

            command = new SqlCommand(query, cnn);

            
            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                   
                    referralBrandi client = new referralBrandi();
                    client.clientCode = Convert.ToInt32(dataReader["clientCode"]);
                    client.fName = Convert.ToString(dataReader["fname"]);
                   

                    client.lName = Convert.ToString(dataReader["lname"]);
                   

                    //int space1 = Convert.ToString(dataReader["dob"]).IndexOf(' ');
                    
                    if (Convert.IsDBNull(dataReader["dob"]))
                    { client.dOB = DateTime.Parse("01/01/1970"); }
                    else
                    {
                        client.dOB = Convert.ToDateTime(dataReader["dob"]);
                    };//fix ints}

                    client.guardianName = Convert.ToString(dataReader["guardianName"]);
                    
                    client.guardianRelationship = Convert.ToString(dataReader["guardianRelationship"]);
                   

                    client.address = Convert.ToString(dataReader["strAddress"]);
                   

                    client.gender = Convert.ToString(dataReader["gender"]);
                    
                    client.guardianEmail = Convert.ToString(dataReader["guardianEmail"]);
             
                    client.guardianPhone = Convert.ToString(dataReader["guardianPhone"]);
                   



                  
                    if (Convert.IsDBNull(dataReader["meeting"]))
                    { client.meeting = 2; }
                    else
                    {
                        client.meeting = Convert.ToInt16(dataReader["meeting"]);
                    };//fix ints}


                       

                    if (Convert.IsDBNull(dataReader["youthInDuvalSchool"]))
                    { client.youthInDuvalSchool = 2; }
                    else
                    {
                        client.youthInDuvalSchool = Convert.ToInt16(dataReader["youthInDuvalSchool"]);
                    };//fix ints}

                
                    if (Convert.IsDBNull(dataReader["youthInSchool"]))
                    { client.youthInSchool = 2; }
                    else
                    {
                        client.youthInSchool = Convert.ToInt16(dataReader["youthInSchool"]);
                    };//fix ints}

                    client.issues = Convert.ToString(dataReader["issues"]);
                   


                    client.school = Convert.ToString(dataReader["school"]);
                    



                    client.zip = Convert.ToString(dataReader["zip"]);
                    

                    client.grade = Convert.ToString(dataReader["grade"]);
                 

                    client.status = Convert.ToString(dataReader["currStatus"]);
                    


                   
                    if (Convert.IsDBNull(dataReader["arrest"]))
                    { client.arrest = 2; }
                    else
                    {
                        client.arrest = Convert.ToInt16(dataReader["arrest"]);
                    };//fix ints}


                    client.school = Convert.ToString(dataReader["school"]);
                   

                 
                   

                    if (Convert.IsDBNull(dataReader["dateInput"]))
                    { client.dateInput= DateTime.Parse("01/01/1970"); }
                    else
                    {
                        client.dateInput = Convert.ToDateTime(dataReader["dateInput"]);
                    };//fix ints}

                    
                    if (Convert.IsDBNull(dataReader["meetingDate"]))
                    { client.date = DateTime.Parse("01/01/1970"); }
                    else
                    {
                        client.date= Convert.ToDateTime(dataReader["meetingDate"]);
                    };//fix ints}




                    if (Convert.IsDBNull(dataReader["arrest"]))
                    { client.arrest = 2; }
                    else
                    {
                        client.arrest = Convert.ToInt16(dataReader["arrest"]);
                    };//fix ints}


                    client.email = Convert.ToString(dataReader["email"]);
                   


                    client.Reach = Convert.ToString(dataReader["reach"]);
                 
                    client.moreInfo = Convert.ToString(dataReader["moreInfo"]);
                   
                    client.reason = Convert.ToString(dataReader["reason"]);
               

                    client.referralfname = Convert.ToString(dataReader["referralfname"]);
                   
                    client.referrallname = Convert.ToString(dataReader["referrallname"]);
                 
                    ViewBag.Lessage = client;

                }
            }

            cnn.Close();
          
            return View();

        }






        public IActionResult detailTrackingM(int clientCode)
        { // referral form I need the firstname, lastname, 
            //sql commands for getting the tracking info
            //displaying the tracking information

            List<trackingDetail> clientl = new List<trackingDetail>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT dbo.refform.clientCode, dbo.refform.fname, dbo.refform.lname, dbo.refform.dob, dbo.refform.guardianName, dbo.refform.guardianRelationship, dbo.refform.strAddress, dbo.refform.gender, dbo.refform.guardianEmail, dbo.refform.guardianPhone, dbo.refform.meeting, dbo.refform.youthInDuvalSchool, dbo.refform.youthInSchool, dbo.refform.issues, dbo.refform.currentSchool, dbo.refform.zip, dbo.refform.grade, dbo.refform.currStatus, dbo.refform.arrest, refform.school, refform.dateInput, dbo.refform.meetingDate, dbo.refform.email, dbo.refform.reach, dbo.refform.moreInfo, dbo.refform.reason, dbo.refform.referralfname, dbo.refform.referrallname, " +
            "dbo.accomodations.accomGained, dbo.accomodations.compServices, dbo.accomodations.ifWhatServices, " +
"dbo.advocacy.rearrestAdvo, dbo.advocacy.courtAdvo, dbo.advocacy.staffingAdvo, dbo.advocacy.legalAdvo, dbo.advocacy.legalAdvoTaken, " +
"dbo.altSchool.altSchool, dbo.altSchool.altSchoolName, dbo.altSchool.altSchoolDate, dbo.altSchool.altSchoolTimes, dbo.altSchool.daysOwed, " +
"dbo.bully.bullied, dbo.bully.reported, dbo.bully.reportDate, " +
"dbo.caregiver.careLast, dbo.caregiver.careFirst, dbo.caregiver.genderIdentity as caregender, dbo.caregiver.ethnicity as careethnic, dbo.caregiver.relationship, " +
"dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, " +
"dbo.client.clientLast, dbo.client.clientFirst, dbo.client.dependency, dbo.client.genderIdentity as clientgender, dbo.client.ethnicity as clientethn, dbo.client.dob, dbo.client.phoneNumber, " +
"dbo.comp.compServices, dbo.comp.compTime, " +
"dbo.currentStatus.readingLevel, dbo.currentStatus.mathLevel, dbo.currentStatus.currentServices, dbo.currentStatus.inPride, dbo.currentStatus.newFBA, dbo.currentStatus.addService, dbo.currentStatus.servicesGained, " +
"dbo.failed.gradeFailed, dbo.failed.whichGrade, dbo.failed.failedRepeat, " +
"dbo.health.bakerActed, dbo.health.marchmanActed, dbo.health.asthma, " +
"dbo.household.femLed, dbo.household.domVio, dbo.household.adopted, dbo.household.evicted, dbo.household.incarParent, dbo.household.publicAssistance, " +
"dbo.referral.referralDate, dbo.referral.intakeDate, dbo.referral.referral1, dbo.referral.referral2, dbo.referral.referral3, dbo.referral.referrerName, dbo.referral.referrerEmail, " +
"dbo.suspension.suspendedThrice, dbo.suspension.numSuspensions, dbo.suspension.totalDaysSuspended, dbo.suspension.ISS, dbo.suspension.OSS, dbo.suspension.daysofDiscipline, dbo.suspension.disciplineSinceIntake, " +
"dbo.iep.IEP, dbo.iep.primaryIEP, dbo.iep.secondaryIEP, dbo.iep.addIEp, dbo.legal.legalIssues, dbo.legal.leagalIssues2" +
" FROM ((((((((((((((((dbo.refform  LEFT JOIN dbo.accomodations  on dbo.refform.clientCode = dbo.accomodations.clientCode)" +
" LEFT JOIN dbo.advocacy on dbo.refform.clientCode = dbo.advocacy.clientCode)  " +
"LEFT JOIN dbo.altSchool on dbo.refform.clientCode = dbo.altSchool.clientCode) " +
"LEFT JOIN dbo.bully on dbo.refform.clientCode = dbo.bully.clientCode) " +
"LEFT JOIN dbo.caregiver on dbo.refform.clientCode = dbo.caregiver.clientCode) " +
"LEFT JOIN dbo.ccr on dbo.refform.clientCode = dbo.ccr.clientCode) " +
"LEFT JOIN dbo.client on dbo.refform.clientCode = dbo.client.clientCode) " +
"LEFT JOIN dbo.comp on dbo.refform.clientCode = dbo.comp.clientCode) " +
"LEFT JOIN dbo.currentStatus on dbo.refform.clientCode = dbo.currentStatus.clientCode) " +
"LEFT JOIN dbo.failed on dbo.refform.clientCode = dbo.failed.clientCode) " +
"LEFT JOIN dbo.health on dbo.refform.clientCode = dbo.health.clientCode) " +
"LEFT JOIN dbo.household on refform.clientCode = dbo.household.clientCode) " +
"LEFT JOIN dbo.referral on dbo.refform.clientCode = dbo.referral.clientCode) " +
"LEFT JOIN dbo.suspension on dbo.refform.clientCode = dbo.suspension.clientCode) " +
"LEFT JOIN dbo.iep on dbo.refform.clientCode = dbo.iep.clientCode) " +
"LEFT JOIN dbo.legal on dbo.refform.clientCode = dbo.legal.clientCode)" +
"WHERE dbo.refform.clientCode =" + clientCode + ";";
            command = new SqlCommand(query, cnn);

            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    trackingDetail client = new trackingDetail();
                    client.ClientID = Convert.ToInt32(dataReader["clientCode"]);

                        client.fName = Convert.ToString(dataReader["fname"]);
                    if (client.fName == " " || client.fName == "null" || client.fName == "")
                    { client.fName = "N/A"; }

                    client.lName = Convert.ToString(dataReader["lname"]);
                    if (client.lName == " " || client.lName == "null" || client.lName == "")
                    { client.lName = "N/A"; }



                    if (Convert.ToString(dataReader["dob"]).Length > 10)

                    {
                        //int space1 = Convert.ToString(dataReader["dob"]).IndexOf(' ');
                        client.dOB = Convert.ToString(dataReader["dob"]).Substring(0, 10);
                    }

                    if (client.dOB == " " || client.dOB == "null" || client.dOB == "" || Convert.ToString(dataReader["dob"]).Length < 10)
                    { client.dOB = "N/A"; }


                    client.guardianName = Convert.ToString(dataReader["guardianName"]);
                    if (client.guardianName == " " || client.guardianName == "null" || client.guardianName == "")
                    { client.guardianName = "N/A"; }
                    client.guardianRelationship = Convert.ToString(dataReader["guardianRelationship"]);
                    if (client.guardianRelationship == " " || client.guardianRelationship == "null" || client.guardianRelationship == "")
                    { client.guardianRelationship = "N/A"; }

                    client.address = Convert.ToString(dataReader["strAddress"]);
                    if (client.address == " " || client.address == "null" || client.address == "")
                    { client.address = "N/A"; }

                    client.gender = Convert.ToString(dataReader["gender"]);
                    if (client.gender == " " || client.gender == "null" || client.gender == "")
                    { client.gender = "N/A"; }
                    client.guardianEmail = Convert.ToString(dataReader["guardianEmail"]);
                    if (client.guardianEmail == " " || client.guardianEmail == "null" || client.guardianEmail == "")
                    { client.guardianEmail = "N/A"; }
                    client.guardianPhone = Convert.ToString(dataReader["guardianPhone"]);
                    if (client.guardianPhone == " " || client.guardianPhone == "null" || client.guardianPhone == "")
                    { client.guardianPhone = "N/A"; }



                    client.meeting = Convert.ToString(dataReader["meeting"]);
                    var gar = Int32.TryParse(client.meeting, out int meet);
                    if (client.meeting == "1")
                    { client.meeting = "Yes"; }
                    if (client.meeting == "2")
                    { client.meeting = "Maybe"; }
                    if (client.meeting == "0")
                    { client.meeting = "No"; }
                    if (client.meeting == "")
                    { client.meeting = "N/A"; }
                    else
                    { client.meeting = client.meeting; }


                    client.youthInDuvalSchool = Convert.ToString(dataReader["youthInDuvalSchool"]);
                    var gart = Int32.TryParse(client.youthInDuvalSchool, out int tss);
                    if (client.youthInDuvalSchool == "1")
                    { client.youthInDuvalSchool = "Yes"; }
                    if (client.youthInDuvalSchool == "2")
                    { client.youthInDuvalSchool = "Maybe"; }
                    if (client.youthInDuvalSchool == "0")
                    { client.youthInDuvalSchool = "No"; }
                    if (client.youthInDuvalSchool == "")
                    { client.youthInDuvalSchool = "N/A"; }
                    else
                    { client.youthInDuvalSchool = client.youthInDuvalSchool; }

                    client.youthInSchool = Convert.ToString(dataReader["youthInSchool"]);
                    var garth = Int32.TryParse(client.youthInSchool, out int tsss);
                    if (client.youthInSchool == "1")
                    { client.youthInSchool = "Yes"; }
                    if (client.youthInSchool == "2")
                    { client.youthInSchool = "Maybe"; }
                    if (client.youthInSchool == "0")
                    { client.youthInSchool = "No"; }
                    if (client.youthInSchool == "")
                    { client.youthInSchool = "N/A"; }
                    else
                    { client.youthInSchool = client.youthInSchool; }

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
                    if (client.grade == " " || client.grade == "null" || client.grade == "")
                    { client.grade = "N/A"; }

                    client.status = Convert.ToString(dataReader["currStatus"]);
                    if (client.status == " " || client.status == "null" || client.status == "")
                    { client.status = "N/A"; }


                    client.arrest = Convert.ToString(dataReader["arrest"]);
                    var garthy = Int32.TryParse(client.arrest, out int tssss);
                    if (client.arrest == "1")
                    { client.arrest = "Yes"; }
                    if (client.arrest == "2")
                    { client.arrest = "Maybe"; }
                    if (client.arrest == "0")
                    { client.arrest = "No"; }
                    if (client.arrest == "")
                    { client.arrest = "N/A"; }
                    else
                    { client.arrest = client.arrest; }


                    client.schoola = Convert.ToString(dataReader["school"]);
                    if (client.schoola== " " || client.schoola == "null" || client.schoola == "")
                    { client.schoola = "N/A"; }

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


                    client.Reach = Convert.ToString(dataReader["reach"]);
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
                    { client.referralfname = "N/A"; }
                    client.referrallname = Convert.ToString(dataReader["referrallname"]);
                    if (client.referrallname == " " || client.referrallname == "null" || client.referrallname == "")
                    { client.referrallname = "N/A"; }
                    
                    
                    //accomodations---------------------------------Done for Datatypes Accomodation---------------------------------------------------------------

                    //int---done
                    client.accomGained = Convert.ToString(dataReader["accomGained"]);
                    var acgained = Int32.TryParse(client.accomGained, out int acg);
                    if (client.accomGained == "1")
                    { client.accomGained = "Yes"; }
                    if (client.accomGained == "2")
                    { client.accomGained = "Other"; }
                    if (client.accomGained == "0")
                    { client.accomGained = "No"; }
                    if (client.accomGained == "")
                    { client.accomGained = "N/A"; }
                    else
                    { client.accomGained = client.accomGained; }
                    //int

                    client.compService = Convert.ToString(dataReader["compServices"]);
                    var compser = Int32.TryParse(client.compService, out int compserv);
                    if (client.compService == "1")
                    { client.compService = "Yes"; }
                    if (client.compService == "0")
                    { client.compService = "No"; }
                    if (client.compService == "")
                    { client.compService = "N/A"; }
                    else
                    { client.compService = client.compService; }
                    //done
                    client.ifWhatServices = Convert.ToString(dataReader["ifWhatServices"]);
                    if (client.ifWhatServices == "")
                    { client.ifWhatServices = "N/A"; }
                    //advocacy-------------------------------------------------------------Done for Datatypes dbo.advocacy-------------------------------------------------------------
                    //int
                    client.rearrestAdvocacy = Convert.ToString(dataReader["rearrestAdvo"]);
                    var rearrestad = Int32.TryParse(client.rearrestAdvocacy, out int readvoca);
                    if (client.rearrestAdvocacy == "1")
                    { client.rearrestAdvocacy = "Yes"; }
                    if (client.rearrestAdvocacy == "0")
                    { client.rearrestAdvocacy = "No"; }
                    if (client.rearrestAdvocacy == "")
                    { client.rearrestAdvocacy = "N/A"; }
                    else
                    { client.rearrestAdvocacy = client.rearrestAdvocacy; }
                    //int

                    client.courtAdvocacy= Convert.ToString(dataReader["courtAdvo"]);
                    var coadvocacy = Int32.TryParse(client.courtAdvocacy, out int couadvocacy);
                    if (client.courtAdvocacy == "1")
                    { client.courtAdvocacy = "Yes"; }
                    if (client.courtAdvocacy == "0")
                    { client.courtAdvocacy = "No"; }
                    if (client.courtAdvocacy == "")
                    { client.courtAdvocacy = "N/A"; }
                    else
                    { client.courtAdvocacy = client.courtAdvocacy; }
                    //int
                    client.staffAdvocacy = Convert.ToString(dataReader["staffingAdvo"]);
                    var stadvoc = Int32.TryParse(client.staffAdvocacy, out int staffadvo);
                    if (client.staffAdvocacy == "1")
                    { client.staffAdvocacy = "Yes"; }
                    if (client.staffAdvocacy == "0")
                    { client.staffAdvocacy = "No"; }
                    if (client.staffAdvocacy == "")
                    { client.staffAdvocacy = "N/A"; }
                    else
                    { client.staffAdvocacy = client.staffAdvocacy; }
                    //int
                    client.legalAdvocacy = Convert.ToString(dataReader["legalAdvo"]);
                   
                    var legadvo = Int32.TryParse(client.staffAdvocacy, out int legalad);
                    if (client.legalAdvocacy == "1")
                    { client.legalAdvocacy = "Yes"; }
                    if (client.legalAdvocacy == "0")
                    { client.legalAdvocacy = "No"; }
                    if (client.legalAdvocacy == "")
                    { client.legalAdvocacy = "N/A"; }
                    else
                    { client.legalAdvocacy = client.legalAdvocacy; }

                    //done
                    client.legalAdvoTaken = Convert.ToString(dataReader["legalAdvoTaken"]);
                    if (client.legalAdvoTaken == "")
                    { client.legalAdvoTaken = "N/A"; }
                 
                    //altSchool-------------------------------------------------------------Done Int for Datatypes dbo.altSchool-------------------------------------------------------------
                    //int
                    client.altSchool = Convert.ToString(dataReader["altSchool"]);
                    var altsch = Int32.TryParse(client.altSchool, out int altschoo);
                    if (client.altSchool == "1")
                    { client.altSchool = "Yes"; }
                    if (client.altSchool == "0")
                    { client.altSchool = "No"; }
                    if (client.altSchool == "")
                    { client.altSchool = "N/A"; }
                    else
                    { client.altSchool = client.altSchool; }

                    client.altSchoolName = Convert.ToString(dataReader["altSchoolName"]);
                    if (client.altSchoolName == "yes")
                    { client.altSchoolName = "Mattie V"; }
                    if (client.altSchoolName == "no")
                    { client.altSchoolName = "Grand Park"; }
                    if (client.altSchoolName == "")
                    { client.altSchoolName = "N/A"; }
                    else
                    { client.altSchoolName = client.altSchoolName; }
                    
                    client.dateOfAlt = Convert.ToString(dataReader["altSchoolDate"]);//date-------------------------------------------------------------DODODODO_________DATE_
                    if (client.dateOfAlt == "")
                    { client.dateOfAlt = "N/A"; }
                    //int
                    client.timesInAlt = Convert.ToString(dataReader["altSchoolTimes"]);
                    if (client.timesInAlt == "")
                    { client.timesInAlt = "N/A"; }
                    
                    //int
                    client.daysOwed = Convert.ToString(dataReader["daysOwed"]);
                    if (client.daysOwed == "")
                    { client.daysOwed = "N/A"; }
                    //bully---------------------------------------------Working on dbo.bully-------------------------------------------------------------------
                    //int
                    client.bullied = Convert.ToString(dataReader["bullied"]);
                    var bulle = Int32.TryParse(client.bullied, out int bulli);
                    if (client.bullied == "1")
                    { client.bullied = "Yes"; }
                    if (client.bullied == "0")
                    { client.bullied = "No"; }
                    if (client.bullied == "")
                    { client.bullied = "N/A"; }
                    else
                    { client.bullied = client.bullied; }
                    //int count
                    client.bullyReport = Convert.ToString(dataReader["reported"]);
                    var bullere = Int32.TryParse(client.bullyReport, out int bullire);
                    if (client.bullyReport == "1")
                    { client.bullyReport = "Yes"; }
                    if (client.bullyReport == "0")
                    { client.bullyReport = "No"; }
                    if (client.bullyReport == "")
                    { client.bullyReport = "N/A"; }
                    else
                    { client.bullyReport = client.bullyReport; }
                    //date
                    client.dateofBully= Convert.ToString(dataReader["reportDate"]);//---------------------------------------------------------------Date

                    //caregiver-done
                    client.careLastName = Convert.ToString(dataReader["careLast"]);
                    if (client.careLastName == "")
                    { client.careLastName = "N/A"; }
                    
                    client.careFirstName = Convert.ToString(dataReader["careFirst"]);

                    if (client.careFirstName == "''" || client.careFirstName == " " || client.careFirstName == "null" || String.IsNullOrEmpty(client.careFirstName))
                    { client.careFirstName = "N/A"; }
                    if (!String.IsNullOrEmpty(Convert.ToString(dataReader["careFirst"])) || !String.IsNullOrWhiteSpace(Convert.ToString(dataReader["careFirst"])))
                    { client.careFirstName = Convert.ToString(dataReader["careFirst"]); }
                    client.careGender = Convert.ToString(dataReader["caregender"]);
                    if (client.careGender == "")
                    { client.careGender = "N/A"; }
                    client.careEthnicity = Convert.ToString(dataReader["careethnic"]);
                    if (client.careEthnicity.Equals("nhWhite") || client.careEthnicity.Contains("nhWhite"))
                    { client.careEthnicity = "Non Hispanic White"; }
                    if (client.careEthnicity.Equals("hispanic") || client.careEthnicity.Contains("hispanic"))
                    { client.careEthnicity = "Hispanic"; }
                    if (client.careEthnicity.Equals("natAm") || client.careEthnicity.Contains("natAm"))
                    { client.careEthnicity = "Native American"; }
                    if (client.careEthnicity.Equals("jewish") || client.careEthnicity.Contains("jewish"))
                    { client.careEthnicity = "Jewish"; }
                    if (client.careEthnicity.Equals("black") || client.careEthnicity.Contains("black"))
                    { client.careEthnicity = "Black"; }
                    if (client.careEthnicity.Equals("multi") || client.careEthnicity.Contains("multi"))
                    { client.careEthnicity = "Multiple Ethnicities"; }
                    if (client.careEthnicity.Equals("notListed") || client.careEthnicity.Contains("notListed"))
                    { client.careEthnicity = "Ethnicity Not Listed"; }
                    if (client.careEthnicity.Equals("null"))
                    { client.careEthnicity = "N/A"; }


                    client.careRelation = Convert.ToString(dataReader["relationship"]);
                    if (client.careRelation == "")
                    { client.careRelation = "N/A"; }

                    //ccr
                    client.levelOfServiceProvided = Convert.ToString(dataReader["levelofService"]);
                    if (client.levelOfServiceProvided == "n")
                    { client.levelOfServiceProvided = "None"; }
                    if (client.levelOfServiceProvided == "info")
                    { client.levelOfServiceProvided = "Information/Education"; }
                    if (client.levelOfServiceProvided == "service")
                    { client.levelOfServiceProvided = "Brief Service/Advice"; }
                    if (client.levelOfServiceProvided == "full")
                    { client.levelOfServiceProvided = "Full"; }
                    if (client.levelOfServiceProvided == "")
                    { client.levelOfServiceProvided = "N/A"; }
                    else
                    { client.levelOfServiceProvided = client.levelOfServiceProvided; }
                    //int
                    client.caseStatus = Convert.ToString(dataReader["ccrStatus"]);
                    var cstat = Int32.TryParse(client.caseStatus, out int csta);
                    if (client.caseStatus == "1")
                    { client.caseStatus = "Open"; }
                    if (client.caseStatus == "2")
                    { client.caseStatus = "Closed due to nonengagement"; }
                    if (client.caseStatus == "0")
                    { client.caseStatus = "Closed"; }
                    if (client.caseStatus == "")
                    { client.caseStatus = "N/A"; }
                    else
                    { client.caseStatus = client.caseStatus; }

                    client.remedyResolution= Convert.ToString(dataReader["remedy"]);
                    var remre = Int32.TryParse(client.remedyResolution, out int rereed);
                    if (client.remedyResolution == "1")
                    { client.remedyResolution = "Yes"; }
                    if (client.remedyResolution == "0")
                    { client.remedyResolution = "No"; }
                    if (client.remedyResolution == "")
                    { client.remedyResolution = "N/A"; }
                    else
                    { client.remedyResolution = client.remedyResolution; }


                    //int
                    client.rearrestWhileRepresented = Convert.ToString(dataReader["rearrestRep"]);
                    var rwr = Int32.TryParse(client.rearrestWhileRepresented, out int rwrep);
                    if (client.rearrestWhileRepresented == "1")
                    { client.rearrestWhileRepresented = "Yes"; }
                    if (client.rearrestWhileRepresented == "0")
                    { client.rearrestWhileRepresented = "No"; }
                    if (client.rearrestWhileRepresented == "")
                    { client.rearrestWhileRepresented = "N/A"; }
                    else
                    { client.rearrestWhileRepresented = client.rearrestWhileRepresented; }
                    client.schoolAtClosure = Convert.ToString(dataReader["closureSchool"]);
                    if (client.schoolAtClosure == "")
                    { client.schoolAtClosure = "N/A"; }

                    //client---------------------------------------------------------------Working on Datatypes for CLIENT------------------------------------
                    client.clientLastName = Convert.ToString(dataReader["clientLast"]);
                    if (client.clientLastName == "")
                    { client.clientLastName = "N/A"; }
                    client.clientFirstName = Convert.ToString(dataReader["clientFirst"]);
                    if (client.clientFirstName == "")
                    { client.clientFirstName = "N/A"; }
                    //int
                    client.dependency = Convert.ToString(dataReader["dependency"]);
                    if (client.dependency == "")
                    { client.dependency = "Null"; }
                    
                    client.clientGender = Convert.ToString(dataReader["gender"]);
              if (client.clientGender == "" || client.clientGender == " "|| client.clientGender == "null" || String.IsNullOrEmpty(Convert.ToString(dataReader["clientgender"])))
                  { client.clientGender = "N/A"; }





                    client.clientEthnicity = Convert.ToString(dataReader["clientethn"]);
                    if (client.clientEthnicity.Equals("nhWhite") || client.clientEthnicity.Contains("nhWhite"))
                    { client.clientEthnicity = "Non Hispanic White"; }
                    if (client.clientEthnicity.Equals("hispanic") || client.clientEthnicity.Contains("hispanic"))
                    { client.clientEthnicity = "Hispanic"; }
                    if (client.clientEthnicity.Equals("natAm") || client.clientEthnicity.Contains("natAm"))
                    { client.clientEthnicity = "Native American"; }
                    if (client.clientEthnicity.Equals("jewish") || client.clientEthnicity.Contains("jewish"))
                    { client.clientEthnicity = "Jewish"; }
                    if (client.clientEthnicity.Equals("black") || client.clientEthnicity.Contains("black"))
                    { client.clientEthnicity = "Black"; }
                    if (client.clientEthnicity.Equals("multi") || client.clientEthnicity.Contains("multi"))
                    { client.clientEthnicity = "Multiple Ethnicities"; }
                    if (client.clientEthnicity.Equals("notListed") || client.clientEthnicity.Contains("notListed"))
                    { client.clientEthnicity = "Ethnicity Not Listed"; }
                    if (client.clientEthnicity.Equals("null"))
                    { client.clientEthnicity = "N/A"; }
                  
                     //date
                    client.clientDOB = Convert.ToString(dataReader["dob"]);//////////////////////Date-----------------------------Date
                    if (client.clientDOB == "")
                    { client.clientDOB = "N/A"; }
                    client.clientphone = Convert.ToString(dataReader["phoneNumber"]);
                    if (client.clientphone == "")
                    { client.clientphone = "N/A"; }

                    //comp
                    //int
                    client.compService = Convert.ToString(dataReader["compServices"]);
                    var comser = Int32.TryParse(client.compService, out int compservic);
                    if (client.compService == "1")
                    { client.compService = "Yes"; }
                    if (client.compService == "0")
                    { client.compService = "No"; }
                    if (client.compService == "")
                    { client.compService = "N/A"; }
                    else
                    { client.compService = client.compService; }

                    client.howManyTimes = Convert.ToString(dataReader["compTime"]);
                    if (client.howManyTimes == "")
                    { client.howManyTimes = "N/A"; }


                    //cu------------------------------------------------------------------Working on CU Datatypes
                    client.readingLevel = Convert.ToString(dataReader["readingLevel"]);
                    if(client.readingLevel =="")
                    { client.readingLevel = "N/A"; }
                    client.mathLevel = Convert.ToString(dataReader["mathLevel"]);
                    if (client.mathLevel == "")
                    { client.mathLevel = "N/A"; }
                    client.currentServ = Convert.ToString(dataReader["currentServices"]);
                    if (client.currentServ == "")
                    { client.currentServ = "N/A"; }
                    //int
                    client.inPride = Convert.ToString(dataReader["inPride"]);
                    if (client.inPride == "y")
                    { client.inPride = "Yes"; }
                    if (client.inPride == "n")
                    { client.inPride = "No"; }
                    if (client.inPride == "")
                    { client.inPride = "N/A"; }
                    else
                    { client.inPride = client.inPride; }
                    //int
                    client.newFBA = Convert.ToString(dataReader["newFBA"]);
                    if (client.newFBA == "y")
                    { client.newFBA = "Yes"; }
                    if (client.newFBA == "n")
                    { client.newFBA = "No"; }
                    if (client.newFBA == "")
                    { client.newFBA = "N/A"; }
                    else
                    { client.newFBA = client.newFBA; }
                    //int
                    client.addServ= Convert.ToString(dataReader["addService"]);
                    if (client.addServ == "")
                    { client.addServ = "N/A"; }
                    client.servgain = Convert.ToString(dataReader["servicesGained"]);
                    if (client.servgain == "")
                    { client.servgain = "N/A"; }



                    //failed-all int------------------------------------------------Working on FAILED DATATYPES

                    client.failedGrade = Convert.ToString(dataReader["gradeFailed"]);
                    var failgr = Int32.TryParse(client.failedGrade, out int failg);
                    if (client.failedGrade == "1")
                    { client.failedGrade = "Yes"; }
                    if (client.failedGrade == "0")
                    { client.failedGrade = "No"; }
                    if (client.failedGrade == "")
                    { client.failedGrade = "N/A"; }
                    else
                    { client.failedGrade = client.failedGrade; }

                    client.whichGradeFailed = Convert.ToString(dataReader["whichGrade"]);
                    if (client.whichGradeFailed == "0")
                    { client.whichGradeFailed = "Kindergarten"; }
                    if (client.whichGradeFailed == "1")
                    { client.whichGradeFailed = "1st Grade"; }
                    if (client.whichGradeFailed == "2")
                    { client.whichGradeFailed = "2nd Grade"; }
                    if (client.whichGradeFailed == "3")
                    { client.whichGradeFailed = "3rd Grade"; }
                    if (client.whichGradeFailed == "4")
                    { client.whichGradeFailed = "4th Grade"; }
                    if (client.whichGradeFailed == "5")  
                    { client.whichGradeFailed = "5th Grade"; }
                    if (client.whichGradeFailed == "6")
                    { client.whichGradeFailed = "6th Grade"; }
                    if (client.whichGradeFailed == "7")
                    { client.whichGradeFailed = "7th Grade"; }
                    if (client.whichGradeFailed == "8")
                    { client.whichGradeFailed = "8th Grade"; }
                    if (client.whichGradeFailed == "9")
                    { client.whichGradeFailed = "9th Grade"; }
                    if (client.whichGradeFailed == "10")
                    { client.whichGradeFailed = "10th Grade"; }
                    if (client.whichGradeFailed == "11")
                    { client.whichGradeFailed = "11th Grade"; }
                    if (client.whichGradeFailed == "12")
                    { client.whichGradeFailed = "12th Grade"; }
                    if(client.whichGradeFailed =="")
                    { client.whichGradeFailed = "N/A"; }

                    client.failCount= Convert.ToString(dataReader["failedRepeat"]);
                    if (client.failCount == "")
                    { client.failCount = "N/A"; }

                    //health- all int------------------------------------------------------------------WORKING ON HEALTH DATATYPES------------------------------------------
                    client.baker = Convert.ToString(dataReader["bakerActed"]);
                    var bak = Int32.TryParse(client.baker, out int abk);
                    if (client.baker == "1")
                    { client.baker = "Yes"; }
                    if (client.baker == "0")
                    { client.baker = "No"; }
                    if (client.baker == "")
                    { client.baker = "N/A"; }
                    else
                    { client.baker = client.baker; }
                    client.marchman= Convert.ToString(dataReader["marchmanActed"]);
                    var madmarch = Int32.TryParse(client.marchman, out int marchmad);
                    if (client.marchman == "1")
                    { client.marchman = "Yes"; }
                    if (client.marchman == "0")
                    { client.marchman = "No"; }
                    if (client.marchman == "")
                    { client.marchman = "N/A"; }
                    else
                    { client.marchman = client.marchman; }
                    client.asthma = Convert.ToString(dataReader["asthma"]);
                    if (client.asthma == "y")
                    { client.asthma = "Yes"; }
                    if (client.asthma == "n")
                    { client.asthma = "No"; }
                    if (client.asthma == "")
                    { client.asthma = "N/A"; }

                    //household- all int
                    client.femHouse = Convert.ToString(dataReader["femLed"]);
                    var hfem = Int32.TryParse(client.femHouse, out int femh);
                    if (client.femHouse == "1")
                    { client.femHouse = "Yes"; }
                    if (client.femHouse == "0")
                    { client.femHouse = "No"; }
                    if (client.femHouse == "")
                    { client.femHouse = "N/A"; }
                    else
                    { client.femHouse = client.femHouse; }
                    client.domVio = Convert.ToString(dataReader["domVio"]);
                    var vd = Int32.TryParse(client.domVio, out int dv);
                    if (client.domVio == "1")
                    { client.domVio = "Yes"; }
                    if (client.domVio == "0")
                    { client.domVio = "No"; }
                    if (client.domVio == "")
                    { client.domVio = "N/A"; }
                    else
                    { client.domVio = client.domVio; }
                    client.adopted = Convert.ToString(dataReader["adopted"]);
                    var adopt= Int32.TryParse(client.adopted, out int adop);
                    if (client.adopted == "1")
                    { client.adopted = "Yes"; }
                    if (client.adopted == "0")
                    { client.adopted = "No"; }
                    if (client.adopted == "")
                    { client.adopted = "N/A"; }
                    else
                    { client.adopted = client.adopted; }
                    client.evicted = Convert.ToString(dataReader["evicted"]);
                    var ev = Int32.TryParse(client.evicted, out int evict);
                    if (client.evicted == "1")
                    { client.evicted = "Yes"; }
                    if (client.evicted == "0")
                    { client.evicted = "No"; }
                    if (client.evicted == "")
                    { client.evicted = "N/A"; }
                    else
                    { client.evicted = client.evicted; }
                    client.incarParent = Convert.ToString(dataReader["incarParent"]);
                    var incarp = Int32.TryParse(client.incarParent, out int incarpare);
                    if (client.incarParent == "1")
                    { client.incarParent = "Yes"; }
                    if (client.incarParent == "0")
                    { client.incarParent = "No"; }
                    if (client.incarParent == "")
                    { client.incarParent = "N/A"; }
                    else
                    { client.incarParent = client.incarParent; }
                    client.publicAssistance = Convert.ToString(dataReader["publicAssistance"]);
                    var publicass = Int32.TryParse(client.publicAssistance, out int publicassis);
                    if (client.publicAssistance == "1")
                    { client.publicAssistance = "Yes"; }
                    if (client.publicAssistance == "0")
                    { client.publicAssistance = "No"; }
                    if (client.publicAssistance == "")
                    { client.publicAssistance = "N/A"; }
                    else
                    { client.publicAssistance = client.publicAssistance; }
                    //referral-----------------------------------------------------Working on Referral---------------------------------
                    
                    client.referralDate = Convert.ToString(dataReader["referralDate"]);//----------------------------Date-----------------------------------
                    if (client.referralDate == "")
                    { client.referralDate = "N/A"; }
                    client.intakeDate= Convert.ToString(dataReader["intakeDate"]);//------------------------------------Date------------------------------------
                    if (client.intakeDate == "")
                    { client.intakeDate = "N/A"; }
                    client.referral1 = Convert.ToString(dataReader["referral1"]);
                    if (client.referral1 == "")
                    { client.referral1 = "N/A"; }
                    client.referral2= Convert.ToString(dataReader["referral2"]);
                    if (client.referral2 == "")
                    { client.referral2 = "N/A"; }
                    client.referral3= Convert.ToString(dataReader["referral3"]);
                    if (client.referral3 == "")
                    { client.referral3 = "N/A"; }
                    client.referralname = Convert.ToString(dataReader["referrerName"]);
                    if (client.referralname == "")
                    { client.referralname = "N/A"; }
                    client.emailOfFirstReferralSource = Convert.ToString(dataReader["referrerEmail"]);
                    if (client.emailOfFirstReferralSource == "")
                    { client.emailOfFirstReferralSource = "N/A"; }
                    //suspended--all int

                    client.suspendedthrice = Convert.ToString(dataReader["suspendedThrice"]);
                    var thrise = Int32.TryParse(client.suspendedthrice, out int thris);
                    if (client.suspendedthrice == "1")
                    { client.suspendedthrice = "Yes"; }
                    if (client.suspendedthrice == "0")
                    { client.suspendedthrice = "No"; }
                    if (client.suspendedthrice == "")
                    { client.suspendedthrice = "N/A"; }
                    else
                    { client.suspendedthrice = client.suspendedthrice; }
                    client.suspendCount = Convert.ToString(dataReader["numSuspensions"]);
                    if (client.suspendCount == "+10")
                    { client.suspendCount = "+10"; }
                    if (client.suspendCount == "")
                    { client.suspendCount = "N/A"; }
                  
                    
                    client.suspendedtotal = Convert.ToString(dataReader["totalDaysSuspended"]);
                    if (client.suspendedtotal == "")
                    { client.suspendedtotal = "N/A"; }
                    client.ISS = Convert.ToString(dataReader["ISS"]);
                    if (client.ISS == "")
                    { client.ISS = "N/A"; }
                    client.OSS = Convert.ToString(dataReader["OSS"]);
                    if (client.OSS == "")
                    { client.OSS = "N/A"; }
                    client.daysdiscipline= Convert.ToString(dataReader["daysofDiscipline"]);
                    if (client.daysdiscipline == "")
                    { client.daysdiscipline = "N/A"; }
                    client.dayssincediscipline = Convert.ToString(dataReader["disciplineSinceIntake"]);
                    if (client.dayssincediscipline == "")
                    { client.dayssincediscipline = "N/A"; }

                    //IEP
                    //int
                    client.iep = Convert.ToString(dataReader["IEP"]);
                    if (client.iep == "y")
                    { client.iep = "Yes"; }
                    if (client.iep == "n")
                    { client.iep = "No"; }
                    if (client.iep == "")
                    { client.iep = "N/A"; }
                    client.iepplan1 = Convert.ToString(dataReader["primaryIEP"]);
                    if (client.iepplan1 == "emo") { client.iepplan1 = "Emotional/Behavioral Disability"; }
                    if (client.iepplan1 == "gifted") { client.iepplan1 = "Gifted"; }
                    if (client.iepplan1 == "intell") { client.iepplan1 = "Intellectual Disability"; }
                    if (client.iepplan1 == "lang") { client.iepplan1 = "Language Impairment"; }
                    if(client.iepplan1 == "otherHealth") { client.iepplan1 = "Other Health Impairment"; }
                    if (client.iepplan1 == "specificLearning") { client.iepplan1 = "Specific Learning Disability"; }
                    if (client.iepplan1 == "speech") { client.iepplan1 = "Speech Impairment"; }
                    if (client.iepplan1 == "other") { client.iepplan1 = "other"; }
                    if (client.iepplan1 == "")
                    { client.iepplan1 = "N/A"; }
                    client.iepplan2 = Convert.ToString(dataReader["secondaryIEP"]);
                    if (client.iepplan2 == "emo") { client.iepplan2 = "Emotional/Behavioral Disability"; }
                    if (client.iepplan2 == "gifted") { client.iepplan2 = "Gifted"; }
                    if (client.iepplan2 == "intell") { client.iepplan2 = "Intellectual Disability"; }
                    if (client.iepplan2 == "lang") { client.iepplan2 = "Language Impairment"; }
                    if (client.iepplan2 == "otherHealth") { client.iepplan2 = "Other Health Impairment"; }
                    if (client.iepplan2 == "specificLearning") { client.iepplan2 = "Specific Learning Disability"; }
                    if (client.iepplan2 == "speech") { client.iepplan2 = "Speech Impairment"; }
                    if (client.iepplan2 == "other") { client.iepplan2 = "other"; }
                    if (client.iepplan2 == "")
                    { client.iepplan2 = "N/A"; }
                    //int
                    client.addiepplan = Convert.ToString(dataReader["addIEP"]);
                    if (client.addiepplan == "")
                    { client.addiepplan = "N/A"; }
                    //legal
                    client.firstLegal = Convert.ToString(dataReader["legalIssues"]);
                    if (client.firstLegal == "edu")
                    { client.firstLegal = "Education"; }
                    if (client.firstLegal == "juv")
                    { client.firstLegal = "Juvenile Justice"; }
                    if (client.firstLegal == "dependency")
                    { client.firstLegal = "Dependency"; }
                    if (client.firstLegal == "baker")
                    { client.firstLegal = "Baker Act"; }
                    if (client.firstLegal == "famlaw")
                    { client.firstLegal = "Family Law"; }
                    if (client.firstLegal == "immig")
                    { client.firstLegal = "Immigration"; }
                    if (client.firstLegal == "publicben")
                    { client.firstLegal = "Public Benefits"; }
                    if (client.firstLegal == "housing")
                    { client.firstLegal = "Housing"; }
                    if (client.firstLegal == "other")
                    { client.firstLegal = "Other"; }
                    if (client.firstLegal == "")
                    { client.firstLegal = "N/A"; }
                    client.secondLegal = Convert.ToString(dataReader["leagalIssues2"]);
                    if (client.firstLegal == "")
                    { client.firstLegal = "N/A"; }
                    clientl.Add(client);

                }
            }

            cnn.Close();
            return View(clientl);

        
        }
        public IActionResult EditTrackingM(int clientCode)
        {
            //edit tracking information in a form format
            return View();

        }
        public IActionResult confirmationM()
        {
            //confirmation thank you page for submiting and give email
            return View();

        }
    }
}
