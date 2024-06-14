using System.Text.Json.Serialization;

namespace Loyalty_campaigns.DTOs
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [JsonIgnore]
        public int RoleId { get; set; }
    }
}
