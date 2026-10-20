namespace ECommerceUseCaseLair
{
    public sealed class RemovePermissionFromRoleUseCase : IRemovePermissionFromRoleUseCase
    {
        private readonly IPermissionsRepository _repo;
        public RemovePermissionFromRoleUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task Execute(int roleId, int permissionId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roleId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(permissionId);
            return _repo.RemovePermissionFromRoleAsync(roleId, permissionId, ct);
        }
    }
}
