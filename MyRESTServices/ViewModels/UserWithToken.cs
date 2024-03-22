using MyRESTServices.BLL.DTOs;

namespace MyRESTServices.ViewModels
{
    public class UserWithToken
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public RoleDTO Role { get; set; }
        public string? Token { get; set; }
    }
}
