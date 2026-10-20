


using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IGetUserByIdUseCase
    {
        Task<UserCoreDTO?> Execute(int userId, CancellationToken ct = default);
    }

}