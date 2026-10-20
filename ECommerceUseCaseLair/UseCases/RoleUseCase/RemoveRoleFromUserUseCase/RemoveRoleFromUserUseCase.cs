namespace ECommerceUseCaseLair
{
    public sealed class RemoveRoleFromUserUseCase : IRemoveRoleFromUserUseCase
    {
        private readonly IRoleRepository _repo;
        public RemoveRoleFromUserUseCase(IRoleRepository repo) => _repo = repo;

        public Task Execute(int userId, int roleId, CancellationToken ct = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(userId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roleId);
            return _repo.RemoveRoleFromUserAsync(userId, roleId, ct);
        }
    }
}
