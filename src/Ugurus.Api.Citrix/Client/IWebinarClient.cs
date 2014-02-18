using System.Threading.Tasks;
using Ugurus.Api.Citrix.DataTypes;

namespace Ugurus.Api.Citrix.Client
{
    public interface ICitrixWebinarClient
    {
        Task<IWebinarCreateRegistrantResponseData> CreateRegistrant(
            string firstName, string lastName, string emailAddress,
            string webinar);
    }
}
