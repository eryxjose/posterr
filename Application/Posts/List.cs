using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Application.AppUsers;

namespace Application.Posts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<PostDto>>>
        {
            public PagingParams PagingParams { get; set; }
            public FilterParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<PostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = _context.Posts.Include(o => o.AppUser).AsQueryable();

                if (request.Params.OnlyFollowing)
                    posts = posts.Where(o => o.AppUser.Followers.Any(x => 
                        x.Observer.UserName == request.Params.CurrentUsername));

                var result = posts.ProjectTo<PostDto>(_mapper.ConfigurationProvider, 
                        new {currentUsername = request.Params.CurrentUsername});
                
                return Result<PagedList<PostDto>>.Success(
                    await PagedList<PostDto>.CreateAsync(
                        result, request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}