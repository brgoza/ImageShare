﻿// <auto-generated />
using System;
using ImageShare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageShare.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220519012356_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlbumImage", b =>
                {
                    b.Property<Guid>("AlbumsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AlbumsId", "ImagesId");

                    b.HasIndex("ImagesId");

                    b.ToTable("AlbumImages", (string)null);
                });

            modelBuilder.Entity("AlbumTag", b =>
                {
                    b.Property<Guid>("AlbumsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagsTagText")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AlbumsId", "TagsTagText");

                    b.HasIndex("TagsTagText");

                    b.ToTable("AlbumTags", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("ImageShare.Core.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("ImageShare.Core.Models.AlbumSubscriber", b =>
                {
                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.HasKey("AlbumId", "SubscriberId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("AlbumSubscribers", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AppUsers", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Models.LibraryAlbum", b =>
                {
                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LibraryId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("LibraryAlbums", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Models.LibrarySubscriber", b =>
                {
                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.HasKey("LibraryId", "SubscriberId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("LibrarySubscribers", (string)null);
                });

            modelBuilder.Entity("ImageShare.Core.Tag", b =>
                {
                    b.Property<string>("TagText")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TagText");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("ImageTag", b =>
                {
                    b.Property<Guid>("ImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagsTagText")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ImagesId", "TagsTagText");

                    b.HasIndex("TagsTagText");

                    b.ToTable("ImageTags", (string)null);
                });

            modelBuilder.Entity("LibraryImage", b =>
                {
                    b.Property<Guid>("ImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibrariesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImagesId", "LibrariesId");

                    b.HasIndex("LibrariesId");

                    b.ToTable("LibraryImages", (string)null);
                });

            modelBuilder.Entity("LibraryTag", b =>
                {
                    b.Property<Guid>("LibrariesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagsTagText")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LibrariesId", "TagsTagText");

                    b.HasIndex("TagsTagText");

                    b.ToTable("LibraryTags", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AlbumImage", b =>
                {
                    b.HasOne("ImageShare.Core.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumTag", b =>
                {
                    b.HasOne("ImageShare.Core.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagText")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImageShare.Core.Image", b =>
                {
                    b.HasOne("ImageShare.Core.Models.AppUser", "Owner")
                        .WithMany("Images")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ImageShare.Core.Models.AlbumSubscriber", b =>
                {
                    b.HasOne("ImageShare.Core.Album", "Album")
                        .WithMany("AlbumSubscribers")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Models.AppUser", "Subscriber")
                        .WithMany("AlbumSubscribers")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("ImageShare.Core.Models.LibraryAlbum", b =>
                {
                    b.HasOne("ImageShare.Core.Album", "Album")
                        .WithMany("LibraryAlbums")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Library", "Library")
                        .WithMany("LibraryAlbums")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("ImageShare.Core.Models.LibrarySubscriber", b =>
                {
                    b.HasOne("ImageShare.Core.Library", "Library")
                        .WithMany("LibrarySubscribers")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Models.AppUser", "Subscriber")
                        .WithMany("LibrarySubscribers")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("ImageTag", b =>
                {
                    b.HasOne("ImageShare.Core.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagText")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryImage", b =>
                {
                    b.HasOne("ImageShare.Core.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Library", null)
                        .WithMany()
                        .HasForeignKey("LibrariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryTag", b =>
                {
                    b.HasOne("ImageShare.Core.Library", null)
                        .WithMany()
                        .HasForeignKey("LibrariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageShare.Core.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagText")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ImageShare.Core.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ImageShare.Core.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ImageShare.Core.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImageShare.Core.Album", b =>
                {
                    b.Navigation("AlbumSubscribers");

                    b.Navigation("LibraryAlbums");
                });

            modelBuilder.Entity("ImageShare.Core.Library", b =>
                {
                    b.Navigation("LibraryAlbums");

                    b.Navigation("LibrarySubscribers");
                });

            modelBuilder.Entity("ImageShare.Core.Models.AppUser", b =>
                {
                    b.Navigation("AlbumSubscribers");

                    b.Navigation("Images");

                    b.Navigation("LibrarySubscribers");
                });
#pragma warning restore 612, 618
        }
    }
}