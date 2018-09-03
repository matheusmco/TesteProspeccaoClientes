﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteTria.Models;

namespace TesteTria.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TesteTria.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConteudoConversa");

                    b.Property<DateTime>("DataHoraConversa");

                    b.Property<string>("Email");

                    b.Property<string>("NomeContato");

                    b.Property<string>("NomeEmpresa");

                    b.Property<string>("Telefone");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TesteTria.Models.ClienteServicoModel", b =>
                {
                    b.Property<int>("ClienteId");

                    b.Property<int>("ServicoId");

                    b.HasKey("ClienteId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ClientesServicos");
                });

            modelBuilder.Entity("TesteTria.Models.ServicoModel", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeServico");

                    b.HasKey("ServicoId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("TesteTria.Models.ClienteServicoModel", b =>
                {
                    b.HasOne("TesteTria.Models.ClienteModel", "Cliente")
                        .WithMany("ClienteServico")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TesteTria.Models.ServicoModel", "Servico")
                        .WithMany("ClienteServico")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
