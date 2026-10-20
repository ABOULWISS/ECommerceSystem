using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<UserDomain>> GetAllAsync(CancellationToken ct = default);

        Task<UserDomain?> GetByIdAsync(int userId, CancellationToken ct = default);

        Task<UserDomain?> GetByNameAsync(string userName, CancellationToken ct = default);

        /// <summary>Returns the newly generated identity.</summary>
        Task<int> CreateAsync(UserDomain user, CancellationToken ct = default);

        /// <summary>False when no row matched the id.</summary>
        Task<bool> UpdateAsync(UserDomain user, CancellationToken ct = default);

        Task<bool> DeleteAsync(int userId, CancellationToken ct = default);

        Task<bool> ExistsByNameAsync(string userName, CancellationToken ct = default);
    }
}



