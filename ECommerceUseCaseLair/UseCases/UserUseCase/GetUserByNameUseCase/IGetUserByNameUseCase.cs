



using ECommerceContractLair;


namespace ECommerceUseCaseLair
{
    public interface IGetUserByNameUseCase
    {
        Task<UserCoreDTO?> Execute(string userName, CancellationToken ct = default);
    }
}