using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _ApplicationDBContext;
        public StudentRepository(ApplicationDBContext ApplicationDBContext)
        {
            _ApplicationDBContext = ApplicationDBContext;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _ApplicationDBContext.students.Include(x => x.Department)
                .ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _ApplicationDBContext.students
                .Include(x => x.Department).AsNoTracking()
                .FirstOrDefaultAsync(x => x.StuID == id);
        }
        public async Task<string> AddStudentASync(Student student)
        {
            var exsitStudent = await _ApplicationDBContext.students.Where(x => x.NameEn == student.NameEn).FirstOrDefaultAsync();
            if (exsitStudent != null)

                return "exsit";
            else
            {
             await   _ApplicationDBContext.students.AddAsync(student);
               await _ApplicationDBContext.SaveChangesAsync();
                return "success";
            }


        }
        public async Task<bool>IsNameExit(string name)
        {
            return await _ApplicationDBContext.students.AnyAsync(x => x.NameEn == name);
        }
        public async Task<string> UpdateStudentAsync(Student student)
        {
            try
            {
                _ApplicationDBContext.students.Update(student);
                await _ApplicationDBContext.SaveChangesAsync();
                return ("Sccuess");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
             
        }
        public async Task<string> DeleteStudentAsync(int Id)
        {
            try
            {
              var student= await  _ApplicationDBContext.students.Where(x=>x.StuID== Id).FirstAsync();
                 _ApplicationDBContext.students.Remove(student);
                await _ApplicationDBContext.SaveChangesAsync();
                return ("Sccuess");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }

        }
        public IQueryable<Student> GetAllStudentsQueryable()
        {
            return _ApplicationDBContext.students.Include (x=>x.Department).AsQueryable();
        }
    }
}
