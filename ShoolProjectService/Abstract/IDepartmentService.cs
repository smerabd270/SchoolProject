using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Abstract
{
    public  interface IDepartmentService
    {
        Task<Department> GetById(int id);
    }
}
