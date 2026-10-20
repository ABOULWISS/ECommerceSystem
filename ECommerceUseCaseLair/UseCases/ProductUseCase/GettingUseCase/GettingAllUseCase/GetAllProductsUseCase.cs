using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceUseCaseLair
{
    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {


        private readonly IProductRepository _repo;





        public GetAllProductsUseCase(IProductRepository repo)
        {
            _repo = repo;
        }




        public IList<ProductCoreDTO> Execute()
        {
            List<ProductDomain> products = _repo.GetAllProductsRepository();

            List<ProductCoreDTO> productDTOs = new List<ProductCoreDTO>();

            foreach (var product in products)
            {
                var productDTO = new ProductCoreDTO
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
      
                    Image = product.Image
                };

                productDTOs.Add(productDTO);
            }

            return productDTOs;

        }



    }
}
