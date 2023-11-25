﻿// <auto-generated />
using System;
using LocalHealth1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalHealth1.Migrations
{
    [DbContext(typeof(LocalHealth1Context))]
    [Migration("20231124210757_Final")]
    partial class Final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiagnosticoDoenca", b =>
                {
                    b.Property<int>("diagnosticoId")
                        .HasColumnType("int");

                    b.Property<string>("doencaNrCid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("diagnosticoId", "doencaNrCid");

                    b.HasIndex("doencaNrCid");

                    b.ToTable("DiagnosticoDoenca");
                });

            modelBuilder.Entity("LocalHealth1.Models.DetalheDiagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiagnosticoId")
                        .HasColumnType("int");

                    b.Property<string>("ExamesSolicitados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosticoId")
                        .IsUnique();

                    b.ToTable("DetalheDiagnostico");
                });

            modelBuilder.Entity("LocalHealth1.Models.Diagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Doenca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalizacaoId")
                        .HasColumnType("int");

                    b.Property<string>("MedicoCrmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SintomasPaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("MedicoCrmId");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("LocalHealth1.Models.Doenca", b =>
                {
                    b.Property<string>("NrCid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sintomas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NrCid");

                    b.ToTable("Doenca");
                });

            modelBuilder.Entity("LocalHealth1.Models.Localizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localizacao");
                });

            modelBuilder.Entity("LocalHealth1.Models.Medico", b =>
                {
                    b.Property<string>("CrmId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrmId");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("DiagnosticoDoenca", b =>
                {
                    b.HasOne("LocalHealth1.Models.Diagnostico", null)
                        .WithMany()
                        .HasForeignKey("diagnosticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalHealth1.Models.Doenca", null)
                        .WithMany()
                        .HasForeignKey("doencaNrCid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalHealth1.Models.DetalheDiagnostico", b =>
                {
                    b.HasOne("LocalHealth1.Models.Diagnostico", "Diagnostico")
                        .WithOne("DetalheDiagnostico")
                        .HasForeignKey("LocalHealth1.Models.DetalheDiagnostico", "DiagnosticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("LocalHealth1.Models.Diagnostico", b =>
                {
                    b.HasOne("LocalHealth1.Models.Localizacao", "Localizacao")
                        .WithMany("diagnostico")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalHealth1.Models.Medico", "Medico")
                        .WithMany("diagnostico")
                        .HasForeignKey("MedicoCrmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("LocalHealth1.Models.Diagnostico", b =>
                {
                    b.Navigation("DetalheDiagnostico")
                        .IsRequired();
                });

            modelBuilder.Entity("LocalHealth1.Models.Localizacao", b =>
                {
                    b.Navigation("diagnostico");
                });

            modelBuilder.Entity("LocalHealth1.Models.Medico", b =>
                {
                    b.Navigation("diagnostico");
                });
#pragma warning restore 612, 618
        }
    }
}
