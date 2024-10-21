﻿// <auto-generated />
using System;
using LocadaoV3.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LocadaoV3.Infra.Migrations
{
    [DbContext(typeof(LocadaoDbContext))]
    partial class LocadaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Aluguel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AgenciaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Alugueis");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Agencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPCD")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("TemCNH")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ValidadeCNH")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("AdaptadoParaPCD")
                        .HasColumnType("boolean");

                    b.Property<Guid>("AgenciaId")
                        .HasColumnType("uuid");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("integer");

                    b.Property<bool>("Automatico")
                        .HasColumnType("boolean");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("DisponivelParaAluguel")
                        .HasColumnType("boolean");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<double>("Quilometragem")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Aluguel", b =>
                {
                    b.HasOne("LocadaoV3.Domain.Models.Agencia", "Agencia")
                        .WithMany("Alugueis")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadaoV3.Domain.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadaoV3.Domain.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Reserva", b =>
                {
                    b.HasOne("LocadaoV3.Domain.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadaoV3.Domain.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Veiculo", b =>
                {
                    b.HasOne("LocadaoV3.Domain.Models.Agencia", "Agencia")
                        .WithMany("Veiculos")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");
                });

            modelBuilder.Entity("LocadaoV3.Domain.Models.Agencia", b =>
                {
                    b.Navigation("Alugueis");

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
