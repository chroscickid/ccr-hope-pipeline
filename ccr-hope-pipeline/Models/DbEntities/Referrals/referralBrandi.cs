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

        public Guid clientCode { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dOB { get; set; }

        public string guardianName { get; set; }
        public string guardianlName { get; set; }
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

        public string nameOrg { get; set;}

        public string youthNu { get; set; }

        public string youthEmail { get; set; }

        public int youthCit { get; set; }
        public int youthOffense { get; set; }
        public string youthImpact { get; set; }
        public int youthAlt { get; set; }

        public int youthSetting { get; set; }
        public int youthInjunction { get; set; }
       
        
        //Hidden variable for javascript edit
        public string fNameHidden { get; set; }

        public string lNameHidden { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dOBHidden { get; set; }

        public string guardianNameHidden { get; set; }
        public string guardianlNameHidden { get; set; }
        public string guardianRelationshipHidden { get; set; }

        public string addressHidden { get; set; }

        public string genderHidden { get; set; }
        public string guardianEmailHidden { get; set; }


        public string guardianPhoneHidden { get; set; }

        public int meetingHidden { get; set; }

        public int youthInDuvalSchoolHidden { get; set; }
        public int youthInSchoolHidden { get; set; }
        public string issuesHidden { get; set; }

        public string currentSchoolHidden { get; set; }


        public string zipHidden { get; set; }
        public string gradeHidden { get; set; }

        public string statusHidden { get; set; }

        public int arrestHidden { get; set; }
        public string schoolHidden { get; set; }
        public Nullable<System.DateTime> dateInputHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateHidden { get; set; }

        public string emailHidden { get; set; }

        public string ReachHidden { get; set; }
        public string moreInfoHidden { get; set; }
        public string reasonHidden { get; set; }


        public string referralfnameHidden { get; set; }
        public string referrallnameHidden { get; set; }

        public string nameOrgHidden { get; set; }

        public string youthNuHidden { get; set; }

        public string youthEmailHidden { get; set; }

        public int youthCitHidden { get; set; }
        public int youthOffenseHidden { get; set; }
        public string youthImpactHidden { get; set; }
        public int youthAltHidden { get; set; }

        public int youthSettingHidden { get; set; }
        public int youthInjunctionHidden { get; set; }

    }
}
