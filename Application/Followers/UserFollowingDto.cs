using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AppUsers;

namespace Application.Followers
{
    public class UserFollowingDto
    {
        public Guid ObserverId { get; set; }
        public AppUserDto Observer { get; set; }
        public Guid TargetId { get; set; }
        public AppUserDto Target { get; set; }
    }
}