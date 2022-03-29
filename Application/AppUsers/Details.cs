using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.AppUsers
{
    public class Details
    {
        public class Query : IRequest<Result<AppUserDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AppUserDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AppUserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.AppUsers.FindAsync(request.Id);
                
                var user = _mapper.Map<AppUserDto>(query);

                return Result<AppUserDto>.Success(user);
            }
        }
    }
}