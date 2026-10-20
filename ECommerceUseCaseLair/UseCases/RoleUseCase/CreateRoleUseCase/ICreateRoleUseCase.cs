




using ECommerceContractLair;

namespace ECommerceUseCaseLair
{


    public interface ICreateRoleUseCase
    {
        /// <returns>The new user's id.</returns>
        Task<int> Execute(RoleCoreDTO role, CancellationToken ct = default);
    }

}