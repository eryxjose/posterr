using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using Persistence;

namespace Application.Posts
{
    public class PostValidator : AbstractValidator<Post>
    {
        private readonly DataContext _context;

        private int PostsCount(Guid appUserId)
        {
            return _context.Posts.Where(o => o.AppUserId == appUserId && 
                o.CreatedAt.Date == DateTime.Now.Date).Count();
        }

        public PostValidator(DataContext context)
        {
            _context = context;

            RuleFor(o => o.Text).NotEmpty().MaximumLength(777);
            RuleFor(o => o.CreatedAt).NotEmpty();
            RuleFor(o => o.AppUserId).Custom((x, context) => 
            {
                if (PostsCount(x) > 5)
                    context.AddFailure("No more posts for today");
            });
        }
            
        public PostValidator()
        {
        }
    }
}