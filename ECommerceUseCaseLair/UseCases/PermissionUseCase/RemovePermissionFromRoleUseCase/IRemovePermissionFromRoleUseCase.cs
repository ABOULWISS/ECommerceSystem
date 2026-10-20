namespace ECommerceUseCaseLair
{
    public interface IRemovePermissionFromRoleUseCase
    {
        Task Execute(int roleId, int permissionId, CancellationToken ct = default);
    }
}
