using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Shared;
using System.Diagnostics.CodeAnalysis;

namespace Server.Models
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(100)] public string FirstName { get; set; }
        [AllowNull, StringLength(100)] public string LastName { get; set; }
        [AllowNull] public DateTime BirthDate { get; set; }
        [Required] public string Gender { get; set; } = Genders.Male.ToString();
        [Required] public string Address { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string State { get; set; }
        [Required] public string City { get; set; }
        [Required] public string ZipCode { get; set; }

    }
}