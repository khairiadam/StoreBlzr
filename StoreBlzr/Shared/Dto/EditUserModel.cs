using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StoreBlzr.Shared.Dto
{
    public class EditUserModel
    {
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

        [DataType(DataType.Password)]
        [AllowNull]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [AllowNull]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        [AllowNull]
        public string ConfirmNewPassword { get; set; }
    }
}