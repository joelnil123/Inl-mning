﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSFIEF;

namespace SSFIEF.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200417121434_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("SSFIEF.Lable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("lables");
                });

            modelBuilder.Entity("SSFIEF.MovieStudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilmStudioName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MovieStudio");
                });

            modelBuilder.Entity("SSFIEF.MovieStudioHandeler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieStudioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("MovieStudioId");

                    b.HasIndex("ReviewId");

                    b.ToTable("MovieStudioHandeler");
                });

            modelBuilder.Entity("SSFIEF.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOfMovies")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRented")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieStudioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieStudioId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SSFIEF.RentedMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieStudioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieStudioId");

                    b.HasIndex("MoviesId");

                    b.ToTable("RentedMovies");
                });

            modelBuilder.Entity("SSFIEF.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SSFIEF.Lable", b =>
                {
                    b.HasOne("SSFIEF.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId");
                });

            modelBuilder.Entity("SSFIEF.MovieStudioHandeler", b =>
                {
                    b.HasOne("SSFIEF.Movies", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSFIEF.MovieStudio", "MovieStudio")
                        .WithMany()
                        .HasForeignKey("MovieStudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSFIEF.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SSFIEF.Movies", b =>
                {
                    b.HasOne("SSFIEF.MovieStudio", null)
                        .WithMany("Movies")
                        .HasForeignKey("MovieStudioId");
                });

            modelBuilder.Entity("SSFIEF.RentedMovies", b =>
                {
                    b.HasOne("SSFIEF.MovieStudio", "MovieStudio")
                        .WithMany()
                        .HasForeignKey("MovieStudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSFIEF.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SSFIEF.Review", b =>
                {
                    b.HasOne("SSFIEF.Movies", null)
                        .WithMany("Reviews")
                        .HasForeignKey("MoviesId");
                });
#pragma warning restore 612, 618
        }
    }
}
