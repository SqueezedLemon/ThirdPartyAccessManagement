using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdPartyAccessManagement.Data
{
    [Table("LedgerAccount")]
    public class LedgerAccount
    {
        public int Id { get; set; }
        public string? PinlessTopupDebit { get; set; }
        public string? PinlessTopupCredit { get; set; }
        public string? VoucherTopupDebit { get; set; }
        public string? VoucherTopupCredit { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ThirdPartyUserId { get; set; }
        public ThirdPartyUser? ThirdPartyUser { get; set; }

        public string? CreatedById { get; set; }
        public UserManager? User { get; set; }
    }
}
