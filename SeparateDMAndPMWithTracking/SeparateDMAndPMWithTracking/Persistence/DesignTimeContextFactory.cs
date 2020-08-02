using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Persistence
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private string conStr = @"Server=.\;Database=SepparateDMandPM_Db;Trusted_Connection=true;";

        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(conStr);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
