﻿// <auto-generated />
using System;
using BlogSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogSystem.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20241219224232_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogSystem.Domain.Posts.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("BlogSystem.Domain.Posts.PostTag", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags", (string)null);
                });

            modelBuilder.Entity("BlogSystem.Domain.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("BlogSystem.Domain.Posts.Post", b =>
                {
                    b.OwnsOne("BlogSystem.Domain.Posts.Author", "Author", b1 =>
                        {
                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Author");

                            b1.HasKey("PostId");

                            b1.ToTable("Posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("BlogSystem.Domain.Posts.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(5000)
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Content");

                            b1.HasKey("PostId");

                            b1.ToTable("Posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("BlogSystem.Domain.Posts.Summary", "Summary", b1 =>
                        {
                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Summary");

                            b1.HasKey("PostId");

                            b1.ToTable("Posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("BlogSystem.Domain.Posts.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Title");

                            b1.HasKey("PostId");

                            b1.ToTable("Posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("Summary")
                        .IsRequired();

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("BlogSystem.Domain.Posts.PostTag", b =>
                {
                    b.HasOne("BlogSystem.Domain.Posts.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogSystem.Domain.Tags.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogSystem.Domain.Tags.Tag", b =>
                {
                    b.OwnsOne("BlogSystem.Domain.Tags.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("TagId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Name");

                            b1.HasKey("TagId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Tags");

                            b1.WithOwner()
                                .HasForeignKey("TagId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("BlogSystem.Domain.Posts.Post", b =>
                {
                    b.Navigation("PostTags");
                });
#pragma warning restore 612, 618
        }
    }
}
