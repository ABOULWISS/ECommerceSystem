using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface IOrderRepository
    {

        // Create OrderDomain 
        int CreateOrderRepository(OrderDomain OrderDomain);

        // Update OrderDomain
        bool UpdateOrderRepository(int orderId, OrderDomain OrderDomain);

        // Delete OrderDomain
        bool DeleteOrderRepository(int orderId);

        // Get OrderDomain by ID 
        OrderDomain GetOrderByIdRepository(int orderId);


        // Get OrderDomain by UserID
        List<OrderDomain> GetOrdersByUserIdRepository(int UserId);


        List<OrderDomain> GetAllOrdersRepository();
        

        // Change OrderDomain Status
        void ChangeOrderStatusRepository(int orderId, string newStatus);


        // Validate OrderDomain
        bool ValidateOrderRepository(OrderDomain OrderDomain);



    }
}
