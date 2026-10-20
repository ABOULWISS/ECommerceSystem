using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;
using System.ComponentModel.DataAnnotations;

namespace ECommerceUseCaseLair

{

    public class GettingAllCustomerUseCase : IGettingAllCustomerUseCase
    {




        private readonly ICustomerRepository _repo;





        public GettingAllCustomerUseCase(ICustomerRepository repo)
        {
            _repo = repo;
        }




        public IList<CustomerCoreDTO> Execute()
        {
            List<CustomerDomain> customers = _repo.GetAllCustomersRepository();

            List<CustomerCoreDTO> customerDTOs = new List<CustomerCoreDTO>();

            foreach (var customer in customers)
            {
                var customerDTO = new CustomerCoreDTO
                {
                    CustomerID = customer.CustomerID,
                    FullName = customer.FullName,
                    Phone = customer.Phone,
                    Email = customer.Email,
                  
                };

                customerDTOs.Add(customerDTO);
            }

            return customerDTOs;

        }










    }
}
