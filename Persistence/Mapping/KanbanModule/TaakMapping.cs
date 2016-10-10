using System;
using System.Data.Entity.ModelConfiguration;
using Domain.KanbanModule.Taak;

namespace Persistence.Mapping
{
    public class TaakMapping : EntityTypeConfiguration<Taak>
    {
        public TaakMapping()
        {
            ToTable("ta_Knb_Taak");

            HasKey(e => new
            {
                e.UID,
            });

            Property(e => e.OmschrijvingKort)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(e => e.Status)
               .WithMany()
               .HasForeignKey(e => e.StatusUID);

        }
    }
}
