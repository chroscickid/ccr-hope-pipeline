namespace HopePipeline.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class filesReferralBrandi
    {

        public int pK { get; set; }
        public string file { get; set; }
        public string fileCode { get; set; }
        public string fileNameY { get; set; }
        [Key] public int idPK { get; set; }

        public virtual referralBrandi Referral { get; set; }

    }
}