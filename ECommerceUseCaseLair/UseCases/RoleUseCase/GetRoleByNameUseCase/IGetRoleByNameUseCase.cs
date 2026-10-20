


using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IGetRoleByNameUseCase
    {
        Task<RoleCoreDTO?> Execute(string roleName, CancellationToken ct = default);
    }

}