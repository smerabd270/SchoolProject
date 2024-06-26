﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProjectCore.Base;
using SchoolProjectCore.Queries.Models;
using SchoolProjectCore.Queries.Response;
using SchoolProjectCore.Resources;
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
        private readonly IStringLocalizer<SharedResources>  _stringLocalizer;

        public StudentListHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer):base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
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
                return NotFound<GetStudentSingleResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetStudentSingleResponse>(entity);
            return Success(result);

        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression =
                          e => new GetStudentPaginatedListResponse(e.StuID, e.NameEn, e.Address, e.Department.GetLocalized());
            var querable = _studentService.GetAllStudentsQueryable( request.OrderBy,request.Search);
            var paginatedList = await querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new {count= paginatedList.Data.Count() };
            return paginatedList;
        }
    }
}
