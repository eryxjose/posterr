using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Persistence;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Followers
{
    public class List
    {
        public class Query : IRequest<Result<List<Profiles.Profile>>>
        {
            public string Predicate { get; set; }
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Profiles.Profile>>>
        {
            private readonly DataContext _context;

            private readonly IMapper _mapper;
            private readonly IAppUserAccessor _accessor;

            public Handler(DataContext context, IMapper mapper, IAppUserAccessor accessor)
            {
                _context = context;
                _mapper = mapper;
                _accessor = accessor;
            }

            public async Task<Result<List<Profiles.Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profiles = new List<Profiles.Profile>();

                switch (request.Predicate)
                {
                    case "followers":
                        profiles = await _context.UserFollowings.Where(x => x.Target.UserName == request.Username)
                            .Select(u => u.Observer)
                            .ProjectTo<Profiles.Profile>(_mapper.ConfigurationProvider, 
                                new {currentUsername = _accessor.GetUsername() }) 
                            .ToListAsync();
                        break;
                    case "following":
                        profiles = await _context.UserFollowings.Where(x => x.Observer.UserName == request.Username)
                            .Select(u => u.Target)
                            .ProjectTo<Profiles.Profile>(_mapper.ConfigurationProvider, 
                                new {currentUsername = _accessor.GetUsername() })
                            .ToListAsync();
                        break;
                }

                return Result<List<Profiles.Profile>>.Success(profiles);
            }
        }
    }
}