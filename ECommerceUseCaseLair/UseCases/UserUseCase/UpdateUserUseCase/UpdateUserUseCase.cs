using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair{

    public sealed class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _repo;
    
        public UpdateUserUseCase(IUserRepository repo)
            => _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    
        public async Task<bool> Execute(int id, UserCoreDTO request, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        
            if (string.IsNullOrWhiteSpace(request.UserName))
                throw new ArgumentException("User name is required.", nameof(request));
        
            var user = await _repo.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (user is null) return false;
        
            if (HasValue(request.UserName))
            {
                var newName = request.UserName.Trim();
        
                if (!string.Equals(user.UserName, newName, StringComparison.OrdinalIgnoreCase)
                    && await _repo.ExistsByNameAsync(newName, ct).ConfigureAwait(false))
                    throw new InvalidOperationException("A user with this name already exists.");
        
                user.UserName = newName;
            }
        
            if (HasValue(request.Email))
                user.Email = request.Email!.Trim();
        
            if (HasValue(request.PasswordHash))
                user.PasswordHash = request.PasswordHash!.Trim(); // ideally: _hasher.Hash(request.Password)
        
            user.IsActive = request.IsActive;
        
            return await _repo.UpdateAsync(user, ct).ConfigureAwait(false);
        }



        private static bool HasValue(string? s) =>
                !string.IsNullOrWhiteSpace(s) &&
                !string.Equals(s.Trim(), "string", StringComparison.OrdinalIgnoreCase);
    }
}