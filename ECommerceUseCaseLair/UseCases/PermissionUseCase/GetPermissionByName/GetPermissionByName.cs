


using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public sealed class GetPermissionByNameUseCase : IGetPermissionByNameUseCase
    {
        private readonly IPermissionsRepository _repo;

        public GetPermissionByNameUseCase(IPermissionsRepository repo) => _repo = repo;

        public async Task<PermissionCoreDTO?> Execute(string permissionName, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(permissionName))
                return null;

            var permission = await _repo.GetPermissionByNameAsync(permissionName.Trim(), ct);

            return permission is null
                ? null
                : new PermissionCoreDTO
                {
                    // adjust to your actual DTO properties
                    PermissionID = permission.PermissionID,
                    PermissionName = permission.PermissionName,
                    PermissionDescription = permission.PermissionDescription,
                    
                };
        }
    }
}


