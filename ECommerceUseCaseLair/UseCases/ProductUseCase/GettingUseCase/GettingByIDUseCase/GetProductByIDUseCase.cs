using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using ECommerceContractLair;

namespace ECommerceUseCaseLair

{

    public class GetProductByIDUseCase : IGetProductByIDUseCase
    {


        private readonly IProductRepository _repo;





        public GetProductByIDUseCase(IProductRepository repo)
        {
            _repo = repo;
        }




        public ProductCoreDTO Execute(int id )
        {


            ProductDomain product = _repo.GetProductByIDRepository(id);

            if (product == null)
                return null!;

            ProductCoreDTO productDTO = new ProductCoreDTO
            {
                ProductID = id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Image = product.Image
            };

            return productDTO;
        }



    }
}
