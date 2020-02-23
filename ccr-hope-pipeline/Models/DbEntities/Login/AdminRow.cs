using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HopePipeline.Models.DbEntities.Login
{
    public class AdminRowContext : DbContext

    {
        public DbSet<AdminRow> AdminRows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = tcp:hope - sqlserver.database.windows.net, 1433; Initial Catalog = hope - database; Persist Security Info = False; User ID = dadmin; Password = Hope2020!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30"
                );
        }
    }
    public class AdminRow
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string pass { get; set; }
        public string Roles { get; set; }

    }
}
