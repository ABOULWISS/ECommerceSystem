




using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class GetRoleByIdUseCase : IGetRoleByIdUseCase
    {
        private readonly IRoleRepository _repo;
    
        public GetRoleByIdUseCase(IRoleRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    
        public async Task<RoleCoreDTO?> Execute(int RoleId, CancellationToken ct = default)
        {
            if (RoleId <= 0)
                throw new ArgumentOutOfRangeException(nameof(RoleId));
    
            var Role = await _repo.GetByIdAsync(RoleId, ct).ConfigureAwait(false);
    
            return Role is null ? null : MapToDto(Role);
        }
    
        private static RoleCoreDTO MapToDto(RoleDomain Role) => new()
        {
            RoleID = Role.RoleID,
            RoleName = Role.RoleName,
            RoleDescription = Role.RoleDescription,
            
        };
    }
}