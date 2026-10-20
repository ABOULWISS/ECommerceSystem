



namespace ECommerceUseCaseLair
{
    public interface IRoleExistsByNameUseCase
    {
        Task<bool> Execute(string RoleName, CancellationToken ct = default);
    }

}