namespace Nmro.Common.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UuId { get; }
        bool IsAuthenticated { get; }
    }
}
