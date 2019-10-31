using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace DieteticSNS.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string AvatarPath { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Following> Followings { get; set; } = new HashSet<Following>();
        public virtual ICollection<Following> Followers { get; set; } = new HashSet<Following>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public virtual ICollection<Stars> Stars { get; set; } = new HashSet<Stars>();
    }
}
