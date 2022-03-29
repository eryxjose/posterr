using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListPosts
    {
        public class Query : IRequest<Result<List<Post>>>
        {
            public string Username { get; set; }
            // public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Post>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<Post>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Posts
                    // .Include(o => o.AppUser)
                    // .Where(u => u.AppUser.UserName == request.Username)
                    .OrderBy(a => a.CreatedAt)
                    .AsQueryable();

                var posts = await query.ToListAsync();

                return Result<List<Post>>.Success(posts);
            }
        }
    }
}