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
            RuleFor(o => o.Text).NotEmpty().MaximumLength(777);
            RuleFor(o => o.CreatedAt).NotEmpty();
        }
    }
}