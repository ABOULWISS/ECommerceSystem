namespace ECommerceUseCaseLair
{
    public sealed class RemovePermissionFromUserUseCase : IRemovePermissionFromUserUseCase
    {
        private readonly IPermissionsRepository _repo;
        public RemovePermissionFromUserUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task Execute(int userId, int permissionId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(permissionId);
            return _repo.RemovePermissionFromUserAsync(userId, permissionId, ct);
        }
    }
}
