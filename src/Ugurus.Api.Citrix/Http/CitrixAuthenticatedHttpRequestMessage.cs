using System;
using System.Net.Http;
using Ugurus.Api.Citrix.DataTypes;

namespace Ugurus.Api.Citrix.Http
{
    internal class CitrixAuthenticatedHttpRequestMessage : HttpRequestMessage
    {
        public CitrixAuthenticatedHttpRequestMessage()
        {
            
        }
        public CitrixAuthenticatedHttpRequestMessage(HttpMethod method, Uri requestUri)
            : base(method, requestUri)
        {
            
        }
        public CitrixAuthenticatedHttpRequestMessage(HttpMethod method, string requestUri)
            : base(method, requestUri)
        {
            
        }        

        public IDirectLoginResponseData AuthenticationData { get; set; }
    }
}
