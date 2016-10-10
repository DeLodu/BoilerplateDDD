using Domain.DependencyContracts;
using Domain.KanbanModule.Taak;

namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using UoW;

    public sealed class Configuration : DbMigrationsConfiguration<UnitOfWorkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UnitOfWorkDbContext context)
        {

            context.Statussen.AddOrUpdate(
                new Status(Guid.Parse("1c23c0aa-d96e-4488-8ba1-bfe2b021188a"), "Nieuw"), 
                new Status(Guid.Parse("f8cdbbfe-4046-4a4e-ae69-ffe25e7b6dc3"), "Goedgekeurd"), 
                new Status(Guid.Parse("407d1448-24ed-4141-b965-9c27575cf73d"), "Bezig"), 
                new Status(Guid.Parse("f6b756ce-5dbe-4ac6-9a1b-c14f1156e93f"), "Afgewerkt"));
        }

        public void SeedDB(UnitOfWork uow)
        {
            Seed((UnitOfWorkDbContext)uow.ConnectionDB);
        }
    }
}
