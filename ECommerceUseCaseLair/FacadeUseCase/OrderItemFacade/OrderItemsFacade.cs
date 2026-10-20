using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;


namespace ECommerceUseCaseLair
{
    public class OrderItemsFacade : IOrderItemsFacade
    {


        private readonly ICreatingOrderItemsUseCase _CreateOrderItemsUseCase;
     

        public OrderItemsFacade(ICreatingOrderItemsUseCase createOrderItemsUseCase)
        {



            _CreateOrderItemsUseCase = createOrderItemsUseCase;
          

        }



        public int Create(OrderItemCoreDTO orderitemsDTO)
        {
            return _CreateOrderItemsUseCase.Execute(orderitemsDTO);
        }


        public int Create(OrderItemDetailsDTO orderitemsDetailsDTO)
        {
            return _CreateOrderItemsUseCase.Execute(orderitemsDetailsDTO);
        }






        //public bool Delete(int OrderID)
        //{
        //    return _DeleteOrderUseCase.Execute(OrderID);
        //}



        //public bool Update(int OrderID, OrderItemsDTO orderDTO)
        //{
        //    return _UpdateOrderUseCase.Execute(OrderID, orderDTO);
        //}



        //public IList<OrderItemsDTO> GetAll()
        //{
        //    return _Ge.Execute();
        //}




    }
}
