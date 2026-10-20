using ECommerceContractLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceUseCaseLair
{
    public interface IGettingCustomersByIDUseCase
    {

        CustomerCoreDTO Execute(int id );

    }
}
