using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StoreBlzr.Shared.Dto
{
    public class EditUserModel
    {
        public string Id { get; set; }

        [AllowNull]
        public string FirstName { get; set; }

        [AllowNull]
        public string LastName { get; set; }

        [AllowNull]
        public string UserName { get; set; }

        [AllowNull]
        public string Email { get; set; }

        [AllowNull]
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [JsonIgnore]
        [DataType(DataType.Password)]
        [AllowNull]
        public string NewPassword { get; set; }

        [JsonIgnore]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Passwords are not identical")]
        [AllowNull]
        public string ConfirmNewPassword { get; set; }
        public string Message { get; set; }
    }
}