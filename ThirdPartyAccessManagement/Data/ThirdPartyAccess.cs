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

        public int ApiEndpointId { get; set; }
        public ApiEndpoint? ApiEndpoint { get; set; }   

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
