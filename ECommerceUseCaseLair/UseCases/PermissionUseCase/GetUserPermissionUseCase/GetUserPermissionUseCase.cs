namespace ECommerceUseCaseLair
{

    // Called during login (or token refresh) to flatten a user's roles
    // into a single permission list that gets baked into the JWT as claims.
    public sealed class GetUserPermissionsUseCase : IGetUserPermissionsUseCase
    {
        private readonly IPermissionsRepository _repo;

        public GetUserPermissionsUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task<IReadOnlyList<string>> Execute(int userId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            return _repo.GetPermissionsForUserAsync(userId, ct);
        }
    }
}