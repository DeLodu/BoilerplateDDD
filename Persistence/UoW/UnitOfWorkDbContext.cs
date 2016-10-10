using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.ApplicationModule.Accounts;
using Domain.ApplicationModule.Logger;
using Domain.KanbanModule.Taak;
using Persistence.Mapping;

namespace Persistence.UoW
{
    public class UnitOfWorkDbContext : DbContext
    {
        public UnitOfWorkDbContext()
        { }

        public UnitOfWorkDbContext(DbConnection conn) : base(conn, true)
        { }

        public virtual DbSet<Gebruiker> Gebruikers { get; set; }
        public virtual DbSet<LogItem> LogItems { get; set; }

        public virtual DbSet<Taak> Taken { get; set; }
        public virtual DbSet<Status> Statussen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Standaard config database
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Geen tabelnamen in meervoud
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // cascade delete standaard af

            modelBuilder.Configurations.Add(new GebruikerMapping());
            modelBuilder.Configurations.Add(new LogItemMapping());

            modelBuilder.Configurations.Add(new TaakMapping());
            modelBuilder.Configurations.Add(new StatusMapping());
        }

    }
}
