using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidencyApplication.Repository.ResidencyApplication
{
    public class ResidencyApplicationContext :DbContext
    {
        public ResidencyApplicationContext(DbContextOptions<ResidencyApplicationContext> options) : base(options)
        {

        }

        public ResidencyApplicationContext()
        {
        }
        public virtual DbSet<ApplicantModel> Applicants { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ResidencyApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
