﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ccr_hope_pipeline.Models.DbEntities.Tracking
{
    public class TrackingForm
    {
        public ccr_hope_pipeline.Models.referralBrandi referralBrandi { get; set; }
        public Guid ClientID { get; set; }
        public Guid refCode { get; set; }
        public string reffname { get; set; }
        public string reflname { get; set; }

        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string clientDOB { get; set; }
        public string clientGender { get; set; }
        public string clientEthnicity { get; set; }
        public string school { get; set; }
        public int currentGrade { get; set; }
        public string compTime { get; set; }

        public string careGender { get; set; }
        public string careFirstName { get; set; }
        public string careLastName { get; set; }
        public string careEthnicity { get; set; }
        [Phone]
        public string carePhone { get; set; }
        public string schoolRef { get; set; }
        public string readingLevel { get; set; }
        public string mathLevel { get; set; }
        public int failCount { get; set; }
        public int failedGrade { get; set; }
        public int whichGradeFailed { get; set; }
        public int baker { get; set; }
        public int femHouse { get; set; }
        public int marchman { get; set; }
        public int domVio { get; set; }
        public int adopted { get; set; }
        public int evicted { get; set; }
        public int incarParent { get; set; }
        public int asthma { get; set; }
        public int publicAssistance { get; set; }
        public int iep { get; set; }
        public string iepplan1 { get; set; }
        public string iepplan2 { get; set; }
        public int inPride { get; set; }
        public int newFBA { get; set; }

        //Accomodations       
        public int accomGained { get; set; }
        public int compService { get; set; }
        public int addServicesGained { get; set; }
        public string ifWhatServices { get; set; }


        public int bullied { get; set; }
        public int bullyReport { get; set; }
        public string dateofBully { get; set; }
        public int reenrolled { get; set; }
        public int pregnantparenting { get; set; }
        public int suspended { get; set; }
        public int suspendCount { get; set; }
        public int iss { get; set; }
        public int oss { get; set; }
        public int altSchool { get; set; }
        public string altSchoolName { get; set; }
        public string dateOfAlt { get; set; }
        public int timesInAlt { get; set; }
        public int daysOwed { get; set; }
        public string justiceOutcome { get; set; }
        public string otherLegal { get; set; }
        public string firstLegal { get; set; }
        public string secondLegal { get; set; }
        public DateTime referralDate { get; set; }
        public DateTime referralTime { get; set; }
        public string intakeDate { get; set; }
        public string schoolAtClosure { get; set; }
        public string emailOfFirstReferralSource { get; set; }
        public string levelOfServiceProvided { get; set; }
        public string nonEngagementReason { get; set; }
        public int caseStatus { get; set; }
        public int legalAdvocacy { get; set; }
        public string legalAdvoTaken { get; set; }
        public int rearrestAdvocacy { get; set; }
        public int remedyResolution { get; set; }
        public int rearrestWhileRepresented { get; set; }
        public int firstReferral { get; set; }
        public string referralCount { get; set; }
        public int courtAdvocacy { get; set; }
        public int staffAdvocacy { get; set; }
        public int daysSinceIntake { get; set; }


    }
}
