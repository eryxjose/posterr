using System.Linq;
using Application.AppUsers;
using Application.Followers;
using Application.Posts;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            string currentUsername = null;

            CreateMap<AppUser, AppUserDto>()
                .ForMember(d => d.Following,
                    o => o.MapFrom(s => s.Followers.Any(x => x.Observer.UserName == currentUsername)));

            CreateMap<Post, PostDto>();

            CreateMap<UserFollowing, UserFollowingDto>();

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
                .ForMember(d => d.Following,
                    o => o.MapFrom(s => s.Followers.Any(x => x.Observer.UserName == currentUsername)));
        }
    }
}