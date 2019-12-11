using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dreamgames.Database.Games;
using DreamGames.Database.Games;
using dreamgames.Database.Scenarios;
using DreamGames.Database.Scenarios;
using Microsoft.EntityFrameworkCore;

namespace DreamGames.Database.Context
{
    public class ContentContext : DbContext
    {

        public ContentContext(DbContextOptions<ContentContext> options)
        : base(options)
        {

        }
        //All DbSets seen here are tables in the database, the tables have the same name as each DbSet
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TagPoint> TagPoints { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VideoSequence> VideoSequences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameTagJunction> GameTagJunction { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }

        //When using add-migration command, it will use the data under here
        //to populate the database with some information.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(model =>
            {
                model.HasKey(q => q.Id);
                model.HasMany(q => q.Answers).WithOne().HasForeignKey(a => a.QuestionId);
                model.HasOne(q => q.IntroVideo).WithMany();
            });

            modelBuilder.Entity<Answer>(model =>
            {
                model.HasKey(a => a.Id);
                model.HasOne(a => a.FollowUpQuestion).WithMany().HasForeignKey(a => a.FollowUpQuestionId);
                model.HasOne(q => q.OutroVideo).WithMany();
            });

            modelBuilder.Entity<VideoSequence>(model =>
            {
                model.HasKey(s => s.Id);
                model.HasMany(s => s.Videos).WithOne().HasForeignKey(v => v.VideoSequenceId);
            });

            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 1,
                    Description = "Description",
                    Ordering = 1,
                    IntroVideoId = 1
                },
                new Question()
                {
                    Id = 2,
                    Description = "Another question",
                    Ordering = 1
                });
                
            modelBuilder.Entity<Answer>().HasData(
                new Answer()
                {
                    Id = 1,
                    AnswerOrder = 1,
                    FollowUpQuestionId = 2,
                    QuestionId = 1,

                    Text = "Text"
                },
                new Answer()
                {
                    Id = 2,
                    AnswerOrder = 1,
                    QuestionId = 2,

                    Text = "Some text"
                });

            modelBuilder.Entity<TagPoint>().HasData(
                new TagPoint()
                {
                    Id = 1,
                    AnswerId = 1,
                    Point = 10,
                    TagId = 2
                });

            modelBuilder.Entity<VideoSequence>().HasData(
                new VideoSequence()
                {
                    Id = 1
                });

            modelBuilder.Entity<Video>().HasData(
                new Video()
                {
                    Id = 1,
                    Order = 1,
                    Path = "music-intro.webm",
                    VideoSequenceId = 1
                },
                new Video()
                {
                    Id = 2,
                    Order = 2,
                    Path = "music-streets.webm",
                    AmbiencePath = "city-ambience.mp3",
                    VideoSequenceId = 1
                });

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1, TagName = "Singleplayer", Slug = "singleplayer", RawGTagId = 31 },
                new Tag() { Id = 2, TagName = "Multiplayer", Slug = "multiplayer", RawGTagId = 7 },
                new Tag() { Id = 3, TagName = "Great Soundtrack", Slug = "great-soundtrack", RawGTagId = 42 },
                new Tag() { Id = 4, TagName = "RPG", Slug = "rpg", RawGTagId = 24 },
                new Tag() { Id = 5, TagName = "Story Rich", Slug = "story-rich", RawGTagId = 118 },
                new Tag() { Id = 6, TagName = "Open World", Slug = "open-world", RawGTagId = 36 },
                new Tag() { Id = 7, TagName = "Sci-fi", Slug = "sci-fi", RawGTagId = 32 },
                new Tag() { Id = 8, TagName = "Horror", Slug = "horror", RawGTagId = 16 },
                new Tag() { Id = 9, TagName = "Fantasy", Slug = "fantasy", RawGTagId = 64 }
            );
        }
    }
}
