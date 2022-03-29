using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Followers;
using Application.Posts;
using Domain;

namespace Application.AppUsers
{
    public class AppUserDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string UserName { get; set; }
        public bool Following { get; set; }
    }
}