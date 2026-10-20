using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using ECommerceInfraStructureLair;

namespace ECommerceInfraStructureLair
{

    internal class OrderRepository : IOrderRepository 
    {


        private ECommerceDbContext _ECommerceDbContext;




        public OrderRepository(ECommerceDbContext ECommerceDbContext)
        {
            _ECommerceDbContext = ECommerceDbContext;
        }
        





        public List<OrderDomain> GetAllOrdersRepository()
        {
            return _ECommerceDbContext.Orders.ToList();
        }
            



        // Create OrderDomain 
        public int CreateOrderRepository(OrderDomain OrderDomain) {

            try
            {

                if (OrderDomain == null)
                    throw new ArgumentNullException(nameof(OrderDomain));

                OrderDomain.OrderID = 0;

                _ECommerceDbContext.Orders.Add(OrderDomain); // This also adds related OrderItems if they exist and navigation is set

                _ECommerceDbContext.SaveChanges();

                return OrderDomain.OrderID;


            }

           catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the OrderDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while creating the OrderDomain.", ex);

            }


        }




            // Update OrderDomain
        public bool UpdateOrderRepository(int orderId, OrderDomain updatedOrder) {

            try
            {

                if (orderId != updatedOrder.OrderID)
                    throw new ArgumentOutOfRangeException(nameof(orderId));

                var existingOrder = _ECommerceDbContext.Orders.Find(orderId);

                if (existingOrder == null)
                    throw new KeyNotFoundException($"OrderDomain with ID {orderId} not found.");


                existingOrder.CreatedAt = updatedOrder.CreatedAt;
                existingOrder.CustomerId = updatedOrder.CustomerId;



                return _ECommerceDbContext.SaveChanges() >0;

            }


            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the OrderDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while Updating the OrderDomain.", ex);

            }


        }









        // Delete OrderDomain
        public bool DeleteOrderRepository(int OrderId) {


            try
            {
                var existingOrder = _ECommerceDbContext.Orders.Find(OrderId);

                if (existingOrder == null)
                    throw new KeyNotFoundException($"OrderDomain with ID {OrderId} not found.");

                _ECommerceDbContext.Orders.Remove(existingOrder);
              
                return   _ECommerceDbContext.SaveChanges() >0;



            }

            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the OrderDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while Updating the OrderDomain.", ex);

            }


        }









        // Get OrderDomain by ID 
        public OrderDomain GetOrderByIdRepository(int orderId ) {

            try
            {

                var OrderDomain = _ECommerceDbContext.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.OrderID == orderId);

                if (OrderDomain == null)
                    throw new KeyNotFoundException($"OrderDomain with ID {orderId} not found.");

                return OrderDomain;
            }


            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the OrderDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while Updating the OrderDomain.", ex);

            }


        }








        // Get OrderDomain by UserID
        public List<OrderDomain> GetOrdersByUserIdRepository(int UserId) {

            // var OrderDomain = _ECommerceDbContext.Orders
            //.Include(o => o.Items)
            //.FirstOrDefault(o => o.OrderID == orderId);

            // if (OrderDomain == null)
            //     throw new KeyNotFoundException($"OrderDomain with ID {orderId} not found.");

            // return OrderDomain;


            return null!;




        }










        // Change OrderDomain Status
        public void ChangeOrderStatusRepository(int orderId, string newStatus) {  }










        // Validate OrderDomain
        public bool ValidateOrderRepository(OrderDomain OrderDomain) { return false; }








    }
}
