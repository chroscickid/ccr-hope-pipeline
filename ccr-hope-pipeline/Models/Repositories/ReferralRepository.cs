﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models
{
    public interface ReferralRepository
    {
        IEnumerable<Referral> Referrals { get; }
    }
}