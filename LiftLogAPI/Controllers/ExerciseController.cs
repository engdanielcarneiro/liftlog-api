using LiftLogAPI.Data;
using LiftLogAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiftLogAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly DataContext _context;

        public ExerciseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetAll()
        {
            var exercises = await _context.Exercises.ToListAsync();

           return Ok(exercises);
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise is null)
                return NotFound("Exercise not found");

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> AddExercise(Exercise newExercise)
        {
            _context.Exercises.Add(newExercise);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<Exercise>> UpdateExercise(Exercise updatedExercise)
        {
            var dbExercise = await _context.Exercises.FindAsync(updatedExercise.Id);

            if (dbExercise is null)
                return NotFound("Exercise not found");

            dbExercise.Name = updatedExercise.Name;
            dbExercise.Category = updatedExercise.Category;
            dbExercise.Description = updatedExercise.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Exercises.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercise>> DeleteExercise(int id)
        {
            var dbExercise = await _context.Exercises.FindAsync(id);

            if (dbExercise is null)
                return NotFound("Exercise not found");

            _context.Exercises.Remove(dbExercise);
            await _context.SaveChangesAsync();

            return Ok(await _context.Exercises.ToListAsync());
        }
    }
}
