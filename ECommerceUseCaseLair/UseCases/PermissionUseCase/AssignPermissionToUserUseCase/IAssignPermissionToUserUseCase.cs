namespace ECommerceUseCaseLair
{
    public interface IAssignPermissionToUserUseCase
    {
        Task Execute(int userId, int permissionId, CancellationToken ct = default);
    }
}
