using ECommerceContractLair;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceUseCaseLair
{
    public class CreatingCustomerUseCase : ICreatingCustomerUseCase
    {




        private readonly ICustomerRepository _repo;


        public CreatingCustomerUseCase(ICustomerRepository repo)
        {
            _repo = repo;
        }


        public int Execute(CustomerCoreDTO customerDto)
        {

            var customer = new CustomerDomain
            {
                CustomerID = -1,
                FullName = customerDto.FullName,
                Phone = customerDto.Phone,
                Email = customerDto.Email,
            };

            return _repo.CreateCustomerRepository(customer);

        }


    }
}



