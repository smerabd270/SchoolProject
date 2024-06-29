using MediatR;
using SchoolProjectCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Students.Command.Models
{
    public class AddStudentCommand:IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }


    }
}
