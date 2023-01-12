﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalBoardGames.Entities;

#nullable disable

namespace RentalBoardGames.Migrations
{
    [DbContext(typeof(MyBoardsContext))]
    partial class MyBoardsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameTag", b =>
                {
                    b.Property<int>("BoardGamesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("BoardGamesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BoardGameTag");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coutry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Jabłonna",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Pruszków",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            City = "Warszawa",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("RentalBoardGames.Entities.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_of_players")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<bool?>("availability")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BoardGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brzdek nie draznij smoka",
                            Numberofplayers = 4
                        },
                        new
                        {
                            Id = 2,
                            Name = "Everdell",
                            Numberofplayers = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nemesis",
                            Numberofplayers = 5
                        });
                });

            modelBuilder.Entity("RentalBoardGames.Entities.BoardGameComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("UserId");

                    b.ToTable("BoardGameComments");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Semi-coop"
                        },
                        new
                        {
                            Id = 4,
                            Value = "Euro"
                        });
                });

            modelBuilder.Entity("RentalBoardGames.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dsds@wp.pl",
                            FirstName = "Marcin",
                            LastName = "Skowroński",
                            UserType = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "mateusz@wp.pl",
                            FirstName = "Mateusz",
                            LastName = "Polak",
                            UserType = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "Kamil@wp.pl",
                            FirstName = "Kamil",
                            LastName = "Chmielewski",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("RentalBoardGames.Entities.ViewModels.TopAuthor", b =>
                {
                    b.Property<int>("CommentsCreated")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("View_TopAuthors", (string)null);
                });

            modelBuilder.Entity("BoardGameTag", b =>
                {
                    b.HasOne("RentalBoardGames.Entities.BoardGame", null)
                        .WithMany()
                        .HasForeignKey("BoardGamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalBoardGames.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalBoardGames.Entities.Adress", b =>
                {
                    b.HasOne("RentalBoardGames.Entities.User", "User")
                        .WithOne("Adress")
                        .HasForeignKey("RentalBoardGames.Entities.Adress", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.BoardGame", b =>
                {
                    b.HasOne("RentalBoardGames.Entities.User", null)
                        .WithMany("Rented_Games")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.BoardGameComment", b =>
                {
                    b.HasOne("RentalBoardGames.Entities.BoardGame", "BoardGame")
                        .WithMany("Comments")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalBoardGames.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.Transaction", b =>
                {
                    b.HasOne("RentalBoardGames.Entities.BoardGame", "BoardGame")
                        .WithMany("Transactions")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalBoardGames.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.BoardGame", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("RentalBoardGames.Entities.User", b =>
                {
                    b.Navigation("Adress");

                    b.Navigation("Comments");

                    b.Navigation("Rented_Games");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
