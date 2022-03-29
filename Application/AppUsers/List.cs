using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Followers;
using System.Linq;

namespace Application.AppUsers
{
    public class List
    {
        public class Query : IRequest<Result<List<AppUserDto>>>
        {
            public string CurrentUsername { get; set; } // TODO: to remove when implement authentication
        }

        public class Handler : IRequestHandler<Query, Result<List<AppUserDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<AppUserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.AppUsers
                    .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider, new { currentUsername = request.CurrentUsername })
                    .ToListAsync();

                return Result<List<AppUserDto>>.Success(users);
            }
        }
    }
}