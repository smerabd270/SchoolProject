using MediatR;
using SchoolProjectCore.Base;
using SchoolProjectCore.Queries.Response;
using SchoolProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Queries.Models
{
    public  class GetStudentByIdQuery:IRequest<Response<GetStudentSingleResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id= id;
        }
        public int Id { get; set; } 
    }
}
