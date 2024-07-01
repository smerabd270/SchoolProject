using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Abstract
{
    public interface IDepartmentRepository: IGenericRepositoryAsync<Department>
    {
    }
}
