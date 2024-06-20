using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProjectCore.Base;
using SchoolProjectCore.Features.Students.Command.Models;
using SchoolProjectData.Entities;
using ShoolProjectService.Abstract;

namespace SchoolProjectCore.Features.Students.Command.Hnadlers
{
    public class StudentCommandHandler
                                        : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
                                                           IRequestHandler<UpdateStudentCommand, Response<string>>,
                                                           IRequestHandler<DeleteStudentCommand, Response<string>>


    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Student>(request);
           var result=await  _studentService.AddStudentASync(mappedEntity);
            if (result == "success")
                return SuccessMessage<string>(null);
            return BadRequest<string>(null);
        }

        public async  Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Student>(request);
            var result= await _studentService.UpdateStudentAsync(mappedEntity);
        
                return SuccessMessage<string>(result);
           
        }

        public async  Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.DeleteStudentAsync(request.Id);

            return SuccessMessage<string>(result);
        }
    }
}
