using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Test.Task.Entities;

namespace Test.Task
{
    public class DataBaseContext : DbContext
    {
        private const string CONN_STRING = "userid=root; Server=localhost; password=Mysql11001@@@; database=cpe_mac_base; Pooling=true";

        public DbSet<MacBase> CpeMacBase { get; set; }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(CONN_STRING,
                mySqlOptionsAction: sqlOption => {
                    sqlOption.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    sqlOption.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            optionsBuilder?.EnableSensitiveDataLogging();
        }
    }
}
