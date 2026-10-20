using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;


namespace ECommerceUseCaseLair
{
    public class OrderUseCaseFacade : IOrderUseCaseFacade
    {
        private readonly ICreateOrderUseCase _CreateOrderUseCase;
        private readonly IDeleteOrderUseCase _DeleteOrderUseCase;
        private readonly IUpdateOrderUseCase _UpdateOrderUseCase;
        private readonly IGetOrdersUseCase _GetOrdersUseCase;


        public OrderUseCaseFacade(ICreateOrderUseCase CreateOrderUseCase, IDeleteOrderUseCase DeleteOrderUseCase,
                                        IUpdateOrderUseCase UpdateOrderUseCase  , IGetOrdersUseCase getOrdersUseCase)
        {



            _CreateOrderUseCase = CreateOrderUseCase;
            _DeleteOrderUseCase = DeleteOrderUseCase;
            _UpdateOrderUseCase = UpdateOrderUseCase;
            _GetOrdersUseCase = getOrdersUseCase;


        }



        public int Create(OrderCoreDTO orderDTO)
        {
           return _CreateOrderUseCase.Execute(orderDTO);
        }


        public bool Delete(int OrderID)
        {
           return _DeleteOrderUseCase.Execute(OrderID);
        }



        public bool Update(int OrderID , OrderCoreDTO orderDTO)
        {
           return _UpdateOrderUseCase.Execute(OrderID , orderDTO);
        }



        public IList<OrderCoreDTO> GetAll()
        {
            return _GetOrdersUseCase.Execute();
        }




    }



}
