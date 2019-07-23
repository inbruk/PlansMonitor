using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class ActualPlansMonitorContext : PlansMonitorContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                              
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbQuery<VwAudit> VwAudit { get; set; }
        public DbQuery<VwAuditLog> VwAuditLog { get; set; }
        public DbQuery<VwCorrectiveAction> VwCorrectiveAction { get; set; }
        public DbQuery<VwEmailTemplate> VwEmailTemplate { get; set; }
        public DbQuery<VwFileStorage> VwFileStorage { get; set; }
        public DbQuery<VwRemark> VwRemark { get; set; }
        public DbQuery<VwUser> VwUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // создаем поддержку представлениям (их прокси классы лежат в каталоге Manual)
            modelBuilder.Query<VwAudit>().ToView("vwAudit");
            modelBuilder.Query<VwAuditLog>().ToView("vwAuditLog");
            modelBuilder.Query<VwCorrectiveAction>().ToView("vwCorrectiveAction");
            modelBuilder.Query<VwEmailTemplate>().ToView("vwEmailTemplate");
            modelBuilder.Query<VwFileStorage>().ToView("vwFileStorage");
            modelBuilder.Query<VwRemark>().ToView("vwRemark");
            modelBuilder.Query<VwUser>().ToView("vwUser");
        }
    }
}
