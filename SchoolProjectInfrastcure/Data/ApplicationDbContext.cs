using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }





    }
}
