using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;

namespace TE.Data.configuration
{
    internal class Assuranceconfig : IEntityTypeConfiguration<Assurance>
    {
        public void Configure(EntityTypeBuilder<Assurance> builder)
        {
            builder.HasMany(houssem => houssem.Sinistres)
                .WithOne(g => g.MyAssurance)
                .HasForeignKey(j => j.AssuranceFK);
        }
    }
}
