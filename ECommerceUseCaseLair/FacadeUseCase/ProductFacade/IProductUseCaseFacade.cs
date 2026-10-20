using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface IProductUseCaseFacade
    {
     

        IList<ProductCoreDTO> GetAll();

        ProductCoreDTO GetByID(int ID);

        int Create(ProductCoreDTO productDto);
    }
}
