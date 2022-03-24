using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Linq;

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

                if (!string.IsNullOrEmpty(request.Params.AppUserId.ToString()))
                    query = query.Where(o => o.AppUserId == request.Params.AppUserId);

                if (request.Params.OnlyRePosts) 
                    query = query.Where(o => o.ParentId != "");

                if (request.Params.OnlyQuotePosts) 
                    query = query.Where(o => o.ParentId != "" && o.Text != "");

                return Result<PagedList<Post>>.Success(
                    await PagedList<Post>.CreateAsync(
                        query, request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}