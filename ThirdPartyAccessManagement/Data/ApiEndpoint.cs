using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("ApiEndpoint")]
    public class ApiEndpoint
    {
        public int Id { get; set; }
        public string? PageName { get; set; }
        public string? MethodName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
