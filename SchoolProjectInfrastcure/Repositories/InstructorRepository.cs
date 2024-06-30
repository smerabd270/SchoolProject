using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using SchoolProjectInfrastrcure.InfrastructureBases;

namespace SchoolProjectInfrastrcure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        private DbSet<Instructor>  instructors;
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
    }
}

