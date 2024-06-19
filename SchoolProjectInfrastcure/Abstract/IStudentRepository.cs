using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Abstract
{
    public  interface IStudentRepository
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddStudentASync(Student student);
    }
}
