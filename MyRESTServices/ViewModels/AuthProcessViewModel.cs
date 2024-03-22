using MyRESTServices.Domain.Models;
using System.Text.Json.Serialization;

namespace MyRESTServices.ViewModels
{
    public class AuthProcessViewModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
