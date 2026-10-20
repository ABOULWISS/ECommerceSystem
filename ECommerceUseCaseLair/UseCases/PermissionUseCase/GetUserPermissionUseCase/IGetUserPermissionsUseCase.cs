




namespace ECommerceUseCaseLair
{
    


    public interface IGetUserPermissionsUseCase
    {
        Task<IReadOnlyList<string>> Execute(int userId, CancellationToken ct = default);
    }


}




