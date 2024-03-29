﻿// <auto-generated />
using System;
using LibraryControllerAPIs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryControllerAPIs.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240209064749_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryControllerAPIs.Models.Author", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryControllerAPIs.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryControllerAPIs.Models.Book+BookCopy", b =>
                {
                    b.Property<string>("CopyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("CopyId");

                    b.HasIndex("BookISBN");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("LibraryControllerAPIs.Models.Book+BookCopy", b =>
                {
                    b.HasOne("LibraryControllerAPIs.Models.Book", null)
                        .WithMany("Copies")
                        .HasForeignKey("BookISBN");
                });

            modelBuilder.Entity("LibraryControllerAPIs.Models.Book", b =>
                {
                    b.Navigation("Copies");
                });
#pragma warning restore 612, 618
        }
    }
}
