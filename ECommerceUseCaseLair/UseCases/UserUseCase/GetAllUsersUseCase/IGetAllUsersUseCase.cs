



using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IGetAllUsersUseCase
    {
        Task<IReadOnlyList<UserCoreDTO>> Execute(CancellationToken ct = default);
    }


}