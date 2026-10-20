

namespace ECommerceUseCaseLair
{


    public sealed class AssignRoleToUserUseCase : IAssignRoleToUserUseCase
    {
        private readonly IRoleRepository _repo;

        public AssignRoleToUserUseCase(IRoleRepository repo) => _repo = repo;

        public Task Execute(int userId, int roleId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roleId);
            return _repo.AssignRoleToUserAsync(userId, roleId, ct);
        }
    }


    
}