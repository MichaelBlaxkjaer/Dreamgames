﻿// <auto-generated />
using System;
using DreamGames.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dreamgames.Migrations
{
    [DbContext(typeof(ContentContext))]
    partial class ContentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("DreamGames.Database.Games.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("AvgRating")
                        .HasColumnType("REAL");

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Trailer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DreamGames.Database.Games.Screenshot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ScreenshotUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Screenshots");
                });

            modelBuilder.Entity("DreamGames.Database.Games.Tag", b =>
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

            modelBuilder.Entity("DreamGames.Database.Scenarios.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnswerOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FollowUpQuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OutroVideoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FollowUpQuestionId");

                    b.HasIndex("OutroVideoId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerOrder = 1,
                            FollowUpQuestionId = 2,
                            QuestionId = 1,
                            Text = "Text"
                        },
                        new
                        {
                            Id = 2,
                            AnswerOrder = 1,
                            QuestionId = 2,
                            Text = "Some text"
                        });
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IntroVideoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MotivePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordering")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IntroVideoId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            IntroVideoId = 1,
                            Ordering = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Another question",
                            Ordering = 1
                        });
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.TagPoint", b =>
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

                    b.HasIndex("AnswerId");

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

            modelBuilder.Entity("DreamGames.Database.Scenarios.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AmbiencePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VideoSequenceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VideoSequenceId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Order = 1,
                            Path = "music-intro.webm",
                            VideoSequenceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AmbiencePath = "city-ambience.mp3",
                            Order = 2,
                            Path = "music-streets.webm",
                            VideoSequenceId = 1
                        });
                });

            modelBuilder.Entity("dreamgames.Database.Games.GameTagJunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("GameTagJunction");
                });

            modelBuilder.Entity("dreamgames.Database.Scenarios.VideoSequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("VideoSequences");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.Answer", b =>
                {
                    b.HasOne("DreamGames.Database.Scenarios.Question", "FollowUpQuestion")
                        .WithMany()
                        .HasForeignKey("FollowUpQuestionId");

                    b.HasOne("dreamgames.Database.Scenarios.VideoSequence", "OutroVideo")
                        .WithMany()
                        .HasForeignKey("OutroVideoId");

                    b.HasOne("DreamGames.Database.Scenarios.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.Question", b =>
                {
                    b.HasOne("dreamgames.Database.Scenarios.VideoSequence", "IntroVideo")
                        .WithMany()
                        .HasForeignKey("IntroVideoId");
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.TagPoint", b =>
                {
                    b.HasOne("DreamGames.Database.Scenarios.Answer", null)
                        .WithMany("TagPoints")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DreamGames.Database.Scenarios.Video", b =>
                {
                    b.HasOne("dreamgames.Database.Scenarios.VideoSequence", null)
                        .WithMany("Videos")
                        .HasForeignKey("VideoSequenceId");
                });
#pragma warning restore 612, 618
        }
    }
}
