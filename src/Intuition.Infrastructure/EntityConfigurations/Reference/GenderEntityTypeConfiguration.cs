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
    class GenderEntityTypeConfiguration
    : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> config)
        {
            config.ToTable(nameof(ReferenceContext.Genders));

            config.HasKey(p => new
            {
                p.Id
            });

            config
                .Property(p => p.Name)
                .HasMaxLength(15)
                .IsRequired(true);

            config
                .Property(p => p.DisplayName)
                .HasMaxLength(30)
                .IsRequired(true);
        }
    }
}
