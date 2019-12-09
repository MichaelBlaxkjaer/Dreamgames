using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamGames.Database.Context;
using DreamGames.Database.Scenarios;

namespace DreamGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenariosController : ControllerBase
    {
        private readonly ContentContext _context;

        public ScenariosController(ContentContext context)
        {
            _context = context;
        }

        // GET: api/Scenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> GetScenarios()
        {
            //Here I populate variables with information from the database.
            //The reason I do it here is to avoid sending out a new call
            //Each time the for loop, loops.
            var scenarios = _context.Scenarios.ToList();
            var answers = _context.Answers.ToList();
            var questions = _context.Questions.ToList();
            var sounds = _context.Sounds.ToList();
            var tagPoints = _context.TagPoints.ToList();
            var videos = _context.Videos.ToList();
            var tags = _context.Tags.ToList();

            for (int i = 0; i < scenarios.Count; i++)
            {
                scenarios[i].Question = questions.Where(e => e.ScenarioId == scenarios[i].Id).ToList();
                for (int j = 0; j < scenarios[i].Question.Count; j++)
                {
                    scenarios[i].Question[j].Answers =
                        answers.Where(e => e.QuestionId == scenarios[i].Question[j].Id).ToList();
                    scenarios[i].Question[j].Video =
                        videos.Where(e => e.QuestionId == scenarios[i].Question[j].Id).ToList();
                    for (int k = 0; k < scenarios[i].Question[j].Answers.Count; k++)
                    {
                        scenarios[i].Question[j].Answers[k].TagPoints =
                            tagPoints.Where(e => e.AnswerId == scenarios[i].Question[j].Answers[k].Id).ToList();
                    }

                    for (int k = 0; k < scenarios[i].Question[j].Video.Count; k++)
                    {
                        scenarios[i].Question[j].Video[k].Sound = 
                            sounds.Where(e => e.VideoId == scenarios[i].Question[j].Video[k].Id).ToList();
                    }
                }
            }
            return scenarios;
            //return await _context.Scenarios.ToListAsync();
        }

        // GET: api/Scenarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scenario>> GetScenario(int id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return scenario;
        }

        //Here we get the the next question by sending along the number inside the variable called "FollowUpQuestionId"
        // GET: api/Scenarios/GetFollowUpQuestion/1
        [HttpGet("GetFollowUpQuestion/{id}")]
        public async Task<ActionResult<Question>> GetFollowUpQuestion(int id)
        {

            return await _context.Questions.FindAsync(id); ;
        }

        // PUT: api/Scenarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScenario(int id, Scenario scenario)
        {
            if (id != scenario.Id)
            {
                return BadRequest();
            }

            _context.Entry(scenario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scenarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            _context.Scenarios.Add(scenario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScenario", new { id = scenario.Id }, scenario);
        }

        // DELETE: api/Scenarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scenario>> DeleteScenario(int id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            _context.Scenarios.Remove(scenario);
            await _context.SaveChangesAsync();

            return scenario;
        }

        private bool ScenarioExists(int id)
        {
            return _context.Scenarios.Any(e => e.Id == id);
        }
    }
}
