



using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IPermissionUseCaseFacade
    {
        /// <summary>Effective permissions for a user (roles plus direct assignments). Used at login / token refresh.</summary>
        Task<IReadOnlyList<string>> GetUserPermissions(int userId, CancellationToken ct = default);

        Task<IReadOnlyList<string>> GetRolePermissions(int roleId, CancellationToken ct = default);

        Task AssignPermissionToRole(int roleId, int permissionId, CancellationToken ct = default);

        Task RemovePermissionFromRole(int roleId, int permissionId, CancellationToken ct = default);

        Task AssignPermissionToUser(int userId, int permissionId, CancellationToken ct = default);

        Task RemovePermissionFromUser(int userId, int permissionId, CancellationToken ct = default);

        Task<PermissionCoreDTO?> GetPermissionByName(string permissionName, CancellationToken ct = default);

        Task<PermissionCoreDTO?> GetById(int id, CancellationToken ct = default);
        Task<int> Create(PermissionCoreDTO role, CancellationToken ct = default);
    }
}




