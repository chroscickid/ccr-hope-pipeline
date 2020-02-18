using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;

namespace HopePipeline.Models
{
    public class trackingReferral
    {
        public string hasIEP504 { get; set; }
        public string which { get; set; }

        public string readLevel { get; set; }

        public string mathLevel { get; set; }
        public string iepServices { get; set; }

        public string inPride { get; set; }

        public string newFBA { get; set; }
        public string addIEPGained { get; set; }
        public string addAcommodGain { get; set; }
        public string addComp { get; set; }
        public string howMuchComp { get; set; }
        public string bullied { get; set; }
        public string bulliedReport { get; set; }
        public DateTime bulliedDate { get; set; }
        public string suspendMoreTwo { get; set; }
        public string suspendHowMany { get; set; }

        public string altSchool { get; set; }
        public string whatAlt { get; set; }
        public string when { get; set; }

        public string howManyTimes { get; set; }
        public string daysOwed { get; set; }
        public string otherIssues { get; set; }
        public int totalDayISSOSS { get; set; }

        public int totalDaysDiscip { get; set; }
        public int totalDiscipSinceIntake { get; set; }
        public int totalOSSSinceIntake { get; set; }
        public string jJOutcome { get; set; }
        [Key]
        public Guid clientCode { get; set; }

        public string genderId { get; set; }

        public string ethnicity { get; set; }
        public string school { get; set; }
        public string gradeLevel { get; set; }
        public string referralSource { get; set; }
        public string failedGrade { get; set; }
        public string fGTimes { get; set; }
        public string bakerAct { get; set; }
        public string femaleLed { get; set; }
        public string flNoWhy { get; set; }
        public string domesticVHX { get; set; }
        public string incarceratedParent { get; set; }
        public string iPIfYesWho { get; set; }
        public string asthma { get; set; }
        public string typeOfRep { get; set; }
        public DateTime intakeDate { get; set; }
        public string nonengageReason { get; set; }
        public string statusTrack { get; set; }
        public string advocacyTaken { get; set; }
        public string resolution { get; set; }
        public string rearrestRepresented { get; set; }
        public string schoolAtClosure { get; set; }
        public string referral1 { get; set; }
        public string referral2 { get; set; }
        public string referral3 { get; set; }
        public string referral4 { get; set; }
        public string referral5 { get; set; }
        public string rearrestAdvocacy { get; set; }
        public string advocacyAtCourt { get; set; }
        public string advocacyAtStaffing { get; set; }
        public int pK { get; set; }
        [ForeignKey("pK")]
        public referralBrandi referralBrandi { get; set; }


    }
}
