﻿// <auto-generated />
using CogeconAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CogeconAPI.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20240314150412_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CogeconAPI.Models.Cooperado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cooperados");
                });

            modelBuilder.Entity("CogeconAPI.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CogeconAPI.Models.UnidadeConsumidora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Concessionaria")
                        .HasColumnType("int");

                    b.Property<int>("CooperadoId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CooperadoId");

                    b.ToTable("UnidadesConsumidoras");
                });

            modelBuilder.Entity("CogeconAPI.Models.Endereco", b =>
                {
                    b.HasOne("CogeconAPI.Models.UnidadeConsumidora", null)
                        .WithOne("Endereco")
                        .HasForeignKey("CogeconAPI.Models.Endereco", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CogeconAPI.Models.UnidadeConsumidora", b =>
                {
                    b.HasOne("CogeconAPI.Models.Cooperado", "Cooperado")
                        .WithMany("UnidadesConsumidoras")
                        .HasForeignKey("CooperadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cooperado");
                });

            modelBuilder.Entity("CogeconAPI.Models.Cooperado", b =>
                {
                    b.Navigation("UnidadesConsumidoras");
                });

            modelBuilder.Entity("CogeconAPI.Models.UnidadeConsumidora", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
