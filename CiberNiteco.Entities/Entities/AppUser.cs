using System;
using Microsoft.AspNetCore.Identity;

namespace CiberNiteco.Entities.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}