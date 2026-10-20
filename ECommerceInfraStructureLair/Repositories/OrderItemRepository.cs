using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceDomainLair;
using ECommerceUseCaseLair;


namespace ECommerceInfraStructureLair
{
    internal class OrderItemRepository : IOrderItemsRepository 
    {

        private ECommerceDbContext _ECommerceDbContext ;


        public OrderItemRepository( ECommerceDbContext ECommerceDbContext)
        {
            _ECommerceDbContext = ECommerceDbContext;
        }


        
        public int CreateOrderItemRepository(OrderItemsDomain orderItems)
        {

            if (orderItems == null)
                throw new ArgumentNullException(nameof(orderItems));

             orderItems.OrderItemID = 0;
            

             _ECommerceDbContext.OrderItems.Add(orderItems); // This also adds related OrderItems if they exist and navigation is set

             _ECommerceDbContext.SaveChanges();



            return orderItems.OrderItemID ;


        }







        // Update Order
        public void UpdateOrderItemRepository(int orderItemId, OrderItemsDomain updatedOrderItem) {

            if (orderItemId != updatedOrderItem.OrderID)
                throw new ArgumentOutOfRangeException(nameof(orderItemId));

            var existingOrderItem = _ECommerceDbContext.OrderItems.Find(orderItemId);

            if (existingOrderItem == null)
                throw new KeyNotFoundException($"Order Item with ID {orderItemId} not found.");


            existingOrderItem.Quantity = updatedOrderItem.Quantity;
            existingOrderItem.OrderID = updatedOrderItem.OrderID;
            existingOrderItem.ProductID = updatedOrderItem.ProductID;


            _ECommerceDbContext.SaveChanges();


        }






        // Delete Order
        public void DeleteOrderItemRepository(int OrderId) { }









        // Get order by ID 
        public OrderDomain GetOrderItemByOrderItemIdRepository(int OrderItemId) { return null; }


        //get order Item by OrderID
        public List<OrderDomain> GetOrderItemsByOrderIDRepository(int OrderID) { return null; }



    }
}
