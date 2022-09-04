using AutoMapper;
using MediatR;
using rihal.challenge.Application.Features.Students.Queries.GetAllStudents;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;
using rihal.challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Students.Queries.GetAllStudent
{
    public class GetAllTaxTypesQueryHandler : IRequestHandler<GetAllStudentQuery, ListResult<GetAllStudentDto>>
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public GetAllTaxTypesQueryHandler(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }
        public async Task<ListResult<GetAllStudentDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, bool>> searchExpression = x => request.SearchKey == null ||
                x.Name.Contains(request.SearchKey)
                || x.Name.Contains(request.SearchKey);

            Expression<Func<Student, object>> orderByExpression = x => request.Sorting.OrderBy == StudentsSortingColumn.Name ? x.Id :
                request.Sorting.OrderBy == StudentsSortingColumn.Name? x.Name :
                x.Id;
            IEnumerable<Student> items;
            if (request.Sorting.OrderByDirection == OrderDirection.ASC)
            {
                items = await _studentRepo.ListOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }
            else
            {
                items = await _studentRepo.ListDescendingOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }

            ListResult<GetAllStudentDto> result = new ListResult<GetAllStudentDto>
            {
                Items = _mapper.Map<IEnumerable<GetAllStudentDto>>(items),
                TotalCount = await _studentRepo.GetTotalCount(searchExpression)
            };
            return result;
        }
    }
}



