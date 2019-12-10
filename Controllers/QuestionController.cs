using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamGames.Database.Context;
using DreamGames.Database.Scenarios;

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
    }
}
