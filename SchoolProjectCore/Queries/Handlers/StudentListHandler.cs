using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProjectCore.Base;
using SchoolProjectCore.Queries.Models;
using SchoolProjectCore.Queries.Response;
using SchoolProjectCore.Warppers;
using SchoolProjectData.Entities;
using ShoolProjectService.Abstract;

namespace SchoolProjectCore.Queries.Handlers
{
    public class StudentListHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
                                                     , IRequestHandler<GetStudentByIdQuery, Response<GetStudentSingleResponse>>
                                                       , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentListHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _studentService.GetStudentsListAsync();
            var result = _mapper.Map<List<GetStudentListResponse>>(entity);
            return Success(result);
        }

        public async Task<Response<GetStudentSingleResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _studentService.GetStudentByIdAsync(request.Id);
            if (entity == null)
                return NotFound<GetStudentSingleResponse>();
            var result = _mapper.Map<GetStudentSingleResponse>(entity);
            return Success(result);

        }

        public Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
