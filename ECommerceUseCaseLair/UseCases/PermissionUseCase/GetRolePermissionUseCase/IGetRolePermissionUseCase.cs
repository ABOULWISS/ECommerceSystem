



namespace ECommerceUseCaseLair
{
    public interface IGetRolePermissionsUseCase
    {
        Task<IReadOnlyList<string>> Execute(int roleId, CancellationToken ct = default);
    }
}