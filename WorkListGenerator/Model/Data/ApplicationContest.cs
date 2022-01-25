using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkListGenerator.Model.Data
{
    public class ApplicationContest : DbContext

    {
        public DbSet<WorkList> WorkLists { get; set; }

        public ApplicationContest()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; user = root; password = root; database = WorkList;", new MySqlServerVersion(new Version(8,0,28)));
        }
    }

   
}
