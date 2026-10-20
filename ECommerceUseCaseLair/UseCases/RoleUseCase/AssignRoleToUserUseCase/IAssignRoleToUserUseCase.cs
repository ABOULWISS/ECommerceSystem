



using ECommerceContractLair;
using System;

namespace ECommerceUseCaseLair
{
    public interface IAssignRoleToUserUseCase
    {
        Task Execute(int userId, int roleId, CancellationToken ct = default);
    }
}