﻿// <auto-generated />
using System;
using Hospitalidée_CRM_Back_End;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospitalidée_CRM_Back_End.Migrations
{
    [DbContext(typeof(UniteLegaleContext))]
    [Migration("20210112110507_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Hospitalidée_CRM_Back_End.Models.Etablissement", b =>
                {
                    b.Property<Guid>("EtablissementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UniteLegaleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("activite_principale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code_postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("denomination_usuelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("libelle_commune")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("libelle_voie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numero_voie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("siret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type_voie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EtablissementId");

                    b.HasIndex("UniteLegaleId");

                    b.ToTable("Etablissements");
                });

            modelBuilder.Entity("Hospitalidée_CRM_Back_End.Models.UniteLegale", b =>
                {
                    b.Property<Guid>("UniteLegaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("denomination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomenclature_activité_principale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom_usuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("siren")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniteLegaleId");

                    b.ToTable("UniteLegale");
                });

            modelBuilder.Entity("Hospitalidée_CRM_Back_End.Models.Etablissement", b =>
                {
                    b.HasOne("Hospitalidée_CRM_Back_End.Models.UniteLegale", null)
                        .WithMany("etablissements")
                        .HasForeignKey("UniteLegaleId");
                });

            modelBuilder.Entity("Hospitalidée_CRM_Back_End.Models.UniteLegale", b =>
                {
                    b.Navigation("etablissements");
                });
#pragma warning restore 612, 618
        }
    }
}