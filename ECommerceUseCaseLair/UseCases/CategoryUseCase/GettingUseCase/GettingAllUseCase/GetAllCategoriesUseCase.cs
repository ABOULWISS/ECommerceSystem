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
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {


        private readonly ICategoryRepository _repo;





        public GetAllCategoriesUseCase(ICategoryRepository repo)
        {
            _repo = repo;
        }




        public virtual IList<CategoryCoreDTO> Execute()
        {
            List<CategoryDomain> Categories = _repo.GetAllCategoriesRepository();

            List<CategoryCoreDTO> categoryDTOs = new List<CategoryCoreDTO>();

            foreach (var category in Categories)
            {
                var categoryDTO = new CategoryCoreDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    ParentCategoryID = category.ParentCategoryID,

                   
                };

                categoryDTOs.Add(categoryDTO);
            }

            return categoryDTOs;

        }




                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
