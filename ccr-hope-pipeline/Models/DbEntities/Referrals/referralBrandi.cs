using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HopePipeline.Models
{
    
    public class referralBrandi
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int clientCode { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dOB { get; set; }

        public string guardianName { get; set; }

        public string guardianRelationship { get; set; }

        public string address { get; set; }

        public string gender { get; set; }
        public string guardianEmail { get; set; }


        public string guardianPhone { get; set; }

        public int meeting { get; set; }

        public int youthInDuvalSchool { get; set; }
        public int youthInSchool { get; set; }
        public string issues { get; set; }

        public string currentSchool { get; set; }


        public string zip { get; set; }
        public string grade { get; set; }

        public string status { get; set; }

        public int arrest { get; set; }
        public string school { get; set; }
        public Nullable<System.DateTime> dateInput { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date { get; set; }

        public string email { get; set; }

        public string Reach { get; set; }
        public string moreInfo { get; set; }
        public string reason { get; set; }


        public string referralfname { get; set; }
        public string referrallname { get; set; }



    }
}
