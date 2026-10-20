




using ECommerceContractLair;

namespace ECommerceUseCaseLair
{




    public sealed class UserUseCaseFacade : IUserUseCaseFacade
    {
        private readonly IGetAllUsersUseCase _getAll;
        private readonly IGetUserByIdUseCase _getById;
        private readonly IGetUserByNameUseCase _getByName;
        private readonly ICreateUserUseCase _create;
        private readonly IUpdateUserUseCase _update;
        private readonly IDeleteUserUseCase _delete;
        private readonly IUserExistsByNameUseCase _existsByName;

        public UserUseCaseFacade(
            IGetAllUsersUseCase getAll,
            IGetUserByIdUseCase getById,
            IGetUserByNameUseCase getByName,
            ICreateUserUseCase create,
            IUpdateUserUseCase update,
            IDeleteUserUseCase delete,
            IUserExistsByNameUseCase existsByName)
        {
            _getAll = getAll;
            _getById = getById;
            _getByName = getByName;
            _create = create;
            _update = update;
            _delete = delete;
            _existsByName = existsByName;
        }

        public Task<IReadOnlyList<UserCoreDTO>> GetAll(CancellationToken ct = default)
            => _getAll.Execute(ct);

        public Task<UserCoreDTO?> GetById(int userId, CancellationToken ct = default)
            => _getById.Execute(userId, ct);

        public Task<UserCoreDTO?> GetByName(string userName, CancellationToken ct = default)
            => _getByName.Execute(userName, ct);

        public Task<int> Create(UserCoreDTO user, CancellationToken ct = default)
            => _create.Execute(user, ct);

        public Task<bool> Update(int id , UserCoreDTO user, CancellationToken ct = default)
            => _update.Execute(id ,user, ct);

        public Task<bool> Delete(int userId, CancellationToken ct = default)
            => _delete.Execute(userId, ct);

        public Task<bool> ExistsByName(string userName, CancellationToken ct = default)
            => _existsByName.Execute(userName, ct);
    }
}