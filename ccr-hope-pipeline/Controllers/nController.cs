using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Referrals;
using HopePipeline.Models.DbEntities.Tracking;
using System.Diagnostics;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace HopePipeline.Controllers
{
    public class nController : Controller
    {
        string connectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        string cconnectionString = "Server=tcp:hopepipeline.database.windows.net,1433;Initial Catalog=Hope-Pipeline;Persist Security Info=False;User ID=badmin;Password=Hope2020!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public IActionResult formReferralM()
        {
            
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = cnn.CreateCommand();
           
            Guid clientCode = Guid.NewGuid();

            ViewBag.Tessage = clientCode;

            ViewBag.Bessage = DateTime.Now;
            

            //SELECT MAX(Price) AS LargestPrice
            //FROM Products;

            cnn.Close();

            return View();

        }//GUID Done-------------------------------------------------------------------------Form Referral Method
        [HttpPost]
        public IActionResult submitform(referralBrandi form)
        {
           
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "INSERT INTO dbo.refform VALUES (@fName, @lName , @dOB , @clientCode, @guardianName,@guardianlName , @guardianRelationship, @address, @gender, @guardianEmail, @guardianPhone, @meeting, @youthInDuvalSchool, @youthInSchool, @issues, @currentSchool, @zip, @grade, @Pending, @arrest, @school , @dateInput, @date, @email, @Reach, @moreInfo,  @reason , @referralfname, @referrallname, @0 , @nameOrg ,@youthNu, @youthEmail, @youthCit, @youthOffense, @youthImpact, @youthAlt, @youthSetting, @youthInjunction);";
            
            command = new SqlCommand(query, cnn);
            //Pass values to Parameters
            SqlParameter fNamecheck = command.Parameters.AddWithValue("@fName", form.fName);
            if (form.fName == null)
            {
                fNamecheck.Value = DBNull.Value;
            }
            SqlParameter lNamecheck = command.Parameters.AddWithValue("@lName", form.lName);
            if (form.lName == null)
            {
               lNamecheck.Value = DBNull.Value;
            }
            SqlParameter dOBcheck = command.Parameters.AddWithValue("@dOB", form.dOB);//check
            if (form.dOB == null)
            {
                dOBcheck.Value = DBNull.Value;
            }

            command.Parameters.AddWithValue("@clientCode", form.clientCode);
            SqlParameter guardianNamecheck =command.Parameters.AddWithValue("@guardianName", form.guardianName);
            if (form.guardianName == null)
            {
                guardianNamecheck.Value = DBNull.Value;
            }
            SqlParameter guardianlNamecheck = command.Parameters.AddWithValue("@guardianlName", form.guardianlName);
            if (form.guardianlName == null)
            {
                guardianlNamecheck.Value = DBNull.Value;
            }
            SqlParameter guardianRelationshipcheck = command.Parameters.AddWithValue("@guardianRelationship", form.guardianRelationship);
            if (form.guardianRelationship == null)
            {
                guardianRelationshipcheck.Value = DBNull.Value;
            }
            SqlParameter addresscheck = command.Parameters.AddWithValue("@address", form.address);
            if (form.address == null)
            {
                addresscheck.Value = DBNull.Value;
            }
            SqlParameter gendercheck = command.Parameters.AddWithValue("@gender", form.gender);
            if (form.gender == null)
            {
                gendercheck.Value = DBNull.Value;
            }
            SqlParameter guardianEmailcheck = command.Parameters.AddWithValue("@guardianEmail", form.guardianEmail);
            if (form.guardianEmail == null)
            {
                guardianEmailcheck.Value = DBNull.Value;
            }
            SqlParameter guardianPhonecheck =  command.Parameters.AddWithValue("@guardianPhone", form.guardianPhone);
            if (form.guardianPhone == null)
            {
                guardianPhonecheck.Value = DBNull.Value;
            }
            SqlParameter meetingcheck = command.Parameters.AddWithValue("@meeting", form.meeting);
            if (form.meeting != 0 && form.meeting !=1 && form.meeting !=2)
            {
                meetingcheck.Value = DBNull.Value;
            }
            SqlParameter youthInDuvalSchoolcheck = command.Parameters.AddWithValue("@youthInDuvalSchool", form.youthInDuvalSchool);
            if (form.youthInDuvalSchool != 0 && form.youthInDuvalSchool != 1 && form.youthInDuvalSchool != 2)
            {
                youthInDuvalSchoolcheck.Value = DBNull.Value;
            }
            SqlParameter youthInSchoolcheck = command.Parameters.AddWithValue("@youthInSchool", form.youthInSchool);
            if (form.youthInSchool != 0 && form.youthInSchool != 1 && form.youthInSchool != 2)
            {
                youthInSchoolcheck.Value = DBNull.Value;
            }
            SqlParameter issuescheck = command.Parameters.AddWithValue("@issues", form.issues);
            if (form.issues == null)
            {
                issuescheck.Value = DBNull.Value;
            }
           SqlParameter currentschoolcheck = command.Parameters.AddWithValue("@currentSchool", "null");
            
            SqlParameter zipcheck =  command.Parameters.AddWithValue("@zip", form.zip);
            if (form.zip == null)
            {
                zipcheck.Value = DBNull.Value;
            }
            SqlParameter gradecheck = command.Parameters.AddWithValue("@grade", form.grade);
            if (form.grade == null)
            {
                gradecheck.Value = DBNull.Value;
            }
            command.Parameters.AddWithValue("@Pending", "Pending");

            SqlParameter arrestcheck = command.Parameters.AddWithValue("@arrest", form.arrest);
            if (form.arrest != 0 && form.arrest != 1 && form.arrest != 2)
            {
                arrestcheck.Value = DBNull.Value;
            }
            SqlParameter schoolcheck = command.Parameters.AddWithValue("@school", form.school);
            if (form.school == null)
            {
                schoolcheck.Value = DBNull.Value;
            }
            SqlParameter dateInputcheck = command.Parameters.AddWithValue("@dateInput", form.dateInput);
            if (form.dateInput == null)
            {
                dateInputcheck.Value = DBNull.Value;
            }
            SqlParameter datecheck = command.Parameters.AddWithValue("@date", form.date);
            if (form.date == null)
            {
                datecheck.Value = DBNull.Value;
            }
            SqlParameter emailcheck = command.Parameters.AddWithValue("@email", form.email);
            if (form.email == null)
            {
                emailcheck.Value = DBNull.Value;
            }
            SqlParameter Reachcheck = command.Parameters.AddWithValue("@Reach", form.Reach);
            if (form.Reach == null)
            {
                Reachcheck.Value = DBNull.Value;
            }
            SqlParameter moreInfocheck = command.Parameters.AddWithValue("@moreInfo", form.moreInfo);
            if (form.moreInfo == null)
            {
                moreInfocheck.Value = DBNull.Value;
            }
            SqlParameter reasoncheck = command.Parameters.AddWithValue("@reason", form.reason);
            if (form.reason == null)
            {
                reasoncheck.Value = DBNull.Value;
            }
            SqlParameter referralfnamecheck = command.Parameters.AddWithValue("@referralfname", form.referralfname);
            if (form.referralfname == null)
            {
                referralfnamecheck.Value = DBNull.Value;
            }
            SqlParameter referrallnamecheck = command.Parameters.AddWithValue("@referrallname", form.referrallname);
            if (form.referrallname == null)
            {
                referrallnamecheck.Value = DBNull.Value;
            }
            command.Parameters.AddWithValue("@0", 0);
            SqlParameter nameOrgcheck = command.Parameters.AddWithValue("@nameOrg", form.nameOrg);
            if (form.nameOrg == null)
            {
                nameOrgcheck.Value = DBNull.Value;
            }
            SqlParameter youthNucheck = command.Parameters.AddWithValue("@youthNu", form.youthNu);
            if (form.youthNu == null)
            {
                youthNucheck.Value = DBNull.Value;
            }
            SqlParameter youthEmailcheck = command.Parameters.AddWithValue("@youthEmail", form.youthEmail);
            if (form.youthEmail == null)
            {
                youthEmailcheck.Value = DBNull.Value;
            }
            SqlParameter youthCitcheck = command.Parameters.AddWithValue("@youthCit", form.youthCit);
            if (form.youthCit != 0 && form.youthCit != 1 )
            {
                youthCitcheck.Value = DBNull.Value;
            }
            SqlParameter youthOffensecheck = command.Parameters.AddWithValue("@youthOffense", form.youthOffense);
            if (form.youthOffense != 0 && form.youthOffense != 1 && form.youthOffense != 2)
            {
                youthOffensecheck.Value = DBNull.Value;
            }
            SqlParameter youthImpactcheck = command.Parameters.AddWithValue("@youthImpact", form.youthImpact);
            if (form.youthImpact == null)
            {
                youthImpactcheck.Value = DBNull.Value;
            }
            SqlParameter youthAltcheck = command.Parameters.AddWithValue("@youthAlt", form.youthAlt);//not done
            if (form.youthAlt != 0 && form.youthAlt != 1 && form.youthAlt != 2)
            {
                youthAltcheck.Value = DBNull.Value;
            }
            SqlParameter youthSettingcheck = command.Parameters.AddWithValue("@youthSetting", form.youthSetting);//not done
            if (form.youthSetting != 0 && form.youthSetting != 1 && form.youthSetting != 2)
            {
                youthSettingcheck.Value = DBNull.Value;
            }
            SqlParameter youthInjunctioncheck = command.Parameters.AddWithValue("@youthInjunction", form.youthInjunction);//not done
            if (form.youthInjunction != 0 && form.youthInjunction != 1 && form.youthInjunction != 2)
            {
                youthInjunctioncheck.Value = DBNull.Value;
            }




            SqlDataReader reader = command.ExecuteReader();
            string fname = form.fName.ToString();
            string lname = form.lName.ToString();
            string namestring = fname+ " " + lname;
            reader.Close();

            //COnnect to the DB

            ViewBag.Name = namestring;
            ViewBag.Bessage = DateTime.Now;
            adapter.Dispose();
            command.Dispose();
            return View("confirmationM", "n");

        }//-------------------------------------------------------------End Form Submit Referral GUID DONE

        public IActionResult contactInfoM(Guid clientCode)
        {
            
            //var client= new Contact();
            List<Contact> clientl = new List<Contact>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT fname, lname, guardianName, guardianlName, guardianRelationship, guardianPhone, guardianEmail, strAddress, zip, reach, referrallname, referralfname, email, nameOrg, youthNu, youthEmail  FROM refform WHERE clientCode= '" + clientCode + "';";

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
                    client.guardianlName = Convert.ToString(dataReader["guardianlName"]);
                    if (client.guardianlName == " " || client.guardianlName == "null" || client.guardianlName == "")
                    { client.guardianlName = "N/A"; }
                    client.relationship = Convert.ToString(dataReader["guardianRelationship"]);
                    if (client.relationship == " " || client.relationship == "null" || client.relationship == "")
                    { client.relationship = "N/A"; }
                    client.phone = Convert.ToString(dataReader["guardianPhone"]);
                    if (client.phone == " " || client.phone == "null" || client.phone == "")
                    { client.phone = "N/A"; }
                    client.address = Convert.ToString(dataReader["strAddress"]);
                    if (client.address == " " || client.address == "null" || client.address == "")
                    { client.address = "N/A"; }
                    client.email = Convert.ToString(dataReader["guardianEmail"]);
                    if (client.email == " " || client.email == "null" || client.email == "")
                    { client.email = "N/A"; }
                    client.zip = Convert.ToString(dataReader["zip"]);
                    if (client.zip == " " || client.zip == "null" || client.zip == "")
                    { client.zip = "N/A"; }
                    client.reach = Convert.ToString(dataReader["reach"]);
                    if (client.reach == " " || client.reach == "null" || client.reach == "")
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

                    client.nameOrg = Convert.ToString(dataReader["nameOrg"]);
                    if (client.nameOrg == " " || client.nameOrg == "null" || client.nameOrg == "")
                    { client.nameOrg = "N/A"; }
                    client.youthNu = Convert.ToString(dataReader["youthNu"]);
                    if (client.youthNu == " " || client.youthNu == "null" || client.youthNu == "")
                    { client.youthNu = "N/A"; }
                    client.youthEmail = Convert.ToString(dataReader["youthEmail"]);
                    if (client.youthEmail == " " || client.youthEmail == "null" || client.youthEmail == "")
                    { client.youthEmail = "N/A"; }

                    clientl.Add(client);

                }
            }
            adapter.Dispose();
            command.Dispose();
            cnn.Close();
            return View(clientl);

        }// GUID --------------------------------------------------GUID should be done for contact----------------------------------------

        public IActionResult detailReferralM(Guid clientCode)
        {
            
            //var client= new Contact();
            List<referralDetail> clientl = new List<referralDetail>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientCode, fname, lname, dob, guardianName, guardianlName, guardianRelationship, strAddress, gender, guardianEmail, guardianPhone, meeting, youthInDuvalSchool, youthInSchool, issues, currentSchool, zip, grade, currStatus, arrest, school, dateInput, meetingDate, email, reach, moreInfo, reason, referralfname, referrallname, nameOrg, youthNu, youthEmail, youthCit, youthOffense, youthImpact, youthAlt, youthSetting, youthInjunction FROM refform WHERE clientCode= '" + clientCode + "';";

            command = new SqlCommand(query, cnn);

            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    referralDetail client = new referralDetail();
                    client.clientCode = Guid.Parse(Convert.ToString(dataReader["clientCode"]));


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
                    client.guardianlName = Convert.ToString(dataReader["guardianlName"]);
                    if (client.guardianlName == " " || client.guardianlName == "null" || client.guardianlName == "")
                    { client.guardianlName = "N/A"; }
                    client.guardianRelationship = Convert.ToString(dataReader["guardianRelationship"]);
                    if (client.guardianRelationship == " " || client.guardianRelationship == "null" || client.guardianRelationship == "")
                    { client.guardianRelationship = "N/A"; }

                    client.address = Convert.ToString(dataReader["strAddress"]);
                    if (client.address == " " || client.address == "null" || client.address == "")
                    { client.address = "N/A"; }

                    client.gender = Convert.ToString(dataReader["gender"]);
                    if (client.gender == "male")
                    { client.gender = "He/Him/His"; }
                    if (client.gender == "female")
                    { client.gender = "She/Her/Hers"; }
                    if (client.gender == "trans*")
                    { client.gender = "They/them/Theirs"; }
                    if (client.gender == "nonbinaryF")
                    { client.gender = "She/They"; }
                    if (client.gender == "nonbinaryM")
                    { client.gender = "He/They"; }
                    if (client.gender == "neutral")
                    { client.gender = "Zie/Zir/Zirs"; }
                    if (client.gender == " " || client.gender == "null" || client.gender == "")
                    { client.gender = "N/A"; }





                    client.guardianEmail = Convert.ToString(dataReader["guardianEmail"]);
                    if (client.guardianEmail == " " || client.guardianEmail == "null" || client.guardianEmail == "")
                    { client.guardianEmail = "N/A"; }
                    client.guardianPhone = Convert.ToString(dataReader["guardianPhone"]);
                    if (client.guardianPhone == " " || client.guardianPhone == "null" || client.guardianPhone == "")
                    { client.guardianPhone = "N/A"; }



                    client.meeting = Convert.ToString(dataReader["meeting"]);
                   // var gar = Int32.TryParse(client.meeting, out int meet);
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
                   // var gart = Int32.TryParse(client.youthInDuvalSchool, out int tss);
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
                   // var garth = Int32.TryParse(client.youthInSchool, out int tsss);
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
                   // var garthy = Int32.TryParse(client.arrest, out int tssss);
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


                    client.school = Convert.ToString(dataReader["school"]);
                    if (client.school == " " || client.school == "null" || client.school == "")
                    { client.school = "N/A"; }

                    int space2 = Convert.ToString(dataReader["dateInput"]).IndexOf(' ');
                    if (Convert.ToString(dataReader["dateInput"]).Length > 10)
                    { client.dateInput = Convert.ToString(dataReader["dateInput"]).Substring(0, space2); }
                    if (client.dateInput == " " || client.dateInput == "null" || client.dateInput == "" || Convert.ToString(dataReader["dateInput"]).Length < 10)
                    { client.dateInput = "N/A"; }

                     client.date = Convert.ToString(dataReader["meetingDate"]);
                    if (client.date == " " || client.date == "null" || client.date == "" || client.date == "1/1/1900 12:00:00 AM")
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
                    //new referral info
                    client.nameOrg = Convert.ToString(dataReader["nameOrg"]);
                    if (client.nameOrg == " " || client.nameOrg == "null" || client.nameOrg == "")
                    { client.nameOrg = "N/A"; }
                    client.youthNu = Convert.ToString(dataReader["youthNu"]);
                    if (client.youthNu == " " || client.youthNu == "null" || client.youthNu == "")
                    { client.youthNu = "N/A"; }
                    client.youthEmail = Convert.ToString(dataReader["youthEmail"]);
                    if (client.youthEmail == " " || client.youthEmail == "null" || client.youthEmail == "")
                    { client.youthEmail = "N/A"; }

                    client.youthCit = Convert.ToString(dataReader["youthCit"]);
                   // var ycit = Int32.TryParse(client.youthCit, out int yc);
                    if (client.youthCit == "1")
                    { client.youthCit = "Yes"; }
                    if (client.youthCit == "0")
                    { client.youthCit = "No"; }
                    if (client.youthCit == "")
                    { client.youthCit = "N/A"; }
                    else
                    { client.youthCit = client.youthCit; }


                    client.youthOffense = Convert.ToString(dataReader["youthOffense"]);
                   // var offense = Int32.TryParse(client.youthOffense, out int ofence);
                    if (client.youthOffense == "1")
                    { client.youthOffense = "Yes"; }
                    if (client.youthOffense == "2")
                    { client.youthOffense = "Maybe"; }
                    if (client.youthOffense == "0")
                    { client.youthOffense = "No"; }
                    if (client.youthOffense == "")
                    { client.youthOffense = "N/A"; }
                    else
                    { client.youthOffense = client.youthOffense; }

                    client.youthImpact = Convert.ToString(dataReader["youthImpact"]);
                    if (client.youthImpact == " " || client.youthImpact == "null" || client.youthImpact == "")
                    { client.youthImpact = "N/A"; }

                    client.youthAlt = Convert.ToString(dataReader["youthAlt"]);
                   // var Alt = Int32.TryParse(client.youthAlt, out int yalt);
                    if (client.youthAlt == "1")
                    { client.youthAlt = "Yes"; }
                    if (client.youthAlt == "2")
                    { client.youthAlt = "Maybe"; }
                    if (client.youthAlt == "0")
                    { client.youthAlt = "No"; }
                    if (client.youthAlt == "")
                    { client.youthAlt = "N/A"; }
                    else
                    { client.youthAlt = client.youthAlt; }

                    client.youthSetting = Convert.ToString(dataReader["youthSetting"]);
                 //   var yset = Int32.TryParse(client.youthSetting, out int ysett);
                    if (client.youthSetting == "1")
                    { client.youthSetting = "Yes"; }
                    if (client.youthSetting == "2")
                    { client.youthSetting = "Maybe"; }
                    if (client.youthSetting == "0")
                    { client.youthSetting = "No"; }
                    if (client.youthSetting == "")
                    { client.youthSetting = "N/A"; }
                    else
                    { client.youthSetting = client.youthSetting; }

                    client.youthInjunction = Convert.ToString(dataReader["youthInjunction"]);
                   // var Injun = Int32.TryParse(client.youthInjunction, out int ction);
                    if (client.youthInjunction == "1")
                    { client.youthInjunction = "Yes"; }
                    if (client.youthInjunction == "2")
                    { client.youthInjunction = "Maybe"; }
                    if (client.youthInjunction == "0")
                    { client.youthInjunction = "No"; }
                    if (client.youthInjunction == "")
                    { client.youthInjunction = "N/A"; }
                    else
                    { client.youthInjunction = client.youthInjunction; }

                    clientl.Add(client);

                }
            }
            adapter.Dispose();
            command.Dispose();
            cnn.Close();
            return View(clientl);

        }



        [HttpPost]///////////////////////////////////////////////////////////edit=========================================================================
        public IActionResult editReferralForm(referralBrandi form)
        {

            SqlConnection cnnn;
            cnnn = new SqlConnection(cconnectionString);
            cnnn.Open();
            object clientcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.client WHERE clientCode = '" + form.clientCode + "'", cnnn).ExecuteScalar();
           
            cnnn.Close();
            int cc = (Convert.ToInt16(clientcheck)) + 0;
           

            if (cc >= 1)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateclient = new SqlCommand("", link))
                {
                    Debug.WriteLine("Send to debug output.");
                    stateclient.CommandText = "UPDATE dbo.client SET clientLast = @clientLast,  clientFirst = @clientFirst, dob = @dob WHERE clientCode = @clientCode; ";
                    stateclient.Parameters.AddWithValue("@clientCode", form.clientCode);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter reasa = stateclient.Parameters.AddWithValue("@clientFirst", form.fName);
                    if (form.fName == null)
                    {
                        reasa.Value = DBNull.Value;
                    }
                    SqlParameter morea = stateclient.Parameters.AddWithValue("@clientLast", form.lName);
                    if (form.lName == null)
                    {
                        morea.Value = DBNull.Value;
                    }

                    SqlParameter rfnas = stateclient.Parameters.AddWithValue("@dob", form.dOB);/////////////////////-Date
                    if (form.dOB == null)
                    {
                        rfnas.Value = DBNull.Value;
                    }

                    link.Open();
                    stateclient.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }
        
          
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
                    "fname = @fName, lname = @lName, dob = @dOB, guardianName = @guardianName, guardianlName = @guardianlName, guardianRelationship = @guardianRelationship, strAddress = @strAddress, gender = @gender, guardianEmail = @guardianEmail, guardianPhone = @guardianPhone, meeting = @meeting, youthInDuvalSchool = @youthInDuvalSchool, youthInSchool = @youthInSchool, issues = @issues, zip = @zip, grade = @grade, currStatus = @currStatus, arrest = @arrest, school = @school, dateInput = @dateInput, meetingDate = @meetingDate, email =@email, reach = @reach,moreInfo = @moreInfo, reason = @reason, referralfname = @referralfname, referrallname = @referrallname,nameOrg=@nameOrg, youthNu=@youthNu, youthEmail=@youthEmail, youthCit= @youthCit, youthOffense=@youthOffense, youthImpact=@youthImpact, youthAlt= @youthAlt, youthSetting= @youthSetting, youthInjunction =@youthInjunction WHERE clientCode = @clientCode;";

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
                SqlParameter guardianlNameCodeParam = command.Parameters.AddWithValue("@guardianlName", form.guardianlName);
                if (form.guardianlName == null)
                {
                    guardianlNameCodeParam.Value = DBNull.Value;
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
                SqlParameter youthInSchoolp = command.Parameters.AddWithValue("@youthInSchool", form.youthInSchool);
                if (form.youthInSchool != 1 && form.youthInSchool != 2 && form.youthInSchool != 0)
                {
                    youthInSchoolp.Value = DBNull.Value;
                }
                SqlParameter y = command.Parameters.AddWithValue("@zip", form.zip);
                if (form.zip == null)
                {
                    y.Value = DBNull.Value;
                }
                SqlParameter yy = command.Parameters.AddWithValue("@strAddress", form.address);
                if (form.address == null)
                {
                    yy.Value = DBNull.Value;
                }
                SqlParameter gin = command.Parameters.AddWithValue("@gender", form.gender);
                if (form.gender == null)
                {
                    gin.Value = DBNull.Value;
                }
                SqlParameter tok = command.Parameters.AddWithValue("@meeting", form.meeting);
                if (form.meeting != 0 && form.meeting != 1 && form.meeting != 2)
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
                SqlParameter sc = command.Parameters.AddWithValue("@school", form.school);
                if (form.school == null||form.school == "")
                {
                    sc.Value = DBNull.Value;
                }
                SqlParameter stat = command.Parameters.AddWithValue("@currStatus", form.status);
                if (form.status == null)
                {
                    stat.Value = DBNull.Value;
                }
                SqlParameter dateii = command.Parameters.AddWithValue("@dateInput", form.dateInput);
                if (form.dateInput == null)
                {
                    dateii.Value = DBNull.Value;
                }
                SqlParameter dates = command.Parameters.AddWithValue("@meetingDate", form.date);
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
                if (form.reason == null)
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
                SqlParameter nameOrgParam = command.Parameters.AddWithValue("@nameOrg", form.nameOrg);
                if (form.nameOrg == null)
                {
                    nameOrgParam.Value = DBNull.Value;
                }
                SqlParameter youthNuParam = command.Parameters.AddWithValue("@youthNu", form.youthNu);
                if (form.youthNu == null)
                {
                    youthNuParam.Value = DBNull.Value;
                }
                SqlParameter youthEmailParam = command.Parameters.AddWithValue("@youthEmail", form.youthEmail);
                if (form.youthEmail == null)
                {
                    youthEmailParam.Value = DBNull.Value;
                }
                SqlParameter youthCitParam = command.Parameters.AddWithValue("@youthCit", form.youthCit);
                if (form.youthCit != 0 && form.youthCit != 1)
                {
                    youthCitParam.Value = DBNull.Value;
                }
                SqlParameter youthOffenseParam = command.Parameters.AddWithValue("@youthOffense", form.youthOffense);
                if (form.youthOffense != 0 && form.youthOffense != 1 && form.youthOffense != 2)
                {
                    youthOffenseParam.Value = DBNull.Value;
                }
                SqlParameter youthImpactpara = command.Parameters.AddWithValue("@youthImpact", form.youthImpact);
                if (form.youthImpact == null)
                {
                    youthImpactpara.Value = DBNull.Value;
                }
                SqlParameter youthAltParam = command.Parameters.AddWithValue("@youthAlt", form.youthAlt);
                if (form.youthAlt != 0 && form.youthAlt != 1 && form.youthAlt != 2)
                {
                    youthAltParam.Value = DBNull.Value;
                }
                SqlParameter youthSettingParam = command.Parameters.AddWithValue("@youthSetting", form.youthSetting);
                if (form.youthSetting != 0 && form.youthSetting != 1 && form.youthSetting != 2)
                {
                    youthSettingParam.Value = DBNull.Value;
                }
                SqlParameter youthInjunctionParam = command.Parameters.AddWithValue("@youthInjunction", form.youthInjunction);
                if (form.youthInjunction != 0 && form.youthInjunction != 1 && form.youthInjunction != 2)
                {
                    youthInjunctionParam.Value = DBNull.Value;
                }
                connection.Open();
                command.ExecuteNonQuery();
                cnn.Dispose();
                connection.Close();
            }
            Guid message = form.clientCode;
            //return RedirectToAction("detailReferralM?clientCode="+ message +"", "n");
            return RedirectToAction("RefList", "Referral");
        }




        public IActionResult editReferralM(Guid clientCode)
        {//this method will display the values from the sql code
            //get the values from specific sql
            //display
            
            //var client= new Contact();

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientCode, fname, lname, dob, guardianName, guardianlName, guardianRelationship, strAddress, gender, guardianEmail, guardianPhone, meeting, youthInDuvalSchool, youthInSchool, issues, currentSchool, zip, grade, currStatus, arrest, school, dateInput, meetingDate, email, reach, moreInfo, reason, referralfname, referrallname, nameOrg, youthNu, youthEmail, youthCit, youthOffense, youthImpact, youthAlt, youthSetting, youthInjunction FROM refform WHERE clientCode= '" + clientCode + "';";

            command = new SqlCommand(query, cnn);


            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    referralBrandi client = new referralBrandi();
                   // client.clientCode = Convert.ToString(dataReader["clientCode"]);
                    client.clientCode = Guid.Parse(Convert.ToString(dataReader["clientCode"]));

                    client.fName = Convert.ToString(dataReader["fname"]);


                    client.lName = Convert.ToString(dataReader["lname"]);


                    //int space1 = Convert.ToString(dataReader["dob"]).IndexOf(' ');

                    if (Convert.IsDBNull(dataReader["dob"]))
                    { client.dOB = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.dOB = Convert.ToDateTime(dataReader["dob"]);
                    };//fix ints}

                    client.guardianName = Convert.ToString(dataReader["guardianName"]);
                    client.guardianlName = Convert.ToString(dataReader["guardianlName"]);
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
                    { client.dateInput = DateTime.Parse("01/01/1900 12:00:00 AM"); }
                    else
                    {
                        client.dateInput = Convert.ToDateTime(dataReader["dateInput"]);
                    };//fix ints}


                    if (Convert.IsDBNull(dataReader["meetingDate"]))
                    { client.date = DateTime.Parse("01/01/1900 12:00:00 AM"); }
                    else
                    {
                        client.date = Convert.ToDateTime(dataReader["meetingDate"]);
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
                    client.nameOrg = Convert.ToString(dataReader["nameOrg"]);
                    client.youthNu = Convert.ToString(dataReader["youthNu"]);
                    client.youthEmail = Convert.ToString(dataReader["youthEmail"]);
                    if (Convert.IsDBNull(dataReader["youthCit"]))
                    { client.youthCit = 0; }
                    else
                    {
                        client.youthCit = Convert.ToInt16(dataReader["youthCit"]);
                    }
                    if (Convert.IsDBNull(dataReader["youthOffense"]))
                    { client.youthOffense = 2; }
                    else
                    {
                        client.youthOffense = Convert.ToInt16(dataReader["youthOffense"]);
                    }
                    client.youthImpact = Convert.ToString(dataReader["youthImpact"]);
                    if (Convert.IsDBNull(dataReader["youthAlt"]))
                    { client.youthAlt = 2; }
                    else
                    {
                        client.youthAlt = Convert.ToInt16(dataReader["youthAlt"]);
                    }
                    if (Convert.IsDBNull(dataReader["youthSetting"]))
                    { client.youthSetting = 2; }
                    else
                    {
                        client.youthSetting = Convert.ToInt16(dataReader["youthSetting"]);
                    }
                    if (Convert.IsDBNull(dataReader["youthInjunction"]))
                    { client.youthInjunction = 2; }
                    else
                    {
                        client.youthInjunction = Convert.ToInt16(dataReader["youthInjunction"]);
                    }

                    ViewBag.Lessage = client;

                }
            }
            adapter.Dispose();
            command.Dispose();
            cnn.Close();

            return View();

        }






        public IActionResult detailTrackingM(Guid clientCode)
        { // referral form I need the firstname, lastname, 
          //sql commands for getting the tracking info
          //displaying the tracking information
            SqlConnection cnnn;
            cnnn = new SqlConnection(cconnectionString);
            cnnn.Open();//Connect

            //if statments pertaining to if the table doesn't have a clientCode in it display all the variable for the table as N/A
            //SqlCommand commandd = cnnn.CreateCommand();
            object bullycheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.bully WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object clientcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.client WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object advocacycheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.advocacy WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object accomodationscheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.accomodations WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object altSchoolcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.altSchool WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object caregivercheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.caregiver WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object ccrcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.ccr WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object compcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.comp WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object currentStatuscheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.currentStatus WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object failedcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.failed WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object healthcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.health WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object householdcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.household WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object suspensioncheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.suspension WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object iepcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.iep WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object legalcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.legal WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            object schoolcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.school WHERE clientCode = '" + clientCode + "'", cnnn).ExecuteScalar();
            cnnn.Close();
        
            int bc = (Convert.ToInt16(bullycheck)) + 0;
            int cc = (Convert.ToInt16(clientcheck)) + 0;
            int ac = (Convert.ToInt16(advocacycheck)) + 0;
            int acc = (Convert.ToInt16(accomodationscheck)) + 0;
            int asc = (Convert.ToInt16(altSchoolcheck)) + 0;
            int cgc = (Convert.ToInt16(caregivercheck)) + 0;
            int ccrc = (Convert.ToInt16(ccrcheck)) + 0;
            int fc = (Convert.ToInt16(failedcheck)) + 0;
            int compch = (Convert.ToInt16(compcheck)) + 0;
            int currentStatusch = (Convert.ToInt16(currentStatuscheck)) + 0;
            int hc = (Convert.ToInt16(healthcheck)) + 0;
            int hhc = (Convert.ToInt16(householdcheck)) + 0;
            int ssc = (Convert.ToInt16(suspensioncheck)) + 0;
            int iepc = (Convert.ToInt16(iepcheck)) + 0;
            int lc = (Convert.ToInt16(legalcheck)) + 0;
            int sc = (Convert.ToInt16(schoolcheck)) + 0;

            //fix the 33 when not radiobuttons
            //fix levelof service descriptor
            //


            List<trackingDetail> clientl = new List<trackingDetail>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            //SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT dbo.accomodations.clientCode, dbo.accomodations.accomGained, dbo.accomodations.compServices, dbo.accomodations.ifWhatServices," +
"dbo.advocacy.rearrestAdvo, dbo.advocacy.courtAdvo, dbo.advocacy.staffingAdvo, dbo.advocacy.legalAdvo, dbo.advocacy.legalAdvoTaken, " +
"dbo.altSchool.altSchool, dbo.altSchool.altSchoolName, dbo.altSchool.altSchoolDate, dbo.altSchool.altSchoolTimes, dbo.altSchool.daysOwed, dbo.altSchool.daysSinceIntake, " +
"dbo.bully.bullied, dbo.bully.reported, dbo.bully.reportDate, " +
"dbo.caregiver.careLast, dbo.caregiver.careFirst, dbo.caregiver.genderIdentity as caregender, dbo.caregiver.ethnicity as careethnic, dbo.caregiver.relationship, " +
"dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.nonEngageReason, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, dbo.ccr.dateInput as trackingdate," +
"dbo.client.clientLast, dbo.client.clientFirst, dbo.client.dependency, dbo.client.genderIdentity as clientgender, dbo.client.ethnicity as clientethn, dbo.client.dob as clientdob, dbo.client.phoneNumber, " +
"dbo.comp.compTime, " +
"dbo.currentStatus.readingLevel, dbo.currentStatus.mathLevel, dbo.currentStatus.currentServices, dbo.currentStatus.inPride, dbo.currentStatus.newFBA, dbo.currentStatus.addService, dbo.currentStatus.servicesGained, " +
"dbo.failed.gradeFailed, dbo.failed.whichGrade, dbo.failed.failedRepeat, " +
"dbo.health.bakerActed, dbo.health.marchmanActed, dbo.health.asthma, " +
"dbo.household.femLed, dbo.household.domVio, dbo.household.adopted, dbo.household.evicted, dbo.household.incarParent, dbo.household.publicAssistance, " +
"dbo.suspension.suspendedThrice, dbo.suspension.numSuspensions, dbo.suspension.totalDaysSuspended, dbo.suspension.ISS, dbo.suspension.OSS, dbo.suspension.daysofDiscipline, dbo.suspension.disciplineSinceIntake, " +
"dbo.iep.IEP, dbo.iep.primaryIEP, dbo.iep.secondaryIEP, dbo.iep.addIEp, dbo.legal.legalIssues, dbo.legal.leagalIssues2, dbo.legal.juvJusticeOutcome, " +
"dbo.school.grade, dbo.school.school, dbo.school.SchoolRef, " +
"dbo.refInfo.refFName, dbo.refInfo.refLName, dbo.refInfo.refDate, dbo.refInfo.refEmail" +
" FROM (((((((((((((((((dbo.accomodations  LEFT JOIN dbo.advocacy  on dbo.accomodations.clientCode = dbo.advocacy.clientCode)" +
"LEFT JOIN dbo.altSchool on dbo.accomodations.clientCode = dbo.altSchool.clientCode) " +
"LEFT JOIN dbo.bully on dbo.accomodations.clientCode = dbo.bully.clientCode) " +
"LEFT JOIN dbo.caregiver on dbo.accomodations.clientCode = dbo.caregiver.clientCode) " +
"LEFT JOIN dbo.ccr on dbo.accomodations.clientCode = dbo.ccr.clientCode) " +
"LEFT JOIN dbo.client on dbo.accomodations.clientCode = dbo.client.clientCode) " +
"LEFT JOIN dbo.comp on dbo.accomodations.clientCode = dbo.comp.clientCode) " +
"LEFT JOIN dbo.currentStatus on dbo.accomodations.clientCode = dbo.currentStatus.clientCode) " +
"LEFT JOIN dbo.failed on dbo.accomodations.clientCode = dbo.failed.clientCode) " +
"LEFT JOIN dbo.health on dbo.accomodations.clientCode = dbo.health.clientCode) " +
"LEFT JOIN dbo.household on accomodations.clientCode = dbo.household.clientCode) " +
"LEFT JOIN dbo.referral on dbo.accomodations.clientCode = dbo.referral.clientCode) " +
"LEFT JOIN dbo.suspension on dbo.accomodations.clientCode = dbo.suspension.clientCode) " +
"LEFT JOIN dbo.iep on dbo.accomodations.clientCode = dbo.iep.clientCode) " +
"LEFT JOIN dbo.legal on dbo.accomodations.clientCode = dbo.legal.clientCode)" +
"LEFT JOIN dbo.school on dbo.accomodations.clientCode = dbo.school.clientCode)" +
"LEFT JOIN dbo.refInfo on dbo.accomodations.clientCode = dbo.refInfo.clientCode) " +
"WHERE dbo.accomodations.clientCode = '" + clientCode + "';";
            command = new SqlCommand(query, cnn);

            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    trackingDetail client = new trackingDetail();
                    client.ClientID = Guid.Parse(Convert.ToString(dataReader["clientCode"]));

                    client.clientFirstName = Convert.ToString(dataReader["clientFirst"]);
                    if (client.clientFirstName == " " || client.clientFirstName == "null" || client.clientFirstName == "" || cc == 0)
                    { client.clientFirstName = "N/A"; }//Done

                    client.clientLastName = Convert.ToString(dataReader["clientLast"]);
                    if (client.clientLastName == " " || client.clientLastName == "null" || client.clientLastName == "" || cc == 0)
                    { client.clientLastName = "N/A"; }//Done

                    client.careGender = Convert.ToString(dataReader["caregender"]);
                    if (client.careGender.Contains("Mother"))
                    { client.careGender = "Mother"; }
                    if (client.careGender.Contains("Father"))
                    { client.careGender = "Father"; }
                    if (client.careGender.Contains("mGrandma"))
                    { client.careGender = "Grandma"; }
                    if (client.careGender.Contains("mGrandpa"))
                    { client.careGender = "Grandpa"; }
                    if (client.careGender.Contains("Other"))
                    { client.careGender = "Other"; }
                    if (String.IsNullOrEmpty(Convert.ToString(dataReader["caregender"])) || cgc == 0)
                    { client.careGender = "N/A"; }
                    else
                    { client.careGender = client.careGender; }



                  //  string time = "";
                    client.clientGender = Convert.ToString(dataReader["clientgender"]);
                //  time = Convert.ToString(dataReader["clientgender"]);
                    if (client.clientGender.Contains("male") && !client.clientGender.Contains("female"))
                    { client.clientGender = "He/Him/His"; }
                    if (client.clientGender.Contains("female"))
                    { client.clientGender = "She/Her/Hers"; }
                    if (client.clientGender.Contains("trans"))
                    { client.clientGender = "They/them/Theirs"; }
                    if (client.clientGender.Contains("nonbinaryF"))
                    { client.clientGender = "She/They"; }
                    if (client.clientGender.Contains("nonbinaryM"))
                    { client.clientGender = "He/They"; }
                    if (client.clientGender.Contains("neutral"))
                    { client.clientGender = "Zie/Zir/Zirs"; }
                    if(client.clientGender.Length == 0||cc == 0 )//////////////Something is wrong
                    { client.clientGender = "N/A"; }
                    else { client.clientGender = client.clientGender; }
               

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
                    if (client.clientEthnicity == "" ||cc ==0)
                    { client.clientEthnicity = "N/A"; }
                    else
                    { client.clientEthnicity = client.clientEthnicity; }


                    string t = Convert.ToString(dataReader["clientdob"]);
                    if (Convert.ToString(dataReader["clientdob"]).Length > 10)
                    {
                        
                        string[] spaceclientdob = t.Split(' ');
                        client.clientDOB =(spaceclientdob[0]); }
                   

                    if (client.clientDOB == " " || client.clientDOB == "null" || client.clientDOB== "" || Convert.ToString(dataReader["clientdob"]).Length < 10)
                    { client.clientDOB = "N/A"; }

                
                    client.school = Convert.ToString(dataReader["school"]);
                    if (client.school == " " || client.school == "null" || client.school == "" || sc ==0)
                    { client.school = "N/A"; }

                    client.currentGrade = Convert.ToString(dataReader["grade"]);
                    //var curgra = Int32.TryParse(client.currentGrade, out int tte);
                    if (client.currentGrade == "0")
                    { client.currentGrade = "Kindergarten"; }
                    if (client.currentGrade == "1")
                    { client.currentGrade = "1st Grade"; }
                    if (client.currentGrade == "2")
                    { client.currentGrade = "2nd Grade"; }
                    if (client.currentGrade == "3")
                    { client.currentGrade = "3rd Grade"; }
                    if (client.currentGrade == "4")
                    { client.currentGrade = "4th Grade"; }
                    if (client.currentGrade == "5")
                    { client.currentGrade = "5th Grade"; }
                    if (client.currentGrade == "6")
                    { client.currentGrade = "6th Grade"; }
                    if (client.currentGrade == "7")
                    { client.currentGrade = "7th Grade"; }
                    if (client.currentGrade == "8")
                    { client.currentGrade = "8th Grade"; }
                    if (client.currentGrade == "9")
                    { client.currentGrade = "9th Grade"; }
                    if (client.currentGrade == "10")
                    { client.currentGrade = "10th Grade"; }
                    if (client.currentGrade == "11")
                    { client.currentGrade = "11th Grade"; }
                    if (client.currentGrade == "12")
                    { client.currentGrade = "12th Grade"; }
                    if (client.currentGrade == "" || sc ==0)
                    { client.currentGrade = "N/A"; }
                    else { client.currentGrade = client.currentGrade; }



                    client.failedGrade = Convert.ToString(dataReader["gradeFailed"]);
                  //  var failgr = Int32.TryParse(client.failedGrade, out int failg);
                    if (client.failedGrade == "1")
                    { client.failedGrade = "Yes"; }
                    if (client.failedGrade == "0")
                    { client.failedGrade = "No"; }
                    if (client.failedGrade == "" || fc ==0)
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
                    if (client.whichGradeFailed == "" || fc ==0)
                    { client.whichGradeFailed = "N/A"; }
                    else
                    { client.whichGradeFailed = client.whichGradeFailed; }

                    client.failCount = Convert.ToString(dataReader["failedRepeat"]);
                    if (client.failCount == "" || fc == 0)
                    { client.failCount = "N/A"; }

                    client.baker = Convert.ToString(dataReader["bakerActed"]);
                   // var bak = Int32.TryParse(client.baker, out int abk);
                    if (client.baker == "1")
                    { client.baker = "Yes"; }
                    if (client.baker == "0")
                    { client.baker = "No"; }
                    if (client.baker == "" || hc ==0)
                    { client.baker = "N/A"; }
                    else
                    { client.baker = client.baker; }
                    client.marchman = Convert.ToString(dataReader["marchmanActed"]);
                  //  var madmarch = Int32.TryParse(client.marchman, out int marchmad);
                    if (client.marchman == "1")
                    { client.marchman = "Yes"; }
                    if (client.marchman == "0")
                    { client.marchman = "No"; }
                    if (client.marchman == "" || hc == 0)
                    { client.marchman = "N/A"; }
                    else
                    { client.marchman = client.marchman; }
                    client.asthma = Convert.ToString(dataReader["asthma"]);
                    if (client.asthma == "1")
                    { client.asthma = "Yes"; }
                    if (client.asthma == "0")
                    { client.asthma = "No"; }
                    if (client.asthma == "" || hc == 0)
                    { client.asthma = "N/A"; }
                    else
                    { client.asthma = client.asthma; }
                    //household- all int
                    client.femHouse = Convert.ToString(dataReader["femLed"]);
                  //  var hfem = Int32.TryParse(client.femHouse, out int femh);
                    if (client.femHouse == "1")
                    { client.femHouse = "Yes"; }
                    if (client.femHouse == "0")
                    { client.femHouse = "No"; }
                    if (client.femHouse == "" || hhc == 0)
                    { client.femHouse = "N/A"; }
                    else
                    { client.femHouse = client.femHouse; }
                    client.domVio = Convert.ToString(dataReader["domVio"]);
                  //  var vd = Int32.TryParse(client.domVio, out int dv);
                    if (client.domVio == "1")
                    { client.domVio = "Yes"; }
                    if (client.domVio == "0")
                    { client.domVio = "No"; }
                    if (client.domVio == "" || hhc == 0)
                    { client.domVio = "N/A"; }
                    else
                    { client.domVio = client.domVio; }
                    client.adopted = Convert.ToString(dataReader["adopted"]);
                //    var adopt = Int32.TryParse(client.adopted, out int adop);
                    if (client.adopted == "1")
                    { client.adopted = "Yes"; }
                    if (client.adopted == "0")
                    { client.adopted = "No"; }
                    if (client.adopted == "" || hhc == 0)
                    { client.adopted = "N/A"; }
                    else
                    { client.adopted = client.adopted; }
                    client.evicted = Convert.ToString(dataReader["evicted"]);
                   // var ev = Int32.TryParse(client.evicted, out int evict);
                    if (client.evicted == "1")
                    { client.evicted = "Yes"; }
                    if (client.evicted == "0")
                    { client.evicted = "No"; }
                    if (client.evicted == "" || hhc == 0)
                    { client.evicted = "N/A"; }
                    else
                    { client.evicted = client.evicted; }
                    client.incarParent = Convert.ToString(dataReader["incarParent"]);
                  //  var incarp = Int32.TryParse(client.incarParent, out int incarpare);
                    if (client.incarParent == "1")
                    { client.incarParent = "Yes"; }
                    if (client.incarParent == "0")
                    { client.incarParent = "No"; }
                    if (client.incarParent == "" || hhc == 0)
                    { client.incarParent = "N/A"; }
                    else
                    { client.incarParent = client.incarParent; }


                    //accomodations---------------------------------CCR---------------------------------------------------------------

                    client.levelOfServiceProvided = Convert.ToString(dataReader["levelofService"]);
                    if (!client.levelOfServiceProvided.Contains("info") && !client.levelOfServiceProvided.Contains("service") && !client.levelOfServiceProvided.Contains("full"))
                    { client.levelOfServiceProvided = "None"; }
                    if (client.levelOfServiceProvided.Contains("info"))
                    { client.levelOfServiceProvided = "Information/Education"; }
                    if (client.levelOfServiceProvided.Contains("service"))
                    { client.levelOfServiceProvided = "Brief Service/Advice"; }
                    if (client.levelOfServiceProvided.Contains("full"))
                    { client.levelOfServiceProvided = "Full"; }
                    if (client.levelOfServiceProvided=="" || ccrc ==0)
                    { client.levelOfServiceProvided = "N/A"; }
                    else
                    { client.levelOfServiceProvided = client.levelOfServiceProvided; }

                    string dateinputstring = Convert.ToString(dataReader["refDate"]);
                    if (Convert.ToString(dataReader["refDate"]).Length > 10)

                    {
                        string[] spacedateinput = dateinputstring.Split(' ');
                        client.referralDate = (spacedateinput[0]);
                    }
                    if (client.referralDate == " " || client.referralDate == "null" || client.referralDate == "" || Convert.ToString(dataReader["refDate"]).Length < 10)
                    { client.referralDate = "N/A"; }


                    //Reason for Nonengagement needs to be added
                    client.nonEngagementReason = Convert.ToString(dataReader["nonEngageReason"]);
                    if (client.nonEngagementReason.Contains("n") &&!client.nonEngagementReason.Contains("info"))
                    { client.nonEngagementReason = "Unable to Contact"; }
                    if (client.nonEngagementReason.Contains("info"))
                    { client.nonEngagementReason = "Unable to Complete Intake"; }
                    if (client.nonEngagementReason.Contains("service"))
                    { client.nonEngagementReason = "Family Declined Services"; }
                    if (client.nonEngagementReason == "" || ccrc == 0)
                    { client.nonEngagementReason = "N/A"; }
                    else
                    { client.nonEngagementReason = client.nonEngagementReason; }

                    client.caseStatus = Convert.ToString(dataReader["ccrStatus"]);
                 //   var cstat = Int32.TryParse(client.caseStatus, out int csta);
                    if (client.caseStatus == "1")
                    { client.caseStatus = "Open"; }
                    if (client.caseStatus == "2")
                    { client.caseStatus = "Closed due to nonengagement"; }
                    if (client.caseStatus == "0")
                    { client.caseStatus = "Closed"; }
                    if (client.caseStatus == "" || ccrc == 0)
                    { client.caseStatus = "N/A"; }
                    else
                    { client.caseStatus = client.caseStatus; }

                    client.legalAdvocacy = Convert.ToString(dataReader["legalAdvo"]);

                  //  var legadvo = Int32.TryParse(client.staffAdvocacy, out int legalad);
                    if (client.legalAdvocacy == "1")
                    { client.legalAdvocacy = "Yes"; }
                    if (client.legalAdvocacy == "0")
                    { client.legalAdvocacy = "No"; }
                    if (client.legalAdvocacy == "" || ac == 0)
                    { client.legalAdvocacy = "N/A"; }
                    else
                    { client.legalAdvocacy = client.legalAdvocacy; }

                    //done
                    client.legalAdvoTaken = Convert.ToString(dataReader["legalAdvoTaken"]);
                    if (client.legalAdvoTaken == "" || ac == 0)
                    { client.legalAdvoTaken = "N/A"; }

                    client.remedyResolution = Convert.ToString(dataReader["remedy"]);
                   // var remre = Int32.TryParse(client.remedyResolution, out int rereed);
                    if (client.remedyResolution.Contains("1"))
                    { client.remedyResolution = "Yes"; }
                    if (client.remedyResolution.Contains("0"))
                    { client.remedyResolution = "No"; }
                    if (client.remedyResolution == "" || ccrc == 0)
                    { client.remedyResolution = "N/A"; }
                    else
                    { client.remedyResolution = client.remedyResolution; }

                    client.rearrestWhileRepresented = Convert.ToString(dataReader["rearrestRep"]);
                   // var rwr = Int32.TryParse(client.rearrestWhileRepresented, out int rwrep);
                    if (client.rearrestWhileRepresented == "1")
                    { client.rearrestWhileRepresented = "Yes"; }
                    if (client.rearrestWhileRepresented == "0")
                    { client.rearrestWhileRepresented = "No"; }
                    if (client.rearrestWhileRepresented == "" || ccrc == 0)
                    { client.rearrestWhileRepresented = "N/A"; }
                    else
                    { client.rearrestWhileRepresented = client.rearrestWhileRepresented; }




                    client.schoolAtClosure = Convert.ToString(dataReader["closureSchool"]);
                    if (client.schoolAtClosure == "" || ccrc == 0)
                    { client.schoolAtClosure = "N/A"; }

                  //  string trackingdate1 = Convert.ToString(dataReader["trackingdate"]);
                    if (Convert.ToString(dataReader["trackingdate"]).Length > 10)
                    {

                        string[] spacetrackingdate1 = t.Split(' ');
                        client.trackingdate = (spacetrackingdate1[0]);
                    }


                    if (client.trackingdate == " " || client.trackingdate == "null" || client.trackingdate == "" || Convert.ToString(dataReader["trackingdate"]).Length < 10)
                    { client.trackingdate = "N/A"; }

                    //is the first referral for the client

                    client.emailOfFirstReferralSource = Convert.ToString(dataReader["refEmail"]);
                    if (client.emailOfFirstReferralSource == "")
                    { client.emailOfFirstReferralSource = "N/A"; }

                    client.referralSource = Convert.ToString(dataReader["refFName"]) + " " + Convert.ToString(dataReader["refLName"]);
                    if (client.referralSource == "")
                    { client.referralSource = "N/A"; }

                    client.rearrestAdvocacy = Convert.ToString(dataReader["rearrestAdvo"]);
                //    var rearrestad = Int32.TryParse(client.rearrestAdvocacy, out int readvoca);
                    if (client.rearrestAdvocacy == "1")
                    { client.rearrestAdvocacy = "Yes"; }
                    if (client.rearrestAdvocacy == "0")
                    { client.rearrestAdvocacy = "No"; }
                    if (client.rearrestAdvocacy == "" || ac == 0)
                    { client.rearrestAdvocacy = "N/A"; }
                    else
                    { client.rearrestAdvocacy = client.rearrestAdvocacy; }
                    //int

                    client.courtAdvocacy = Convert.ToString(dataReader["courtAdvo"]);
                   // var coadvocacy = Int32.TryParse(client.courtAdvocacy, out int couadvocacy);
                    if (client.courtAdvocacy == "1")
                    { client.courtAdvocacy = "Yes"; }
                    if (client.courtAdvocacy == "0")
                    { client.courtAdvocacy = "No"; }
                    if (client.courtAdvocacy == "" || ac == 0)
                    { client.courtAdvocacy = "N/A"; }
                    else
                    { client.courtAdvocacy = client.courtAdvocacy; }
                    //int
                    client.staffAdvocacy = Convert.ToString(dataReader["staffingAdvo"]);
                    //var stadvoc = Int32.TryParse(client.staffAdvocacy, out int staffadvo);
                    if (client.staffAdvocacy == "1")
                    { client.staffAdvocacy = "Yes"; }
                    if (client.staffAdvocacy == "0")
                    { client.staffAdvocacy = "No"; }
                    if (client.staffAdvocacy == "" || ac == 0)
                    { client.staffAdvocacy = "N/A"; }
                    else
                    { client.staffAdvocacy = client.staffAdvocacy; }

                    //-------------------------------------------------------School Info----------------------------------------------
                    client.iep = Convert.ToString(dataReader["IEP"]);
                    if (client.iep == "1")
                    { client.iep = "Yes"; }
                    if (client.iep == "0")
                    { client.iep = "No"; }
                    if (client.iep == "" ||iepc == 0)
                    { client.iep = "N/A"; }

                    client.iepplan1 = Convert.ToString(dataReader["primaryIEP"]);
                    if (client.iepplan1.Contains("emo")) { client.iepplan1 = "Emotional/Behavioral Disability"; }
                    if (client.iepplan1.Contains("gifted")) { client.iepplan1 = "Gifted"; }
                    if (client.iepplan1.Contains("intell")) { client.iepplan1 = "Intellectual Disability"; }
                    if (client.iepplan1.Contains("lang")) { client.iepplan1 = "Language Impairment"; }
                    if (client.iepplan1.Contains("otherHealth")) { client.iepplan1 = "Other Health Impairment"; }
                    if (client.iepplan1.Contains("specificLearning")) { client.iepplan1 = "Specific Learning Disability"; }
                    if (client.iepplan1.Contains("speech")) { client.iepplan1 = "Speech Impairment"; }
                    if (client.iepplan1.Contains("other")) { client.iepplan1 = "other"; }
                    if (client.iepplan1 == ""||iepc == 0)
                    { client.iepplan1 = "N/A"; }

                    client.iepplan2 = Convert.ToString(dataReader["secondaryIEP"]);
                    if (client.iepplan2.Contains("emo")) { client.iepplan2 = "Emotional/Behavioral Disability"; }
                    if (client.iepplan2.Contains("gifted")) { client.iepplan2 = "Gifted"; }
                    if (client.iepplan2.Contains("intell")) { client.iepplan2 = "Intellectual Disability"; }
                    if (client.iepplan2.Contains("lang")) { client.iepplan2 = "Language Impairment"; }
                    if (client.iepplan2.Contains("otherHealth")) { client.iepplan2 = "Other Health Impairment"; }
                    if (client.iepplan2.Contains("specificLearning")) { client.iepplan2 = "Specific Learning Disability"; }
                    if (client.iepplan2.Contains("speech")) { client.iepplan2 = "Speech Impairment"; }
                    if (client.iepplan2.Contains("other")) { client.iepplan2 = "other"; }
                    if (client.iepplan2 == "" || iepc == 0)
                    { client.iepplan2 = "N/A"; }

                    client.schoolRef = Convert.ToString(dataReader["schoolRef"]);
                    if (client.schoolRef == "" || sc == 0)
                    { client.schoolRef = "N/A"; }

                    client.readingLevel = Convert.ToString(dataReader["readingLevel"]);
                    if (client.readingLevel == "K")
                    { client.readingLevel = "Kindergarten"; }
                    if (client.readingLevel == "" || currentStatusch == 0)
                    { client.readingLevel = "N/A"; }

                    client.mathLevel = Convert.ToString(dataReader["mathLevel"]);
                    if (client.readingLevel == "K")
                    { client.readingLevel = "Kindergarten"; }
                    if (client.mathLevel == "" || currentStatusch == 0)
                    { client.mathLevel = "N/A"; }

                    client.inPride = Convert.ToString(dataReader["inPride"]);
                    if (client.inPride == "1")
                    { client.inPride = "Yes"; }
                    if (client.inPride == "0")
                    { client.inPride = "No"; }
                    if (client.inPride == "" || currentStatusch == 0)
                    { client.inPride = "N/A"; }
                    else
                    { client.inPride = client.inPride; }
                    //int
                    client.newFBA = Convert.ToString(dataReader["newFBA"]);
                    if (client.newFBA == "1")
                    { client.newFBA = "Yes"; }
                    if (client.newFBA == "0")
                    { client.newFBA = "No"; }
                    if (client.newFBA == "" || currentStatusch == 0)
                    { client.newFBA = "N/A"; }
                    else
                    { client.newFBA = client.newFBA; }

                    client.accomGained = Convert.ToString(dataReader["accomGained"]);
                   // var acgained = Int32.TryParse(client.accomGained, out int acg);
                    if (client.accomGained == "1")
                    { client.accomGained = "Yes"; }
                    if (client.accomGained == "2")
                    { client.accomGained = "Other"; }
                    if (client.accomGained == "0")
                    { client.accomGained = "No"; }
                    if (client.accomGained == "" || acc== 0)
                    { client.accomGained = "N/A"; }
                    else
                    { client.accomGained = client.accomGained; }
                    //int

                    client.compService = Convert.ToString(dataReader["compServices"]);
                   // var compser = Int32.TryParse(client.compService, out int compserv);
                    if (client.compService == "1")
                    { client.compService = "Yes"; }
                    if (client.compService == "0")
                    { client.compService = "No"; }
                    if (client.compService == "" || acc == 0)
                    { client.compService = "N/A"; }
                    else
                    { client.compService = client.compService; }

                    //done
                    client.ifWhatServices = Convert.ToString(dataReader["ifWhatServices"]);
                    if (client.ifWhatServices == "" || acc == 0)
                    { client.ifWhatServices = "N/A"; }

                    client.compTime = Convert.ToString(dataReader["compTime"]);
                    if (client.compTime == "" || compch ==0)
                    { client.compTime = "N/A"; }

                    client.bullied = Convert.ToString(dataReader["bullied"]);
                  //  var bulle = Int32.TryParse(client.bullied, out int bulli);
                    if (client.bullied == "1")
                    { client.bullied = "Yes"; }
                    if (client.bullied == "0")
                    { client.bullied = "No"; }
                    if (client.bullied == "" || bc ==0)
                    { client.bullied = "N/A"; }
                    else
                    { client.bullied = client.bullied; }
                    //int count
                    client.bullyReport = Convert.ToString(dataReader["reported"]);
                 //   var bullere = Int32.TryParse(client.bullyReport, out int bullire);
                    if (client.bullyReport == "1")
                    { client.bullyReport = "Yes"; }
                    if (client.bullyReport == "0")
                    { client.bullyReport = "No"; }
                    if (client.bullyReport == "" || bc == 0)
                    { client.bullyReport = "N/A"; }
                    else
                    { client.bullyReport = client.bullyReport; }
                    //date
                    string reportdatestring = Convert.ToString(dataReader["reportDate"]);
                    if (Convert.ToString(dataReader["reportDate"]).Length > 10)

                    {string[] spacedateofbully = reportdatestring.Split(' ');
                        client.dateofBully = (spacedateofbully[0]);
                    }

                    if (client.dateofBully == " " || client.dateofBully == "null" || client.dateofBully == "" || Convert.ToString(dataReader["reportDate"]).Length < 10)
                    { client.dateofBully = "N/A"; }

             
                    //----------------------------------------------------------------------------Discipline-------------------------------
                    client.suspended = Convert.ToString(dataReader["suspendedThrice"]);
                   // var thrise = Int32.TryParse(client.suspended, out int thris);
                    if (client.suspended == "1")
                    { client.suspended = "Yes"; }
                    if (client.suspended == "0")
                    { client.suspended = "No"; }
                    if (client.suspended == "" || ssc == 0)
                    { client.suspended = "N/A"; }
                    else
                    { client.suspended = client.suspended; }

                    client.suspendCount = Convert.ToString(dataReader["numSuspensions"]);
                    if (client.suspendCount == "" || ssc == 0)
                    { client.suspendCount = "N/A"; }

                    client.altSchool = Convert.ToString(dataReader["altSchool"]);
                  //  var altsch = Int32.TryParse(client.altSchool, out int altschoo);
                    if (client.altSchool == "1")
                    { client.altSchool = "Yes"; }
                    if (client.altSchool == "0")
                    { client.altSchool = "No"; }
                    if (client.altSchool == "" || asc ==0)
                    { client.altSchool = "N/A"; }
                    else
                    { client.altSchool = client.altSchool; }

                    client.altSchoolName = Convert.ToString(dataReader["altSchoolName"]);
                    if (client.altSchoolName.Contains("yes"))
                    { client.altSchoolName = "Mattie V"; }
                    if (client.altSchoolName.Contains("no"))
                    { client.altSchoolName = "Grand Park"; }
                    if (client.altSchoolName == "" || asc == 0)
                    { client.altSchoolName = "N/A"; }
                    else
                    { client.altSchoolName = client.altSchoolName; }

                    string altSchoolDatestring = Convert.ToString(dataReader["altSchoolDate"]);
                  if (Convert.ToString(dataReader["altSchoolDate"]).Length > 10)

                    {
                        string[] spacealtdate = altSchoolDatestring.Split(' ');
                        client.dateOfAlt =(spacealtdate[0]);
                    }
                
                    if (client.dateOfAlt == " " || client.dateOfAlt == "null" || client.dateOfAlt == "" || Convert.ToString(dataReader["altSchoolDate"]).Length < 10)
                    { client.dateOfAlt = "N/A"; }

                    //int
                    client.timesInAlt = Convert.ToString(dataReader["altSchoolTimes"]);
                    if (client.timesInAlt == "" || asc == 0)
                    { client.timesInAlt = "N/A"; }

                    //int
                    client.daysOwed = Convert.ToString(dataReader["daysOwed"]);
                    if (client.daysOwed == "" || asc == 0)
                    { client.daysOwed = "N/A"; }

                    client.firstLegal = Convert.ToString(dataReader["legalIssues"]);
                    if (client.firstLegal == "education")
                    { client.firstLegal = "Education"; }
                    if (client.firstLegal == "juvenilejustice")
                    { client.firstLegal = "Juvenile Justice"; }
                    if (client.firstLegal == "dependency")
                    { client.firstLegal = "Dependency"; }
                    if (client.firstLegal == "bakeract")
                    { client.firstLegal = "Baker Act"; }
                    if (client.firstLegal == "familylaw")
                    { client.firstLegal = "Family Law"; }
                    if (client.firstLegal == "immigration")
                    { client.firstLegal = "Immigration"; }
                    if (client.firstLegal == "publicbenefits")
                    { client.firstLegal = "Public Benefits"; }
                    if (client.firstLegal == "housing")
                    { client.firstLegal = "Housing"; }
                    if (client.firstLegal == "other")
                    { client.firstLegal = "Other"; }
                    if (client.firstLegal == "" || lc == 0)
                    { client.firstLegal = "N/A"; }

                    client.secondLegal = Convert.ToString(dataReader["leagalIssues2"]);
                    if (client.secondLegal == "" || lc == 0)
                    { client.secondLegal = "N/A"; }



                    client.iss = Convert.ToString(dataReader["ISS"]);
                    if (client.iss == "" || ssc ==0)
                    { client.iss = "N/A"; }
                    client.totaldaysdisicpline = Convert.ToString(dataReader["totalDaysSuspended"]);
                    client.oss = Convert.ToString(dataReader["OSS"]);
                    if (client.oss == "" || ssc == 0)
                    { client.oss = "N/A"; }

                    client.daysSinceIntake = Convert.ToString(dataReader["daysSinceIntake"]);
                    if (client.daysSinceIntake == "" || ssc == 0)
                    { client.daysSinceIntake = "N/A"; }

                    client.justiceOutcome = Convert.ToString(dataReader["juvJusticeOutcome"]);
                    if (client.justiceOutcome == "" || lc == 0)
                    { client.justiceOutcome = "N/A"; }

                    client.publicAssistance = Convert.ToString(dataReader["publicAssistance"]);
                   // var publicass = Int32.TryParse(client.publicAssistance, out int publicassis);
                    if (client.publicAssistance == "1")
                    { client.publicAssistance = "Yes"; }
                    if (client.publicAssistance == "0")
                    { client.publicAssistance = "No"; }
                    if (client.publicAssistance == "" ||hhc ==0)
                    { client.publicAssistance = "N/A"; }
                    else
                    { client.publicAssistance = client.publicAssistance; }


                    client.careLastName = Convert.ToString(dataReader["careLast"]);
                    if (client.careLastName == ""|| cgc == 0)
                    { client.careLastName = "N/A"; }

                    client.careFirstName = Convert.ToString(dataReader["careFirst"]);
                    if (client.careFirstName == "" || client.careFirstName == "null" || String.IsNullOrEmpty(client.careFirstName) || cgc == 0)
                    { client.careFirstName = "N/A"; }

                    client.carePhone = Convert.ToString(dataReader["phoneNumber"]);

                    if (client.carePhone == "" || client.carePhone == "null" || String.IsNullOrEmpty(client.carePhone) || cc == 0)
                    { client.carePhone = "N/A"; }

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
                    if (client.careEthnicity.Equals("null") || cgc == 0)
                    { client.careEthnicity = "N/A"; }

                    clientl.Add(client);

                }
            }
            command.Dispose();
            cnn.Close();
            return View(clientl);


        }
        public IActionResult EditTrackingM(Guid clientCode)

        //edit tracking information in a form format
        {//this method will display the values from the sql code
         //get the values from specific sql
         //display
            
            //var client= new Contact();

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT dbo.accomodations.clientCode, dbo.accomodations.accomGained, dbo.accomodations.compServices, dbo.accomodations.ifWhatServices," +
            "dbo.advocacy.rearrestAdvo, dbo.advocacy.courtAdvo, dbo.advocacy.staffingAdvo, dbo.advocacy.legalAdvo, dbo.advocacy.legalAdvoTaken, " +
            "dbo.altSchool.altSchool, dbo.altSchool.altSchoolName, dbo.altSchool.altSchoolDate, dbo.altSchool.altSchoolTimes, dbo.altSchool.daysOwed, dbo.altSchool.daysSinceIntake, " +
            "dbo.bully.bullied, dbo.bully.reported, dbo.bully.reportDate, " +
            "dbo.caregiver.careLast, dbo.caregiver.careFirst, dbo.caregiver.genderIdentity as caregender, dbo.caregiver.ethnicity as careethnic, dbo.caregiver.relationship, " +
            "dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.nonEngageReason, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, dbo.ccr.dateInput as trackingdate ," +
            "dbo.client.clientLast, dbo.client.clientFirst, dbo.client.dependency, dbo.client.genderIdentity as clientgender, dbo.client.ethnicity as clientethn, dbo.client.dob as clientdob, dbo.client.phoneNumber, " +
            "dbo.comp.compTime, " +
            "dbo.currentStatus.readingLevel, dbo.currentStatus.mathLevel, dbo.currentStatus.currentServices, dbo.currentStatus.inPride, dbo.currentStatus.newFBA, dbo.currentStatus.addService, dbo.currentStatus.servicesGained, " +
            "dbo.failed.gradeFailed, dbo.failed.whichGrade, dbo.failed.failedRepeat, " +
            "dbo.health.bakerActed, dbo.health.marchmanActed, dbo.health.asthma, " +
            "dbo.household.femLed, dbo.household.domVio, dbo.household.adopted, dbo.household.evicted, dbo.household.incarParent, dbo.household.publicAssistance, " +
            //"dbo.referral.referralDate, dbo.referral.intakeDate, dbo.referral.referral1, dbo.referral.referral2, dbo.referral.referral3, dbo.referral.referrerName, dbo.referral.referrerEmail, " +
            "dbo.suspension.suspendedThrice, dbo.suspension.numSuspensions, dbo.suspension.totalDaysSuspended, dbo.suspension.ISS, dbo.suspension.OSS, dbo.suspension.daysofDiscipline, dbo.suspension.disciplineSinceIntake, " +
            "dbo.iep.IEP, dbo.iep.primaryIEP, dbo.iep.secondaryIEP, dbo.iep.addIEp, dbo.legal.legalIssues, dbo.legal.leagalIssues2, dbo.legal.juvJusticeOutcome, " +
            "dbo.school.grade, dbo.school.school, dbo.school.SchoolRef, " +
            "dbo.refform.email, dbo.refform.referralfname, dbo.refform.referrallname, dbo.refform.dateInput," +
            "dbo.refInfo.refFName, dbo.refInfo.refLName, dbo.refInfo.refDate, dbo.refInfo.refEmail" +
            " FROM ((((((((((((((((((dbo.accomodations  LEFT JOIN dbo.advocacy  on dbo.accomodations.clientCode = dbo.advocacy.clientCode)" +
            "LEFT JOIN dbo.altSchool on dbo.accomodations.clientCode = dbo.altSchool.clientCode) " +
            "LEFT JOIN dbo.bully on dbo.accomodations.clientCode = dbo.bully.clientCode) " +
            "LEFT JOIN dbo.caregiver on dbo.accomodations.clientCode = dbo.caregiver.clientCode) " +
            "LEFT JOIN dbo.ccr on dbo.accomodations.clientCode = dbo.ccr.clientCode) " +
            "LEFT JOIN dbo.client on dbo.accomodations.clientCode = dbo.client.clientCode) " +
            "LEFT JOIN dbo.comp on dbo.accomodations.clientCode = dbo.comp.clientCode) " +
            "LEFT JOIN dbo.currentStatus on dbo.accomodations.clientCode = dbo.currentStatus.clientCode) " +
            "LEFT JOIN dbo.failed on dbo.accomodations.clientCode = dbo.failed.clientCode) " +
            "LEFT JOIN dbo.health on dbo.accomodations.clientCode = dbo.health.clientCode) " +
            "LEFT JOIN dbo.household on accomodations.clientCode = dbo.household.clientCode) " +
            "LEFT JOIN dbo.referral on dbo.accomodations.clientCode = dbo.referral.clientCode) " +
            "LEFT JOIN dbo.suspension on dbo.accomodations.clientCode = dbo.suspension.clientCode) " +
            "LEFT JOIN dbo.iep on dbo.accomodations.clientCode = dbo.iep.clientCode) " +
            "LEFT JOIN dbo.legal on dbo.accomodations.clientCode = dbo.legal.clientCode)" +
            "LEFT JOIN dbo.school on dbo.accomodations.clientCode = dbo.school.clientCode)" +
            "LEFT JOIN dbo.refform on dbo.accomodations.clientCode = dbo.refform.clientCode)" +
            "LEFT JOIN dbo.refInfo on dbo.accomodations.clientCode = dbo.refInfo.clientCode)" +
            "WHERE dbo.accomodations.clientCode ='" + clientCode + "';";
            command = new SqlCommand(query, cnn);


            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    EditTrackingm client = new EditTrackingm();
                    client.ClientID = Guid.Parse(Convert.ToString(dataReader["clientCode"]));
                    client.clientFirstName = Convert.ToString(dataReader["clientFirst"]);
                    client.clientLastName = Convert.ToString(dataReader["clientLast"]);
                    client.careGender = Convert.ToString(dataReader["caregender"]);
                    client.clientGender = Convert.ToString(dataReader["clientgender"]);
                    client.clientEthnicity = Convert.ToString(dataReader["clientethn"]);
              
                 
                      if (Convert.IsDBNull(dataReader["clientdob"]))
                    { client.clientDOB = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.clientDOB = Convert.ToDateTime(dataReader["clientdob"]);
                        string answerdob = client.clientDOB.ToString();
                        int spacedob = answerdob.IndexOf(" ");
                        string datedob = answerdob.Substring(0, spacedob);


                        string[] strlistdob = datedob.Split('/');


                        string yeardob = strlistdob[2];
                        string monthdob = strlistdob[1];
                        if ((monthdob.Length) == 1)
                        { monthdob = "0" + monthdob; }
                        string daydob = strlistdob[0];
                        if ((daydob.Length) == 1)
                        { daydob = "0" + daydob; }
                        string answerb = yeardob + "-" + daydob + "-" + monthdob;
                        client.stringDateOfBirth = answerb;
                    };


                    client.school = Convert.ToString(dataReader["school"]);
                    client.currentGrade = Convert.ToString(dataReader["grade"]);
                    client.referralSource = Convert.ToString(dataReader["refFName"]);
                    client.referrallSource = Convert.ToString(dataReader["refLName"]);
                    if (Convert.IsDBNull(dataReader["gradeFailed"]))
                    { client.failedGrade = 33; }
                    else { client.failedGrade = Convert.ToInt16(dataReader["gradeFailed"]); }

                    if (Convert.IsDBNull(dataReader["whichGrade"]))
                    { client.whichGradeFailed = 33; }
                    else { client.whichGradeFailed = Convert.ToInt16(dataReader["whichGrade"]); }

                    if (Convert.IsDBNull(dataReader["failedRepeat"]))
                    { client.failCount = 33; }
                    else { client.failCount = Convert.ToInt16(dataReader["failedRepeat"]); }

                    if (Convert.IsDBNull(dataReader["bakerActed"]))
                    { client.baker = 33; }
                    else { client.baker = Convert.ToInt16(dataReader["bakerActed"]); }

                    if (Convert.IsDBNull(dataReader["marchmanActed"]))
                    { client.marchman = 33; }
                    else { client.marchman = Convert.ToInt16(dataReader["marchmanActed"]); }

                    if (Convert.IsDBNull(dataReader["asthma"]))
                    { client.asthma = 33; }
                    else { client.asthma = Convert.ToInt16(dataReader["asthma"]); }

                    if (Convert.IsDBNull(dataReader["femLed"]))
                    { client.femHouse = 33; }
                    else { client.femHouse = Convert.ToInt16(dataReader["femLed"]); }

                    if (Convert.IsDBNull(dataReader["domVio"]))
                    { client.domVio = 33; }
                    else { client.domVio = Convert.ToInt16(dataReader["domVio"]); }

                    if (Convert.IsDBNull(dataReader["adopted"]))
                    { client.adopted = 33; }
                    else { client.adopted = Convert.ToInt16(dataReader["adopted"]); }

                    if (Convert.IsDBNull(dataReader["evicted"]))
                    { client.evicted = 33; }
                    else { client.evicted = Convert.ToInt16(dataReader["evicted"]); }

                    if (Convert.IsDBNull(dataReader["incarParent"]))
                    { client.incarParent = 33; }
                    else { client.incarParent = Convert.ToInt16(dataReader["incarParent"]); }


                    //accomodations---------------------------------CCR---------------------------------------------------------------

                    client.levelOfServiceProvided = Convert.ToString(dataReader["levelofService"]);

                 
                    if (Convert.IsDBNull(dataReader["refDate"]))
                    { client.referralDate = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.referralDate = Convert.ToDateTime(dataReader["refDate"]);
                        string answer = client.referralDate.ToString();
                        int space = answer.IndexOf(" ");
                        string date = answer.Substring(0, space);


                        string[] strlist = date.Split('/');


                        string year = strlist[2];
                        string month = strlist[1];
                        if ((month.Length) == 1)
                        { month = "0" + month; }
                        string day = strlist[0];
                        if ((day.Length) == 1)
                        { day = "0" + day; }
                        string answera = year + "-" + day + "-" + month;
                        client.stringReferralDate = answera;
                    };
                    //client.intakeDate = Convert.ToString(dataReader["intakeDate"]);//------------------------------------Date------------------------------------

                    //Reason for Nonengagement needs to be added

                    if (Convert.IsDBNull(dataReader["ccrStatus"]))
                    { client.caseStatus = 33; }
                    else { client.caseStatus = Convert.ToInt16(dataReader["ccrStatus"]); }


                    if (Convert.IsDBNull(dataReader["legalAdvo"]))
                    { client.legalAdvocacy = 33; }
                    else { client.legalAdvocacy = Convert.ToInt16(dataReader["legalAdvo"]); }

                    //done
                    client.legalAdvoTaken = Convert.ToString(dataReader["legalAdvoTaken"]);


                    if (Convert.IsDBNull(dataReader["remedy"]))
                    { client.remedyResolution = 33; }
                    else { client.remedyResolution = Convert.ToInt16(dataReader["remedy"]); }

                    client.nonEngagementReason = Convert.ToString(dataReader["nonEngageReason"]);

                    if (Convert.IsDBNull(dataReader["rearrestRep"]))
                    { client.rearrestWhileRepresented = 33; }
                    else { client.rearrestWhileRepresented = Convert.ToInt16(dataReader["rearrestRep"]); }

                    //referral count needs to be inserted here

                    client.schoolAtClosure = Convert.ToString(dataReader["closureSchool"]);

                    if (Convert.IsDBNull(dataReader["trackingdate"]))
                    { client.trackingdate = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.trackingdate = Convert.ToDateTime(dataReader["trackingdate"]);
                        string answertrackingdate = client.trackingdate.ToString();
                        int spacedtrackingdate = answertrackingdate.IndexOf(" ");
                        string datetrackingdate = answertrackingdate.Substring(0, spacedtrackingdate);


                        string[] strlisttrackingdate = datetrackingdate.Split('/');


                        string yeartrackingdate = strlisttrackingdate[2];
                        string monthtrackingdate = strlisttrackingdate[1];
                        if ((monthtrackingdate.Length) == 1)
                        { monthtrackingdate = "0" + monthtrackingdate; }
                        string daytrackingdate = strlisttrackingdate[0];
                        if ((daytrackingdate.Length) == 1)
                        { daytrackingdate = "0" + daytrackingdate; }
                        string answerI = yeartrackingdate + "-" + daytrackingdate + "-" + monthtrackingdate;
                        client.stringtrackingdate = answerI;
                    };

                    //is the first referral for the client

                    client.emailOfFirstReferralSource = Convert.ToString(dataReader["refEmail"]);



                    if (Convert.IsDBNull(dataReader["rearrestAdvo"]))
                    { client.rearrestAdvocacy = 33; }
                    else { client.rearrestAdvocacy = Convert.ToInt16(dataReader["rearrestAdvo"]); }
                    //int

                    if (Convert.IsDBNull(dataReader["courtAdvo"]))
                    { client.courtAdvocacy = 33; }
                    else { client.courtAdvocacy = Convert.ToInt16(dataReader["courtAdvo"]); }

                    if (Convert.IsDBNull(dataReader["staffingAdvo"]))
                    { client.staffAdvocacy = 33; }
                    else { client.staffAdvocacy = Convert.ToInt16(dataReader["staffingAdvo"]); }

                    //-------------------------------------------------------School Info----------------------------------------------

                    if (Convert.IsDBNull(dataReader["IEP"]))
                    { client.iep = 33; }
                    else { client.iep = Convert.ToInt16(dataReader["IEP"]); }

                    client.iepplan1 = Convert.ToString(dataReader["primaryIEP"]);

                    client.iepplan2 = Convert.ToString(dataReader["secondaryIEP"]);

                    client.schoolRef = Convert.ToString(dataReader["schoolRef"]);

                    client.readingLevel = Convert.ToString(dataReader["readingLevel"]);

                    client.mathLevel = Convert.ToString(dataReader["mathLevel"]);

                    if (Convert.IsDBNull(dataReader["inPride"]))
                    { client.inPride = 33; }
                    else { client.inPride = Convert.ToInt16(dataReader["inPride"]); }


                    if (Convert.IsDBNull(dataReader["newFBA"]))
                    { client.newFBA = 33; }
                    else { client.newFBA = Convert.ToInt16(dataReader["newFBA"]); }

                    if (Convert.IsDBNull(dataReader["accomGained"]))
                    { client.accomGained = 33; }
                    else { client.accomGained = Convert.ToInt16(dataReader["accomGained"]); }

                    if (Convert.IsDBNull(dataReader["compServices"]))
                    { client.compService = 33; }
                    else { client.compService = Convert.ToInt16(dataReader["compServices"]); }

                    client.ifWhatServices = Convert.ToString(dataReader["ifWhatServices"]);

                    client.compTime = Convert.ToString(dataReader["compTime"]);


                    if (Convert.IsDBNull(dataReader["bullied"]))
                    { client.bullied = 33; }
                    else { client.bullied = Convert.ToInt16(dataReader["bullied"]); }

                    if (Convert.IsDBNull(dataReader["reported"]))
                    { client.bullyReport = 33; }
                    else { client.bullyReport = Convert.ToInt16(dataReader["reported"]); }

                    //date
             
                    if (Convert.IsDBNull(dataReader["reportDate"]))
                    { client.dateofBully = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.dateofBully = Convert.ToDateTime(dataReader["reportDate"]);
                        string answerbully = client.dateofBully.ToString();
                        int spacebully = answerbully.IndexOf(" ");
                        string datebully = answerbully.Substring(0, spacebully);


                        string[] strlistbully = datebully.Split('/');


                        string yearbully = strlistbully[2];
                        string monthbully = strlistbully[1];
                        if ((monthbully.Length) == 1)
                        { monthbully = "0" + monthbully; }
                        string daybully = strlistbully[0];
                        if ((daybully.Length) == 1)
                        { daybully = "0" + daybully; }
                        string answerdatebully = yearbully + "-" + daybully + "-" + monthbully;
                        client.stringDateOfBully = answerdatebully;
                    };

                    //----------------------------------------------------------------------------Discipline-------------------------------

                    if (Convert.IsDBNull(dataReader["suspendedThrice"]))
                    { client.suspended = 33; }
                    else { client.suspended = Convert.ToInt16(dataReader["suspendedThrice"]); }

                    if (Convert.IsDBNull(dataReader["numSuspensions"]))
                    { client.suspendCount = 33; }
                    else { client.suspendCount = Convert.ToInt16(dataReader["numSuspensions"]); }

                    if (Convert.IsDBNull(dataReader["altSchool"]))
                    { client.altSchool = 33; }
                    else { client.altSchool = Convert.ToInt16(dataReader["altSchool"]); }

                    client.altSchoolName = Convert.ToString(dataReader["altSchoolName"]);

                  if (Convert.IsDBNull(dataReader["altSchoolDate"]))
                    { client.dateOfAlt = DateTime.Parse("01/01/1990"); }
                    else
                    {
                        client.dateOfAlt = Convert.ToDateTime(dataReader["altSchoolDate"]);
                        string answeralt = client.dateOfAlt.ToString();
                        int spacealt = answeralt.IndexOf(" ");
                        string datealt = answeralt.Substring(0, spacealt);


                        string[] strlistalt = datealt.Split('/');


                        string yearalt = strlistalt[2];
                        string monthalt = strlistalt[1];
                        if ((monthalt.Length) == 1)
                        { monthalt = "0" + monthalt; }
                        string dayalt = strlistalt[0];
                        if ((dayalt.Length) == 1)
                        { dayalt = "0" + dayalt; }
                        string answeraltschool = yearalt + "-" + dayalt + "-" + monthalt;
                        client.stringDateOfAlt = answeraltschool;

                    };

                    if (Convert.IsDBNull(dataReader["altSchoolTimes"]))
                    { client.timesInAlt = 33; }
                    else { client.timesInAlt = Convert.ToInt16(dataReader["altSchoolTimes"]); }


                    if (Convert.IsDBNull(dataReader["daysOwed"]))
                    { client.daysOwed = 33; }
                    else { client.daysOwed = Convert.ToInt16(dataReader["daysOwed"]); }

                    client.firstLegal = Convert.ToString(dataReader["legalIssues"]);

                    client.secondLegal = Convert.ToString(dataReader["leagalIssues2"]);


                    if (Convert.IsDBNull(dataReader["ISS"]))
                    { client.iss = 0; }
                    else { client.iss = Convert.ToInt16(dataReader["ISS"]); }

                    if (Convert.IsDBNull(dataReader["OSS"]))
                    { client.oss = 0; }
                    else { client.oss = Convert.ToInt16(dataReader["OSS"]); }


                    if (Convert.IsDBNull(dataReader["daysSinceIntake"]))
                    { client.daysSinceIntake = 0; }
                    else { client.daysSinceIntake = Convert.ToInt16(dataReader["daysSinceIntake"]); }

                    client.justiceOutcome = Convert.ToString(dataReader["juvJusticeOutcome"]);



                    if (Convert.IsDBNull(dataReader["publicAssistance"]))
                    { client.publicAssistance = 33; }
                    else { client.publicAssistance = Convert.ToInt16(dataReader["publicAssistance"]); }

                    client.careLastName = Convert.ToString(dataReader["careLast"]);

                    client.careFirstName = Convert.ToString(dataReader["careFirst"]);

                    client.carePhone = Convert.ToString(dataReader["phoneNumber"]);

                    client.careEthnicity = Convert.ToString(dataReader["careethnic"]);

                    ViewBag.LSessage = client;

                }
            }
            adapter.Dispose();
            command.Dispose();
            cnn.Close();

            return View();

        }


        [HttpPost]
        public IActionResult EditTrackingForm(EditTrackingm form)
        {
            SqlConnection cnnn;
            cnnn = new SqlConnection(cconnectionString);
            cnnn.Open();//Connect
                        //as you edit the tracking form update the clients referral name, dob, case status
           
            object clientcheckc = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.refform WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();

            //if client code is not in the table client ID insert values in table

            //SqlCommand commandd = cnnn.CreateCommand();
            object bullycheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.bully WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object clientcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.client WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object advocacycheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.advocacy WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object accomodationscheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.accomodations WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object altSchoolcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.altSchool WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object caregivercheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.caregiver WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object ccrcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.ccr WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object compcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.comp WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object currentStatuscheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.currentStatus WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object failedcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.failed WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object healthcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.health WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object householdcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.household WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object suspensioncheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.suspension WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object iepcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.iep WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object legalcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.legal WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object schoolcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.school WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            object refcheck = new SqlCommand("SELECT COUNT(clientCode) FROM dbo.refInfo WHERE clientCode = '" + form.ClientID + "'", cnnn).ExecuteScalar();
            cnnn.Close();
            int ccc = (Convert.ToInt16(clientcheckc)) + 0;
           
            int bc = (Convert.ToInt16(bullycheck)) + 0;
            int cc = (Convert.ToInt16(clientcheck)) + 0;
            int ac = (Convert.ToInt16(advocacycheck)) + 0;
            int acc = (Convert.ToInt16(accomodationscheck)) + 0;
            int asc = (Convert.ToInt16(altSchoolcheck)) + 0;
            int cgc = (Convert.ToInt16(caregivercheck)) + 0;
            int ccrc = (Convert.ToInt16(ccrcheck)) + 0;
            int fc = (Convert.ToInt16(failedcheck)) + 0;
            int compch = (Convert.ToInt16(compcheck)) + 0;
            int currentStatusch = (Convert.ToInt16(currentStatuscheck)) + 0;
            int hc = (Convert.ToInt16(healthcheck)) + 0;
            int hhc = (Convert.ToInt16(householdcheck)) + 0;
            int ssc = (Convert.ToInt16(suspensioncheck)) + 0;
            int iepc = (Convert.ToInt16(iepcheck)) + 0;
            int lc = (Convert.ToInt16(legalcheck)) + 0;
            int sc = (Convert.ToInt16(schoolcheck)) + 0;
            int ri = (Convert.ToInt16(refcheck)) + 0;

            if (ri == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateclientq = new SqlCommand("", link))
                {
                    Debug.WriteLine("Send to debug output.");
                    stateclientq.CommandText = "INSERT INTO dbo.refInfo (refFName,  refLName,  refDate, clientCode, refEmail) VALUES (@reFName,  @refLName, @refDate, @clientCode, @refEmail);";

                    //, dob = @birthday //need to add this when it is working and null bday is accepted
                    stateclientq.Parameters.AddWithValue("@clientCode", form.ClientID);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter firstref = stateclientq.Parameters.AddWithValue("@reFName", form.referralSource);
                    if (form.referralSource == null)
                    {
                        firstref.Value = DBNull.Value;
                    }
                    SqlParameter lastref= stateclientq.Parameters.AddWithValue("@refLName", form.referrallSource);
                    if (form.referrallSource == null)
                    {
                        lastref.Value = DBNull.Value;
                    }
                    SqlParameter refemaill = stateclientq.Parameters.AddWithValue("@refEmail", form.emailOfFirstReferralSource);
                    if (form.emailOfFirstReferralSource == null)
                    {
                        refemaill.Value = DBNull.Value;
                    }
                    SqlParameter refdates = stateclientq.Parameters.AddWithValue("@refDate", form.referralDate);
                    if (form.referralDate == null)
                    {
                        refdates.Value = DBNull.Value;
                    }
                    // SqlParameter rfnas = stateclient.Parameters.AddWithValue("@birthday", form.clientDOB);/////////////////////-Date
                    // if (form.clientDOB == null)
                    // {
                    //   rfnas.Value = DBNull.Value;
                    // }

                    link.Open();
                    stateclientq.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (ccc >= 1)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateclient = new SqlCommand("", link))
                {
                    Debug.WriteLine("Send to debug output.");
                    stateclient.CommandText = "UPDATE dbo.refform SET fname = @fname,  lname = @lname WHERE clientCode = @clientCode; ";
                    //, dob = @birthday //need to add this when it is working and null bday is accepted
                    stateclient.Parameters.AddWithValue("@clientCode", form.ClientID);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter reasa = stateclient.Parameters.AddWithValue("@fname", form.clientFirstName);
                    if (form.clientFirstName == null)
                    {
                        reasa.Value = DBNull.Value;
                    }
                    SqlParameter morea = stateclient.Parameters.AddWithValue("@lname", form.clientLastName);
                    if (form.clientLastName == null)
                    {
                        morea.Value = DBNull.Value;
                    }

                    // SqlParameter rfnas = stateclient.Parameters.AddWithValue("@birthday", form.clientDOB);/////////////////////-Date
                    // if (form.clientDOB == null)
                    // {
                    //   rfnas.Value = DBNull.Value;
                    // }

                    link.Open();
                    stateclient.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }




            if (bc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand bullyins = new SqlCommand("", link))
                {
                    bullyins.CommandText = "INSERT INTO dbo.bully (bullied,  reported,  reportDate, clientCode) VALUES (@bullied,  @reported, @reportDate, @clientCode);";
                    bullyins.Parameters.AddWithValue("@clientCode", form.ClientID);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter issu = bullyins.Parameters.AddWithValue("@bullied", form.bullied);
                    if (form.bullied < 0 || form.bullied > 1)
                    {
                        issu.Value = DBNull.Value;
                    }
                    SqlParameter arr = bullyins.Parameters.AddWithValue("@reported", form.bullyReport);
                    if (form.bullyReport != 0 && form.bullyReport != 1)
                    {
                        arr.Value = DBNull.Value;
                    }
                    SqlParameter dateofbullie = bullyins.Parameters.AddWithValue("@reportDate", form.dateofBully);
                    if (form.dateofBully == null)
                    {
                        dateofbullie.Value = DBNull.Value;
                    }
                    link.Open();
                    bullyins.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();

                }


            }
            if (cc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateclient = new SqlCommand("", link))
                {
                    stateclient.CommandText = "INSERT INTO dbo.client (clientLast,  clientFirst,  genderIdentity,  ethnicity,  dob,  phoneNumber, clientCode) VALUES (@clientLast,  @clientFirst, @clientgender, @clientethn, @dob, @phoneNumber, @clientCode); ";
                    stateclient.Parameters.AddWithValue("@clientCode", form.ClientID);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter reasa = stateclient.Parameters.AddWithValue("@clientFirst", form.clientFirstName);
                    if (form.clientFirstName == null)
                    {
                        reasa.Value = DBNull.Value;
                    }
                    SqlParameter morea = stateclient.Parameters.AddWithValue("@clientLast", form.clientLastName);
                    if (form.clientLastName == null)
                    {
                        morea.Value = DBNull.Value;
                    }
                    SqlParameter rlna = stateclient.Parameters.AddWithValue("@clientgender", form.clientGender);
                    if (form.clientGender != "male" && form.clientGender != "female" && form.clientGender != "trans" && form.clientGender != "nonbinaryF" && form.clientGender != "nonbinaryM" && form.clientGender != "neutral")
                    {
                        rlna.Value = DBNull.Value;
                    }
                    SqlParameter graw = stateclient.Parameters.AddWithValue("@clientethn", form.clientEthnicity);
                    if (form.clientEthnicity != "nhWhite" && form.clientEthnicity != "hispanic" && form.clientEthnicity != "natAm" && form.clientEthnicity != "jewish" && form.clientEthnicity != "black" && form.clientEthnicity != "multi" && form.clientEthnicity != "notListed")
                    {
                        graw.Value = DBNull.Value;
                    }
                    SqlParameter rfnas = stateclient.Parameters.AddWithValue("@dob", form.clientDOB);/////////////////////-Date
                    if (form.clientDOB == null)
                    {
                        rfnas.Value = DBNull.Value;
                    }
                    SqlParameter rlnt = stateclient.Parameters.AddWithValue("@phoneNumber", form.carePhone);
                    if (form.carePhone == null)
                    {
                        rlnt.Value = DBNull.Value;
                    }
                    link.Open();
                    stateclient.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }

            if (ac == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateadvo = new SqlCommand("", link))
                {
                    stateadvo.CommandText = "INSERT INTO dbo.advocacy (rearrestAdvo, courtAdvo, staffingAdvo, legalAdvo, legalAdvoTaken, clientCode) VALUES (@rearrestAdvo, @courtAdvo, @staffingAdvo,  @legalAdvo, @legalAdvoTaken, @clientCode); ";
                    stateadvo.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter rearrestAdvoCodeParam = stateadvo.Parameters.AddWithValue("@rearrestAdvo", form.rearrestAdvocacy);
                    if (form.rearrestAdvocacy != 1 && form.rearrestAdvocacy != 0)
                    {
                        rearrestAdvoCodeParam.Value = DBNull.Value;
                    }

                    SqlParameter courtAdvoCodeParam = stateadvo.Parameters.AddWithValue("@courtAdvo", form.courtAdvocacy);
                    if (form.courtAdvocacy < 0 || form.courtAdvocacy > 1)
                    {
                        courtAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter staffingAdvoCodeParam = stateadvo.Parameters.AddWithValue("@staffingAdvo", form.staffAdvocacy);
                    if (form.staffAdvocacy < 0 || form.staffAdvocacy > 1)
                    {
                        staffingAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoCodeParam = stateadvo.Parameters.AddWithValue("@legalAdvo", form.legalAdvocacy);
                    if (form.legalAdvocacy > 1 || form.legalAdvocacy < 0)
                    {
                        legalAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoTakenCodeParam = stateadvo.Parameters.AddWithValue("@legalAdvoTaken", form.legalAdvoTaken);
                    if (form.legalAdvoTaken == null)
                    {
                        legalAdvoTakenCodeParam.Value = DBNull.Value;
                    }
                    link.Open();
                    stateadvo.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }

            if (acc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand stateacc = new SqlCommand("", link))
                {
                    stateacc.CommandText = "INSERT INTO dbo.accomodations (accomGained,  compServices, ifWhatServices, clientCode) VALUES (@accomGained,  @compServices, @ifWhatServices, @clientCode);";
                    stateacc.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter rearrestAdvoCodeParam = stateacc.Parameters.AddWithValue("@rearrestAdvo", form.rearrestAdvocacy);
                    SqlParameter accomGainedCodeParam = stateacc.Parameters.AddWithValue("@accomGained", form.accomGained);
                    if (form.accomGained != 1 && form.accomGained != 2 && form.accomGained != 0)
                    {
                        accomGainedCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter compServicesCodeParam = stateacc.Parameters.AddWithValue("@compServices", form.compService);
                    if (form.compService != 1 && form.compService != 0)
                    {
                        compServicesCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter ifWhatServicesCodeParam = stateacc.Parameters.AddWithValue("@ifWhatServices", form.ifWhatServices);
                    if (form.ifWhatServices == null)
                    {
                        ifWhatServicesCodeParam.Value = DBNull.Value;
                    }
                    link.Open();
                    stateacc.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }
            if (asc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand altschoolstate = new SqlCommand("", link))
                {
                    altschoolstate.CommandText = "INSERT INTO dbo.altSchool (altSchool, altSchoolName, altSchoolDate, altSchoolTimes, daysOwed, daysSinceIntake, clientCode) VALUES (@altSchool, @altSchoolName, @altSchoolDate, @altSchoolTimes, @daysOwed, @daysSinceIntake, @clientCode);";
                    altschoolstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter altSchool = altschoolstate.Parameters.AddWithValue("@altSchool", form.altSchool);
                    if (form.altSchool != 0 && form.altSchool != 1)
                    {
                        altSchool.Value = DBNull.Value;
                    }
                    SqlParameter y = altschoolstate.Parameters.AddWithValue("@altSchoolName", form.altSchoolName);
                    if (form.altSchoolName == null)
                    {
                        y.Value = DBNull.Value;
                    }
                    SqlParameter yy = altschoolstate.Parameters.AddWithValue("@altSchoolDate", form.dateOfAlt);
                    if (form.dateOfAlt == null)
                    {
                        yy.Value = DBNull.Value;
                    }
                    SqlParameter gin = altschoolstate.Parameters.AddWithValue("@altSchoolTimes", form.timesInAlt);
                    if (form.timesInAlt < 0 || form.timesInAlt > 3)
                    {
                        gin.Value = DBNull.Value;
                    }

                    SqlParameter tok = altschoolstate.Parameters.AddWithValue("@daysOwed", form.daysOwed);//may work may not
                    if ((form.daysOwed.ToString()).Length ==0)
                    {
                        tok.Value = DBNull.Value;
                    }

                    SqlParameter daysSinceIntake = altschoolstate.Parameters.AddWithValue("@daysSinceIntake", form.daysSinceIntake);//may not work
                    if ((form.daysSinceIntake.ToString()).Length == 0)
                    {
                        daysSinceIntake.Value = DBNull.Value;
                    }
                    link.Open();
                    altschoolstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (cgc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand carestate = new SqlCommand("", link))
                {
                    carestate.CommandText = "INSERT INTO dbo.caregiver (careLast,  careFirst,  genderIdentity,  ethnicity, clientCode) VALUES (@careLast,  @careFirst, @caregender, @careethnic , @clientCode);";
                    carestate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter stat = carestate.Parameters.AddWithValue("@careLast", form.careLastName);
                    if (form.careLastName == null)
                    {
                        stat.Value = DBNull.Value;
                    }
                    SqlParameter dateii = carestate.Parameters.AddWithValue("@careFirst", form.careFirstName);
                    if (form.careFirstName == null)
                    {
                        dateii.Value = DBNull.Value;
                    }
                    SqlParameter dates = carestate.Parameters.AddWithValue("@caregender", form.careGender);
                    if (form.careGender != "Mother" && form.careGender != "Father" && form.careGender != "mGrandma" && form.careGender != "mGrandpa" && form.careGender != "Other")
                    {
                        dates.Value = DBNull.Value;
                    }
                    SqlParameter ema = carestate.Parameters.AddWithValue("@careethnic", form.careEthnicity);
                    if (form.careEthnicity == null)
                    {
                        ema.Value = DBNull.Value;
                    }
                    link.Open();
                    carestate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (ccrc == 0)
            {

                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand ccrcstate = new SqlCommand("", link))
                {
                    ccrcstate.CommandText = "INSERT INTO dbo.ccr (dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.nonEngageReason, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, clientCode) VALUES (@levelofService, @ccrStatus, @nonEngageReason, @remedy, @rearrestRep, @closureSchool, @clientCode);";
                    ccrcstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter morei = ccrcstate.Parameters.AddWithValue("@levelofService", form.levelOfServiceProvided);
                    if (form.levelOfServiceProvided == null)
                    {
                        morei.Value = DBNull.Value;
                    }
                    SqlParameter reas = ccrcstate.Parameters.AddWithValue("@ccrStatus", form.caseStatus);
                    if (form.caseStatus > 2 || form.caseStatus < 0)
                    {
                        reas.Value = DBNull.Value;
                    }
                    SqlParameter nonEngageReason = ccrcstate.Parameters.AddWithValue("@nonEngageReason", form.nonEngagementReason);
                    if (form.nonEngagementReason == null)
                    {
                        nonEngageReason.Value = DBNull.Value;
                    }

                    SqlParameter rfn = ccrcstate.Parameters.AddWithValue("@remedy", form.remedyResolution);
                    if (form.remedyResolution > 1 || form.remedyResolution < 0)
                    {
                        rfn.Value = DBNull.Value;
                    }
                    SqlParameter rln = ccrcstate.Parameters.AddWithValue("@rearrestRep", form.rearrestWhileRepresented);
                    if (form.rearrestWhileRepresented > 1 || form.rearrestWhileRepresented < 0)
                    {
                        rln.Value = DBNull.Value;
                    }
                    SqlParameter gra = ccrcstate.Parameters.AddWithValue("@closureSchool", form.schoolAtClosure);
                    if (form.schoolAtClosure == null)
                    {
                        gra.Value = DBNull.Value;
                    }

                    link.Open();
                    ccrcstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }

            if (compch == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand compstate = new SqlCommand("", link))
                {
                    compstate.CommandText = "INSERT INTO dbo.comp (compTime, clientCode) VALUES (@compTime, @clientCode);";
                    compstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter comptime = compstate.Parameters.AddWithValue("@compTime", form.compTime);
                    if (form.compTime == null)
                    {
                        comptime.Value = DBNull.Value;
                    }

                    link.Open();
                    compstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (currentStatusch == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand currstate = new SqlCommand("", link))
                {
                    currstate.CommandText = "INSERT INTO dbo.currentStatus (readingLevel,  mathLevel,  inPride,  newFBA, clientCode) VALUES (@readingLevel,  @mathLevel, @inPride, @newFBA, @clientCode);";
                    currstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter readingLevel = currstate.Parameters.AddWithValue("@readingLevel", form.readingLevel);
                    if (form.readingLevel == null)
                    {
                        readingLevel.Value = DBNull.Value;
                    }
                    SqlParameter mathLevel = currstate.Parameters.AddWithValue("@mathLevel", form.mathLevel);
                    if (form.mathLevel == null)
                    {
                        mathLevel.Value = DBNull.Value;
                    }
                    SqlParameter inPride = currstate.Parameters.AddWithValue("@inPride", form.inPride);
                    if (form.inPride < 1 || form.inPride > 0)
                    {
                        inPride.Value = DBNull.Value;
                    }
                    SqlParameter newFBA = currstate.Parameters.AddWithValue("@newFBA", form.newFBA);
                    if (form.newFBA < 0 || form.newFBA > 1)
                    {
                        newFBA.Value = DBNull.Value;
                    }

                    link.Open();
                    currstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }

            if (fc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand failedstate = new SqlCommand("", link))
                {
                    failedstate.CommandText = "INSERT INTO dbo.failed (gradeFailed,  whichGrade,  failedRepeat, clientCode) VALUES (@gradeFailed,  @whichGrade, @failedRepeat, @clientCode);";
                    failedstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter gradeFailed = failedstate.Parameters.AddWithValue("@gradeFailed", form.failedGrade);
                    if (form.failedGrade != 0 && form.failedGrade != 1)
                    {
                        gradeFailed.Value = DBNull.Value;
                    }
                    SqlParameter whichGrade = failedstate.Parameters.AddWithValue("@whichGrade", form.whichGradeFailed);
                    if (0 > form.whichGradeFailed || form.whichGradeFailed > 12)
                    {
                        whichGrade.Value = DBNull.Value;
                    }
                    SqlParameter failedRepeat = failedstate.Parameters.AddWithValue("@failedRepeat", form.failCount);
                    if (form.failCount >= 0)
                    { }
                    else
                    {
                        failedRepeat.Value = DBNull.Value;
                    }

                    link.Open();
                    failedstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (hc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand healthstate = new SqlCommand("", link))
                {
                    healthstate.CommandText = "INSERT INTO dbo.health (bakerActed,  marchmanActed,  asthma, clientCode) VALUES (@bakerActed,  @marchmanActed,  @asthma, @clientCode);";
                    healthstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter bakerActed = healthstate.Parameters.AddWithValue("@bakerActed", form.baker);
                    if ((form.baker != 0 && form.baker != 1))
                    {
                        bakerActed.Value = DBNull.Value;
                    }
                    SqlParameter march = healthstate.Parameters.AddWithValue("@marchmanActed", form.marchman);
                    if ((form.marchman != 0 && form.marchman != 1))
                    {
                        march.Value = DBNull.Value;
                    }
                    SqlParameter asthma = healthstate.Parameters.AddWithValue("@asthma", form.asthma);
                    if (form.asthma != 0 && form.asthma != 1)
                    {
                        asthma.Value = DBNull.Value;
                    }

                    link.Open();
                    healthstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (hhc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand hhstate = new SqlCommand("", link))
                {
                    hhstate.CommandText = "INSERT INTO dbo.household (femLed,  domVio,  adopted,  evicted,  incarParent,  publicAssistance, clientCode) VALUES ( @femLed,  @domVio,  @adopted, @evicted, @incarParent, @publicAssistance, @clientCode);";
                    hhstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter femLed = hhstate.Parameters.AddWithValue("@femLed", form.femHouse);
                    if (form.femHouse != 0 && form.femHouse != 1)
                    {
                        femLed.Value = DBNull.Value;
                    }
                    SqlParameter domVio = hhstate.Parameters.AddWithValue("@domVio", form.domVio);
                    if (form.domVio != 0 && form.domVio != 1)
                    {
                        domVio.Value = DBNull.Value;
                    }
                    SqlParameter adopted = hhstate.Parameters.AddWithValue("@adopted", form.adopted);
                    if (form.adopted != 0 && form.adopted != 1)
                    {
                        adopted.Value = DBNull.Value;
                    }
                    SqlParameter evicted = hhstate.Parameters.AddWithValue("@evicted", form.evicted);
                    if (form.evicted != 0 && form.evicted != 1)
                    {
                        evicted.Value = DBNull.Value;
                    }
                    SqlParameter incarParent = hhstate.Parameters.AddWithValue("@incarParent", form.incarParent);
                    if (form.incarParent != 0 && form.incarParent != 1)
                    {
                        incarParent.Value = DBNull.Value;
                    }
                    SqlParameter publicAssistance = hhstate.Parameters.AddWithValue("@publicAssistance", form.publicAssistance);
                    if (form.publicAssistance != 0 && form.publicAssistance != 1)
                    {
                        publicAssistance.Value = DBNull.Value;
                    }

                    link.Open();
                    hhstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (ssc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand susstate = new SqlCommand("", link))
                {
                    susstate.CommandText = "INSERT INTO dbo.suspension (suspendedThrice,  numSuspensions,  totalDaysSuspended,  ISS,  OSS, clientCode) VALUES ( @suspendedThrice, @numSuspensions, @totalDaysSuspended, @ISS,  @OSS, @clientCode);";
                    susstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter suspendedThrice = susstate.Parameters.AddWithValue("@suspendedThrice", form.suspended);
                    if (form.suspended != 1 && form.suspended != 0)
                    {
                        suspendedThrice.Value = DBNull.Value;
                    }
                    SqlParameter numSuspensions = susstate.Parameters.AddWithValue("@numSuspensions", form.suspendCount);
                    if (form.suspendCount < 4 || form.suspended > 10)
                    {
                        numSuspensions.Value = DBNull.Value;
                    }
                    SqlParameter totalDaysSuspended = susstate.Parameters.AddWithValue("@totalDaysSuspended", (form.iss + form.oss));
                    if ((form.iss.ToString().Length == 0 )&& (form.oss.ToString().Length != 0))
                    { totalDaysSuspended.Value = form.oss; }
                    if ((form.oss.ToString().Length == 0) && (form.iss.ToString().Length != 0))
                    { totalDaysSuspended.Value = form.iss; }
                    if (form.iss.ToString().Length == 0 && (form.iss.ToString().Length ==0))
                    { totalDaysSuspended.Value = DBNull.Value; }
                    SqlParameter ISS = susstate.Parameters.AddWithValue("@ISS", form.iss);
                    if ((form.iss.ToString().Length == 0))
                    { ISS.Value = DBNull.Value; }
                    SqlParameter OSS = susstate.Parameters.AddWithValue("@OSS", form.oss);
                    if ((form.oss.ToString().Length == 0))
                    { OSS.Value = DBNull.Value; }
                    link.Open();
                    susstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (iepc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand iepstate = new SqlCommand("", link))
                {
                    iepstate.CommandText = "INSERT INTO dbo.iep (IEP,  primaryIEP,  secondaryIEP, clientCode) VALUES ( @IEP,  @primaryIEP,  @secondaryIEP , @clientCode);";
                    iepstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter IEP = iepstate.Parameters.AddWithValue("@IEP", form.iep);
                    if (form.iep < 0 || form.iep > 1)
                    {
                        IEP.Value = DBNull.Value;
                    }
                    SqlParameter primaryIEP = iepstate.Parameters.AddWithValue("@primaryIEP", form.iepplan1);
                    if (form.iepplan1 == null)
                    {
                        primaryIEP.Value = DBNull.Value;
                    }
                    SqlParameter secondaryIEP = iepstate.Parameters.AddWithValue("@secondaryIEP", form.iepplan2);
                    if (form.iepplan2 == null)
                    {
                        secondaryIEP.Value = DBNull.Value;
                    }

                    link.Open();
                    iepstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            if (lc == 0)
            {
                // clientcode is not in the table insert the values
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand statelegal = new SqlCommand("", link))
                {
                    statelegal.CommandText = "INSERT INTO dbo.legal (legalIssues, leagalIssues2, juvJusticeOutcome, clientCode) VALUES (@legalIssues,  @leagalIssues2,  @juvJusticeOutcome, @clientCode);";
                    statelegal.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter legalIssues = statelegal.Parameters.AddWithValue("@legalIssues", form.firstLegal);
                    if (form.firstLegal == null)
                    {
                        legalIssues.Value = DBNull.Value;
                    }
                    SqlParameter leagalIssues2 = statelegal.Parameters.AddWithValue("@leagalIssues2", form.secondLegal);
                    if (form.secondLegal == null)
                    {
                        leagalIssues2.Value = DBNull.Value;
                    }

                    SqlParameter justiceOutcome = statelegal.Parameters.AddWithValue("@juvJusticeOutcome", form.justiceOutcome);
                    if (form.justiceOutcome == null)
                    {
                        justiceOutcome.Value = DBNull.Value;
                    }

                    link.Open();
                    statelegal.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }

            }
            if (sc == 0)
            {
                SqlConnection cnnt;
                cnnt = new SqlConnection(cconnectionString);
                using (SqlConnection link = new SqlConnection(cconnectionString))
                using (SqlCommand schoolstate = new SqlCommand("", link))
                {
                    schoolstate.CommandText = "INSERT INTO dbo.school (grade,  school,  SchoolRef, clientCode) VALUES (@grade,  @school,  @SchoolRef, @clientCode);";
                    schoolstate.Parameters.AddWithValue("@clientCode", form.ClientID);
                    SqlParameter grade = schoolstate.Parameters.AddWithValue("@grade", form.currentGrade);
                    if (form.currentGrade == null)
                    {
                        grade.Value = DBNull.Value;
                    }
                    SqlParameter school = schoolstate.Parameters.AddWithValue("@school", form.school);
                    if (form.school == null)
                    {
                        school.Value = DBNull.Value;
                    }
                    SqlParameter schoolRef = schoolstate.Parameters.AddWithValue("@schoolRef", form.schoolRef);
                    if (form.schoolRef == null)
                    {
                        schoolRef.Value = DBNull.Value;
                    }

                    link.Open();
                    schoolstate.ExecuteNonQuery();
                    link.Close();
                    cnnt.Close();
                }
            }
            cnnn.Close();
            {

                
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("", connection))
                {

                    command.CommandText =
                         "UPDATE dbo.bully " +
                        "SET bullied = @bullied,  reported = @reported,  reportDate = @reportDate WHERE clientCode = @clientCode;" +

                              "UPDATE dbo.client " +
                    "SET clientLast = @clientLast,  clientFirst = @clientFirst,  genderIdentity = @clientgender,  ethnicity = @clientethn,  dob = @dob,  phoneNumber = @phoneNumber " +
                    "WHERE  clientCode= @clientCode;" +

                    "UPDATE dbo.advocacy " +
                     "SET rearrestAdvo = @rearrestAdvo, courtAdvo = @courtAdvo, staffingAdvo = @staffingAdvo, legalAdvo = @legalAdvo, legalAdvoTaken = @legalAdvoTaken " +
                   "WHERE clientCode = @clientCode; " +

                    "UPDATE dbo.accomodations" +
                    " SET accomGained = @accomGained,  compServices = @compServices ,ifWhatServices = @ifWhatServices " +
                    " WHERE  clientCode = @clientCode; " +

                    "UPDATE dbo.altSchool" +
                    " SET altSchool = @altSchool, altSchoolName = @altSchoolName, altSchoolDate = @altSchoolDate, altSchoolTimes = @altSchoolTimes, daysOwed = @daysOwed, daysSinceIntake = @daysSinceIntake" +
                    " WHERE  clientCode = @clientCode; " +

             "UPDATE dbo.caregiver" +
                  " SET  careLast = @careLast,  careFirst = @careFirst,  genderIdentity = @caregender,  ethnicity = @careethnic " +
                    " WHERE  clientCode= @clientCode; " +

                   "UPDATE dbo.ccr" +
                    " SET dbo.ccr.levelofService = @levelofService, dbo.ccr.ccrStatus = @ccrStatus, dbo.ccr.nonEngageReason = @nonEngageReason, dbo.ccr.remedy = @remedy, dbo.ccr.rearrestRep = @rearrestRep, dbo.ccr.closureSchool = @closureSchool, dbo.ccr.dateInput =@trackingdate " +
                   " WHERE dbo.ccr.clientCode = @clientCode; " +

                    "UPDATE dbo.comp" +
                    " SET compTime = @compTime " +
                    " WHERE  clientCode = @clientCode; " +

                    "UPDATE dbo.currentStatus" +
                  " SET readingLevel = @readingLevel,  mathLevel = @mathLevel,  inPride = @inPride,  newFBA = @newFBA " +
                  " WHERE  clientCode=  @clientCode; " +

                    "UPDATE dbo.failed" +
                    " SET gradeFailed = @gradeFailed,  whichGrade = @whichGrade,  failedRepeat = @failedRepeat " +
                    " WHERE  clientCode = @clientCode; " +

                    "UPDATE dbo.health" +
                    " SET bakerActed = @bakerActed,  marchmanActed = @marchmanActed,  asthma = @asthma " +
                    " WHERE  clientCode = @clientCode; " +

                    " UPDATE dbo.household" +
                    " SET femLed = @femLed,  domVio = @domVio,  adopted = @adopted,  evicted = @evicted,  incarParent = @incarParent,  publicAssistance = @publicAssistance " +
                     " WHERE  clientCode = @clientCode; " +

                    " UPDATE dbo.suspension" +
                    " SET  suspendedThrice = @suspendedThrice,  numSuspensions = @numSuspensions,  totalDaysSuspended = @totalDaysSuspended,  ISS = @ISS,  OSS = @OSS " +
                    " WHERE  clientCode = @clientCode; " +

                    " UPDATE dbo.iep" +
                    " SET IEP = @IEP,  primaryIEP = @primaryIEP,  secondaryIEP = @secondaryIEP " +
                    " WHERE  clientCode = @clientCode; " +

                    " UPDATE dbo.legal" +
                   " SET  legalIssues = @legalIssues,  leagalIssues2 = @leagalIssues2,  juvJusticeOutcome =@juvJusticeOutcome" +
                   " WHERE  clientCode = @clientCode; " +

                   " UPDATE dbo.school" +
                    " SET  grade = @grade,  school = @school,  SchoolRef = @SchoolRef" +
                   " WHERE  clientCode = @clientCode; " +

                     " UPDATE dbo.refInfo" +
               " SET refFName = @reFName,  refLName = @reLName,  refDate = @refDate,  refEmail = @refEmail " +
                " WHERE  clientCode = @clientCode; " +

               " UPDATE dbo.refform" +
               " SET email = @email,  referralfname = @referralfname,  referrallname = @referrallname,  dateInput = @dateInput, fname = @fname, lname =@lname, dob= @birthday " +
                " WHERE  clientCode = @clientCode; ";


                    command.Parameters.AddWithValue("@clientCode", form.ClientID);
                    //----------------------------------------------Demographics--------------------------------
                    SqlParameter issu = command.Parameters.AddWithValue("@bullied", form.bullied);
                    if (form.bullied < 0 || form.bullied > 1)
                    {
                        issu.Value = DBNull.Value;
                    }
                    SqlParameter arr = command.Parameters.AddWithValue("@reported", form.bullyReport);
                    if (form.bullyReport != 0 && form.bullyReport != 1)
                    {
                        arr.Value = DBNull.Value;
                    }
                    SqlParameter dateofbullie = command.Parameters.AddWithValue("@reportDate", form.dateofBully);
                    if (form.dateofBully == null)
                    {
                        dateofbullie.Value = DBNull.Value;
                    }
                    SqlParameter reasa = command.Parameters.AddWithValue("@clientFirst", form.clientFirstName);
                    if (form.clientFirstName == null)
                    {
                        reasa.Value = DBNull.Value;
                    }
                    SqlParameter morea = command.Parameters.AddWithValue("@clientLast", form.clientLastName);
                    if (form.clientLastName == null)
                    {
                        morea.Value = DBNull.Value;
                    }
                    SqlParameter rlna = command.Parameters.AddWithValue("@clientgender", form.clientGender);
                    if (form.clientGender != "male" && form.clientGender != "female" && form.clientGender != "trans" && form.clientGender != "nonbinaryF" && form.clientGender != "nonbinaryM" && form.clientGender != "neutral")
                    {
                        rlna.Value = DBNull.Value;
                    }
                    SqlParameter graw = command.Parameters.AddWithValue("@clientethn", form.clientEthnicity);
                    if (form.clientEthnicity != "nhWhite" && form.clientEthnicity != "hispanic" && form.clientEthnicity != "natAm" && form.clientEthnicity != "jewish" && form.clientEthnicity != "black" && form.clientEthnicity != "multi" && form.clientEthnicity != "notListed")
                    {
                        graw.Value = DBNull.Value;
                    }
                    SqlParameter rfnas = command.Parameters.AddWithValue("@dob", form.clientDOB);/////////////////////-Date
                    if (form.clientDOB == null)
                    {
                        rfnas.Value = DBNull.Value;
                    }
                    SqlParameter rlnt = command.Parameters.AddWithValue("@phoneNumber", form.carePhone);
                    if (form.carePhone == null)
                    {
                        rlnt.Value = DBNull.Value;
                    }
                    SqlParameter rearrestAdvoCodeParam = command.Parameters.AddWithValue("@rearrestAdvo", form.rearrestAdvocacy);
                    if (form.rearrestAdvocacy != 1 && form.rearrestAdvocacy != 0)
                    {
                        rearrestAdvoCodeParam.Value = DBNull.Value;
                    }

                    SqlParameter courtAdvoCodeParam = command.Parameters.AddWithValue("@courtAdvo", form.courtAdvocacy);
                    if (form.courtAdvocacy < 0 || form.courtAdvocacy > 1)
                    {
                        courtAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter staffingAdvoCodeParam = command.Parameters.AddWithValue("@staffingAdvo", form.staffAdvocacy);
                    if (form.staffAdvocacy < 0 || form.staffAdvocacy > 1)
                    {
                        staffingAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoCodeParam = command.Parameters.AddWithValue("@legalAdvo", form.legalAdvocacy);
                    if (form.legalAdvocacy > 1 || form.legalAdvocacy < 0)
                    {
                        legalAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoTakenCodeParam = command.Parameters.AddWithValue("@legalAdvoTaken", form.legalAdvoTaken);
                    if (form.legalAdvoTaken == null)
                    {
                        legalAdvoTakenCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter accomGainedCodeParam = command.Parameters.AddWithValue("@accomGained", form.accomGained);
                    if (form.accomGained != 1 && form.accomGained != 2 && form.accomGained != 0)
                    {
                        accomGainedCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter compServicesCodeParam = command.Parameters.AddWithValue("@compServices", form.compService);
                    if (form.compService != 1 && form.compService != 0)
                    {
                        compServicesCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter ifWhatServicesCodeParam = command.Parameters.AddWithValue("@ifWhatServices", form.ifWhatServices);
                    if (form.ifWhatServices == null)
                    {
                        ifWhatServicesCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter altSchool = command.Parameters.AddWithValue("@altSchool", form.altSchool);
                    if (form.altSchool != 0 && form.altSchool != 1)
                    {
                        altSchool.Value = DBNull.Value;
                    }
                    SqlParameter y = command.Parameters.AddWithValue("@altSchoolName", form.altSchoolName);
                    if (form.altSchoolName == null)
                    {
                        y.Value = DBNull.Value;
                    }
                    SqlParameter yy = command.Parameters.AddWithValue("@altSchoolDate", form.dateOfAlt);
                    if (form.dateOfAlt == null)
                    {
                        yy.Value = DBNull.Value;
                    }
                    SqlParameter gin = command.Parameters.AddWithValue("@altSchoolTimes", form.timesInAlt);
                    if (form.timesInAlt < 0 || form.timesInAlt > 3)
                    {
                        gin.Value = DBNull.Value;
                    }

                    SqlParameter tok = command.Parameters.AddWithValue("@daysOwed", form.daysOwed);
                    if ((form.daysOwed.ToString()).Length == 0)
                    {
                        tok.Value = DBNull.Value;
                    }
                    SqlParameter daysSinceIntake = command.Parameters.AddWithValue("@daysSinceIntake", form.daysSinceIntake);
                    if ((form.daysSinceIntake.ToString()).Length == 0)
                    {
                        daysSinceIntake.Value = DBNull.Value;
                    }
                    SqlParameter stat = command.Parameters.AddWithValue("@careLast", form.careLastName);
                    if (form.careLastName == null)
                    {
                        stat.Value = DBNull.Value;
                    }
                    SqlParameter dateii = command.Parameters.AddWithValue("@careFirst", form.careFirstName);
                    if (form.careFirstName == null)
                    {
                        dateii.Value = DBNull.Value;
                    }
                    SqlParameter dates = command.Parameters.AddWithValue("@caregender", form.careGender);
                    if (form.careGender != "Mother" && form.careGender != "Father" && form.careGender != "mGrandma" && form.careGender != "mGrandpa" && form.careGender != "Other")
                    {
                        dates.Value = DBNull.Value;
                    }
                    SqlParameter ema = command.Parameters.AddWithValue("@careethnic", form.careEthnicity);
                    if (form.careEthnicity == null)
                    {
                        ema.Value = DBNull.Value;
                    }
                    SqlParameter morei = command.Parameters.AddWithValue("@levelofService", form.levelOfServiceProvided);
                    if (form.levelOfServiceProvided == null)
                    {
                        morei.Value = DBNull.Value;
                    }
                    SqlParameter reas = command.Parameters.AddWithValue("@ccrStatus", form.caseStatus);
                    if (form.caseStatus > 2 || form.caseStatus < 0)
                    {
                        reas.Value = DBNull.Value;
                    }
                    SqlParameter nonEngageReason = command.Parameters.AddWithValue("@nonEngageReason", form.nonEngagementReason);
                    if (form.nonEngagementReason == null)
                    {
                        nonEngageReason.Value = DBNull.Value;
                    }

                    SqlParameter rfn = command.Parameters.AddWithValue("@remedy", form.remedyResolution);
                    if (form.remedyResolution > 1 || form.remedyResolution < 0)
                    {
                        rfn.Value = DBNull.Value;
                    }
                    SqlParameter rln = command.Parameters.AddWithValue("@rearrestRep", form.rearrestWhileRepresented);
                    if (form.rearrestWhileRepresented > 1 || form.rearrestWhileRepresented < 0)
                    {
                        rln.Value = DBNull.Value;
                    }
                    SqlParameter gra = command.Parameters.AddWithValue("@closureSchool", form.schoolAtClosure);
                    if (form.schoolAtClosure == null)
                    {
                        gra.Value = DBNull.Value;
                    }
                    SqlParameter trackingdateCodeParam = command.Parameters.AddWithValue("@trackingdate", form.trackingdate);
                    if (form.trackingdate == null)
                    {
                        trackingdateCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter comptime = command.Parameters.AddWithValue("@compTime", form.compTime);
                    if (form.compTime == null)
                    {
                        comptime.Value = DBNull.Value;
                    }
                    SqlParameter readingLevel = command.Parameters.AddWithValue("@readingLevel", form.readingLevel);
                    if (form.readingLevel == null)
                    {
                        readingLevel.Value = DBNull.Value;
                    }
                    SqlParameter mathLevel = command.Parameters.AddWithValue("@mathLevel", form.mathLevel);
                    if (form.mathLevel == null)
                    {
                        mathLevel.Value = DBNull.Value;
                    }
                    SqlParameter inPride = command.Parameters.AddWithValue("@inPride", form.inPride);
                    if (form.inPride > 1 || form.inPride < 0)
                    {
                        inPride.Value = DBNull.Value;
                    }
                    SqlParameter newFBA = command.Parameters.AddWithValue("@newFBA", form.newFBA);
                    if (form.newFBA < 0 || form.newFBA > 1)
                    {
                        newFBA.Value = DBNull.Value;
                    }
                    SqlParameter gradeFailed = command.Parameters.AddWithValue("@gradeFailed", form.failedGrade);
                    if (form.failedGrade != 0 && form.failedGrade != 1)
                    {
                        gradeFailed.Value = DBNull.Value;
                    }
                    SqlParameter whichGrade = command.Parameters.AddWithValue("@whichGrade", form.whichGradeFailed);
                    if (0 > form.whichGradeFailed || form.whichGradeFailed > 12)
                    {
                        whichGrade.Value = DBNull.Value;
                    }
                    SqlParameter failedRepeat = command.Parameters.AddWithValue("@failedRepeat", form.failCount);
                    if (form.failCount >= 0)
                    { }
                    else
                    {
                        failedRepeat.Value = DBNull.Value;
                    }
                    SqlParameter bakerActed = command.Parameters.AddWithValue("@bakerActed", form.baker);
                    if ((form.baker != 0 && form.baker != 1))
                    {
                        bakerActed.Value = DBNull.Value;
                    }
                    SqlParameter march = command.Parameters.AddWithValue("@marchmanActed", form.marchman);
                    if ((form.marchman != 0 && form.marchman != 1))
                    {
                        march.Value = DBNull.Value;
                    }
                    SqlParameter asthma = command.Parameters.AddWithValue("@asthma", form.asthma);
                    if (form.asthma != 0 && form.asthma != 1)
                    {
                        asthma.Value = DBNull.Value;
                    }

                    SqlParameter femLed = command.Parameters.AddWithValue("@femLed", form.femHouse);
                    if (form.femHouse != 0 && form.femHouse != 1)
                    {
                        femLed.Value = DBNull.Value;
                    }
                    SqlParameter domVio = command.Parameters.AddWithValue("@domVio", form.domVio);
                    if (form.domVio != 0 && form.domVio != 1)
                    {
                        domVio.Value = DBNull.Value;
                    }
                    SqlParameter adopted = command.Parameters.AddWithValue("@adopted", form.adopted);
                    if (form.adopted != 0 && form.adopted != 1)
                    {
                        adopted.Value = DBNull.Value;
                    }
                    SqlParameter evicted = command.Parameters.AddWithValue("@evicted", form.evicted);
                    if (form.evicted != 0 && form.evicted != 1)
                    {
                        evicted.Value = DBNull.Value;
                    }
                    SqlParameter incarParent = command.Parameters.AddWithValue("@incarParent", form.incarParent);
                    if (form.incarParent != 0 && form.incarParent != 1)
                    {
                        incarParent.Value = DBNull.Value;
                    }
                    SqlParameter publicAssistance = command.Parameters.AddWithValue("@publicAssistance", form.publicAssistance);
                    if (form.publicAssistance != 0 && form.publicAssistance != 1)
                    {
                        publicAssistance.Value = DBNull.Value;
                    }
                    SqlParameter suspendedThrice = command.Parameters.AddWithValue("@suspendedThrice", form.suspended);
                    if (form.suspended != 1 && form.suspended != 0)
                    {
                        suspendedThrice.Value = DBNull.Value;
                    }
                    SqlParameter numSuspensions = command.Parameters.AddWithValue("@numSuspensions", form.suspendCount);
                    if (form.suspendCount < 4 || form.suspended > 10)
                    {
                        numSuspensions.Value = DBNull.Value;
                    }
                    SqlParameter totalDaysSuspended = command.Parameters.AddWithValue("@totalDaysSuspended", (form.iss + form.oss));
                    if ((form.iss.ToString().Length == 0) && (form.oss.ToString().Length != 0))
                    { totalDaysSuspended.Value = form.oss; }
                    if ((form.oss.ToString().Length == 0) && (form.iss.ToString().Length != 0))
                    { totalDaysSuspended.Value = form.iss; }
                    if (form.iss.ToString().Length == 0 && (form.iss.ToString().Length == 0))
                    { totalDaysSuspended.Value = DBNull.Value; }
                    SqlParameter ISS = command.Parameters.AddWithValue("@ISS", form.iss);
                    if ((form.oss.ToString().Length == 0))
                    { ISS.Value = DBNull.Value; }
                    SqlParameter OSS = command.Parameters.AddWithValue("@OSS", form.oss);
                    if ((form.oss.ToString().Length == 0))
                    { OSS.Value = DBNull.Value; }
                    SqlParameter IEP = command.Parameters.AddWithValue("@IEP", form.iep);
                    if (form.iep < 0 || form.iep > 1)
                    {
                        IEP.Value = DBNull.Value;
                    }
                    SqlParameter primaryIEP = command.Parameters.AddWithValue("@primaryIEP", form.iepplan1);
                    if (form.iepplan1 == null)
                    {
                        primaryIEP.Value = DBNull.Value;
                    }
                    SqlParameter secondaryIEP = command.Parameters.AddWithValue("@secondaryIEP", form.iepplan2);
                    if (form.iepplan2 == null)
                    {
                        secondaryIEP.Value = DBNull.Value;
                    }
                    SqlParameter legalIssues = command.Parameters.AddWithValue("@legalIssues", form.firstLegal);
                    if (form.firstLegal == null)
                    {
                        legalIssues.Value = DBNull.Value;
                    }
                    SqlParameter leagalIssues2 = command.Parameters.AddWithValue("@leagalIssues2", form.secondLegal);
                    if (form.secondLegal == null)
                    {
                        leagalIssues2.Value = DBNull.Value;
                    }

                    SqlParameter justiceOutcome = command.Parameters.AddWithValue("@juvJusticeOutcome", form.justiceOutcome);
                    if (form.justiceOutcome == null)
                    {
                        justiceOutcome.Value = DBNull.Value;
                    }
                    SqlParameter grade = command.Parameters.AddWithValue("@grade", form.currentGrade);
                    if (form.currentGrade == null)
                    {
                        grade.Value = DBNull.Value;
                    }
                    SqlParameter school = command.Parameters.AddWithValue("@school", form.school);
                    if (form.school == null)
                    {
                        school.Value = DBNull.Value;
                    }
                    SqlParameter schoolRef = command.Parameters.AddWithValue("@schoolRef", form.schoolRef);
                    if (form.schoolRef == null)
                    {
                        schoolRef.Value = DBNull.Value;
                    }
                    SqlParameter referrerEmailinfo = command.Parameters.AddWithValue("@refEmail", form.emailOfFirstReferralSource);
                    if (form.emailOfFirstReferralSource == null)
                    {
                        referrerEmailinfo.Value = DBNull.Value;
                    }
                    SqlParameter referrerEmail = command.Parameters.AddWithValue("@email", form.emailOfFirstReferralSource);
                    if (form.emailOfFirstReferralSource == null)
                    {
                        referrerEmail.Value = DBNull.Value;
                    }
                    SqlParameter referrerNamefirstrefform = command.Parameters.AddWithValue("@referralfname", form.referralSource);
                    if (form.referralSource == null)
                    {
                        referrerNamefirstrefform.Value = DBNull.Value;
                    }
                    SqlParameter referrerNamefirstt = command.Parameters.AddWithValue("@reFName", form.referralSource);
                    if (form.referralSource == null)
                    {
                        referrerNamefirstt.Value = DBNull.Value;
                    }
                    SqlParameter referrerNamelastrefform = command.Parameters.AddWithValue("@referrallname", form.referrallSource);
                    if (form.referrallSource == null)
                    {
                        referrerNamelastrefform.Value = DBNull.Value;
                    }
                    SqlParameter referrerNamelastt = command.Parameters.AddWithValue("@reLName", form.referrallSource);
                    if (form.referrallSource == null)
                    {
                        referrerNamelastt.Value = DBNull.Value;
                    }
                   
                    SqlParameter referralDate = command.Parameters.AddWithValue("@dateInput", form.referralDate);
                    if (form.referralDate == null)
                    {
                        referralDate.Value = DBNull.Value;
                    }
                        SqlParameter referralDate1 = command.Parameters.AddWithValue("@refDate", form.referralDate);
                        if (form.referralDate == null)
                        {
                            referralDate1.Value = DBNull.Value;
                        }
                        SqlParameter fNameCodeParam = command.Parameters.AddWithValue("@fName", form.clientFirstName);
                    if (form.clientFirstName == null)
                    {
                        fNameCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter lNameCodeParam = command.Parameters.AddWithValue("@lName", form.clientLastName);
                    if (form.clientLastName == null)
                    {
                        lNameCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter dOBCodeParam = command.Parameters.AddWithValue("@birthday", form.clientDOB);
                    if (form.clientDOB == null)
                    {
                        dOBCodeParam.Value = DBNull.Value;
                    }
                

                    connection.Open();
                    command.ExecuteNonQuery();
                    cnn.Dispose();

                    connection.Close();

                }
                //int message = form.ClientID;
                //return RedirectToAction("detailReferralM?clientCode="+ message +"", "n");
               return RedirectToAction("TrackingList", "Tracking");
            }
           
        }
        public IActionResult confirmationM()
        {
            //confirmation thank you page for submiting and give email
            return View();

        }
        [HttpPost]
        public IActionResult Emailreferral( string emailaddress)
        {
          //  Main(emailaddress);
            //confirmation thank you page for submiting and give email submit referral
            Execute(emailaddress).Wait();

            return RedirectToAction("Index", "Home");

        }

        static async Task Execute(string emailaddress)
        {
            //    Execute().Wait();
            //}
           

            //static async Task Execute()
            //{
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("n01057930@unf.edu", "The Center for Children's Rights");
            var subject = "Ex. The Center for Children's Rights Referral Confirmation";
            var to = new EmailAddress(emailaddress, "Referral Source");
            var plainTextContent = "Waiting for the template form from betsy on what is wanted in this section";
            var htmlContent = "<strong>Waiting for the template form from betsy on what is wanted in this section</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
