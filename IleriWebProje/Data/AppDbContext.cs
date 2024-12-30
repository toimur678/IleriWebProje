﻿using IleriWebProje.Models;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentors_Skills>().HasKey(ms => new
            {
                ms.MentorID,
                ms.SkillID
            });

            modelBuilder.Entity<Mentors_Skills>()
                .HasOne(ms => ms.Mentors)
                .WithMany(m => m.Mentors_Skills)
                .HasForeignKey(ms => ms.MentorID);

            modelBuilder.Entity<Mentors_Skills>()
                .HasOne(ms => ms.Skills)
                .WithMany(s => s.Mentors_Skills)
                .HasForeignKey(ms => ms.SkillID);

            modelBuilder.Entity<Skills>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Skills>()
                .HasOne(s => s.Platforms)
                .WithMany(p => p.Skills)
                .HasForeignKey(s => s.PlatformId);

            modelBuilder.Entity<Skills>()
                .HasOne(s => s.Skill_Organizers)
                .WithMany(o => o.Skills)
                .HasForeignKey(s => s.SkillOrganizerID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mentors> Mentors { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Mentors_Skills> Mentors_Skills { get; set; }
        public DbSet<Platforms> Platforms { get; set; }
        public DbSet<SkillOrganizers> Skill_Organizers { get; set; }
    }
}
