










using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class GetPermissionByIdUseCase : IGetPermissionByIdUseCase
    {
        private readonly IPermissionsRepository _repo;
    
        public GetPermissionByIdUseCase(IPermissionsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    
        public async Task<PermissionCoreDTO?> Execute(int prId, CancellationToken ct = default)
        {
            if (prId <= 0)
                throw new ArgumentOutOfRangeException(nameof(prId));
    
            var pr = await _repo.GetByIdAsync(prId, ct).ConfigureAwait(false);
    
            return pr is null ? null : MapToDto(pr);
        }
    
        private static PermissionCoreDTO MapToDto( PermissionDomain pr) => new()
        {
            PermissionID = pr.PermissionID,
            PermissionName = pr.PermissionName,
            PermissionDescription = pr.PermissionDescription,
            
        };

        
    }
}