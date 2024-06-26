using LiftLogAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiftLogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }
    }
}
