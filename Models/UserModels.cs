using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class UserModels : IdentityUser
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }

}
