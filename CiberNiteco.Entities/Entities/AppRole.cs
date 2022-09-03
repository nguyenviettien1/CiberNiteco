using System;
using Microsoft.AspNetCore.Identity;

namespace CiberNiteco.Entities.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}