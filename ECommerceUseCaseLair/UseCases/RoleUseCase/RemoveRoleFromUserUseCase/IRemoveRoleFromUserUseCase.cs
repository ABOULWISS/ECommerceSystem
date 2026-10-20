namespace ECommerceUseCaseLair
{
    public interface IRemoveRoleFromUserUseCase
    {
        Task Execute(int userId, int roleId, CancellationToken ct = default);
    }
}
