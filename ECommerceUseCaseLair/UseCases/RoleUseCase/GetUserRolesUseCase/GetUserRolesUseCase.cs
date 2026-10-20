


namespace ECommerceUseCaseLair
{


    public sealed class GetUserRolesUseCase : IGetUserRolesUseCase
    {
        private readonly IRoleRepository _repo;

        public GetUserRolesUseCase(IRoleRepository repo) => _repo = repo;

        public Task<IReadOnlyList<string>> Execute(int userId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            return _repo.GetRolesForUserAsync(userId, ct);
        }
    }



    
}