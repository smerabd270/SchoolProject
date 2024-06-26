using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>().HasKey(x => new { x.SubID, x.DID });
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });
            modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.InsId, x.SubjectId });
            modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>().HasOne(x => x.Instructor)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                 .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }




    }
}
