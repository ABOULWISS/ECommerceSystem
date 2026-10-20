using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{


    public sealed class RoleUseCaseFacade : IRoleUseCaseFacade
    {
        private readonly IAssignRoleToUserUseCase _assignRoleToUser;
        private readonly IRemoveRoleFromUserUseCase _removeRoleFromUser;
        private readonly IGetUserRolesUseCase _getRolesForUser;
        private readonly IGetRoleByNameUseCase _getRoleByName;

        private readonly ICreateRoleUseCase _create ;

        private readonly IGetRoleByIdUseCase _getById;

        private readonly IRoleExistsByNameUseCase _Existe ;
        public RoleUseCaseFacade(
            IAssignRoleToUserUseCase assignRoleToUser,
            IRemoveRoleFromUserUseCase removeRoleFromUser,
            IGetUserRolesUseCase getUserRoles,
            IGetRoleByNameUseCase getRoleByName,
            IGetRoleByIdUseCase getRoleById,
            ICreateRoleUseCase createRole ,
            IRoleExistsByNameUseCase ExisteRole
            )
        {
            _assignRoleToUser = assignRoleToUser;
            _removeRoleFromUser = removeRoleFromUser;
            _getRolesForUser = getUserRoles;
            _getRoleByName = getRoleByName;
            _create = createRole;
            _Existe = ExisteRole ;
            _getById = getRoleById ;
        }

        public Task AssignRoleToUser(int userId, int roleId, CancellationToken ct = default)
            => _assignRoleToUser.Execute(userId, roleId, ct);

        public Task RemoveRoleFromUser(int userId, int roleId, CancellationToken ct = default)
            => _removeRoleFromUser.Execute(userId, roleId, ct);

        public Task<IReadOnlyList<string>> GetRolesForUser(int userId, CancellationToken ct = default)
            => _getRolesForUser.Execute(userId, ct);

        public Task<RoleCoreDTO?> GetRoleByName(string roleName, CancellationToken ct = default)
            => _getRoleByName.Execute(roleName, ct);


        public Task<int> Create(RoleCoreDTO role, CancellationToken ct = default)
        => _create.Execute(role, ct);

        public Task<RoleCoreDTO?> GetById(int roleId, CancellationToken ct = default)
            => _getById.Execute(roleId, ct);
    }
}
