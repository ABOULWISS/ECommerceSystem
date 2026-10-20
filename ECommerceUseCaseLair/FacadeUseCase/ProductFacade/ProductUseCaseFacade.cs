using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;


namespace ECommerceUseCaseLair
{
    public class ProductUseCaseFacade : IProductUseCaseFacade
    {





        private readonly IGetAllProductsUseCase _GetAllProductsUseCase;

        private readonly IGetProductByIDUseCase _GetProductByIDUseCase;

        private readonly ICreateProductUseCase _CreateProductUseCase;

        public ProductUseCaseFacade(IGetAllProductsUseCase ProductUseCaseFacade  , IGetProductByIDUseCase GetProductByIDUseCase , ICreateProductUseCase CreateProductUseCase)
        {


            _GetAllProductsUseCase= ProductUseCaseFacade;
            _GetProductByIDUseCase = GetProductByIDUseCase;
            _CreateProductUseCase = CreateProductUseCase;
        }



     

        public IList<ProductCoreDTO> GetAll()
        {
            return _GetAllProductsUseCase.Execute();
        }


        public ProductCoreDTO GetByID(int id) {

            return _GetProductByIDUseCase.Execute(id);
        }


        public int  Create (ProductCoreDTO productDto) {
            
            return  _CreateProductUseCase.Execute(productDto);
           
        }


    }
}
