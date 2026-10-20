using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceDomainLair;
using ECommerceUseCaseLair;
using ECommerceInfraStructureLair;

namespace ECommerceInfraStructureLair
{
    internal  class CategoryRepository  : ICategoryRepository
    {

     
        
     


        private ECommerceDbContext _ECommerceDbContext;




        public CategoryRepository( ECommerceDbContext ECommerceDbContext)
        {
             _ECommerceDbContext = ECommerceDbContext;
        }



        public List<CategoryDomain> GetAllCategoriesRepository()
        {
            return _ECommerceDbContext.Categories
            .Include(c => c.Products)
            .ToList();
        }



        public CategoryDomain GetCategoryByID(int id)
        {
            return _ECommerceDbContext.Categories.First(c => c.CategoryID == id);
        }


        public List<CategoryDomain> GetCategoryByName(string Name)
        {

            return _ECommerceDbContext.Categories
                                     .Where(c=> c.CategoryName == Name).ToList();
        }


        public List<CategoryDomain> GetCategoryByParentCategoryID(int id )
        {

            return _ECommerceDbContext.Categories
                                     .Where(c => c.ParentCategoryID == id).ToList();
        }



        // Create CategoryDomain 
        public int CreateCategoryRepository(CategoryDomain CategoryDomain)
        {

            try
            {

                if (CategoryDomain == null)
                    throw new ArgumentNullException(nameof(CategoryDomain));
                CategoryDomain.CategoryID = 0;

                _ECommerceDbContext.Categories.Add(CategoryDomain); // This also adds related CategoryItems if they exist and navigation is set

                _ECommerceDbContext.SaveChanges();

                return CategoryDomain.CategoryID;


            }

            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the CategoryDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while creating the CategoryDomain.", ex);

            }


        }





    }
}
