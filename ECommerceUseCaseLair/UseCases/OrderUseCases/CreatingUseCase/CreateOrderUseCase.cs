using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {

        private readonly IOrderRepository _repo;


        public  CreateOrderUseCase(IOrderRepository repo)
        {
            _repo = repo;
        }


        public int Execute(OrderCoreDTO orderDto)
        {

            var order = new OrderDomain
            {
                OrderID = -1,
                CustomerId = orderDto.CustomerId,
                CreatedAt = DateTime.Now,
                Status =  (ECommerceDomainLair.OrderStatus)orderDto.Status,
            };

            return _repo.CreateOrderRepository(order);

        }




    }
}
