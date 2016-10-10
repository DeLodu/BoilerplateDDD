using System;
using System.Data.Entity.ModelConfiguration;
using Domain.KanbanModule.Taak;

namespace Persistence.Mapping
{
    public class StatusMapping : EntityTypeConfiguration<Status>
    {
        public StatusMapping()
        {
            ToTable("ta_Knb_Status");

            HasKey(e => new
            {
                e.UID,
            });

            Property(e => e.Omschrijving)
                .IsRequired()
                .HasMaxLength(40);

        }
    }
}
