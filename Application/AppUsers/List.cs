using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;


namespace Application.AppUsers
{
    public class List
    {
        public class Query : IRequest<Result<List<AppUser>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<AppUser>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<AppUser>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.AppUsers.AsQueryable();
                
                return Result<List<AppUser>>.Success(await query.ToListAsync());
            }
        }
    }
}