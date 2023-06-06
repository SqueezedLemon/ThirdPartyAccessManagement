using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("ThirdPartyUserStatus")]
    public class ThirdPartyUserStatus
    {
        public int Id { get; set; }
        public bool IsDisabled { get; set; } = false;
        public DateTime CreatedDate { get; set; }

        public int ThirdPartyUserId { get; set; }
        public ThirdPartyUser? ThirdPartyUser { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
