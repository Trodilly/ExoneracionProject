using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Models;

namespace ExoneracionProject.Data
{
    public class RecruitContext : DbContext
    {
        public RecruitContext (DbContextOptions<RecruitContext> options)
          : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Competences> Competences { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Administrator");
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");
            modelBuilder.Entity<Job>().ToTable("Jobs");
            modelBuilder.Entity<Competences>().ToTable("Competences");
            modelBuilder.Entity<JobExperience>().ToTable("JobExperiences");
        }
    }
}
