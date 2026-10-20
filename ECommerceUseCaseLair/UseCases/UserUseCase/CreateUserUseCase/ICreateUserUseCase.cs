




using ECommerceContractLair;

namespace ECommerceUseCaseLair
{


    public interface ICreateUserUseCase
    {
        /// <returns>The new user's id.</returns>
        Task<int> Execute(UserCoreDTO user, CancellationToken ct = default);
    }

}