using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;



namespace ECommerceUseCaseLair
{
    public interface ICustomerUseCaseFacade
    {

        int Create(CustomerCoreDTO customerDTO);
        //bool Delete(int CustomerID);
        //bool Update(int CustomerID, CustomerDTO CustomerDTO);

        IList<CustomerCoreDTO> GetAll();
        CustomerCoreDTO GetByID(int ID);


    }
}
