﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projeto_cinema.Data;

#nullable disable

namespace projeto_cinema.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projeto_cinema.Models.EventosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataDoEvento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("HoraDoEvento")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraDoFimEvento")
                        .HasColumnType("time");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortoesCadastrados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelecioneUmLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("projeto_cinema.Models.LocaisModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CadatroCatracas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CadatroEntradas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelecioneTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("projeto_cinema.Models.EventosModel", b =>
                {
                    b.HasOne("projeto_cinema.Models.LocaisModel", "Local")
                        .WithMany("Eventos")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("projeto_cinema.Models.LocaisModel", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
