﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240530181012_ChangeDecimalToDouble")]
    partial class ChangeDecimalToDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actived")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TB_Clientes", (string)null);
                });

            modelBuilder.Entity("Experiencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actived")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Avaliacao")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FreelancerId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Projeto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tecnologia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId")
                        .IsUnique();

                    b.HasIndex("FreelancerId1");

                    b.ToTable("TB_Experiencias", (string)null);
                });

            modelBuilder.Entity("Freelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actived")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PretensaoSalarial")
                        .HasColumnType("REAL");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TB_Freelancers", (string)null);
                });

            modelBuilder.Entity("Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId1")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FreelancerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Remuneracao")
                        .HasColumnType("REAL");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("ClienteId1");

                    b.HasIndex("FreelancerId")
                        .IsUnique();

                    b.ToTable("TB_Vagas", (string)null);
                });

            modelBuilder.Entity("Experiencia", b =>
                {
                    b.HasOne("Freelancer", "Freelancer")
                        .WithOne()
                        .HasForeignKey("Experiencia", "FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Freelancer", null)
                        .WithMany("Experiencias")
                        .HasForeignKey("FreelancerId1");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("Vaga", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithOne()
                        .HasForeignKey("Vaga", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cliente", null)
                        .WithMany("Vagas")
                        .HasForeignKey("ClienteId1");

                    b.HasOne("Freelancer", "Freelancer")
                        .WithOne()
                        .HasForeignKey("Vaga", "FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cliente");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("Freelancer", b =>
                {
                    b.Navigation("Experiencias");
                });
#pragma warning restore 612, 618
        }
    }
}
