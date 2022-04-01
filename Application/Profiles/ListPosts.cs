using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Posts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListPosts
    {
        public class Query : IRequest<Result<PagedList<PostDto>>>
        {
            public string Username { get; set; }
            public PagingParams PagingParams { get; set; }

            // public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<PostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentUser = _context.AppUsers.FirstOrDefault(o => o.UserName == request.Username);

                var query = _context.Posts
                    .Where(u => u.AppUserId == currentUser.Id)
                    .OrderBy(a => a.CreatedAt)
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider);

                return Result<PagedList<PostDto>>.Success(
                    await PagedList<PostDto>.CreateAsync(
                        query, request.PagingParams.PageNumber, request.PagingParams.PageSize));
            }
        }
    }
}