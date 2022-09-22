using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using MetarAPI.Models.DataModels;

namespace MetarAPI
{
    public class DiMetarContext : DbContext
    {
        // <summary>
        // This Context is to be used with a DI framework, such as ASP.NET Core web app.
        // </summary>
        private string _conn { get; set; }
        public DbSet<Metar>? Metars { get; set; }
        public DbSet<SkyCondition>? SkyConditions { get; set; }
        public DbSet<QualityFlags>? QualityFlags { get; set; }

        public DiMetarContext(string conn)
        {
            _conn = conn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_conn);


        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Metar>()
                .HasIndex(raw => raw.RawText)
                .IsUnique();

    }
}
