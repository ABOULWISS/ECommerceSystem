




namespace ECommerceUseCaseLair
{
    public interface IGetUserRolesUseCase
    {
        Task<IReadOnlyList<string>> Execute(int userId, CancellationToken ct = default);
    }

}