using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string ParentId { get; set; }
        public Guid AppUserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}