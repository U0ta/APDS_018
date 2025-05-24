
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using System.Data.Common;

namespace APDS_018.Data
{
    public class APDSContextDb : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Testing> Testings { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<ParamResult> ParamResults { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=APDS_018Db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Test (1) → Question (N)
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId);

            // Test (1) → Answer (N)
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Test)
                .WithMany(t => t.Answers)
                .HasForeignKey(a => a.TestId);

            // Test (1) → ParamResult (N)
            modelBuilder.Entity<ParamResult>()
                .HasOne(p => p.Test)
                .WithMany(t => t.ParamResults)
                .HasForeignKey(p => p.TestId);

            // Respondent (1) → Testing (N)
            modelBuilder.Entity<Testing>()
                .HasOne(t => t.Respondent)
                .WithMany(r => r.Testings)
                .HasForeignKey(t => t.RespondentId);

            // Test (1) → Testing (N)
            modelBuilder.Entity<Testing>()
                .HasOne(t => t.Test)
                .WithMany(t => t.Testings)
                .HasForeignKey(t => t.TestId);

            // Testing (1) → Protocol (N)
            modelBuilder.Entity<Protocol>()
                .HasOne(p => p.Testing)
                .WithMany(t => t.Protocols)
                .HasForeignKey(p => p.TestingId);

            // Question (1) → Protocol (N)
            modelBuilder.Entity<Protocol>()
                .HasOne(p => p.Question)
                .WithMany(q => q.Protocols)
                .HasForeignKey(p => p.NumQuestion);

            // Answer (1) → Protocol (N)
            modelBuilder.Entity<Protocol>()
                .HasOne(p => p.Answer)
                .WithMany(a => a.Protocols)
                .HasForeignKey(p => p.NumAnswer);

            // Testing (1) → Result (N)
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Testing)
                .WithMany(t => t.Results)
                .HasForeignKey(r => r.TestingId);

            // ParamResult (1) → Result (N)
            modelBuilder.Entity<Result>()
                .HasOne(r => r.ParamResult)
                .WithMany(p => p.Results)
                .HasForeignKey(r => r.ParamResultId);
        }



    }
}
