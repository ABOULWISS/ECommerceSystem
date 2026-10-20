



using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{


    public sealed class CreateRoleUseCase : ICreateRoleUseCase
    {
        private readonly IRoleRepository _repo;
       

        public CreateRoleUseCase(IRoleRepository repo)
        {
            _repo = repo;
          
        }

        public async Task<int> Execute( RoleCoreDTO role, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(role);

            if (await _repo.ExistsByNameAsync( role.RoleName, ct))
                throw new InvalidOperationException("A role with this name already exists.");

            var roleDomain = new RoleDomain
            {
                RoleName     = role.RoleName,
                RoleDescription      = role.RoleDescription,
            
            };

            return await _repo.CreateAsync(roleDomain, ct);
        }
    }
}