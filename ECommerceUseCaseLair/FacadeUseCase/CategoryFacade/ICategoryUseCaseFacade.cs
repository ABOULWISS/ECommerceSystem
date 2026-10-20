using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;

namespace ECommerceUseCaseLair
{
    public interface ICategoryUseCaseFacade
    {

        IList<CategoryCoreDTO> GetAll();

        int Create( CategoryCoreDTO categoryCoreDTO );
    }
}
