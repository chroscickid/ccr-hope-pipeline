using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HopePipeline.Models;
using System.Net.Mail;
using HopePipeline.Models.DbEntities;
using HopePipeline.Models.DbEntities.Login;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopePipeline.Controllers
{
   
   // [Route("account")]
    public class AccountController : Controller
    {
        public string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //SqlConnection con = new SqlConnection();
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

   //     void connectionString()
     //   {
      //      con.ConnectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //}

        public ActionResult Verify(Account acc)
        {
            SqlConnection con;
            con = new SqlConnection(connectionString);
            SqlCommand command;
            //return Content(acc.pass);
            con.Open();

            //  connectionString();
            // con.Open();
            //com.Connection = con;
            // com.CommandText = "select * from dbo.account where username='"+acc.username+"' and pass='"+acc.pass+"'";
             string query = "select * from dbo.account where email='" + acc.username + "' and pass='" + acc.pass + "'";
            //string query = "SELECT* FROM dbo.account WHERE username = 'username' AND password = 'password'";

            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                con.Close();
                return RedirectToAction("RefList","Referral");
            }

            else
            {
                ViewBag.error = "Invalid Account";
                con.Close();
                return RedirectToAction("Index","Home");
            }
           
        }
        // [HttpGet]
        // public IActionResult Index()
        // {
        //     return View();
        // }

        //[Route("login")]
        //[HttpPost]

        // public IActionResult Login(string username, string pass)
        // {
        // public string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //if (username != null && pass != null && username.Equals("ccr") && pass.Equals("123"))
        //{
        //    HttpContext.Session.SetString("username", username);
        //    return RedirectToAction("RefList","Referral");
        //}
        //else
        //{
        //    ViewBag.error = "Invalid Account";
        //    return View("../Home/Index");
        //}
    }

    //[Route("logout")]
    //[HttpGet]

    //public IActionResult Logout()
    //{
    //    HttpContext.Session.Remove("username");
    //    return RedirectToAction("Index", "Home");
    //}


    //public ActionResult ForgotPassword()
    //{
    //    return View();
    //}

   // [HttpPost]
    //public ActionResult SendForgotPassEmail(ForgotAccount account)
    //{
    //      MailMessage mail = new MailMessage();
    //                  SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    //                  mail.From = new MailAddress("hopepipeline@gmail.com");
    //                  string rsemail = account.email;
    //                  mail.To.Add(rsemail);

    //                  mail.Subject = "Forgot Password link";
    //                  DateTime Date = DateTime.Now;
    //                  string mails = "PLaceholder. Email is " + account.email;
    //                  mail.Body = mails;



    //                  SmtpServer.Port = 587;
    //                  SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
    //                  SmtpServer.EnableSsl = true;
    //                  SmtpServer.Send(mail);

    //    return RedirectToAction("Index", "Home");
    //}


}
