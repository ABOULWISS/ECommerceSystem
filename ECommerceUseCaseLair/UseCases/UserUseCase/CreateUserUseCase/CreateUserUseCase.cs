



using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{


    public sealed class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _repo;
       

        public CreateUserUseCase(IUserRepository repo)
        {
            _repo = repo;
          
        }

        public async Task<int> Execute( UserCoreDTO user, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (await _repo.ExistsByNameAsync(user.UserName, ct))
                throw new InvalidOperationException("A user with this name already exists.");

            var userDomain = new UserDomain
            {
                UserName     = user.UserName,
                Email        = string.IsNullOrWhiteSpace(user.Email) ? null : user.Email.Trim(),
                PasswordHash = user.PasswordHash,
                IsActive     = true
            };

            return await _repo.CreateAsync(userDomain, ct);
        }
    }
}