using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContractLair;
using ECommerceDomainLair;
using ECommerceUseCaseLair;

namespace ECommerceUseCaseLair
{
    public class GetAllCategoriesDetailsUseCase : IGetAllCategoriesDetailsUseCase
    {


        private readonly ICategoryRepository _repo;





        public GetAllCategoriesDetailsUseCase(ICategoryRepository repo)
        {
            _repo = repo;
        }







        public IList<CategoryDetailsDTO> Execute()
        {
           List<CategoryDomain> categories = _repo.GetAllCategoriesRepository();

           List<CategoryDetailsDTO> categoryDTOs = new List<CategoryDetailsDTO>();

                foreach (var category in categories)
                {
                    var categoryDTO = new CategoryDetailsDTO
                    {
                        Category = new CategoryCoreDTO
                        {
                            CategoryID = category.CategoryID,
                            CategoryName = category.CategoryName,
                            CategoryDescription = category.CategoryDescription,
                            ParentCategoryID = category.ParentCategoryID,
                        },

                        Products = category.Products?
                            .Select(p => new ProductCoreDTO
                            {
                                ProductID = p.ProductID,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                Image = p.Image
                            })
                            .ToList() ?? new List<ProductCoreDTO>(),

                        CategoryDiscounts = category.CategoryDiscount?
                            .Select(d => new CategoryDiscountCoreDTO
                            {
                                // map the fields CategoryDiscountCoreDTO actually has
                            })
                            .ToList() ?? new List<CategoryDiscountCoreDTO>()
                    };

                    categoryDTOs.Add(categoryDTO);
                }

                return categoryDTOs;
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
    }
}
