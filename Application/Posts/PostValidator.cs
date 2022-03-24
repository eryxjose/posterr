using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Posts
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(o => o.Text).NotEmpty();
            RuleFor(o => o.CreatedAt).NotEmpty();
            
        }
    }
}