


using ECommerceContractLair;


namespace ECommerceUseCaseLair
{

    
    

    public interface IUpdateUserUseCase
    {
        /// <returns>False when the user doesn't exist.</returns>
        Task<bool> Execute(int id , UserCoreDTO user, CancellationToken ct = default);
    }

}