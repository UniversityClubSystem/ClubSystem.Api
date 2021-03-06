using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClubSystem.Lib.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ClubSystem.Lib.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserClubs = new Collection<UserClub>();
            UserPosts = new Collection<UserPost>();
        }

        public ICollection<UserPost> UserPosts { get; set; }
        public ICollection<UserClub> UserClubs { get; set; }
    }
}