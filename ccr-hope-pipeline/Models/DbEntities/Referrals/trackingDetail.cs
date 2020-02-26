using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Referrals
{
    public class trackingDetail
    {

        public int ClientID { get; set; }
        //Demographics


        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string careGender { get; set; }
        public string clientGender { get; set; }
        public string clientEthnicity { get; set; }

        public string clientDOB { get; set; }

        public string school { get; set; }
        public string currentGrade { get; set; }

        public string referralSource { get; set; }
        public string failCount { get; set; }
        public string failedGrade { get; set; }
        public string whichGradeFailed { get; set; }
        public string baker { get; set; }
        public string femHouse { get; set; }
        public string marchman { get; set; }
        public string domVio { get; set; }
        public string adopted { get; set; }
        public string evicted { get; set; }
        public string incarParent { get; set; }
        public string asthma { get; set; }
        //demographics done
        //school 
        public string iep { get; set; }
        public string iepplan1 { get; set; }
        public string iepplan2 { get; set; }
        public string schoolRef { get; set; }

        public string readingLevel { get; set; }
        public string mathLevel { get; set; }
        //current iep service???
        public string inPride { get; set; }
        public string newFBA { get; set; }
        public string accomGained { get; set; }
        public string compService { get; set; }
        public string ifWhatServices { get; set; }
        public string compTime { get; set; }
        public string bullied { get; set; }
        public string bullyReport { get; set; }
        public string dateofBully { get; set; }
        //stilll working on school

        //CCR

        public string levelOfServiceProvided { get; set; }
        public string referralDate { get; set; }
        //public string intakeDate { get; set; }
        public string nonEngagementReason { get; set; }
        public string caseStatus { get; set; }
        public string legalAdvocacy { get; set; }
        public string legalAdvoTaken { get; set; }
        public string remedyResolution { get; set; }
        public string rearrestWhileRepresented { get; set; }
        public string referralCount { get; set; }
        public string schoolAtClosure { get; set; }
        //public string firstReferral { get; set; }
        public string emailOfFirstReferralSource { get; set; }
        public string courtAdvocacy { get; set; }
        public string staffAdvocacy { get; set; }
        public string rearrestAdvocacy { get; set; }
        //end ccr
        //Discipline

        public string suspended { get; set; }
        public string suspendCount { get; set; }
        public string altSchool { get; set; }
        public string altSchoolName { get; set; }
        public string dateOfAlt { get; set; }
        public string timesInAlt { get; set; }
        public string daysOwed { get; set; }
        public string firstLegal { get; set; }
        public string secondLegal { get; set; }
        public string iss { get; set; }
        public string totaldaysdisicpline { get; set; }
        public string daysSinceIntake { get; set; }
        public string oss { get; set; }
        public string justiceOutcome { get; set; }
        //end Discipline
        //other
        public string careFirstName { get; set; }
        public string careLastName { get; set; }
        public string careEthnicity { get; set; }
        public string carePhone { get; set; }

        public string publicAssistance { get; set; }




        public string otherLegal { get; set; }


    }
}




