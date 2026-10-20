using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceContractLair;
using ECommerceUseCaseLair;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPILayer
{          
    [Route("api/ProductController")]
    [ApiController]
    [EnableCors("UseCors")]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductUseCaseFacade _ProductUseCaseFacade;



        public ProductController(IProductUseCaseFacade ProductUseCaseFacade)
        {
            _ProductUseCaseFacade = ProductUseCaseFacade;
        }





       [HttpPost("Create", Name = "CreateProduct")]
        public IActionResult CreateProduct(ProductCoreDTO productDto)
        {
           _ProductUseCaseFacade.Create(productDto);

           return Ok();
        }





        [HttpGet("GetAll", Name = "GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductCoreDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IList<ProductCoreDTO>> GetAllProducts()
        {
            try
            {
                IList<ProductCoreDTO> Product = _ProductUseCaseFacade.GetAll(); // You may or may not use `ProductDto`
                return Ok(Product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    



        [HttpGet("GetProductByID/{ID}", Name = "GetProductByID")]
        [ProducesResponseType(typeof(ProductCoreDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductCoreDTO> GetProductByID(int ID)
        {
            try
            {
               
                ProductCoreDTO product = _ProductUseCaseFacade.GetByID(ID);

                if (product == null)
                {
                    return NotFound($"Product with ID {ID} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }



        
    }
}
