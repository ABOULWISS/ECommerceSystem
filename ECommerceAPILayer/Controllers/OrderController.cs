using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;
using ECommerceContractLair;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;


namespace ECommerceAPILayer
{

    
    [Route("api/Order")]
    [ApiController]
    [EnableCors("UseCors")]
    [Authorize]


    public class OrderController : ControllerBase
    {

        public readonly IOrderUseCaseFacade _orderUseCaseFacade;

        internal OrderController(IOrderUseCaseFacade orderUseCaseFacade)
        {
            _orderUseCaseFacade = orderUseCaseFacade;
        }











    //    [HttpPost("GetAll", Name = "GetAllOrder")]
    //    [ProducesResponseType(typeof(IList<OrderDTO>), StatusCodes.Status200OK)]
    //    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    //    public ActionResult<IList<OrderDTO>> GetAllOrders()
    //    {
    //        try
    //        {
    //            IList<OrderDTO> orders = _orderUseCaseFacade.GetAll(); // You may or may not use `orderDto`
    //            return Ok(orders);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    }
}
