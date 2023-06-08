using ThirdPartyAccessManagement.Data;

namespace ThirdPartyAccessManagement.Models
{
    public class BaseViewModel
    {
        public List<Method>? Methods { get; set; }
        public List<Page>? Pages { get; set; }
        public Api? Api { get; set; }
    }
}
