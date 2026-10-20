


namespace ECommerceUseCaseLair
{
 

    public sealed class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _repo;

        public DeleteUserUseCase(IUserRepository repo) => _repo = repo;

        public Task<bool> Execute(int userId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            return _repo.DeleteAsync(userId, ct);
        }
    }
}