

namespace ECommerceUseCaseLair
{
  

    public sealed class AssignPermissionToRoleUseCase : IAssignPermissionToRoleUseCase
    {
        private readonly IPermissionsRepository _repo;

        public AssignPermissionToRoleUseCase(IPermissionsRepository repo) => _repo = repo;

        public Task Execute(int roleId, int permissionId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roleId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(permissionId);
            return _repo.AssignPermissionToRoleAsync(roleId, permissionId, ct);
        }
    }
}