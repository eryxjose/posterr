using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Followers
{
    public class FollowToggle
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string TargetUsername { get; set; }
            public string CurrentUsername { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IAppUserAccessor _appUserAcessor;
            public Handler(DataContext context, IAppUserAccessor appUserAcessor)
            {
                _context = context;
                _appUserAcessor = appUserAcessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var observer = await _context.AppUsers.FirstOrDefaultAsync(
                    o => o.UserName == request.CurrentUsername);

                var target = await _context.AppUsers.FirstOrDefaultAsync(
                    o => o.UserName == request.TargetUsername);

                if (target == null || observer == null || observer.UserName == target.UserName)
                    return null;

                var following = await _context.UserFollowings.FindAsync(observer.Id, target.Id);

                if (following == null)
                {
                    following = new UserFollowing
                    {
                        Observer = observer,
                        Target = target
                    };

                    _context.UserFollowings.Add(following);
                }
                else
                {
                    _context.UserFollowings.Remove(following);
                }

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed.");
            }
        }
    }
}