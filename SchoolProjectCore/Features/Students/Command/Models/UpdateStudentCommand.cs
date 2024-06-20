using MediatR;
using SchoolProjectCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Students.Command.Models
{
    public class UpdateStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }


    }
}

