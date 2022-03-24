using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Posts
{
    public class FilterParams : PagingParams
    {
        public Guid AppUserId { get; set; }
        public bool OnlyRePosts { get; set; }
        public bool OnlyQuotePosts { get; set; }
    }
}