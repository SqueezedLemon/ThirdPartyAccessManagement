using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("ThirdParyAccess")]
    public class ThirdPartyAccess
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ThirdPartyUserId { get; set; }
        public ThirdPartyUser? ThirdPartyUser { get; set; }

        public int MethodId { get; set; }
        public Method? Method { get; set; }   

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
