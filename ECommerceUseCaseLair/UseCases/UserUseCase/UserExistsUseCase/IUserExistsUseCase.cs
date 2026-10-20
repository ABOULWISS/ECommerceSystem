



namespace ECommerceUseCaseLair
{
    public interface IUserExistsByNameUseCase
    {
        Task<bool> Execute(string userName, CancellationToken ct = default);
    }

}