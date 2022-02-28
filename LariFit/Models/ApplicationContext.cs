using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LariFit.Models;
using LariFit.Models.Trainings;

namespace LariFit.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Measurement> Measurements { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<PerformingExercise> TrainingExercises { get; set; } = null!;
        public DbSet<ExerciseSet> ExerciseSets { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}