using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public class GettingCustomersByIDUseCase : IGettingCustomersByIDUseCase
    {
        private readonly ICustomerRepository _repo;

        public GettingCustomersByIDUseCase(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public CustomerCoreDTO Execute(int id)
        {
            // Implementation for getting a customer by ID
            throw new NotImplementedException();
        }
    }
}
