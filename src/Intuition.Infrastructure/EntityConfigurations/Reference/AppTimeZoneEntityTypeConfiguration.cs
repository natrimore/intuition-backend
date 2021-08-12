using Intuition.Domains.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations.Reference
{
    class AppTimeZoneEntityTypeConfiguration
      : IEntityTypeConfiguration<AppTimeZone>
    {
        public void Configure(EntityTypeBuilder<AppTimeZone> config)
        {
            config.ToTable(nameof(ReferenceContext.AppTimeZones));

            config.HasKey(p => new
            {
                p.Id
            });

            config
                .Property(p => p.Id)
                .HasMaxLength(50);

            config
                .Property(p => p.DisplayName)
                .HasComment("The general display name that represents the time zone.")
                .HasMaxLength(50)
                .IsRequired(true);

            config
                .Property(p => p.StandartName)
                .HasComment("The display name for the time zone's standard time.")
                .HasMaxLength(50)
                .IsRequired(true);

            config
                .Property(p => p.BaseUtcOffsetHours)
                .HasComment("The minutes component of the time interval.")
                .IsRequired(true);

            config
                .Property(p => p.BaseUtcOffsetMinutes)
                .HasComment("The minutes component of the time interval.")
                .IsRequired(true);

            config
                .Property(p => p.BaseUtcOffsetSeconds)
                .HasComment("The seconds component of the time interval.")
                .IsRequired(true);

        }
    }
}
