using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models
{
    public class FakeReferralRepo : ReferralRepository
    {
        public IEnumerable<Referral> Referrals => new List<Referral>
        {
            new Referral { pK = 0, fName = "David", lName = "Chroscicki" , dOB = new DateTime(1996, 10, 17), status = "Pending"},
            new Referral { pK = 1, fName = "Bridget", lName = "Lyon" , dOB = new DateTime(2002, 2, 10), status = "Pending"},
            new Referral { pK = 2, fName = "Kristina", lName = "Huston" , dOB = new DateTime(1998, 4, 13), status = "Pending"},
            new Referral { pK = 3, fName = "Lili", lName = "Weinstein" , dOB = new DateTime(1998, 4, 15), status = "Pending"}

        };
    }
}