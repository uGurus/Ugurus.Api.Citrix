using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Ugurus.Api.Citrix.Config;
using Ugurus.Api.Citrix.DataTypes;
using Ugurus.Api.Citrix.DataTypes.Impl;
using Ugurus.Api.Citrix.Http;

namespace Ugurus.Api.Citrix.Client.Impl
{
    internal class CitrixWebinarApiClient : CitrixApiClientBase,
            ICitrixWebinarClient
    {
        internal CitrixWebinarApiClient(CitrixApiConfiguration config)
            : base(config)
        {

        }

        public Task<IWebinarCreateRegistrantResponseData> CreateRegistrantAsync(
            string firstName, string lastName, string emailAddress,
            string webinar)
        {
            if (_Disposed)
                throw new ObjectDisposedException("CitrixWebinarApiClient");

            return AuthenticateAsync().ContinueWith(_ =>
            {
                string requestLocation = string.Format(
                  "G2W/rest/organizers/{0}/webinars/{1}/registrants",
                  _LoginData.OrganizerKey,
                  webinar);

                var msg = new CitrixAuthenticatedHttpRequestMessage(
                    HttpMethod.Post, requestLocation)
                    {
                        AuthenticationData = _LoginData,
                        Content = new ObjectContent<object>(
                            new
                            {
                                firstName = firstName,
                                lastName = lastName,
                                email = emailAddress
                            }, new JsonMediaTypeFormatter())
                    };

                return _Cli.SendAsync(msg).ContinueWith(requestTask =>
                {
                    var message = requestTask.Result;
                    if (message.IsSuccessStatusCode
                        || message.StatusCode == HttpStatusCode.Conflict)
                    {
                        return message.Content
                            .ReadAsAsync<WebinarCreateRegistrantResponseData>()
                            .ContinueWith(
                                readTask =>
                                {
                                    return readTask.Result
                                    as IWebinarCreateRegistrantResponseData;
                                });
                    }
                    throw new HttpRequestException();

                }).Unwrap();
            }).Unwrap();
        }
    }
}
