using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;



namespace ECommerceUseCaseLair
{


    public interface IProductRepository
    {


        public List<ProductDomain> GetAllProductsRepository();

        public int CreateProductRepository(ProductDomain ProductDomain);

        public ProductDomain GetProductByIDRepository(int id);

    }


}
