



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
    internal class CustomerRepository : ICustomerRepository
    {




        private ECommerceDbContext _ECommerceDbContext;




        public CustomerRepository(ECommerceDbContext ECommerceDbContext)
        {
            _ECommerceDbContext = ECommerceDbContext;
        }



        public List<CustomerDomain> GetAllCustomersRepository()
        {
            return _ECommerceDbContext.Customers.ToList();
        }



        public CustomerDomain GetCustmerByIDRepository(int id)
        {
            return _ECommerceDbContext.Customers.First(c => c.CustomerID == id);
        }


        public List<CustomerDomain> GetCustomerByName(string Name)
        {

            return _ECommerceDbContext.Customers
                                     .Where(c => c.FullName == Name).ToList();
        }


       



        // Create Category 
        public int CreateCustomerRepository(CustomerDomain CustomerDomain)
        {

            try
            {

                if (CustomerDomain == null)
                    throw new ArgumentNullException(nameof(CustomerDomain));
                CustomerDomain.CustomerID = 0;

                _ECommerceDbContext.Customers.Add(CustomerDomain); // This also adds related CategoryItems if they exist and navigation is set

                _ECommerceDbContext.SaveChanges();

                return CustomerDomain.CustomerID;


            }

            catch (DbUpdateException dbEx)
            {

                Console.WriteLine($"Database Update Error: {dbEx.Message}");
                throw new ApplicationException("An error occurred while saving the CustomerDomain to the database.", dbEx);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while creating the CustomerDomain.", ex);

            }


        }





    }
}
