using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public class CreateOrderItemsUseCase : ICreatingOrderItemsUseCase
    {

        private readonly IOrderItemsRepository _repo;


        public CreateOrderItemsUseCase(IOrderItemsRepository repo)
        {
            _repo = repo;
        }


        public int Execute(OrderItemCoreDTO orderitemsDto)
        {

            var Item = new OrderItemsDomain
            {
                OrderItemID = -1,
                ProductID = orderitemsDto.ProductID,
                Quantity = orderitemsDto.Quantity,
                OrderID = orderitemsDto.OrderID
                
            };

            return _repo.CreateOrderItemRepository(Item);

        }

     
        public int Execute(OrderItemDetailsDTO orderitemsDto)
        {

            var Item = new OrderItemsDomain();

            return _repo.CreateOrderItemRepository(Item);

        }



    }
}
