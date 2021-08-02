using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class ErrorEntityTypeConfiguration
     : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> config)
        {
            config.ToTable(nameof(IdentityContext.Errors), IdentityContext.DEFAULT_SCHEME);

            config.HasKey(p => new
            {
                p.Code,
                p.LanguageId
            });

            config
                .HasOne(w => w.Language)
                .WithMany()
                .HasForeignKey(w => w.LanguageId);

            config
                .Property(p => p.LanguageId)
                .HasMaxLength(3)
                .IsRequired(true);

            config
                .Property(w => w.Message)
                .HasMaxLength(500)
                .IsRequired(true);

            config
                .Property(w => w.HttpStatusCode)
                .HasDefaultValue(0)
                .IsRequired(true);
        }
    }
}
