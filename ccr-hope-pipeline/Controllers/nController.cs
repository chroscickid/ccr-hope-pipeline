using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Referrals;
using HopePipeline.Models.DbEntities.Tracking;

namespace HopePipeline.Controllers
{
    public class nController : Controller
    {
        public IActionResult formReferralM()
        {
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

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
            {
                i = Convert.ToInt32(value);
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
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "INSERT INTO dbo.refform VALUES ('" + form.fName + "', '" + form.lName + "', '" + form.dOB + "', '" + form.clientCode + "', '" + form.guardianName + "', '" + form.guardianRelationship + "', '" + form.address + "', '" + form.gender + "', '" + form.guardianEmail + "', '" + form.guardianPhone + "', '" + form.meeting + "', '" + form.youthInDuvalSchool + "', '" + form.youthInSchool + "', '" + form.issues + "', '" + form.currentSchool + "', '" + form.zip + "', '" + form.grade + "', 'Open', '" + form.arrest + "', '" + form.school + "', '" + form.dateInput + "', '" + form.date + "', '" + form.email + "', '" + form.Reach + "', '" + form.moreInfo + "', '" + form.reason + "', '" + form.referralfname + "', '" + form.referrallname + "')";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            //COnnect to the DB



            return RedirectToAction("Index", "Home");

        }

        public IActionResult contactInfoM(int clientCode)
        {
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

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
                    clientl.Add(client);

                }
            }

            cnn.Close();
            return View(clientl);

        }

