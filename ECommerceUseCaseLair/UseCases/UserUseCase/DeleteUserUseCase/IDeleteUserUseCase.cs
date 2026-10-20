



namespace ECommerceUseCaseLair
{
    public interface IDeleteUserUseCase
    {
        /// <returns>False when the user doesn't exist.</returns>
        Task<bool> Execute(int userId, CancellationToken ct = default);
    }
}



