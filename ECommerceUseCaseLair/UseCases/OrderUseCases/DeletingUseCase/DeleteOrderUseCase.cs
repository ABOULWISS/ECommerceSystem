using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;


namespace ECommerceUseCaseLair
{
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {

        private readonly IOrderRepository _repo;


        public DeleteOrderUseCase(IOrderRepository repo)
        {
            _repo = repo;
        }


        public bool Execute(int OrderID)
        {

            var existingorder = _repo.GetOrderByIdRepository(OrderID);


            if (existingorder == null)
                throw new ArgumentOutOfRangeException(nameof(OrderID));



            return _repo.DeleteOrderRepository(OrderID);


        }



    }
}
