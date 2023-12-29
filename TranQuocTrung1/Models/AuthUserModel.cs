namespace TranQuocTrung1.Models
{
    public partial class AuthUserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
    }
}
