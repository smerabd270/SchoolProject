using MediatR;
using SchoolProjectCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Features.Students.Command.Models
{
    public  class DeleteStudentCommand: IRequest<Response<string>>
    {
        public int Id { get; set; } 
    public DeleteStudentCommand(int Id)
        {
            this.Id=Id;
        }

    }
}
