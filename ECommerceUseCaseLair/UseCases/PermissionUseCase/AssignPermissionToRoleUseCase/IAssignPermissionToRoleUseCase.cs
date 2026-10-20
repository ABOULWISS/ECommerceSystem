


namespace ECommerceUseCaseLair
{
    public interface IAssignPermissionToRoleUseCase
    {
        Task Execute(int roleId, int permissionId, CancellationToken ct = default);
    }

}