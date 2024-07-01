using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using SchoolProjectInfrastrcure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private DbSet<Department> departments;
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            departments=dbContext.Set<Department>();
        }
    }
}
