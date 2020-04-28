using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models.DbEntities.Referrals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class referralDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid clientCode { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }


        public string dOB { get; set; }

        public string guardianName { get; set; }
        public string guardianlName { get; set; }
        public string guardianRelationship { get; set; }

        public string address { get; set; }

        public string gender { get; set; }
        public string guardianEmail { get; set; }


        public string guardianPhone { get; set; }

        public string meeting { get; set; }

        public string youthInDuvalSchool { get; set; }
        public string youthInSchool { get; set; }
        public string issues { get; set; }

        public string currentSchool { get; set; }



        public string zip { get; set; }
        public string grade { get; set; }

        public string status { get; set; }

        public string arrest { get; set; }
        public string school { get; set; }
        public string dateInput { get; set; }

        public string date { get; set; }

        public string email { get; set; }

        public string Reach { get; set; }
        public string moreInfo { get; set; }
        public string reason { get; set; }


        public string referralfname { get; set; }
        public string referrallname { get; set; }

        public string nameOrg { get; set; }

        public string youthNu { get; set; }
        public string youthEmail { get; set; }
        public string youthCit{ get; set; }


        public string youthOffense{ get; set; }
        public string youthImpact { get; set; }

        public string youthAlt { get; set; }


        public string youthSetting { get; set; }
        public string youthInjunction { get; set; }
      
        public string filename { get; set; }
    }
}
