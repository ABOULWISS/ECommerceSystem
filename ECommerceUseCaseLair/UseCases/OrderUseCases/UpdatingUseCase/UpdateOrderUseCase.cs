using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public  class UpdateOrderUseCase : IUpdateOrderUseCase
    {


        private readonly IOrderRepository _repo;


        public UpdateOrderUseCase(IOrderRepository repo)
        {
            _repo = repo;
        }


        public bool Execute(int orderId, OrderCoreDTO orderDTO)
        {

            var existingOrder = _repo.GetOrderByIdRepository(orderId);

            if (existingOrder == null)
                throw new ArgumentOutOfRangeException(nameof(orderId));



            existingOrder.CustomerId = orderDTO.CustomerId;
            existingOrder.Status = (ECommerceDomainLair.OrderStatus)orderDTO.Status;




            return _repo.UpdateOrderRepository(orderId, existingOrder);


        }



    }
}
