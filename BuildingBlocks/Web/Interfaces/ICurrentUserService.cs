namespace Nmro.Blocks.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UuId { get; }
        bool IsAuthenticated { get; }
    }
}