        public IActionResult detailReferralM(int clientCode)
        {
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            //var client= new Contact();
            List<referralDetail> clientl = new List<referralDetail>();
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

                    referralDetail client = new referralDetail();
                    client.clientCode = Convert.ToInt32(dataReader["clientCode"]);

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


                    client.school = Convert.ToString(dataReader["school"]);
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

                    clientl.Add(client);

                }
            }

            cnn.Close();
            return View(clientl);

        }



        [HttpPost]///////////////////////////////////////////////////////////edit=========================================================================
        public IActionResult editReferralForm(referralBrandi form)
        {


            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                if (form.school == null)
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
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                    { client.dateInput = DateTime.Parse("01/01/1970"); }
                    else
                    {
                        client.dateInput = Convert.ToDateTime(dataReader["dateInput"]);
                    };//fix ints}


                    if (Convert.IsDBNull(dataReader["meetingDate"]))
                    { client.date = DateTime.Parse("01/01/1970"); }
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
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            List<trackingDetail> clientl = new List<trackingDetail>();
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
"dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.nonEngageReason, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, " +
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
"dbo.refform.email, dbo.refform.referralfname, dbo.refform.referrallname, dbo.refform.dateInput" +
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
"LEFT JOIN dbo.refform on dbo.accomodations.clientCode = dbo.refform.clientCode)" +
"WHERE dbo.accomodations.clientCode =" + clientCode + ";";
            command = new SqlCommand(query, cnn);

            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    trackingDetail client = new trackingDetail();
                    client.ClientID = Convert.ToInt32(dataReader["clientCode"]);

                    client.clientFirstName = Convert.ToString(dataReader["clientFirst"]);
                    if (client.clientFirstName == " " || client.clientFirstName == "null" || client.clientFirstName == "")
                    { client.clientFirstName = "N/A"; }//Done

                    client.clientLastName = Convert.ToString(dataReader["clientLast"]);
                    if (client.clientLastName == " " || client.clientLastName == "null" || client.clientLastName == "")
                    { client.clientLastName = "N/A"; }//Done

                    client.careGender = Convert.ToString(dataReader["caregender"]);
                    if (client.careGender == "Mother")
                    { client.careGender = "Mother"; }
                    if (client.careGender == "Father")
                    { client.careGender = "Father"; }
                    if (client.careGender == "mGrandma")
                    { client.careGender = "Grandma"; }
                    if (client.careGender == "mGrandpa")
                    { client.careGender = "Grandpa"; }
                    if (client.careGender == "Other")
                    { client.careGender = "Other"; }
                    if (String.IsNullOrEmpty(Convert.ToString(dataReader["caregender"])))
                    { client.careGender = "N/A"; }
                    else
                    { client.careGender = client.careGender; }


                    if (Convert.IsDBNull(dataReader["clientgender"]))
                    { client.clientGender = "N/A"; }
                    if (!Convert.IsDBNull(dataReader["clientgender"]))
                    { client.clientGender = Convert.ToString(dataReader["clientgender"]); }
                    if (client.clientGender == "male")
                    { client.clientGender = "He/Him/His"; }
                    if (client.clientGender == "female")
                    { client.clientGender = "She/Her/Hers"; }
                    if (client.clientGender == "trans*")
                    { client.clientGender = "They/them/Theirs"; }
                    if (client.clientGender == "nonbinaryF")
                    { client.clientGender = "She/They"; }
                    if (client.clientGender == "nonbinaryM")
                    { client.clientGender = "He/They"; }
                    if (client.clientGender == "neutral")
                    { client.clientGender = "Zie/Zir/Zirs"; }
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
                    if (client.clientEthnicity == "")
                    { client.clientEthnicity = "N/A"; }
                    else
                    { client.clientEthnicity = client.clientEthnicity; }


                    client.clientDOB = Convert.ToString(dataReader["clientdob"]);
                    if (client.clientDOB == " " || client.clientDOB == "null" || client.clientDOB == "")
                    { client.clientDOB = "N/A"; }

                    client.school = Convert.ToString(dataReader["school"]);
                    if (client.school == " " || client.school == "null" || client.school == "")
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
                    if (client.currentGrade == "")
                    { client.currentGrade = "N/A"; }
                    else { client.currentGrade = client.currentGrade; }



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
                    if (client.whichGradeFailed == "")
                    { client.whichGradeFailed = "N/A"; }
                    else
                    { client.whichGradeFailed = client.whichGradeFailed; }

                    client.failCount = Convert.ToString(dataReader["failedRepeat"]);
                    if (client.failCount == "")
                    { client.failCount = "N/A"; }

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
                    client.marchman = Convert.ToString(dataReader["marchmanActed"]);
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
                    if (client.asthma == "1")
                    { client.asthma = "Yes"; }
                    if (client.asthma == "0")
                    { client.asthma = "No"; }
                    if (client.asthma == "")
                    { client.asthma = "N/A"; }
                    else
                    { client.asthma = client.asthma; }
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
                    var adopt = Int32.TryParse(client.adopted, out int adop);
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


                    //accomodations---------------------------------CCR---------------------------------------------------------------

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

                    client.referralDate = Convert.ToString(dataReader["dateInput"]);

                    //Reason for Nonengagement needs to be added
                    client.nonEngagementReason = Convert.ToString(dataReader["nonEngageReason"]);
                    if (client.nonEngagementReason == "n")
                    { client.nonEngagementReason = "Unable to Contact"; }
                    if (client.nonEngagementReason == "info")
                    { client.nonEngagementReason = "Unable to Complete Intake"; }
                    if (client.nonEngagementReason == "service")
                    { client.nonEngagementReason = "Family Declined Services"; }
                    if (client.nonEngagementReason == "")
                    { client.nonEngagementReason = "N/A"; }
                    else
                    { client.nonEngagementReason = client.nonEngagementReason; }

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

                    client.remedyResolution = Convert.ToString(dataReader["remedy"]);
                    var remre = Int32.TryParse(client.remedyResolution, out int rereed);
                    if (client.remedyResolution.Contains("1"))
                    { client.remedyResolution = "Yes"; }
                    if (client.remedyResolution.Contains("0"))
                    { client.remedyResolution = "No"; }
                    if (client.remedyResolution == "")
                    { client.remedyResolution = "N/A"; }
                    else
                    { client.remedyResolution = client.remedyResolution; }

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

                    //is the first referral for the client

                    client.emailOfFirstReferralSource = Convert.ToString(dataReader["email"]);
                    if (client.emailOfFirstReferralSource == "")
                    { client.emailOfFirstReferralSource = "N/A"; }

                    client.referralSource = Convert.ToString(dataReader["referralfname"]) + " " + Convert.ToString(dataReader["referrallname"]);
                    if (client.referralSource == "")
                    { client.referralSource = "N/A"; }

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

                    client.courtAdvocacy = Convert.ToString(dataReader["courtAdvo"]);
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

                    //-------------------------------------------------------School Info----------------------------------------------
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
                    if (client.iepplan1 == "otherHealth") { client.iepplan1 = "Other Health Impairment"; }
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

                    client.schoolRef = Convert.ToString(dataReader["schoolRef"]);
                    if (client.schoolRef == "")
                    { client.schoolRef = "N/A"; }

                    client.readingLevel = Convert.ToString(dataReader["readingLevel"]);
                    if (client.readingLevel == "K")
                    { client.readingLevel = "Kindergarten"; }
                    if (client.readingLevel == "")
                    { client.readingLevel = "N/A"; }

                    client.mathLevel = Convert.ToString(dataReader["mathLevel"]);
                    if (client.readingLevel == "K")
                    { client.readingLevel = "Kindergarten"; }
                    if (client.mathLevel == "")
                    { client.mathLevel = "N/A"; }

                    client.inPride = Convert.ToString(dataReader["inPride"]);
                    if (client.inPride == "1")
                    { client.inPride = "Yes"; }
                    if (client.inPride == "0")
                    { client.inPride = "No"; }
                    if (client.inPride == "")
                    { client.inPride = "N/A"; }
                    else
                    { client.inPride = client.inPride; }
                    //int
                    client.newFBA = Convert.ToString(dataReader["newFBA"]);
                    if (client.newFBA == "1")
                    { client.newFBA = "Yes"; }
                    if (client.newFBA == "0")
                    { client.newFBA = "No"; }
                    if (client.newFBA == "")
                    { client.newFBA = "N/A"; }
                    else
                    { client.newFBA = client.newFBA; }

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

                    client.compTime = Convert.ToString(dataReader["compTime"]);
                    if (client.compTime == "")
                    { client.compTime = "N/A"; }

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
                    client.dateofBully = Convert.ToString(dataReader["reportDate"]);

                    //----------------------------------------------------------------------------Discipline-------------------------------
                    client.suspended = Convert.ToString(dataReader["suspendedThrice"]);
                    var thrise = Int32.TryParse(client.suspended, out int thris);
                    if (client.suspended == "1")
                    { client.suspended = "Yes"; }
                    if (client.suspended == "0")
                    { client.suspended = "No"; }
                    if (client.suspended == "")
                    { client.suspended = "N/A"; }
                    else
                    { client.suspended = client.suspended; }

                    client.suspendCount = Convert.ToString(dataReader["numSuspensions"]);
                    if (client.suspendCount == "")
                    { client.suspendCount = "N/A"; }

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
                    if (client.secondLegal == "")
                    { client.secondLegal = "N/A"; }



                    client.iss = Convert.ToString(dataReader["ISS"]);
                    if (client.iss == "")
                    { client.iss = "N/A"; }
                    client.totaldaysdisicpline = Convert.ToString(dataReader["totalDaysSuspended"]);
                    client.oss = Convert.ToString(dataReader["OSS"]);
                    if (client.oss == "")
                    { client.oss = "N/A"; }

                    client.daysSinceIntake = Convert.ToString(dataReader["daysSinceIntake"]);
                    if (client.daysSinceIntake == "")
                    { client.daysSinceIntake = "N/A"; }

                    client.justiceOutcome = Convert.ToString(dataReader["juvJusticeOutcome"]);
                    if (client.justiceOutcome == "")
                    { client.justiceOutcome = "N/A"; }

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


                    client.careLastName = Convert.ToString(dataReader["careLast"]);
                    if (client.careLastName == "")
                    { client.careLastName = "N/A"; }

                    client.careFirstName = Convert.ToString(dataReader["careFirst"]);
                    if (client.careFirstName == "" || client.careFirstName == "null" || String.IsNullOrEmpty(client.careFirstName))
                    { client.careFirstName = "N/A"; }

                    client.carePhone = Convert.ToString(dataReader["phoneNumber"]);

                    if (client.carePhone == "" || client.carePhone == "null" || String.IsNullOrEmpty(client.carePhone))
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
                    if (client.careEthnicity.Equals("null"))
                    { client.careEthnicity = "N/A"; }

                    clientl.Add(client);

                }
            }

            cnn.Close();
            return View(clientl);


        }
        public IActionResult EditTrackingM(int clientCode)

        //edit tracking information in a form format
        {//this method will display the values from the sql code
         //get the values from specific sql
         //display
            string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            "dbo.ccr.levelofService, dbo.ccr.ccrStatus, dbo.ccr.nonEngageReason, dbo.ccr.remedy, dbo.ccr.rearrestRep, dbo.ccr.closureSchool, " +
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
            "dbo.refform.email, dbo.refform.referralfname, dbo.refform.referrallname, dbo.refform.dateInput" +
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
            "LEFT JOIN dbo.refform on dbo.accomodations.clientCode = dbo.refform.clientCode)" +
            "WHERE dbo.accomodations.clientCode =" + clientCode + ";";
            command = new SqlCommand(query, cnn);


            //SqlDataReader reader = command.ExecuteReader();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    TrackingForm client = new TrackingForm();
                    client.ClientID = Convert.ToInt32(dataReader["clientCode"]);
                    client.clientFirstName = Convert.ToString(dataReader["clientFirst"]);
                    client.clientLastName = Convert.ToString(dataReader["clientLast"]);
                    client.careGender = Convert.ToString(dataReader["caregender"]);
                    client.clientGender = Convert.ToString(dataReader["clientgender"]);
                    client.clientEthnicity = Convert.ToString(dataReader["clientethn"]);
                    client.clientDOB = Convert.ToString(dataReader["clientdob"]);
                    client.school = Convert.ToString(dataReader["school"]);
                    client.currentGrade = Convert.ToInt32(dataReader["grade"]);
                    client.referralSource = Convert.ToString(dataReader["referralfname"]) + " " + Convert.ToString(dataReader["referrallname"]);
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

                    client.referralDate = Convert.ToString(dataReader["dateInput"]);//----------------------------Date-----------------------------------

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

                    //is the first referral for the client

                    client.emailOfFirstReferralSource = Convert.ToString(dataReader["email"]);



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
                    client.dateofBully = Convert.ToString(dataReader["reportDate"]);

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

                    client.dateOfAlt = Convert.ToString(dataReader["altSchoolDate"]);//date-------------------------------------------------------------DODODODO_________DATE_


                    if (Convert.IsDBNull(dataReader["altSchoolTimes"]))
                    { client.timesInAlt = 33; }
                    else { client.timesInAlt = Convert.ToInt16(dataReader["altSchoolTimes"]); }


                    if (Convert.IsDBNull(dataReader["daysOwed"]))
                    { client.daysOwed = 33; }
                    else { client.daysOwed = Convert.ToInt16(dataReader["daysOwed"]); }

                    client.firstLegal = Convert.ToString(dataReader["legalIssues"]);

                    client.secondLegal = Convert.ToString(dataReader["leagalIssues2"]);


                    if (Convert.IsDBNull(dataReader["ISS"]))
                    { client.iss = 33; }
                    else { client.iss = Convert.ToInt16(dataReader["ISS"]); }

                    if (Convert.IsDBNull(dataReader["OSS"]))
                    { client.oss = 33; }
                    else { client.oss = Convert.ToInt16(dataReader["OSS"]); }


                    if (Convert.IsDBNull(dataReader["daysSinceIntake"]))
                    { client.daysSinceIntake = 33; }
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

            cnn.Close();

            return View();

        }
        [HttpPost]
        public IActionResult editTrackingForm(TrackingForm info)
        {
            //update total sum, nonengagment, referral source, intake date delete, referral email, delete referral1, delete first referral, 
            {
                string connectionString = "Data Source=hope-sqlserver.database.windows.net;Initial Catalog=hope-database;User ID=dadmin;Password=Hope2020!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);



                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandText = "UPDATE dbo.advocacy" +
                        "SET dbo.advocacy.rearrestAdvo = @rearrestAdvo, dbo.advocacy.courtAdvo = @courtAdvo, dbo.advocacy.staffingAdvo = @staffingAdvo, dbo.advocacy.legalAdvo = @legalAdvo, dbo.advocacy.legalAdvoTaken = @legalAdvoTaken " +
                        "WHERE dbo.advocacy.clientCode = @clientCode;" +

                        "UPDATE dbo.accomodations" +
                        "SET  dbo.accomodations.accomGained = @accomGained, dbo.accomodations.compServices = @compServices , dbo.accomodations.ifWhatServices = @ifWhatServices " +
                        "WHERE dbo.accomodations.clientCode = @clientCode;" +

                        "UPDATE dbo.altSchool" +
                        "SET dbo.altSchool.altSchool = @altSchool, dbo.altSchool.altSchoolName = @altSchoolName, dbo.altSchool.altSchoolDate = @altSchoolDate, dbo.altSchool.altSchoolTimes = @altSchoolTimes, dbo.altSchool.daysOwed = @daysOwed, dbo.altSchool.daysSinceIntake = @daysSinceIntake" +
                        "WHERE dbo.altSchool.clientCode = @clientCode;" +

                          "UPDATE dbo.bully" +
                        "SET dbo.bully.bullied = @bullied, dbo.bully.reported = @reported, dbo.bully.reportDate = @reportDate " +
                        "WHERE dbo.bully.clientCode = @clientCode;" +

                        "UPDATE dbo.caregiver" +
                        "SET dbo.caregiver.careLast = @careLast, dbo.caregiver.careFirst = @careFirst, dbo.caregiver.genderIdentity as caregender = @caregender, dbo.caregiver.ethnicity as careethnic = @careethnic, dbo.caregiver.relationship = @relationship " +
                        "WHERE dbo.caregiver.clientCode= @clientCode;" +

                        "UPDATE dbo.ccr" +
                        "SET dbo.ccr.levelofService = @levelofService, dbo.ccr.ccrStatus = @ccrStatus, dbo.ccr.nonEngageReason = @nonEngageReason, dbo.ccr.remedy = @remedy, dbo.ccr.rearrestRep = @rearrestRep, dbo.ccr.closureSchool = @closureSchool " +
                        "WHERE dbo.ccr.clientCode = @clientCode;" +

                        "UPDATE dbo.client" +
                        "SET dbo.client.clientLast = @clientLast, dbo.client.clientFirst = @clientFirst, dbo.client.dependency = @dependency, dbo.client.genderIdentity as clientgender = @clientgender, dbo.client.ethnicity as clientethn = @clientethn, dbo.client.dob = @dob, dbo.client.phoneNumber = @phoneNumber" +
                        "WHERE dbo.client.clientCode= @clientCode;" +
                        "UPDATE dbo.comp" +
                        "SET dbo.comp.compTime = @compTime " +
                        "WHERE dbo.comp.clientCode = @clientCode;" +

                        "UPDATE dbo.currentStatus" +
                        "SET dbo.currentStatus.readingLevel = @readingLevel, dbo.currentStatus.mathLevel = @mathLevel, dbo.currentStatus.currentServices = @currentServices, dbo.currentStatus.inPride = @inPride, dbo.currentStatus.newFBA = @newFBA, dbo.currentStatus.addService = @addService, dbo.currentStatus.servicesGained = @servicesGained " +
                        "WHERE dbo.currentStatus.clientCode=  @clientCode; " +
                        "UPDATE dbo.failed" +
                        "SET dbo.failed.gradeFailed = @gradeFailed, dbo.failed.whichGrade = @whichGrade, dbo.failed.failedRepeat = @failedRepeat " +
                        "WHERE dbo.failed.clientCode = @clientCode;" +
                        "UPDATE dbo.health" +
                        "SET dbo.health.bakerActed = @bakerActed, dbo.health.marchmanActed = @marchmanActed, dbo.health.asthma = @asthma " +
                        "WHERE dbo.health.clientCode = @clientCode;" +

                        "UPDATE dbo.household" +
                        "SET dbo.household.femLed = @femLed, dbo.household.domVio = @domVio, dbo.household.adopted = @adopted, dbo.household.evicted = @evicted, dbo.household.incarParent = @incarParent, dbo.household.publicAssistance = @publicAssistance " +
                        "WHERE dbo.household.clientCode = @clientCode;" +

                        //"UPDATE dbo.referral" +
                        //"SET dbo.referral.referralDate = @referralDate, dbo.referral.intakeDate = @intakeDate, dbo.referral.referral1 = @referral1, dbo.referral.referral2 = @referral2, dbo.referral.referral3 = @referral3, dbo.referral.referrerName = @referrerName, dbo.referral.referrerEmail = @referrerEmail " +
                        //"WHERE dbo.referral.clientCode= @clientCode;" +

                        "UPDATE dbo.suspension" +
                        "SET dbo.suspension.suspendedThrice = @suspendedThrice, dbo.suspension.numSuspensions = @numSuspensions, dbo.suspension.totalDaysSuspended = @totalDaysSuspended, dbo.suspension.ISS = @ISS, dbo.suspension.OSS = @OSS, dbo.suspension.daysofDiscipline = @daysofDiscipline, dbo.suspension.disciplineSinceIntake = @disciplineSinceIntake " +
                        "WHERE dbo.suspension.clientCode = @clientCode;" +

                        "UPDATE dbo.iep" +
                        "SET dbo.iep.IEP = @IEP, dbo.iep.primaryIEP = @primaryIEP, dbo.iep.secondaryIEP = @secondaryIEP, dbo.iep.addIEp = @addIEp" +
                        "WHERE dbo.iep.clientCode =@clientCode;" +

                         "UPDATE dbo.legal" +
                        "SET dbo.legal.legalIssues = @legalIssues, dbo.legal.leagalIssues2 = @leagalIssues2, dbo.legal.juvJusticeOutcome" +
                        "WHERE dbo.legal.clientCode = @clientCode;" +

                        "UPDATE dbo.school" +
                        "SET dbo.school.grade = @grade, dbo.school.school = @school, dbo.school.SchoolRef = @SchoolRef" +
                        "WHERE dbo.school.clientCode = @clientCode;" +

                    "UPDATE dbo.refform" +
                    "SET dbo.refform.email = @email, dbo.refform.referralfname = @referralfname, dbo.refform.referrallname = @referrallname, dbo.refform.dateInput = @dateInput" +
                     "WHERE dbo.refform.clientCode = @clientCode;";

                    command.Parameters.AddWithValue("@clientCode", info.ClientID);
                    //----------------------------------------------Demographics--------------------------------

                    SqlParameter reasa = command.Parameters.AddWithValue("@clientFirst", info.clientFirstName);
                    if (info.clientFirstName == null)
                    {
                        reasa.Value = DBNull.Value;
                    }
                    SqlParameter morea = command.Parameters.AddWithValue("@clientLast", info.clientLastName);
                    if (info.clientLastName == null)
                    {
                        morea.Value = DBNull.Value;
                    }
                    SqlParameter dates = command.Parameters.AddWithValue("@caregender", info.careGender);
                    if (info.careGender != "Mother" || info.careGender != "Father" || info.careGender != "mGrandma" || info.careGender != "mGrandpa" || info.careGender != "Other")
                    {
                        dates.Value = DBNull.Value;
                    }
                    SqlParameter rlna = command.Parameters.AddWithValue("@clientgender", info.clientGender);
                    if (info.clientGender != "male" || info.clientGender != "female" || info.clientGender != "trans" || info.clientGender != "nonbinaryF" || info.clientGender != "nonbinaryM" || info.clientGender != "neutral")
                    {
                        rlna.Value = DBNull.Value;
                    }
                    SqlParameter graw = command.Parameters.AddWithValue("@clientethn", info.clientEthnicity);
                    if (info.clientEthnicity != "nhWhite" || info.clientEthnicity != "hispanic" || info.clientEthnicity != "natAm" || info.clientEthnicity != "jewish" || info.clientEthnicity != "black" || info.clientEthnicity != "multi" || info.clientEthnicity != "notListed")
                    {
                        graw.Value = DBNull.Value;
                    }
                    SqlParameter rfnas = command.Parameters.AddWithValue("@dob", info.clientDOB);/////////////////////-Date
                    if (info.clientDOB == null)
                    {
                        rfnas.Value = DBNull.Value;
                    }
                    SqlParameter school = command.Parameters.AddWithValue("@school", info.school);
                    if (info.school == null)
                    {
                        school.Value = DBNull.Value;
                    }
                    SqlParameter grade = command.Parameters.AddWithValue("@grade", info.currentGrade);
                    if (info.currentGrade == null)
                    {
                        grade.Value = DBNull.Value;
                    }
                    var referralnamefix = info.referralSource;
                    string[] stage1fix = referralnamefix.Split(" ");

                    SqlParameter referralfname = command.Parameters.AddWithValue("@referralfname", stage1fix[0]);
                    SqlParameter referrallname = command.Parameters.AddWithValue("@referrallname", stage1fix[1]);
                    if (info.referralSource == null)
                    {
                        referralfname.Value = DBNull.Value;
                        referrallname.Value = DBNull.Value;
                    }
                    SqlParameter gradeFailed = command.Parameters.AddWithValue("@gradeFailed", info.failedGrade);
                    if (info.failedGrade != 0 || info.failedGrade != 1)
                    {
                        gradeFailed.Value = DBNull.Value;
                    }
                    SqlParameter whichGrade = command.Parameters.AddWithValue("@whichGrade", info.whichGradeFailed);
                    if (0 > info.whichGradeFailed || info.whichGradeFailed > 12)
                    {
                        whichGrade.Value = DBNull.Value;
                    }
                    SqlParameter failedRepeat = command.Parameters.AddWithValue("@failedRepeat", info.failCount);
                    if (info.failCount >= 0)
                    { }
                    else
                    {
                        failedRepeat.Value = DBNull.Value;
                    }
                    SqlParameter bakerActed = command.Parameters.AddWithValue("@bakerActed", info.baker);
                    if ((info.baker != 0 || info.baker != 1))
                    {
                        bakerActed.Value = DBNull.Value;
                    }
                    SqlParameter march = command.Parameters.AddWithValue("@marchmanActed", info.marchman);
                    if ((info.marchman != 0 || info.marchman != 1))
                    {
                        march.Value = DBNull.Value;
                    }
                    SqlParameter domVio = command.Parameters.AddWithValue("@domVio", info.domVio);
                    if (info.domVio != 0 || info.domVio != 1)
                    {
                        domVio.Value = DBNull.Value;
                    }
                    //more
                    SqlParameter femLed = command.Parameters.AddWithValue("@femLed", info.femHouse);
                    if (info.femHouse != 0 || info.femHouse != 1)
                    {
                        femLed.Value = DBNull.Value;
                    }
                    SqlParameter adopted = command.Parameters.AddWithValue("@adopted", info.adopted);
                    if (info.adopted != 0 || info.adopted != 1)
                    {
                        adopted.Value = DBNull.Value;
                    }
                    SqlParameter evicted = command.Parameters.AddWithValue("@evicted", info.evicted);
                    if (info.evicted != 0 || info.evicted != 1)
                    {
                        bakerActed.Value = DBNull.Value;
                    }
                    SqlParameter incarParent = command.Parameters.AddWithValue("@incarParent", info.incarParent);
                    if (info.incarParent != 0 || info.incarParent != 1)
                    {
                        incarParent.Value = DBNull.Value;
                    }
                    SqlParameter asthma = command.Parameters.AddWithValue("@asthma", info.asthma);
                    if (info.asthma != 0 || info.asthma != 1)
                    {
                        asthma.Value = DBNull.Value;
                    }
                    //-----------------------CCR----------------------------------------------

                    SqlParameter accomGainedCodeParam = command.Parameters.AddWithValue("@accomGained", info.accomGained);
                    if (info.accomGained != 1 && info.accomGained != 2 && info.accomGained != 0)
                    {
                        accomGainedCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter compServicesCodeParam = command.Parameters.AddWithValue("@compServices", info.compService);
                    if (info.compService != 1 && info.compService != 2 && info.compService != 0)
                    {
                        compServicesCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter ifWhatServicesCodeParam = command.Parameters.AddWithValue("@ifWhatServices", info.ifWhatServices);
                    if (info.ifWhatServices == null)
                    {
                        ifWhatServicesCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter rearrestAdvoCodeParam = command.Parameters.AddWithValue("@rearrestAdvo", info.rearrestAdvocacy);
                    if (info.rearrestAdvocacy != 1 && info.rearrestAdvocacy != 2 && info.rearrestAdvocacy != 0)
                    {
                        rearrestAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter courtAdvoCodeParam = command.Parameters.AddWithValue("@courtAdvo p", info.courtAdvocacy);
                    if (info.courtAdvocacy == null)
                    {
                        courtAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter staffingAdvoCodeParam = command.Parameters.AddWithValue("@staffingAdvo", info.staffAdvocacy);
                    if (info.staffAdvocacy == null)
                    {
                        staffingAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoCodeParam = command.Parameters.AddWithValue("@legalAdvo", info.legalAdvocacy);
                    if (info.legalAdvocacy == null)
                    {
                        legalAdvoCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter legalAdvoTakenCodeParam = command.Parameters.AddWithValue("@legalAdvoTaken", info.legalAdvoTaken);
                    if (info.legalAdvoTaken == null)
                    {
                        legalAdvoTakenCodeParam.Value = DBNull.Value;
                    }
                    SqlParameter altSchool = command.Parameters.AddWithValue("@altSchool", info.altSchool);
                    if (info.altSchool == null)
                    {
                        altSchool.Value = DBNull.Value;
                    }
                    SqlParameter y = command.Parameters.AddWithValue("@altSchoolName", info.altSchoolName);
                    if (info.altSchoolName == null)
                    {
                        y.Value = DBNull.Value;
                    }
                    SqlParameter yy = command.Parameters.AddWithValue("@altSchoolDate", info.dateOfAlt);
                    if (info.dateOfAlt == null)
                    {
                        yy.Value = DBNull.Value;
                    }
                    SqlParameter gin = command.Parameters.AddWithValue("@altSchoolTimes", info.timesInAlt);
                    if (info.timesInAlt == null)
                    {
                        gin.Value = DBNull.Value;
                    }
                    SqlParameter tok = command.Parameters.AddWithValue("@daysOwed", info.daysOwed);
                    if (info.daysOwed != 0 && info.daysOwed != 1 && info.daysOwed != 2)
                    {
                        tok.Value = DBNull.Value;
                    }
                    SqlParameter issu = command.Parameters.AddWithValue("@bullied", info.bullied);
                    if (info.bullied == null)
                    {
                        issu.Value = DBNull.Value;
                    }
                    SqlParameter arr = command.Parameters.AddWithValue("@reported", info.bullyReport);
                    if (info.bullyReport != 0 && info.bullyReport != 1 && info.bullyReport != 2)
                    {
                        arr.Value = DBNull.Value;
                    }
                    SqlParameter sc = command.Parameters.AddWithValue("@reportDate", info.dateofBully);
                    if (info.dateofBully == null)
                    {
                        sc.Value = DBNull.Value;
                    }
                    SqlParameter stat = command.Parameters.AddWithValue("@careLast", info.careLastName);
                    if (info.careLastName == null)
                    {
                        stat.Value = DBNull.Value;
                    }
                    SqlParameter dateii = command.Parameters.AddWithValue("@careFirst", info.careFirstName);
                    if (info.careFirstName == null)
                    {
                        dateii.Value = DBNull.Value;
                    }

                    SqlParameter ema = command.Parameters.AddWithValue("@careethnic", info.careEthnicity);
                    if (info.careEthnicity == null)
                    {
                        ema.Value = DBNull.Value;
                    }

                    SqlParameter morei = command.Parameters.AddWithValue("@levelofService", info.levelOfServiceProvided);
                    if (info.levelOfServiceProvided == null)
                    {
                        morei.Value = DBNull.Value;
                    }
                    SqlParameter reas = command.Parameters.AddWithValue("@ccrStatus", info.caseStatus);
                    if (info.caseStatus == null)
                    {
                        reas.Value = DBNull.Value;
                    }
                    SqlParameter rfn = command.Parameters.AddWithValue("@remedy", info.remedyResolution);
                    if (info.remedyResolution == null)
                    {
                        rfn.Value = DBNull.Value;
                    }
                    SqlParameter rln = command.Parameters.AddWithValue("@rearrestRep", info.rearrestWhileRepresented);
                    if (info.rearrestWhileRepresented == null)
                    {
                        rln.Value = DBNull.Value;
                    }
                    SqlParameter gra = command.Parameters.AddWithValue("@closureSchool", info.schoolAtClosure);
                    if (info.schoolAtClosure == null)
                    {
                        gra.Value = DBNull.Value;
                    }


                    SqlParameter rlnt = command.Parameters.AddWithValue("@phoneNumber", info.carePhone);
                    if (info.carePhone == null)
                    {
                        rlnt.Value = DBNull.Value;
                    }
                    SqlParameter rfnacomps = command.Parameters.AddWithValue("@compServices", info.compService);
                    if (info.compService == null)
                    {
                        rfnacomps.Value = DBNull.Value;
                    }
                    //SqlParameter rlntcomp = command.Parameters.AddWithValue("@compTime", info.comptime);
                    //if (info.carePhone == null)
                    //{
                    //  rlntcomp.Value = DBNull.Value;
                    //}
                    SqlParameter readingLevel = command.Parameters.AddWithValue("@readingLevel", info.readingLevel);
                    if (info.readingLevel == null)
                    {
                        readingLevel.Value = DBNull.Value;
                    }
                    SqlParameter mathLevel = command.Parameters.AddWithValue("@mathLevel", info.mathLevel);
                    if (info.mathLevel == null)
                    {
                        mathLevel.Value = DBNull.Value;
                    }
                    SqlParameter currentServices = command.Parameters.AddWithValue("@currentServices", info.ifWhatServices);
                    if (info.ifWhatServices == null)
                    {
                        currentServices.Value = DBNull.Value;
                    }
                    SqlParameter inPride = command.Parameters.AddWithValue("@inPride", info.inPride);
                    if (info.inPride == null)
                    {
                        inPride.Value = DBNull.Value;
                    }
                    SqlParameter newFBA = command.Parameters.AddWithValue("@newFBA", info.newFBA);
                    if (info.newFBA == null)
                    {
                        newFBA.Value = DBNull.Value;
                    }
                    //SqlParameter addService = command.Parameters.AddWithValue("@addService", info.addserv);
                    //if (info.carePhone == null)
                    // {
                    //    addService.Value = DBNull.Value;
                    // }
                    //SqlParameter servicesGained = command.Parameters.AddWithValue("@servicesGained", info.gain);
                    //if (info.compService == null)
                    //{
                    //  servicesGained.Value = DBNull.Value;
                    //}



                    SqlParameter publicAssistance = command.Parameters.AddWithValue("@publicAssistance", info.publicAssistance);
                    if (info.publicAssistance == null)
                    {
                        publicAssistance.Value = DBNull.Value;
                    }
                    //more more
                    SqlParameter referralDate = command.Parameters.AddWithValue("@referralDate", info.referralDate);
                    if (info.referralDate == null)
                    {
                        referralDate.Value = DBNull.Value;
                    }

                    SqlParameter referrerEmail = command.Parameters.AddWithValue("@referrerEmail", info.emailOfFirstReferralSource);
                    if (info.emailOfFirstReferralSource == null)
                    {
                        referrerEmail.Value = DBNull.Value;
                    }
                    //suspended
                    SqlParameter suspendedThrice = command.Parameters.AddWithValue("@suspendedThrice", info.suspended);
                    if (info.suspended == null)
                    {
                        suspendedThrice.Value = DBNull.Value;
                    }
                    SqlParameter numSuspensions = command.Parameters.AddWithValue("@numSuspensions", info.suspendCount);
                    if (info.suspendCount == null)
                    {
                        numSuspensions.Value = DBNull.Value;
                    }
                    //WRONG
                    SqlParameter totalDaysSuspended = command.Parameters.AddWithValue("@totalDaysSuspended", info.daysOwed);
                    if (info.daysOwed == null)
                    {
                        totalDaysSuspended.Value = DBNull.Value;
                    }
                    SqlParameter ISS = command.Parameters.AddWithValue("@ISS", info.iss);
                    if (info.iss == null)
                    {
                        ISS.Value = DBNull.Value;
                    }
                    SqlParameter OSS = command.Parameters.AddWithValue("@OSS", info.oss);
                    if (info.oss == null)
                    {
                        OSS.Value = DBNull.Value;
                    }
                    SqlParameter daysofDiscipline = command.Parameters.AddWithValue("@daysofDiscipline", info.daysOwed);
                    if (info.daysOwed == null)
                    {
                        daysofDiscipline.Value = DBNull.Value;
                    }
                    //SqlParameter disciplineSinceIntake = command.Parameters.AddWithValue("@disciplineSinceIntake", info.emailOfFirstReferralSource);
                    //if (info.sin == null)
                    //{
                    //  disciplineSinceIntake.Value = DBNull.Value;
                    //}
                    SqlParameter IEP = command.Parameters.AddWithValue("@IEP", info.iep);
                    if (info.iep == null)
                    {
                        IEP.Value = DBNull.Value;
                    }
                    SqlParameter primaryIEP = command.Parameters.AddWithValue("@primaryIEP", info.iepplan1);
                    if (info.iepplan1 == null)
                    {
                        primaryIEP.Value = DBNull.Value;
                    }
                    SqlParameter secondaryIEP = command.Parameters.AddWithValue("@secondaryIEP", info.iepplan2);
                    if (info.iepplan2 == null)
                    {
                        secondaryIEP.Value = DBNull.Value;
                    }
                    //SqlParameter addIEp = command.Parameters.AddWithValue("@addIEP", info.daysOwed);
                    //  if (info.iep == null)
                    // {
                    //      addIEp.Value = DBNull.Value;
                    //   }
                    SqlParameter legalIssues = command.Parameters.AddWithValue("@legalIssues", info.firstLegal);
                    if (info.firstLegal == null)
                    {
                        legalIssues.Value = DBNull.Value;
                    }
                    SqlParameter leagalIssues2 = command.Parameters.AddWithValue("@leagalIssues2", info.secondLegal);
                    if (info.secondLegal == null)
                    {
                        leagalIssues2.Value = DBNull.Value;
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                int message = info.ClientID;
                //return RedirectToAction("detailReferralM?clientCode="+ message +"", "n");
                return RedirectToAction("RefList", "Referral");
            }
        }
        public IActionResult confirmationM()
        {
            //confirmation thank you page for submiting and give email
            return View();

        }

    }
}