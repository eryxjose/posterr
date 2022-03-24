using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;

namespace Application.Posts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Post>>>
        {
            public PagingParams PagingParams { get; set; }
            public FilterParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<Post>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Post>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Posts.AsQueryable();

                return Result<PagedList<Post>>.Success(
                    await PagedList<Post>.CreateAsync(
                        query, request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}