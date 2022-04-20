﻿// <auto-generated />
using System;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    [DbContext(typeof(HelloFriendsContext))]
    [Migration("20211016185408_AdicaoColunaSituacaoAluno_CriaTabelaModulo")]
    partial class AdicaoColunaSituacaoAluno_CriaTabelaModulo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelloFriendsAPI.Model.Aluno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAniversario");

                    b.Property<string>("Email");

                    b.Property<string>("Imagem");

                    b.Property<string>("NomeCompleto");

                    b.Property<string>("NomeResponsavel");

                    b.Property<string>("Situacao");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.Modulo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeModulo");

                    b.HasKey("Id");

                    b.ToTable("Modulo");
                });
#pragma warning restore 612, 618
        }
    }
}