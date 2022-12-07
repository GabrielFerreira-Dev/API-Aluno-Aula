﻿// <auto-generated />
using System;
using AlunoAulaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlunoAulaAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221207012226_APIAulaAluno")]
    partial class APIAulaAluno
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlunoAulaAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Matricula"));

                    b.Property<int?>("AulaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Matricula");

                    b.HasIndex("AulaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("AlunoAulaAPI.Models.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("AlunoAulaAPI.Models.Aluno", b =>
                {
                    b.HasOne("AlunoAulaAPI.Models.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("AulaId");

                    b.Navigation("Aula");
                });
#pragma warning restore 612, 618
        }
    }
}
