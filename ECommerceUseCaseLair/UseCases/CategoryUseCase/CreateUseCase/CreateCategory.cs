using ECommerceContractLair;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceUseCaseLair
{
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {




        private readonly ICategoryRepository _repo;


        public CreateCategoryUseCase(ICategoryRepository repo)
        {
            _repo = repo;
        }


        public int Execute(CategoryCoreDTO categoryDto)
        {

            var category = new CategoryDomain
            {
                CategoryID = -1,
                CategoryName = categoryDto.CategoryName,
                CategoryDescription = categoryDto.CategoryDescription,
                ParentCategoryID = categoryDto.ParentCategoryID ,
                CreatedAt = DateTime.Now ,
                UpdatedAt = DateTime.Now ,
            };

            return _repo.CreateCategoryRepository(category);

        }


    }
}


 



    



