using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IOrderItemsRepository
    {

        // Create Order 
        int CreateOrderItemRepository(OrderItemsDomain OrderItems);


        //// Update Order
        //void UpdateOrderItemRepository(int OrderItemsId, OrderItems OrderItems);


        //// Delete Order
        //void DeleteOrderItemRepository(int OrderItemsId);

        //// Get order by ID 
        //Order GetOrderItemByOrderItemIdRepository(int OrderItemId);


        ////get order Item by OrderID
        //List<Order> GetOrderItemsByOrderIDRepository(int OrderID);

    }
}
