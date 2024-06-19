using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Queries.Response
{
    public class GetStudentListResponse
    {
        public int StuID { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

    }
}
