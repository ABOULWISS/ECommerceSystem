using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IRoleUseCaseFacade
    {
        Task AssignRoleToUser(int userId, int roleId, CancellationToken ct = default);

        Task RemoveRoleFromUser(int userId, int roleId, CancellationToken ct = default);

        Task<IReadOnlyList<string>> GetRolesForUser(int userId, CancellationToken ct = default);

        Task<RoleCoreDTO?> GetRoleByName(string roleName, CancellationToken ct = default);

        Task<RoleCoreDTO?> GetById(int id, CancellationToken ct = default);
        Task<int> Create(RoleCoreDTO role, CancellationToken ct = default);
    }

}