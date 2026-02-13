using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Data
{
    public class QuizAppContext : DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options)
            : base(options)
        {
        }

        public DbSet<QuizApp.Models.Quiz> Quiz { get; set; } = default!;
        public DbSet<QuizApp.Models.Question> Question { get; set; } = default!;
        public DbSet<QuizApp.Models.AnswerOption> AnswerOption { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);
            
            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerOptions)
                .WithOne(q => q.Question)
                .HasForeignKey(q => q.QuestionId);
        }
    }
}
