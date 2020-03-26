namespace Nmro.Blocks.Interfaces
{
    public interface ICurrentUserService
    {
        long UserId { get; }
        string UuId { get; }

        bool IsAuthenticated { get; }
    }
}
