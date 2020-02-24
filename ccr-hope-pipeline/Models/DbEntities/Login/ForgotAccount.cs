using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HopePipeline.Models
{
    public class ForgotAccount
    {
        public string email { get; set; }
    }
}
