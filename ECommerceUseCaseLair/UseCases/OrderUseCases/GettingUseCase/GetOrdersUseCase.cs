using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public class GetOrdersUseCase : IGetOrdersUseCase
    {

        private readonly IOrderRepository _repo;


        public GetOrdersUseCase(IOrderRepository repo)
        {
            _repo = repo;
        }


        public IList<OrderCoreDTO> Execute()
        {
            List<OrderDomain> orders = _repo.GetAllOrdersRepository();

            // هنا نحضّر قائمة جديدة من النوع DTO
            List<OrderCoreDTO> orderDTOs = new List<OrderCoreDTO>();

            foreach (var order in orders)
            {
                var orderDTO = new OrderCoreDTO
                {
                    OrderID = order.OrderID,
                    CustomerId = order.CustomerId,
                   
                };

                orderDTOs.Add(orderDTO);
            }

            return orderDTOs;

        }



    }
}
