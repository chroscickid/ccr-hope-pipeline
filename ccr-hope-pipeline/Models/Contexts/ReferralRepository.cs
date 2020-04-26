using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.Contexts
{
    public interface ReferralRepository
    {
        IEnumerable<Referral> Referrals { get; }
    }
}