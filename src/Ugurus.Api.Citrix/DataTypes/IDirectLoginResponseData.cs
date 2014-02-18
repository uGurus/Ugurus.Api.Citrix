
namespace Ugurus.Api.Citrix.DataTypes
{
    public interface IDirectLoginResponseData
    {
        string AccessToken { get; }
        int ExpiresIn { get; }
        string RefreshToken { get; }
        string OrganizerKey { get; }
        string AccountKey { get; }
        string AccountType { get; }
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
    }
}
