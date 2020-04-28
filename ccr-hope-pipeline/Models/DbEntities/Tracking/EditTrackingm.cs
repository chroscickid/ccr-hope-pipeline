using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccr_hope_pipeline.Models.DbEntities.Tracking
{
    public class EditTrackingm
{

        public ccr_hope_pipeline.Models.referralBrandi referralBrandi { get; set; }
        public Guid ClientID { get; set; }
        //Demographics


        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string careGender { get; set; }
        public string clientGender { get; set; }
        public string clientEthnicity { get; set; }
        [DataType(DataType.Date)]
        public DateTime? clientDOB { get; set; }

        public string school { get; set; }
        public string currentGrade { get; set; }

        public string referralSource { get; set; }
        public string referrallSource { get; set; }
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
        //demographics done
        //school 
        public int iep { get; set; }
        public string iepplan1 { get; set; }
        public string iepplan2 { get; set; }
        public string schoolRef { get; set; }

        public string readingLevel { get; set; }
        public string mathLevel { get; set; }
        //current iep service???
        public int inPride { get; set; }
        public int newFBA { get; set; }
        public int accomGained { get; set; }
        public int compService { get; set; }
        public string ifWhatServices { get; set; }
        public string compTime { get; set; }
        public int bullied { get; set; }
        public int bullyReport { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateofBully { get; set; }
        //stilll working on school

        //CCR

        public string levelOfServiceProvided { get; set; }
        [DataType(DataType.Date)]
        public DateTime? referralDate { get; set; }
        public string intakeDate { get; set; }
        public string nonEngagementReason { get; set; }
        public int caseStatus { get; set; }
        public int legalAdvocacy { get; set; }
        public string legalAdvoTaken { get; set; }
        public int remedyResolution { get; set; }
        public int rearrestWhileRepresented { get; set; }
        public string referralCount { get; set; }
        public string schoolAtClosure { get; set; }
        public int firstReferral { get; set; }
        public string emailOfFirstReferralSource { get; set; }
        public int courtAdvocacy { get; set; }
        public int staffAdvocacy { get; set; }
        public int rearrestAdvocacy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? trackingdate { get; set; }
       
        //end ccr
        //Discipline

        public int suspended { get; set; }
        public int suspendCount { get; set; }
        public int altSchool { get; set; }
        public string altSchoolName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateOfAlt { get; set; }
        public int timesInAlt { get; set; }
        public int daysOwed { get; set; }
        public string firstLegal { get; set; }
        public string secondLegal { get; set; }
        public int iss { get; set; }
        public int daysSinceIntake { get; set; }
        public int oss { get; set; }
        public string justiceOutcome { get; set; }
        //end Discipline
        //other
        public string careFirstName { get; set; }
        public string careLastName { get; set; }
        public string careEthnicity { get; set; }
        public string carePhone { get; set; }

        public int publicAssistance { get; set; }
        public string otherLegal { get; set; }


        //String representation for date
        public string stringDateOfAlt { get; set; }
        public string stringReferralDate { get; set; }
        public string stringDateOfBully { get; set; }
        public string stringDateOfBirth { get; set; }
        public string stringtrackingdate { get; set; }

        //Default Value of edit tracking for hidden variables
        //HIDDEN VARIABLES

        public string clientFirstNameHidden { get; set; }
        public string clientLastNameHidden { get; set; }
        public string careGenderHidden { get; set; }
        public string clientGenderHidden { get; set; }
        public string clientEthnicityHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? clientDOBHidden { get; set; }

        public string schoolHidden { get; set; }
        public string currentGradeHidden { get; set; }

        public string referralSourceHidden { get; set; }
        public int failCountHidden { get; set; }
        public int failedGradeHidden { get; set; }
        public int whichGradeFailedHidden { get; set; }
        public int bakerHidden { get; set; }
        public int femHouseHidden { get; set; }
        public int marchmanHidden { get; set; }
        public int domVioHidden { get; set; }
        public int adoptedHidden { get; set; }
        public int evictedHidden { get; set; }
        public int incarParentHidden { get; set; }
        public int asthmaHidden { get; set; }
        //demographics done
        //school 
        public int iepHidden { get; set; }
        public string iepplan1Hidden { get; set; }
        public string iepplan2Hidden { get; set; }
        public string schoolRefHidden { get; set; }

        public string readingLevelHidden { get; set; }
        public string mathLevelHidden { get; set; }
        //current iep service???
        public int inPrideHidden { get; set; }
        public int newFBAHidden { get; set; }
        public int accomGainedHidden { get; set; }
        public int compServiceHidden { get; set; }
        public string ifWhatServicesHidden { get; set; }
        public string compTimeHidden { get; set; }
        public int bulliedHidden { get; set; }
        public int bullyReportHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateofBullyHidden { get; set; }
        //stilll working on school

        //CCR

        public string levelOfServiceProvidedHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? referralDateHidden { get; set; }
        public string intakeDateHidden { get; set; }
        public string nonEngagementReasonHidden { get; set; }
        public int caseStatusHidden { get; set; }
        public int legalAdvocacyHidden { get; set; }
        public string legalAdvoTakenHidden { get; set; }
        public int remedyResolutionHidden { get; set; }
        public int rearrestWhileRepresentedHidden { get; set; }
        public string referralCountHidden { get; set; }
        public string schoolAtClosureHidden { get; set; }
        public int firstReferralHidden { get; set; }
        public string emailOfFirstReferralSourceHidden { get; set; }
        public int courtAdvocacyHidden { get; set; }
        public int staffAdvocacyHidden { get; set; }
        public int rearrestAdvocacyHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? trackingdateHidden { get; set; }

        //end ccr
        //Discipline

        public int suspendedHidden { get; set; }
        public int suspendCountHidden { get; set; }
        public int altSchoolHidden { get; set; }
        public string altSchoolNameHidden { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateOfAltHidden { get; set; }
        public int timesInAltHidden { get; set; }
        public int daysOwedHidden { get; set; }
        public string firstLegalHidden { get; set; }
        public string secondLegalHidden { get; set; }
        public int issHidden { get; set; }
        public int daysSinceIntakeHidden { get; set; }
        public int ossHidden { get; set; }
        public string justiceOutcomeHidden { get; set; }
        public string referrallSourceHidden { get; set; }
        //end Discipline
        //other
        public string careFirstNameHidden { get; set; }
        public string careLastNameHidden { get; set; }
        public string careEthnicityHidden { get; set; }
        public string carePhoneHidden { get; set; }

        public int publicAssistanceHidden { get; set; }
        public string otherLegalHidden { get; set; }

        public int addServicesGained { get; set; }
        public int addServicesGainedHidden { get; set; }
        public int reenrolled { get; set; }
        public int reenrolledHidden { get; set; }
        public int pregnantparenting { get; set; }
        public int pregnantparentingHidden { get; set; }
    }
}
