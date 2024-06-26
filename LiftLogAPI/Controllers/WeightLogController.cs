using LiftLogAPI.Data;
using LiftLogAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiftLogAPI.Controllers
{
    [Route("/api/[controller]s")]
    [ApiController]
    public class WeightLogController : Controller
    {
        private readonly DataContext _context;

        public WeightLogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeightLog>>> GetAll()
        {
            var weightLogs = await _context.WeightLogs.ToListAsync();
            return Ok(weightLogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeightLog>> GetWeightLog(int id)
        {
            var dbWeightLog = await _context.WeightLogs.FindAsync(id);
            if (dbWeightLog is null)
                return NotFound("WeightLog not found");

            return Ok(dbWeightLog);
        }

        [HttpPost]
        public async Task<ActionResult> AddWeightLog(WeightLog newWeightLog)
        {
            _context.WeightLogs.Add(newWeightLog);

            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<WeightLog>> UpdateWeightLog(WeightLog updatedWeightLog)
        {
            var dbWeightLog = await _context.WeightLogs.FindAsync(updatedWeightLog.Id);

            if (dbWeightLog is null)
                return NotFound("WeightLog not found");

            dbWeightLog.Weight = updatedWeightLog.Weight;
            dbWeightLog.ExerciseId = updatedWeightLog.ExerciseId;

            await _context.SaveChangesAsync();

            return Ok(await _context.WeightLogs.FindAsync(updatedWeightLog.Id));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WeightLog>>> DeleteWeightLog(int id)
        {
            var dbWeightLog = await _context.WeightLogs.FindAsync(id);

            if (dbWeightLog is null)
                return NotFound("WeightLog not found");

            _context.WeightLogs.Remove(dbWeightLog);
            await _context.SaveChangesAsync();

            return Ok(await _context.WeightLogs.ToListAsync());
        }
    }
}
