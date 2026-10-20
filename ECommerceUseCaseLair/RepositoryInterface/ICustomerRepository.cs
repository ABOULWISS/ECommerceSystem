using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;



namespace ECommerceUseCaseLair
{


    public interface ICustomerRepository
    {

        
        public List<CustomerDomain> GetAllCustomersRepository();

        public int CreateCustomerRepository(CustomerDomain CustomerDomain);

        public CustomerDomain GetCustmerByIDRepository(int id);

    }


}
