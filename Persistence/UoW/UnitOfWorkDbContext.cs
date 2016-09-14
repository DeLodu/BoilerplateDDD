using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.ApplicationModule;
using Domain.ApplicationModule.Logger;
using Persistence.Mapping;

namespace Persistence.UoW
{
    public class UnitOfWorkDbContext : DbContext
    {
        public UnitOfWorkDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
        }

        public virtual DbSet<Gebruiker> Gebruikers { get; set; }
        public virtual DbSet<LogItem> LogItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Standaard config database
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Geen tabelnamen in meervoud
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // cascade delete standaard af

            modelBuilder.Configurations.Add(new GebruikerMapping());
            modelBuilder.Configurations.Add(new LogItemMapping());
        }

    }
}
