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

namespace rihal.challenge.Application.Features.Classes.Queries.GetAllClasses
{
    public class GetAllClassesQueryHandler : IRequestHandler<GetAllStudentQuery, ListResult<GetAllStudentDto>>
    {
        private readonly IClassRepo _classRepo;
        private readonly IMapper _mapper;

        public GetAllClassesQueryHandler(IClassRepo classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }
        public async Task<ListResult<GetAllStudentDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Class, bool>> searchExpression = x => request.SearchKey == null ||
                x.Name.Contains(request.SearchKey)
                || x.Name.Contains(request.SearchKey);

            Expression<Func<Class, object>> orderByExpression = x => request.Sorting.OrderBy == StudentsSortingColumn.Name ? x.Id :
                request.Sorting.OrderBy == StudentsSortingColumn.Name? x.Name :
                x.Id;
            IEnumerable<Class> items;
            if (request.Sorting.OrderByDirection == OrderDirection.ASC)
            {
                items = await _classRepo.ListOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }
            else
            {
                items = await _classRepo.ListDescendingOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }

            ListResult<GetAllStudentDto> result = new ListResult<GetAllStudentDto>
            {
                Items = _mapper.Map<IEnumerable<GetAllStudentDto>>(items),
                TotalCount = await _classRepo.GetTotalCount(searchExpression)
            };
            return result;
        }
    }
}



