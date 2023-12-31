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
    internal class ExpertiseConfig : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder
                .HasOne(r => r.MySinistre)
                .WithMany(p => p.Expertises)
                .HasForeignKey(r => r.SinistreFK)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(r => r.MyExpert)
                .WithMany(f => f.Expertises)
                .HasForeignKey(r => r.ExpertFK)
                 .OnDelete(DeleteBehavior.Cascade);


            builder.HasKey(r => new
            {
                r.ExpertFK,
                r.SinistreFK,
                r.DateExpertise
            });
        }
    }
}
