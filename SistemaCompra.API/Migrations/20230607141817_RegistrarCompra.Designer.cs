﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCompra.Infra.Data;

namespace SistemaCompra.API.Migrations
{
    [DbContext(typeof(SistemaCompraContext))]
    [Migration("20230607141817_RegistrarCompra")]
    partial class RegistrarCompra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<Guid?>("SolicitacaoCompraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SolicitacaoCompraId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.NomeFornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("NomeFornecedor");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("NomeFornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioSolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NomeFornecedorId");

                    b.HasIndex("UsuarioSolicitanteId");

                    b.ToTable("SolicitacaoCompras");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UsuarioSolicitante");
                });

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "Preco", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Preco")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.HasOne("SistemaCompra.Domain.ProdutoAggregate.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", null)
                        .WithMany("Itens")
                        .HasForeignKey("SolicitacaoCompraId");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.NomeFornecedor", "NomeFornecedor")
                        .WithMany()
                        .HasForeignKey("NomeFornecedorId");

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", "UsuarioSolicitante")
                        .WithMany()
                        .HasForeignKey("UsuarioSolicitanteId");
                });
#pragma warning restore 612, 618
        }
    }
}
