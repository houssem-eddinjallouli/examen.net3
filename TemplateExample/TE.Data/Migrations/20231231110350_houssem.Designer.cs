﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TE.Data;

#nullable disable

namespace TE.Data.Migrations
{
    [DbContext(typeof(TEContext))]
    [Migration("20231231110350_houssem")]
    partial class houssem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TE.Core.Domain.Assurance", b =>
                {
                    b.Property<int>("AssuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssuranceId"));

                    b.Property<DateTime>("DateEcheance")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateEffet")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("AssuranceId");

                    b.ToTable("Assurance");
                });

            modelBuilder.Entity("TE.Core.Domain.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DomaineExpertise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TarifHoraire")
                        .HasColumnType("float");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Expert");
                });

            modelBuilder.Entity("TE.Core.Domain.Expertise", b =>
                {
                    b.Property<int>("ExpertFK")
                        .HasColumnType("int");

                    b.Property<int>("SinistreFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateExpertise")
                        .HasColumnType("date");

                    b.Property<string>("AvisTechnique")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Duree")
                        .HasColumnType("float");

                    b.Property<double>("MontantEstime")
                        .HasColumnType("float");

                    b.HasKey("ExpertFK", "SinistreFK", "DateExpertise");

                    b.HasIndex("SinistreFK");

                    b.ToTable("Expertise");
                });

            modelBuilder.Entity("TE.Core.Domain.Sinistre", b =>
                {
                    b.Property<int>("SinistreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinistreId"));

                    b.Property<int>("AssuranceFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDeclaration")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SinistreId");

                    b.HasIndex("AssuranceFK");

                    b.ToTable("Sinistre");
                });

            modelBuilder.Entity("TE.Core.Domain.Expertise", b =>
                {
                    b.HasOne("TE.Core.Domain.Expert", "MyExpert")
                        .WithMany("Expertises")
                        .HasForeignKey("ExpertFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TE.Core.Domain.Sinistre", "MySinistre")
                        .WithMany("Expertises")
                        .HasForeignKey("SinistreFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyExpert");

                    b.Navigation("MySinistre");
                });

            modelBuilder.Entity("TE.Core.Domain.Sinistre", b =>
                {
                    b.HasOne("TE.Core.Domain.Assurance", "MyAssurance")
                        .WithMany("Sinistres")
                        .HasForeignKey("AssuranceFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyAssurance");
                });

            modelBuilder.Entity("TE.Core.Domain.Assurance", b =>
                {
                    b.Navigation("Sinistres");
                });

            modelBuilder.Entity("TE.Core.Domain.Expert", b =>
                {
                    b.Navigation("Expertises");
                });

            modelBuilder.Entity("TE.Core.Domain.Sinistre", b =>
                {
                    b.Navigation("Expertises");
                });
#pragma warning restore 612, 618
        }
    }
}
