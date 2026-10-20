


using ECommerceDomainLair;
using ECommerceContractLair;




namespace ECommerceUseCaseLair
{
    public sealed class PermissionUseCaseFacade : IPermissionUseCaseFacade
    {
        private readonly IGetUserPermissionsUseCase _getUserPermissions;
        private readonly IGetRolePermissionsUseCase _getRolePermissions;
        private readonly IAssignPermissionToRoleUseCase _assignPermissionToRole;
        private readonly IRemovePermissionFromRoleUseCase _removePermissionFromRole;
        private readonly IAssignPermissionToUserUseCase _assignPermissionToUser;
        private readonly IRemovePermissionFromUserUseCase _removePermissionFromUser;
        private readonly IGetPermissionByNameUseCase _getPermissionByName;

        private readonly ICreatePermissionUseCase _create ;

        private readonly IGetPermissionByIdUseCase _getById;


        public PermissionUseCaseFacade(
            IGetUserPermissionsUseCase getUserPermissions,
            IGetRolePermissionsUseCase getRolePermissions,
            IAssignPermissionToRoleUseCase assignPermissionToRole,
            IRemovePermissionFromRoleUseCase removePermissionFromRole,
            IAssignPermissionToUserUseCase assignPermissionToUser,
            IRemovePermissionFromUserUseCase removePermissionFromUser,
            IGetPermissionByNameUseCase getPermissionByName,
            IGetPermissionByIdUseCase  getPermissionByID,
            ICreatePermissionUseCase createPermission )
        {
            _getUserPermissions = getUserPermissions;
            _getRolePermissions = getRolePermissions;
            _assignPermissionToRole = assignPermissionToRole;
            _removePermissionFromRole = removePermissionFromRole;
            _assignPermissionToUser = assignPermissionToUser;
            _removePermissionFromUser = removePermissionFromUser;
            _getPermissionByName = getPermissionByName;
            _create = createPermission;
            _getById = getPermissionByID ;
        }






        public Task<IReadOnlyList<string>> GetUserPermissions(int userId, CancellationToken ct = default)
            => _getUserPermissions.Execute(userId, ct);

        public Task<IReadOnlyList<string>> GetRolePermissions(int roleId, CancellationToken ct = default)
            => _getRolePermissions.Execute(roleId, ct);

        public Task AssignPermissionToRole(int roleId, int permissionId, CancellationToken ct = default)
            => _assignPermissionToRole.Execute(roleId, permissionId, ct);

        public Task RemovePermissionFromRole(int roleId, int permissionId, CancellationToken ct = default)
            => _removePermissionFromRole.Execute(roleId, permissionId, ct);

        public Task AssignPermissionToUser(int userId, int permissionId, CancellationToken ct = default)
            => _assignPermissionToUser.Execute(userId, permissionId, ct);

        public Task RemovePermissionFromUser(int userId, int permissionId, CancellationToken ct = default)
            => _removePermissionFromUser.Execute(userId, permissionId, ct);

        public Task<PermissionCoreDTO?> GetPermissionByName(string permissionName, CancellationToken ct = default)
            => _getPermissionByName.Execute(permissionName, ct);

        public Task<int> Create(PermissionCoreDTO pr, CancellationToken ct = default)
        => _create.Execute(pr, ct);

        public Task<PermissionCoreDTO?> GetById(int prId, CancellationToken ct = default)
            => _getById.Execute(prId, ct);


    }
}



