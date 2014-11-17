
namespace SupperSlonicWebSite.DomainLogic.Models.Account
{
    public class ExternalLoginInfo
    {
        public ExternalLoginProvider ProviderType { get; set; }

        public string ProviderKey { get; set; }
    }
}