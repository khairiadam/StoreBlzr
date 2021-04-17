using System.ComponentModel.DataAnnotations;

namespace Shared.Dto
{
    public class UserModel
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }



        [Required, StringLength(256)]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }

        public string Message { get; set; }
    }
}