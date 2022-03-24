using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.AppUsers.Any()) return;

            var user1 = new AppUser
            {
                CreatedAt = DateTime.Now.AddMonths(-2),
                Id = new Guid(),
                UserName = "usr1",
            };
            var user2 = new AppUser
            {
                CreatedAt = DateTime.Now.AddMonths(-1),
                Id = new Guid(),
                UserName = "usr2",
            };
            var user3 = new AppUser
            {
                CreatedAt = DateTime.Now.AddMonths(-1),
                Id = new Guid(),
                UserName = "usr3",
            };
            var users = new List<AppUser>
            {
                user1, user2, user3
            };
            
            await context.AppUsers.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var post1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-2),
                Text = "Phasellus hendrerit lorem felis, at condimentum odio convallis eu.",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post2 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-1),
                Text = "Nunc nec aliquam risus, non vestibulum diam.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post3 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-1),
                Text = "Suspendisse interdum arcu nec est commodo semper.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var posts = new List<Post>
            {
                post1, post2, post3
            };

            
            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}