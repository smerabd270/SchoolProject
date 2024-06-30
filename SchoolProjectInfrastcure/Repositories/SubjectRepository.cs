using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using SchoolProjectInfrastrcure.InfrastructureBases;

namespace SchoolProjectInfrastrcure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private DbSet<Subject> subjects;
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subject>();
        }
    }
}

