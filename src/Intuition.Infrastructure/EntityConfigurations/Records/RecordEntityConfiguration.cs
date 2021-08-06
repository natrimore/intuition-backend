using Intuition.Domains.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations.Records
{
    class RecordEntityConfiguration
    : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> config)
        {
            config.ToTable(nameof(RecordContext.Records), RecordContext.DEFAULT_SCHEME);

            config.HasKey(p => new
            {
                p.Id
            });

            config
                .Property(p => p.Data)
                .IsRequired(true);

            
            config
                .Property(p => p.Date)
                .IsRequired(true);

            config
                .HasOne(h => h.AppUser)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .IsRequired(true);
        }
    }
}
