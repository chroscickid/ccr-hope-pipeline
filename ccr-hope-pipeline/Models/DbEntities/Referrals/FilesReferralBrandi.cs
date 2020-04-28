namespace HopePipeline.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection.Metadata;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class filesReferralBrandi
    {

        public Guid pK { get; set; }
        public string file { get; set; }
        public string fileCode { get; set; }
        public string fileNameY { get; set; }
        [Key] public Guid idPK { get; set; }

       // public virtual referralBrandi Referral { get; set; }

    }
}