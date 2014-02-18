using Newtonsoft.Json;

namespace Ugurus.Api.Citrix.DataTypes.Impl
{
    internal class DirectLoginResponseData : IDirectLoginResponseData
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty("organizer_key")]
        public string OrganizerKey { get; private set; }

        [JsonProperty("account_key")]
        public string AccountKey { get; private set; }

        [JsonProperty("account_type")]
        public string AccountType { get; private set; }

        [JsonProperty("firstName")]
        public string FirstName { get; private set; }

        [JsonProperty("lastName")]
        public string LastName { get; private set; }

        [JsonProperty("email")]
        public string EmailAddress { get; private set; }
    }
}
