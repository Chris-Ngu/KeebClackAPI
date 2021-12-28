﻿// <auto-generated />
using System;
using KeebClack.API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KeebClack.API.Migrations
{
    [DbContext(typeof(KeyboardDbContext))]
    [Migration("20211228213020_ForeignKey")]
    partial class ForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KeebClack.API.models.Keyboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BoardName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Keycaps")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Switch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserForeignKey")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("_keyboards");
                });

            modelBuilder.Entity("KeebClack.API.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KeebClack.API.models.Keyboard", b =>
                {
                    b.HasOne("KeebClack.API.models.User", "user")
                        .WithMany("Keyboards")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("KeebClack.API.models.User", b =>
                {
                    b.Navigation("Keyboards");
                });
#pragma warning restore 612, 618
        }
    }
}
