using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceUseCaseLair;
using ECommerceContractLair;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;




namespace ECommerceAPILayer
{
    [Route("api/OrderItemsAPI")]
    [ApiController]
    [EnableCors("UseCors")]
    [Authorize]
    public class OrderItemsAPIController : ControllerBase
    {







        private readonly IOrderItemsFacade _orderItemsFacade;
        private readonly IOrderUseCaseFacade _orderUseCaseFacade;








        public OrderItemsAPIController(IOrderUseCaseFacade orderUseCaseFacade , IOrderItemsFacade orderItemsFacade)
        {
            _orderUseCaseFacade = orderUseCaseFacade;
            _orderItemsFacade =  orderItemsFacade;
        }












        [HttpPost("Create", Name = "CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrderItemDetailsDTO orderItemsDto)
        {
            try
            {
                if (orderItemsDto == null || orderItemsDto.Order == null)
                    return BadRequest("Invalid order data.");

                OrderCoreDTO orderDTO = orderItemsDto.Order;

                // 1. Create the order first
                var orderId = _orderUseCaseFacade.Create(orderDTO);
                if (orderId <= 0)
                    return BadRequest("Failed to create order.");

                // 2. Attach orderId to items and save them
                orderItemsDto.Order.OrderID = orderId;
                var itemResult = _orderItemsFacade.Create(orderItemsDto);

                if (itemResult > 0)
                    return Ok(new { Message = "Order created successfully.", OrderId = orderId });

                return BadRequest("Failed to create order items.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }
}
