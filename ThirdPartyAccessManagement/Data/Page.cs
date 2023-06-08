using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("Page")]
    public class Page
    { 
        public int Id { get; set; }
        public string? PageName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }

        public bool PageExists(ApplicationDbContext _dbContext, string pageName)
        {
            var page = _dbContext.Pages.FirstOrDefault(p => p.PageName == pageName);
            if (page != null)
            {
                return true;
            }
            return false;
        }
    }
}
