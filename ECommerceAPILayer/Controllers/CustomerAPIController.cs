
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;
using ECommerceContractLair;
using Microsoft.AspNetCore.Authorization;



namespace ECommerceAPILayer
{

    
    [Route("api/CustomerAPI")]
    [EnableCors("UseCors")]
    [ApiController]
    [Authorize]


    public class CustomerAPIController : ControllerBase
    {







  
        private readonly ICustomerUseCaseFacade _customerUseCaseFacade;








        public CustomerAPIController(ICustomerUseCaseFacade customerUseCaseFacade)
        {
            _customerUseCaseFacade = customerUseCaseFacade;
            
        }














        [HttpGet("GetAll", Name = "GetAllCustomers")]
        [ProducesResponseType(typeof(IList<CustomerCoreDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IList<CustomerCoreDTO>> GetAllCustomers()
        {
            try
            {
                IList<CustomerCoreDTO> Customer = _customerUseCaseFacade.GetAll(); // You may or may not use `ProductDto`
                return Ok(Customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        [HttpGet("GetCustomerByID/{ID}", Name = "GetCustomerByID")]
        [ProducesResponseType(typeof(CustomerCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerCoreDTO> GetCustomerByID(int ID)
        {
            try
            {

                CustomerCoreDTO customer = _customerUseCaseFacade.GetByID(ID);

                if (customer == null)
                {
                    return NotFound($"customer with ID {ID} not found.");
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }












        [HttpPost("Create", Name = "CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerCoreDTO customerDto)
        {
            try
            {
                if (customerDto == null )
                    return BadRequest("Invalid customer data.");

                

                // 1. Create the order first
                var customerId = _customerUseCaseFacade.Create(customerDto);

                if (customerId > 0)
                    return Ok(new { Message = "customer created successfully.", CustomerId = customerId });

                return BadRequest("Failed to create customer items.");

            }
                 


            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }







    }
}
