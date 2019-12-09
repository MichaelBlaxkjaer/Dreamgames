﻿// <auto-generated />
using DreamGamesAPI.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dreamgames.Migrations
{
    [DbContext(typeof(ContentContext))]
    [Migration("20191209081223_Initial migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("DreamGamesAPI.Database.Games.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RawGTagId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RawGTagId = 31,
                            Slug = "singleplayer",
                            TagName = "Singleplayer"
                        },
                        new
                        {
                            Id = 2,
                            RawGTagId = 7,
                            Slug = "multiplayer",
                            TagName = "Multiplayer"
                        },
                        new
                        {
                            Id = 3,
                            RawGTagId = 42,
                            Slug = "great-soundtrack",
                            TagName = "Great Soundtrack"
                        },
                        new
                        {
                            Id = 4,
                            RawGTagId = 24,
                            Slug = "rpg",
                            TagName = "RPG"
                        },
                        new
                        {
                            Id = 5,
                            RawGTagId = 118,
                            Slug = "story-rich",
                            TagName = "Story Rich"
                        },
                        new
                        {
                            Id = 6,
                            RawGTagId = 36,
                            Slug = "open-world",
                            TagName = "Open World"
                        },
                        new
                        {
                            Id = 7,
                            RawGTagId = 32,
                            Slug = "sci-fi",
                            TagName = "Sci-fi"
                        },
                        new
                        {
                            Id = 8,
                            RawGTagId = 16,
                            Slug = "horror",
                            TagName = "Horror"
                        },
                        new
                        {
                            Id = 9,
                            RawGTagId = 64,
                            Slug = "fantasy",
                            TagName = "Fantasy"
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnswerOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowUpQuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("OutroVideo")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerOrder = 1,
                            FollowUpQuestionId = 1,
                            ImagePath = "A Path",
                            OutroVideo = "Outro Vid",
                            QuestionId = 1,
                            Text = "Text"
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordering")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScenarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Ordering = 1,
                            ScenarioId = 1
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numbering")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Scenarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Numbering = 1,
                            Title = "AScenario"
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.Sound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlPath")
                        .HasColumnType("TEXT");

                    b.Property<int>("VideoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Sounds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Order = 1,
                            UrlPath = "APathToSound",
                            VideoId = 1
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.TagPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnswerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TagPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerId = 1,
                            Point = 10,
                            TagId = 2
                        });
                });

            modelBuilder.Entity("DreamGamesAPI.Database.Scenarios.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlPath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Order = 1,
                            QuestionId = 1,
                            UrlPath = "APathToAVideo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
