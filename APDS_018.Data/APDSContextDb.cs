
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace APDS_018.Data
{
    public class APDSContextDb : DbContext
    {
        public APDSContextDb() { }
        public APDSContextDb(DbContextOptions<APDSContextDb> options)
            : base(options)
        {
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Testing> Testings { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<ParamResult> ParamResults { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
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
                .HasForeignKey(p => p.TestingId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .HasForeignKey(r => r.TestingId)
                .OnDelete(DeleteBehavior.Cascade);

            // ParamResult (1) → Result (N)
            modelBuilder.Entity<Result>()
                .HasOne(r => r.ParamResult)
                .WithMany(p => p.Results)
                .HasForeignKey(r => r.ParamResultId);
        }



    }
}
