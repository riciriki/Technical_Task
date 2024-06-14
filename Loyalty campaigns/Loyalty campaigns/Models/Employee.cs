namespace Loyalty_campaigns.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Reward>? Rewards { get; set; }
    }
}
