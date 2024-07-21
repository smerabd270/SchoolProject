using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities.Identity;
using System.Data;

namespace SchoolProjectInfrastrcure.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }

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
