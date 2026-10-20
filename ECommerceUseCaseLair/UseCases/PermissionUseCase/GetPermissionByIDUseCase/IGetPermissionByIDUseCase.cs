





using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IGetPermissionByIdUseCase
    {
        Task<PermissionCoreDTO?> Execute(int prId, CancellationToken ct = default);
    }

}