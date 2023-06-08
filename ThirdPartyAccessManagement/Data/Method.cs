using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("Method")]
    public class Method
    {
        public int Id { get; set; }
        public string? MethodName { get; set; }
        public DateTime CreatedDate { get; set; }

        public int PageId { get; set; }
        public Page? Page { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }

        public bool MethodExists(ApplicationDbContext _dbContext, string methodName)
        {
            var method = _dbContext.Methods.FirstOrDefault(m => m.MethodName == methodName);
            if (method != null)
            {
                return true;
            }
            return false;
        }
    }

}
