using System.ComponentModel.DataAnnotations;

namespace StoreBlzr.Shared.Dto
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}