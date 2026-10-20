







using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IUserUseCaseFacade
    {
        Task<IReadOnlyList<UserCoreDTO>> GetAll(CancellationToken ct = default);

        Task<UserCoreDTO?> GetById(int userId, CancellationToken ct = default);

        Task<UserCoreDTO?> GetByName(string userName, CancellationToken ct = default);

        /// <summary>Returns the newly generated identity.</summary>
        Task<int> Create(UserCoreDTO user, CancellationToken ct = default);

        /// <summary>False when no row matched the id.</summary>
        Task<bool> Update(int id , UserCoreDTO user, CancellationToken ct = default);

        Task<bool> Delete(int userId, CancellationToken ct = default);

        Task<bool> ExistsByName(string userName, CancellationToken ct = default);
    }


}