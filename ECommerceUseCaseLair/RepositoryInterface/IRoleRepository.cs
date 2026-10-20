using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IRoleRepository
    {
        Task AssignRoleToUserAsync(int userId, int roleId, CancellationToken ct = default);
        Task RemoveRoleFromUserAsync(int userId, int roleId, CancellationToken ct = default);
        Task<IReadOnlyList<string>> GetRolesForUserAsync(int userId, CancellationToken ct = default);
        Task<RoleDomain?> GetRoleByNameAsync(string roleName, CancellationToken ct = default);
        Task<RoleDomain?> GetByIdAsync(int roleId, CancellationToken ct = default);
        Task<int> CreateAsync(RoleDomain role, CancellationToken ct = default);
        Task<bool> ExistsByNameAsync(string RoleName, CancellationToken ct = default);
    }
}
