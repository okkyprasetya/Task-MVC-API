using MyRESTServices.BLL.DTOs;
using System.Text.Json.Serialization;

namespace MyRESTServices.ViewModels
{
    public class LoginViewModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public RoleDTO Role { get; set; }

        [JsonIgnore]
        public string? Token { get; set; }
    }
}
