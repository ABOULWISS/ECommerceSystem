using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface ICreateOrderUseCase
    {
        int Execute(OrderCoreDTO orderdto);
    }
}
