using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceContractLair;
using ECommerceUseCaseLair;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;


namespace ECommerceAPILayer
{
    [Route("api/CategoryAPiController")]
    [ApiController]
    [EnableCors("UseCors")]
    [Authorize]



     public class CategoryAPiController : ControllerBase
    {

        private readonly ICategoryUseCaseFacade _CategoryUseCaseFacade;

        public CategoryAPiController(ICategoryUseCaseFacade CategoryUseCaseFacade)
        {
            _CategoryUseCaseFacade = CategoryUseCaseFacade;
        }





        
        [HttpPost("Create", Name = "CreateCategory")]
        public IActionResult CreateCategory([FromBody] CategoryCoreDTO CategoryDto)
        {
            try
            {
                if (CategoryDto.ParentCategoryID <= 0)
                {
                    CategoryDto.ParentCategoryID = null;
                }

 
                _CategoryUseCaseFacade.Create(CategoryDto);
        
                return Ok("Category  created successfully.");
        
            }
        
            catch (Exception ex)
            {
        
                return BadRequest(ex.Message);
        
            }
        
        }


        
        
        
        
        
        
        
        
        
        
        
        
        






        [HttpGet("GetAll", Name = "GetAllCategorys")]
        [ProducesResponseType(typeof(IList<CategoryCoreDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IList<CategoryCoreDTO>> GetAllCategories()
        {
            try
            {
                IList<CategoryCoreDTO> category = _CategoryUseCaseFacade.GetAll(); // You may or may not use `ProductDto`
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        //[HttpGet("GetByPerentCategoryID", Name = "GetCategorysByPerentCategoryID")]
        //[ProducesResponseType(typeof(IList<CategoryDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //public ActionResult<IList<CategoryDTO>> GetCategorysByPerentCategoryID(int id)
        //{
        //    //try
        //    //{   
        //    //    IList<CategoryDTO> categoryDTO = _ICategoryUseCaseFacade.GetAll(); // You may or may not use `ProductDto`
        //    //    return Ok(categoryDTO);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
        //}




    }

}

