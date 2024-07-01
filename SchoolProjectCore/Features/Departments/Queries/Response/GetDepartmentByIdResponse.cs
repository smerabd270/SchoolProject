using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Departments.Queries.Response
{
    public  class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<StudentResponse>? StudentList { get; set; }
        public List<InstructortResponse>? InstructortList { get; set; }
        public class StudentResponse
        {
            public int Id { get; set; }
            public string Name { get; set;}
          


        }
        public class SubjectResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class InstructortResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
