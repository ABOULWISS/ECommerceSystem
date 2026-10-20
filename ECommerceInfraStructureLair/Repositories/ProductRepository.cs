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
    internal class ProductRepository : IProductRepository
    {


        private ECommerceDbContext _ECommerceDbContext;




        public ProductRepository(ECommerceDbContext ECommerceDbContext)
        {
            _ECommerceDbContext = ECommerceDbContext;
        }





        
        public List<ProductDomain> GetAllProductsRepository()
        {
            return _ECommerceDbContext.Products.ToList();
        }


        public ProductDomain GetProductByIDRepository(int id)
        {
            var product = _ECommerceDbContext.Products.FirstOrDefault(x => x.ProductID == id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            return product;
        }




        

        // Create Product 
        public int CreateProductRepository(ProductDomain Product)
        {

            try
            {

                if (Product == null)
                    throw new ArgumentNullException(nameof(Product));

                Product.ProductID = 0;

                _ECommerceDbContext.Products.Add(Product); // This also adds related ProductItems if they exist and navigation is set

                _ECommerceDbContext.SaveChanges();

                return Product.ProductID;


            }

            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the Product to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while creating the Product.", ex);

            }


        }




        // Update Product
        //public bool UpdateProductRepository(int ProductId, Product updatedProduct)
        //{

        //    try
        //    {

        //        if (ProductId != updatedProduct.ProductID)
        //            throw new ArgumentOutOfRangeException(nameof(ProductId));

        //        var existingProduct = _ECommerceDbContext.Products.Find(ProductId);

        //        if (existingProduct == null)
        //            throw new KeyNotFoundException($"Product with ID {ProductId} not found.");


        //        existingProduct.CreatedAt = updatedProduct.CreatedAt;
        //        existingProduct.CustomerID = updatedProduct.CustomerID;



        //        return _ECommerceDbContext.SaveChanges() > 0;

        //    }


        //    catch (DbUpdateException dbEx)
        //    {

        //        Console.WriteLine($"Database Update Error: {dbEx.Message}");
        //        throw new ApplicationException("An error occurred while saving the Product to the database.", dbEx);

        //    }

        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Unexpected Error: {ex.Message}");
        //        throw new ApplicationException("An unexpected error occurred while Updating the Product.", ex);

        //    }


        //}









        // Delete Product
        public bool DeleteProductRepository(int ProductId)
        {


            try
            {
                var existingProduct = _ECommerceDbContext.Products.Find(ProductId);

                if (existingProduct == null)
                    throw new KeyNotFoundException($"Product with ID {ProductId} not found.");

                _ECommerceDbContext.Products.Remove(existingProduct);

                return _ECommerceDbContext.SaveChanges() > 0;



            }

            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the Product to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while Updating the Product.", ex);

            }


        }









        //// Get Product by ID 
        //public Product GetProductByIdRepository(int ProductId)
        //{

        //    try
        //    {

        //        var Product = _ECommerceDbContext.Products
        //        .Include(o => o.Items)
        //        .FirstOrDefault(o => o.ProductID == ProductId);

        //        if (Product == null)
        //            throw new KeyNotFoundException($"Product with ID {ProductId} not found.");

        //        return Product;
        //    }


        //    catch (DbUpdateException dbEx)
        //    {

        //        Console.WriteLine($"Database Update Error: {dbEx.Message}");
        //        throw new ApplicationException("An error occurred while saving the Product to the database.", dbEx);

        //    }

        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Unexpected Error: {ex.Message}");
        //        throw new ApplicationException("An unexpected error occurred while Updating the Product.", ex);

        //    }


        //}









    }
}
