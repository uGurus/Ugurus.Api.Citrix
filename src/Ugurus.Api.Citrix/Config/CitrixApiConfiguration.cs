using Ugurus.Api.Citrix.Client;
using Ugurus.Api.Citrix.Client.Impl;

namespace Ugurus.Api.Citrix.Config
{
    public class CitrixApiConfiguration : ICitrixApiConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }

        public CitrixApiConfiguration(string username, string password, string apiKey)
        {
            Username = username;
            Password = password;
            ApiKey = apiKey;
        }

        public ICitrixWebinarClient GetWebinarClient()
        {
            return new CitrixWebinarApiClient(this);
        }
    }    
}
