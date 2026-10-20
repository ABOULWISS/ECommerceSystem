using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDomainLair;

namespace ECommerceUseCaseLair
{
    public interface ICategoryRepository
    {


        public CategoryDomain GetCategoryByID(int id);
        public List<CategoryDomain> GetAllCategoriesRepository();
        public int CreateCategoryRepository(CategoryDomain Category);
        public List<CategoryDomain> GetCategoryByName(string Name);
        public List<CategoryDomain> GetCategoryByParentCategoryID(int id);

    }
}







