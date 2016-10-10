using System;
using System.Data.Entity.ModelConfiguration;
using Domain.ApplicationModule.Accounts;

namespace Persistence.Mapping
{
    public class GebruikerMapping : EntityTypeConfiguration<Gebruiker>
    {
        public GebruikerMapping()
        {
            ToTable("ta_App_Gebruiker");

            HasKey(e => new
            {
                e.UID,
            });

            Property(e => e.Naam)
                .IsOptional()
                .HasMaxLength(100);

            Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Salt)
                .IsOptional()
                .HasMaxLength(100);

            Property(e => e.PasswordHash)
                .IsOptional()
                .HasMaxLength(100);

        }
    }
}
