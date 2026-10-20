using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class GetRoleByNameUseCase : IGetRoleByNameUseCase
    {
        private readonly IRoleRepository _repo;
    
        public GetRoleByNameUseCase(IRoleRepository repo)
            => _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    
        public async Task<RoleCoreDTO?> Execute(string rolename, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(rolename))
                throw new ArgumentException("rolename is required.", nameof(rolename));
    
            var role = await _repo.GetRoleByNameAsync(rolename.Trim(), ct).ConfigureAwait(false);
    
            return role is null ? null : MapToDto(role);
        }
    
        private static RoleCoreDTO MapToDto(RoleDomain role) => new()
        {
            RoleID = role.RoleID,
            RoleName = role.RoleName,
            RoleDescription = role.RoleDescription
        };
    }
}