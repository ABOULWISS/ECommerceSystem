


using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public sealed class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserRepository _repo;
    
        public GetAllUsersUseCase(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    
        public async Task<IReadOnlyList<UserCoreDTO>> Execute(CancellationToken ct = default)
        {
            var users = await _repo.GetAllAsync(ct).ConfigureAwait(false);
    
            return  users
                .Select(MapToDto)
                .ToList()
                .AsReadOnly();
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