using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IOrderItemsFacade
    {


        int Create(OrderItemDetailsDTO orderDTO);
        int Create(OrderItemCoreDTO orderDTO);
        //bool Delete(int OrderItemsID);
        //bool Update(int OrderItemsID, OrderItemsDTO orderItemsDTO);

        //IList<OrderItemsDTO> GetAll();
    }
}
