using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Abstract
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student> GetStudentByIdAsync(int Id);
        Task<string> AddStudentASync(Student student);
        Task<bool> IsNameExit(string name);
        Task <string>UpdateStudentAsync(Student student);
        Task<string> DeleteStudentAsync(int Id);


    }
}
