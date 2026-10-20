using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IPermissionsRepository
    {
        Task AssignPermissionToRoleAsync(int roleId, int permissionId, CancellationToken ct = default);
        Task RemovePermissionFromRoleAsync(int roleId, int permissionId, CancellationToken ct = default);

        Task AssignPermissionToUserAsync(int userId, int permissionId, CancellationToken ct = default);
        Task RemovePermissionFromUserAsync(int userId, int permissionId, CancellationToken ct = default);

        Task<IReadOnlyList<string>> GetPermissionsForRoleAsync(int roleId, CancellationToken ct = default);
        Task<IReadOnlyList<string>> GetPermissionsForUserAsync(int userId, CancellationToken ct = default);

        Task<PermissionDomain?> GetPermissionByNameAsync(string permissionName, CancellationToken ct = default);
        Task<PermissionDomain?> GetByIdAsync(int prId, CancellationToken ct = default);
        Task<int> CreateAsync(PermissionDomain pr, CancellationToken ct = default);
        Task<bool> ExistsByNameAsync(string permissionName, CancellationToken ct = default);
    }
}
