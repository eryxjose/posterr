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
        
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UserFollowing> Followings { get; set; } = new List<UserFollowing>();
        public ICollection<UserFollowing> Followers { get; set; } = new List<UserFollowing>();
    }
}