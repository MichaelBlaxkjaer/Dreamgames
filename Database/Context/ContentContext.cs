using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamGamesAPI.Database.Games;
using DreamGamesAPI.Database.Scenarios;
using Microsoft.EntityFrameworkCore;

namespace DreamGamesAPI.Database.Context
{
    public class ContentContext : DbContext
    { 

        public ContentContext(DbContextOptions<ContentContext> options)
        : base(options)
        {

        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public DbSet<TagPoint> TagPoints { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scenario>().HasData(
                new Scenario() 
                {
                    Id = 1,
                    Numbering = 1,
                    Title = "AScenario"
                }
            );
            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 1,
                    ScenarioId = 1,
                    Description = "Description",
                    Ordering = 1,
                });
            modelBuilder.Entity<Answer>().HasData(
                    new Answer()
                    {
                        Id = 1,
                        AnswerOrder = 1,
                        FollowUpQuestionId = 1,
                        ImagePath = "A Path",
                        OutroVideo = "Outro Vid",
                        QuestionId = 1,
                        
                        Text = "Text"
                    });
            modelBuilder.Entity<TagPoint>().HasData(
                new TagPoint()
                {
                    Id = 1,
                    AnswerId = 1,
                    Point = 10,
                    TagId = 2
                });
            modelBuilder.Entity<Video>().HasData(
                new Video()
                {
                    Id = 1,
                    Order = 1,
                    QuestionId = 1,
                    UrlPath = "APathToAVideo"
                });
             modelBuilder.Entity<Sound>().HasData(
                new Sound()
                {
                    Id = 1,
                    VideoId = 1,
                    Order = 1,
                    UrlPath = "APathToSound"
                });
             modelBuilder.Entity<Tag>().HasData(
                 new Tag(){Id = 1, TagName = "Singleplayer", Slug = "singleplayer", RawGTagId = 31},
                 new Tag(){Id = 2, TagName = "Multiplayer", Slug = "multiplayer", RawGTagId = 7},
                 new Tag(){Id = 3, TagName = "Great Soundtrack", Slug = "great-soundtrack", RawGTagId = 42},
                 new Tag(){Id = 4, TagName = "RPG", Slug = "rpg", RawGTagId = 24},
                 new Tag(){Id = 5, TagName = "Story Rich", Slug = "story-rich", RawGTagId = 118},
                 new Tag(){Id = 6, TagName = "Open World", Slug = "open-world", RawGTagId = 36},
                 new Tag(){Id = 7, TagName = "Sci-fi", Slug = "sci-fi", RawGTagId = 32 },
                 new Tag(){Id = 8, TagName = "Horror", Slug = "horror", RawGTagId = 16 },
                 new Tag(){Id = 9, TagName = "Fantasy", Slug = "fantasy", RawGTagId = 64 }
                 );
        }
    }
}
