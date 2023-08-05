using EF012.CodeFirstMigration.Data.Config;
using EF012.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF012.CodeFirstMigration.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var pathConnectionString = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build()
                .GetSection("constr").Value;
            optionsBuilder.UseSqlServer(pathConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        }

    }
}
