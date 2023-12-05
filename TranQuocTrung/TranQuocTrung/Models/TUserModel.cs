namespace TranQuocTrung.Models
{
    public class TUserModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? LoaiUser { get; set; }
    }
}
