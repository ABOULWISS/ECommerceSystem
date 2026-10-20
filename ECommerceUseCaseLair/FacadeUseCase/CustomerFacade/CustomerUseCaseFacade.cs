using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceUseCaseLair;



namespace ECommerceUseCaseLair
{
    public class CustomerUseCaseFacade : ICustomerUseCaseFacade
    {




        private readonly ICreatingCustomerUseCase _CreateCustomerUseCase;
        private readonly IGettingAllCustomerUseCase _GettingAllCustomerUseCase;
        private readonly IGettingCustomersByIDUseCase _GettingCustomerByIDUseCase;
        
        public CustomerUseCaseFacade(ICreatingCustomerUseCase CreateCustomerUseCase , IGettingAllCustomerUseCase GettingAllCustomerUseCase, IGettingCustomersByIDUseCase GettingCustomerByIDUseCas)
        {


            _GettingAllCustomerUseCase = GettingAllCustomerUseCase;
            _CreateCustomerUseCase = CreateCustomerUseCase;
            _GettingCustomerByIDUseCase = GettingCustomerByIDUseCas;


        }



        public int Create(CustomerCoreDTO customerDTO)
        {
            return _CreateCustomerUseCase.Execute(customerDTO);
        }



        public IList<CustomerCoreDTO> GetAll()
        {
            return _GettingAllCustomerUseCase.Execute();
        }




        public CustomerCoreDTO GetByID(int id )
        {
            return _GettingCustomerByIDUseCase.Execute(id);
        }




    }



}
