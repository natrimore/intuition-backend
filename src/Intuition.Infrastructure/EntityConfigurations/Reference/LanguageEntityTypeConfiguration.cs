using Intuition.Domains.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Infrastructures.EntityConfigurations.Reference
{
    class LanguageEntityTypeConfiguration
     : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> config)
        {
            config.ToTable(nameof(ReferenceContext.Languages));

            config
                .HasKey(p => new
                {
                    p.Id
                });

            config
                .Property(p => p.Id)
                .HasMaxLength(3)
                .IsRequired(true);

            config
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired(true);

            config
                .Property(p => p.DisplayName)
                .HasMaxLength(70)
                .IsRequired(true);
        }
    }
}
