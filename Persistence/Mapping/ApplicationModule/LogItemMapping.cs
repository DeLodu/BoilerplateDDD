using System;
using System.Data.Entity.ModelConfiguration;
using Domain.ApplicationModule;
using Domain.ApplicationModule.Logger;

namespace Persistence.Mapping
{
    public class LogItemMapping : EntityTypeConfiguration<LogItem>
    {
        public LogItemMapping()
        {
            ToTable("ta_App_LogItem");

            HasKey(e => new
            {
                e.UID,
            });

            Property(e => e.Melding)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.LoginNaam)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
