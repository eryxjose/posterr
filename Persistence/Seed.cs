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
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Phasellus hendrerit lorem felis, at condimentum odio convallis eu.",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post2 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Nunc nec aliquam risus, non vestibulum diam.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post3 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Suspendisse interdum arcu nec est commodo semper.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var post4 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Phasellus elit justo, porta nec convallis quis, interdum quis mauris.",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post5 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Sed sit amet luctus libero, non rutrum risus.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post6 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "Phasellus eu iaculis orci.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var post7 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-14),
                Text = "Aliquam id semper purus.",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post8 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-14),
                Text = "Suspendisse ac velit posuere, consectetur metus id, tincidunt lectus",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post9 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-14),
                Text = "Sed dignissim urna purus, ac aliquet lorem tempor ut.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var post10 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-13),
                Text = "Maecenas luctus eget ipsum nec scelerisque. ",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post11 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-13),
                Text = "Sed at condimentum quam.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post12 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-13),
                Text = "Mauris fermentum blandit magna, id facilisis est dapibus eu.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var post13 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "Etiam id augue at ipsum porttitor pharetra quis imperdiet diam.",
                AppUserId = user1.Id,
                ParentId = ""
            };
            
            var post14 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "Pellentesque sit amet elit sit amet erat semper elementum vitae id eros.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post15 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "Pellentesque a vestibulum enim.",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var post16 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-11),
                Text = "Ut a nisl eget nunc consectetur viverra eget sed ipsum.",
                AppUserId = user1.Id,
                ParentId = ""
            };

            var post17 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-11),
                Text = "Maecenas fermentum mi eu leo vestibulum, ac feugiat dui laoreet.",
                AppUserId = user2.Id,
                ParentId = ""
            };

            var post18 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-11),
                Text = "Etiam maximus eget tellus vitae vulputate. ",
                AppUserId = user3.Id,
                ParentId = ""
            };

            var posts = new List<Post>
            {
                post1, post2, post3, post4, post5, post6, post7, post8, post9, post10,
                post11, post12, post13, post14, post15, post16, post17, post18
            };
            
            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();

            var repost1post1usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "",
                AppUserId = user2.Id,
                ParentId = post1.Id.ToString()
            };

            var repost2post1usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-14),
                Text = "",
                AppUserId = user3.Id,
                ParentId = post1.Id.ToString()
            };

            var repost1post4usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-13),
                Text = "",
                AppUserId = user2.Id,
                ParentId = post4.Id.ToString()
            };

            var respost1post4usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-13),
                Text = "",
                AppUserId = user3.Id,
                ParentId = post4.Id.ToString()
            };

            var repost1post5usr2 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "",
                AppUserId = user1.Id,
                ParentId = post5.Id.ToString()
            };

            var repost1post14usr2 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "",
                AppUserId = user1.Id,
                ParentId = post14.Id.ToString()
            };

            var repost2post14usr2 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-12),
                Text = "",
                AppUserId = user3.Id,
                ParentId = post14.Id.ToString()
            };

            var repost1post18usr3 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-11),
                Text = "",
                AppUserId = user1.Id,
                ParentId = post18.Id.ToString()
            };

            var reposts = new List<Post>
            {
                repost1post14usr2, repost1post1usr1, repost1post4usr1, repost1post5usr2, 
                repost2post14usr2, repost2post1usr1, repost1post18usr3
            };
            
            await context.Posts.AddRangeAsync(reposts);
            await context.SaveChangesAsync();

            var qrepost1post1usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-15),
                Text = "quote: Curabitur sodales sapien ut maximus tempor.",
                AppUserId = user3.Id,
                ParentId = post1.Id.ToString()
            };

            var qrepost2post1usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-14),
                Text = "Donec pretium ligula ut quam auctor rutrum",
                AppUserId = user2.Id,
                ParentId = post1.Id.ToString()
            };

            var qrepost1post16usr1 = new Post
            {
                CreatedAt = DateTime.Now.AddMonths(-10),
                Text = "Pellentesque a faucibus orci. ",
                AppUserId = user3.Id,
                ParentId = post16.Id.ToString()
            };

            var qposts = new List<Post>
            {
                qrepost1post16usr1, qrepost1post1usr1, qrepost2post1usr1
            };

            await context.Posts.AddRangeAsync(qposts);
            await context.SaveChangesAsync();


        }
    }
}