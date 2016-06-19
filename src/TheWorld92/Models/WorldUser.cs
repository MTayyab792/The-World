using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TheWorld92.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}