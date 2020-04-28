
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccr_hope_pipeline.Models.DbEntities.Referrals
{
    public class RefRowContext : DbContext
    {
        public DbSet<RefRow> RefRows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
        }
    }

    public class RefRow
    {
        [Key]
        public string fname { get; set; }
        public string lname { get; set; }
        public string dob { get; set; }
        public string status { get; set; }
        public string phone { get; set; }
        public Guid clientCode { get; set; }
    }
}