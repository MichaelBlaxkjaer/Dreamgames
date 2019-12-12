using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamGames.Database.Context;
using DreamGames.Database.Scenarios;
using DreamGames.Database.Games;
using dreamgames.Classes;
using System;

namespace DreamGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ContentContext _context;

        public QuestionController(ContentContext context)
        {
            _context = context;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            // We needed the whole hierachy of questions to be loaded, the easiest way to this was load it all and let EF fix up the relationships.
            _context.Questions.Load();
            _context.Answers.Load();
            _context.Videos.Load();
            _context.VideoSequences.Load();

            // We filter out questions with a parent answer
            return await _context.Questions
                .Where(q => _context.Answers.Where(a => a.FollowUpQuestionId == q.Id).FirstOrDefault() == null)
                .OrderBy(q => q.Ordering)
                .ToListAsync();
        }

        // GET: api/questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var scenario = await _context.Questions.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return scenario;
        }

        // GET: api/question/result
        [HttpPost("result")]
        public ActionResult<Game> GetResult(int[] answerIds)
        {
            var scores = ( 
                from tag in _context.Tags.AsEnumerable()
                join tagpoints in (
                        from tagpoint in _context.TagPoints
                        where answerIds.Contains(tagpoint.AnswerId)
                        select tagpoint
                    )
                    on tag.Id equals tagpoints.TagId into grouping
                where grouping.Sum(tp => tp.Point) > 0
                select new { tag, points = grouping.Sum(tp => tp.Point) }
            ).Take(5).OrderByDescending(t => t.points).ToList();

            var apiFetcher = new ApiFetcher(_context);

            // ugly hack but we're running out of time (as if everything else is pretty)
            for (int amount = scores.Count; amount > 0; amount--) {
                try {
                    var subset = scores.Take(amount).ToDictionary(score => score.tag, score => score.points);
                    return apiFetcher.GetGameFromApi(subset);
                } catch { }
            }

            return null;
        }
    }
}
