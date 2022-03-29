using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AppUsers;
using Domain;

namespace Application.Posts
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string ParentId { get; set; }
        public Guid AppUserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}