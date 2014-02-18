using Ugurus.Api.Citrix.Client;

namespace Ugurus.Api.Citrix
{
    public interface ICitrixApiConfiguration
    {
        string Username { get; set; }
        string Password { get; set; }
        string ApiKey { get; set; }
        ICitrixWebinarClient GetWebinarClient();
    }
}
