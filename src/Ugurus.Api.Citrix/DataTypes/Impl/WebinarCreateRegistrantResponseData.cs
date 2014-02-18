using Newtonsoft.Json;

namespace Ugurus.Api.Citrix.DataTypes.Impl
{
    internal class WebinarCreateRegistrantResponseData :
            IWebinarCreateRegistrantResponseData
    {
        [JsonProperty("registrantKey")]
        public string RegistrationKey { get; private set; }

        [JsonProperty("joinUrl")]
        public string JoinUrl { get; private set; }
    }
}
