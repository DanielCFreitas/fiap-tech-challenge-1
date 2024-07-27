﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TechChallenge.Infrastructure.Data;

#nullable disable

namespace TechChallenge.Infrastructure.Migrations
{
    [DbContext(typeof(TechChallengeDbContext))]
    partial class TechChallengeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TechChallenge.Domain.Entities.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contatos", (string)null);
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Contato", b =>
                {
                    b.OwnsOne("TechChallenge.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ContatoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("EnderecoDeEmail")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("Email");

                            b1.HasKey("ContatoId");

                            b1.ToTable("Contatos");

                            b1.WithOwner()
                                .HasForeignKey("ContatoId");
                        });

                    b.OwnsOne("TechChallenge.Domain.ValueObjects.Regiao", "Regiao", b1 =>
                        {
                            b1.Property<Guid>("ContatoId")
                                .HasColumnType("uuid");

                            b1.Property<int>("DDD")
                                .HasColumnType("integer")
                                .HasColumnName("DDD");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("VARCHAR(2)")
                                .HasColumnName("Estado");

                            b1.HasKey("ContatoId");

                            b1.ToTable("Contatos");

                            b1.WithOwner()
                                .HasForeignKey("ContatoId");
                        });

                    b.OwnsOne("TechChallenge.Domain.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("ContatoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("VARCHAR(9)")
                                .HasColumnName("Telefone");

                            b1.HasKey("ContatoId");

                            b1.ToTable("Contatos");

                            b1.WithOwner()
                                .HasForeignKey("ContatoId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Regiao")
                        .IsRequired();

                    b.Navigation("Telefone")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
