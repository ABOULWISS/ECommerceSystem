


/*
using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{

    public sealed class GetUserByIdUseCase : IGetUserByIdUseCase
    {


        private readonly IUserRepository _repo;



        public GetUserByIdUseCase(IUserRepository repo)
        {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

   




        public async Task<IReadOnlyList<UserCoreDTO>> Execute(int userId,CancellationToken ct = default)
        {
          var user = await _repo.GetByIdAsync(userId , ct).ConfigureAwait(false);

          return  user
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

*/




using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUserRepository _repo;
    
        public GetUserByIdUseCase(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
    
        public async Task<UserCoreDTO?> Execute(int userId, CancellationToken ct = default)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(nameof(userId));
    
            var user = await _repo.GetByIdAsync(userId, ct).ConfigureAwait(false);
    
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