namespace ECommerceUseCaseLair
{
    public sealed class AssignPermissionToUserUseCase : IAssignPermissionToUserUseCase
    {
        private readonly IPermissionsRepository _repo;
        public AssignPermissionToUserUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task Execute(int userId, int permissionId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(permissionId);
            return _repo.AssignPermissionToUserAsync(userId, permissionId, ct);
        }
    }
}
