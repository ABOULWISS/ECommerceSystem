namespace ECommerceUseCaseLair
{
    public interface IRemovePermissionFromUserUseCase
    {
        Task Execute(int userId, int permissionId, CancellationToken ct = default);
    }
}
