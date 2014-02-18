using System;
using System.Threading.Tasks;
using Ugurus.Api.Citrix.DataTypes;

namespace Ugurus.Api.Citrix.Client
{
    public interface ICitrixWebinarClient: IDisposable
    {
        Task<IWebinarCreateRegistrantResponseData> CreateRegistrantAsync(
            string firstName, string lastName, string emailAddress,
            string webinar);
    }
}
