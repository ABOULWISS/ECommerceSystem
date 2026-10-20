


namespace ECommerceUseCaseLair
{


    public sealed class UserExistsByNameUseCase : IUserExistsByNameUseCase
    {
        private readonly IUserRepository _repo;

        public UserExistsByNameUseCase(IUserRepository repo) => _repo = repo;

        public Task<bool> Execute(string userName, CancellationToken ct = default)
            => string.IsNullOrWhiteSpace(userName)
                ? Task.FromResult(false)
                : _repo.ExistsByNameAsync(userName.Trim(), ct);
    }
}


