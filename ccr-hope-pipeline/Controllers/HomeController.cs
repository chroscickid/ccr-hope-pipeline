using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;


using System.Web;

using System.Data;

using System.Net;
using System.Net.Mail;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HopePipeline.Services.SendgridEmailInAspNetCore.Services;

namespace HopePipeline.Controllers
{
    public class HomeController : Controller


    {


        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "HomePage";
            return View();
        }
       

        public IActionResult Admin()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SendEmail()
        {
            return View();
        }
        //public async task sendemail(emailmodel model)
        //{
        //    if (modelstate.isvalid)
        //    {
        //        var emails = new list();
        //        emails.add(model.email);
        //        await _emailsender.sendemailasync(emails, model.subject, model.message);
        //    }
        //    return View(model);
        //}
    }
    }

