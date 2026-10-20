




using ECommerceUseCaseLair;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;



namespace ECommerceUseCaseLair
{
    public static class ECommerceUseCaseServiceCollectionExtensions
    {




        public static IServiceCollection AddECommerceUseCase(
            this IServiceCollection services )
        {



  
                // Order UseCases + Facades
                services.AddScoped<IOrderUseCaseFacade, OrderUseCaseFacade>();
                services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
                services.AddScoped<IDeleteOrderUseCase, DeleteOrderUseCase>();
                services.AddScoped<IUpdateOrderUseCase, UpdateOrderUseCase>();
                services.AddScoped<IGetOrdersUseCase, GetOrdersUseCase>();
                
                
                
                // Order Items UseCases + Facades
                services.AddScoped<IOrderItemsFacade, OrderItemsFacade>();
                services.AddScoped<ICreatingOrderItemsUseCase, CreateOrderItemsUseCase>();
                
                
                
                
                
                // Product UseCases + Facades
                services.AddScoped<IProductUseCaseFacade, ProductUseCaseFacade>();
                services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
                services.AddScoped<IGetProductByIDUseCase, GetProductByIDUseCase>();
                services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
                
                
                
                
                
                
                // Category UseCases + Facades
                services.AddScoped<ICategoryUseCaseFacade, CategoryUseCaseFacade>();
                services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
                services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
                
                
                
                
                
                
                // Customer UseCases + Facades
                services.AddScoped<ICustomerUseCaseFacade, CustomerUseCaseFacade>();
                services.AddScoped<IGettingAllCustomerUseCase, GettingAllCustomerUseCase>();
                services.AddScoped<IGettingCustomersByIDUseCase, GettingCustomersByIDUseCase>();
                services.AddScoped<ICreatingCustomerUseCase, CreatingCustomerUseCase>();
          



                
                
                
                
                
 
    

                



            //Roles



                //Facade
                services.AddScoped<IRoleUseCaseFacade, RoleUseCaseFacade>();

                //UseCases
                services.AddScoped<IAssignRoleToUserUseCase, AssignRoleToUserUseCase>();
                services.AddScoped<IRemoveRoleFromUserUseCase, RemoveRoleFromUserUseCase>();
                services.AddScoped<IGetUserRolesUseCase, GetUserRolesUseCase>();
                services.AddScoped<IGetRoleByNameUseCase, GetRoleByNameUseCase>();
                services.AddScoped<IRoleExistsByNameUseCase, RoleExistsByNameUseCase>();
                services.AddScoped<IGetRoleByIdUseCase, GetRoleByIdUseCase>();
                services.AddScoped<ICreateRoleUseCase, CreateRoleUseCase>();



            //Users  

                //Facade
                services.AddScoped<IUserUseCaseFacade, UserUseCaseFacade>();

                //UseCases
                services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
                services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
                services.AddScoped<IGetUserByNameUseCase, GetUserByNameUseCase>();
                services.AddScoped<IUserExistsByNameUseCase, UserExistsByNameUseCase>();
                services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
                services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
                services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();






            //Permissions
                //Facade
                services.AddScoped<IPermissionUseCaseFacade, PermissionUseCaseFacade>();
                
                //UseCases
                services.AddScoped<ICreatePermissionUseCase, CreatePermissionUseCase>();
                services.AddScoped<IGetPermissionByIdUseCase, GetPermissionByIdUseCase>();
                services.AddScoped<IGetUserPermissionsUseCase, GetUserPermissionsUseCase>();
                services.AddScoped<IGetRolePermissionsUseCase, GetRolePermissionsUseCase>();
                services.AddScoped<IAssignPermissionToRoleUseCase, AssignPermissionToRoleUseCase>();
                services.AddScoped<IRemovePermissionFromRoleUseCase, RemovePermissionFromRoleUseCase>();
                services.AddScoped<IAssignPermissionToUserUseCase, AssignPermissionToUserUseCase>();
                services.AddScoped<IRemovePermissionFromUserUseCase, RemovePermissionFromUserUseCase>();
                services.AddScoped<IGetPermissionByNameUseCase, GetPermissionByNameUseCase>();


                 



            return services;

        }







    }
}