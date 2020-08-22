namespace Nmro.Hosting.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UuId { get; }
        bool IsAuthenticated { get; }
    }
}
