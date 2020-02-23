using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models
{
  public class AppDbContext : IdentityDbContext
    {
       // public AppDbContext() { }
                public AppDbContext() { }
                public AppDbContext(DbContextOptions<AppDbContext> options)
                     : base(options)
                {

                }

    }
}
