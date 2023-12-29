namespace TranQuocTrung1.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
    }
}
