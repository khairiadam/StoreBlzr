using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace StoreBlzr.Shared
{
    public class AppClient : IdentityUser
    {
        [Required, StringLength(100)] public string FirstName { get; set; }
        [AllowNull, StringLength(100)] public string LastName { get; set; }
        [AllowNull] public DateTime BirthDate { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string State { get; set; }
        [Required] public string City { get; set; }
        [Required] public string ZipCode { get; set; }

    }
}