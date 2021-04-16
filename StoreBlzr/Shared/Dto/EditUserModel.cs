using System.ComponentModel.DataAnnotations;

namespace Shared.Dto
{
    public class EditUserModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string? ConfirmNewPassword { get; set; }
    }
}