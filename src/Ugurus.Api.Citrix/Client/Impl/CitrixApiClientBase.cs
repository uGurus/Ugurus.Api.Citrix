using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ugurus.Api.Citrix.DataTypes;
using Ugurus.Api.Citrix.DataTypes.Impl;
using Ugurus.Api.Citrix.Http;

namespace Ugurus.Api.Citrix.Client.Impl
{
    internal abstract class CitrixApiClientBase : IDisposable
    {
        protected HttpClient _Cli;
        protected ICitrixApiConfiguration _Config;
        protected IDirectLoginResponseData _LoginData;
        protected bool _Disposed;

        protected CitrixApiClientBase(ICitrixApiConfiguration config)
        {
            _Cli = new HttpClient(new CitrixApiMessageHandler());
            _Cli.BaseAddress = new Uri("https://api.citrixonline.com/");
            _Config = config;
        }

        protected virtual Task<IDirectLoginResponseData> Authenticate()
        {
            if (_Disposed)
                throw new ObjectDisposedException("CitrixApiClientBase");

            if (_LoginData != null)
                return Task.FromResult(_LoginData);

            var requestLocation = String.Format(
                "oauth/access_token?grant_type=password&user_id={0}&password={1}&client_id={2}",
                _Config.Username,
                _Config.Password,
                _Config.ApiKey);

            return _Cli.GetAsync(requestLocation).ContinueWith(
                requestTask =>
                {
                    var message = requestTask.Result;
                    message.EnsureSuccessStatusCode();
                    return message.Content
                        .ReadAsAsync<DirectLoginResponseData>().ContinueWith(
                            readTask =>
                            {
                                _LoginData = readTask.Result
                                    as IDirectLoginResponseData;
                                return _LoginData;

                            });
                }).Unwrap();
        }

        public void Dispose()
        {
            if (_Cli != null)
            {
                _Cli.Dispose();
                _Cli = null;
                _Disposed = true;
            }
        }
    }
}