






using ECommerceContractLair;

namespace ECommerceUseCaseLair
{


    public interface ICreatePermissionUseCase
    {
        /// <returns>The new user's id.</returns>
        Task<int> Execute(PermissionCoreDTO role, CancellationToken ct = default);
    }

}