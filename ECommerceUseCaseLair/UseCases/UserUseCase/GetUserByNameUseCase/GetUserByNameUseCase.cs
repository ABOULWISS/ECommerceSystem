using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class GetUserByNameUseCase : IGetUserByNameUseCase
    {
        private readonly IUserRepository _repo;
    
        public GetUserByNameUseCase(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    
        public async Task<UserCoreDTO?> Execute(string username, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.", nameof(username));
    
            var user = await _repo.GetByNameAsync(username, ct).ConfigureAwait(false);
    
            return user is null ? null : MapToDto(user);
        }
    
        private static UserCoreDTO MapToDto(UserDomain user) => new()
        {
            UserID = user.UserID,
            UserName = user.UserName,
            Email = user.Email ?? string.Empty,
            IsActive = user.IsActive
        };
    }
}