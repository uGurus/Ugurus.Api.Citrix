using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Ugurus.Api.Citrix.DataTypes;

namespace Ugurus.Api.Citrix.Http
{
    internal class CitrixApiMessageHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request is CitrixAuthenticatedHttpRequestMessage)
            {
                IDirectLoginResponseData authData =
                    ((CitrixAuthenticatedHttpRequestMessage)(request))
                        .AuthenticationData;

                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "OAuth",
                    String.Format("oauth_token={0}", authData.AccessToken));
            }

            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return base.SendAsync(request, cancellationToken);
        }
    }
}
