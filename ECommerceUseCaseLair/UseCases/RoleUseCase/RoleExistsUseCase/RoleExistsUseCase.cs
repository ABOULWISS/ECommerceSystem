


namespace ECommerceUseCaseLair
{


    public sealed class RoleExistsByNameUseCase : IRoleExistsByNameUseCase
    {
        private readonly IRoleRepository _repo;

        public RoleExistsByNameUseCase(IRoleRepository repo) => _repo = repo;

        public Task<bool> Execute(string RoleName, CancellationToken ct = default)
            => string.IsNullOrWhiteSpace(RoleName)
                ? Task.FromResult(false)
                : _repo.ExistsByNameAsync(RoleName.Trim(), ct);
    }
}


