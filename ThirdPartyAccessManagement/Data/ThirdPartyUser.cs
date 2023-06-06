using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("ThirdPartyUser")]
    public class ThirdPartyUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Ip { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
