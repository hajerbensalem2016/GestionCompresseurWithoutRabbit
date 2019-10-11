﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuiviCompresseur.GestionCompresseur.Data.Context;

namespace SuiviCompresseur.GestionCompresseur.Data.Migrations
{
    [DbContext(typeof(CompresseurDbContext))]
    partial class CompresseurDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.CompresseurFiliale", b =>
                {
                    b.Property<Guid>("CompFilialeID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompresseurID");

                    b.Property<DateTime>("DateDebut");

                    b.Property<int>("Duree");

                    b.Property<Guid>("FilialeID");

                    b.Property<float>("MontantMensuel");

                    b.Property<float>("MontantTotal");

                    b.Property<string>("Name");

                    b.HasKey("CompFilialeID");

                    b.HasIndex("CompresseurID");

                    b.ToTable("CompresseurFiliales");
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.Consommable", b =>
                {
                    b.Property<Guid>("ConsommableID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompFilialeID");

                    b.Property<int>("ConsommationComp");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("PrixUnitaire");

                    b.HasKey("ConsommableID");

                    b.HasIndex("CompFilialeID");

                    b.ToTable("Consommables");
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.FicheCompresseur", b =>
                {
                    b.Property<Guid>("CompresseurID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodeCompresseur");

                    b.Property<string>("Constructeur");

                    b.Property<float>("Debit");

                    b.Property<Guid>("FournisseurID");

                    b.Property<int>("Puissance");

                    b.Property<string>("TypeCompresseur");

                    b.HasKey("CompresseurID");

                    b.ToTable("FicheCompresseurs");
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.Fiche_Suivi", b =>
                {
                    b.Property<Guid>("FicheSuiviID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompFilialeID");

                    b.Property<double>("CourantAbsorbePhase");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Etat");

                    b.Property<string>("FrequenceEentretienDeshuileur");

                    b.Property<int>("Index_Electrique");

                    b.Property<int>("Nbre_Heurs_Charge");

                    b.Property<int>("Nbre_Heurs_Total");

                    b.Property<double>("PriseCompteur");

                    b.Property<string>("Remarques");

                    b.Property<double>("THuileC");

                    b.Property<string>("TSecheurC");

                    b.Property<double>("TempsArret");

                    b.Property<string>("TypeDernierEntretien");

                    b.HasKey("FicheSuiviID");

                    b.HasIndex("CompFilialeID");

                    b.ToTable("Fiche_Suivis");
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.GRH", b =>
                {
                    b.Property<Guid>("GRhID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Charge_Compresseur");

                    b.Property<float>("Charge_Secteur");

                    b.Property<float>("Charge_Total");

                    b.Property<Guid>("CompFilialeID");

                    b.Property<float>("Compresseur_Pourcentage");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<decimal>("Salaire");

                    b.Property<float>("Secheur_Pourcentage");

                    b.HasKey("GRhID");

                    b.HasIndex("CompFilialeID");

                    b.ToTable("GRHs");
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.CompresseurFiliale", b =>
                {
                    b.HasOne("SuiviCompresseur.GestionCompresseur.Domain.Models.FicheCompresseur", "FicheCompresseur")
                        .WithMany("CompresseurFiliales")
                        .HasForeignKey("CompresseurID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.Consommable", b =>
                {
                    b.HasOne("SuiviCompresseur.GestionCompresseur.Domain.Models.CompresseurFiliale", "CompresseurFiliale")
                        .WithMany("Consommables")
                        .HasForeignKey("CompFilialeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.Fiche_Suivi", b =>
                {
                    b.HasOne("SuiviCompresseur.GestionCompresseur.Domain.Models.CompresseurFiliale", "CompresseurFiliale")
                        .WithMany("Fiche_Suivis")
                        .HasForeignKey("CompFilialeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuiviCompresseur.GestionCompresseur.Domain.Models.GRH", b =>
                {
                    b.HasOne("SuiviCompresseur.GestionCompresseur.Domain.Models.CompresseurFiliale", "CompresseurFiliale")
                        .WithMany("GRHs")
                        .HasForeignKey("CompFilialeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
