using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> GetById(int id)
        {
            return await _departmentRepository.GetTableNoTracking().Where(x => x.DID == id)
                 .Include(x => x.DepartmentSubjects).ThenInclude(x=>x.Subject)
                 .Include(x => x.Students)
                 .Include(x => x.Instructor)
                  .Include(x => x.Instructors).FirstOrDefaultAsync();

        }
    }
}
