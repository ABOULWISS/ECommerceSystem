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
    public class CategoryUseCaseFacade : ICategoryUseCaseFacade
    {





        private readonly IGetAllCategoriesUseCase _GetAllCategoriesUseCase;
        private readonly ICreateCategoryUseCase _CreateCategoryUseCase;




         public CategoryUseCaseFacade(IGetAllCategoriesUseCase GetAllCategoriesUseCase , ICreateCategoryUseCase CreateCategoryUseCase)
        {


            _GetAllCategoriesUseCase = GetAllCategoriesUseCase;
            _CreateCategoryUseCase = CreateCategoryUseCase;

        }





        public IList<CategoryCoreDTO> GetAll()
        {
            return _GetAllCategoriesUseCase.Execute();
        }


        public int Create(CategoryCoreDTO categoryCoreDTO)
        {
            return _CreateCategoryUseCase.Execute(categoryCoreDTO);
        }



    }
}
