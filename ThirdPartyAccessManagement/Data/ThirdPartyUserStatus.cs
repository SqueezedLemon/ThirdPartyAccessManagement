using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("ThirdPartyUserStatus")]
    public class ThirdPartyUserStatus
    {
        public int Id { get; set; }
        public string? Status { get; set; }
    }
}
