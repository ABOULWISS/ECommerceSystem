






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
    public class CreateProductUseCase : ICreateProductUseCase
    {


        private readonly IProductRepository _repo;





        public CreateProductUseCase(IProductRepository repo)
        {
            _repo = repo;
        }




        public int Execute(ProductCoreDTO productDto)
        {

             var product = new ProductDomain
             {
                ProductID = -1,
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Price = productDto.Price,
                Status = (ECommerceDomainLair.ProductStatus)productDto.Status,
                Image = productDto.Image,
                CategoryID = productDto.CategoryID,
               
             };
             
             return _repo.CreateProductRepository(product);


        }



    }
}

   
  
      
    
