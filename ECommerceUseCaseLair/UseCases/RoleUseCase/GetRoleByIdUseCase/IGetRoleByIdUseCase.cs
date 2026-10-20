


using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IGetRoleByIdUseCase
    {
        Task<RoleCoreDTO?> Execute(int roleId, CancellationToken ct = default);
    }

}