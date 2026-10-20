


namespace ECommerceUseCaseLair
{


    public sealed class GetRolePermissionsUseCase : IGetRolePermissionsUseCase
    {
        private readonly IPermissionsRepository _repo;

        public GetRolePermissionsUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task<IReadOnlyList<string>> Execute(int roleId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roleId);
            return _repo.GetPermissionsForRoleAsync(roleId, ct);
        }
    }
}