








using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{


    public sealed class CreatePermissionUseCase : ICreatePermissionUseCase
    {
        private readonly IPermissionsRepository _repo;
       

        public CreatePermissionUseCase(IPermissionsRepository repo)
        {
            _repo = repo;
          
        }

        public async Task<int> Execute( PermissionCoreDTO pr, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(pr);

            if (await _repo.ExistsByNameAsync(pr.PermissionName, ct))
                throw new InvalidOperationException("A permission with this name already exists.");

            var prDomain = new PermissionDomain
            {
                PermissionName    = pr.PermissionName,
                PermissionDescription      = pr.PermissionDescription,
                
            };

            return await _repo.CreateAsync(prDomain, ct);
        }
    }
}