using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string UserName { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<UserFollowing> Followings { get; set; } = new List<UserFollowing>();
        public List<UserFollowing> Followers { get; set; } = new List<UserFollowing>();
    }
}