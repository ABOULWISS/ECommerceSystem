
using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{


    
    public interface IGetPermissionByNameUseCase
    {
        Task<PermissionCoreDTO?> Execute(string permissionName, CancellationToken ct = default);
    }



}