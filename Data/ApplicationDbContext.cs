using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using APPR_TASK1.Models;
using APPR_TASK1.Controllers;

namespace APPR_TASK1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<APPR_TASK1.Models.Donation> Donation { get; set; }
        public DbSet<APPR_TASK1.Controllers.Catergory> Catergory { get; set; }
        public DbSet<APPR_TASK1.Models.Disaster> Disaster { get; set; }
        public DbSet<APPR_TASK1.Models.Goods> Goods { get; set; }
        public DbSet<APPR_TASK1.Models.Money> Money { get; set; }
        public DbSet<APPR_TASK1.Models.ActiveDisaster> ActiveDisaster { get; set; }
        public DbSet<APPR_TASK1.Models.Report> Report { get; set; }
       
    }
}
