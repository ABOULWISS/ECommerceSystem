using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IOrderUseCaseFacade
    {
        int Create(OrderCoreDTO orderDTO);
        bool Delete(int OrderID);
        bool Update(int OrderID, OrderCoreDTO orderDTO);

        IList<OrderCoreDTO> GetAll();

       // OrderDTO GetOrderByID(int OrderID);

        //IList<OrderDTO> GetOrdersByCustomerID(int CustomerID);
    }
}
