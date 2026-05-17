using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AudioShop.BusinessLogic.Interfaces;
using AudioShop.Domains.Enums.Order;
using AudioShop.Domains.Models.Order;

namespace AudioShop.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private IOrderActions _orderActions;
        public OrderController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _orderActions = _bl.GetOrderActions();
        }

        [HttpGet("{_userId}")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetAllOrdersOfUser(int _userId)
        {
            var _orders = _orderActions.GetAllOrdersOfUserAction(_userId);
            return Ok(_orders);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateOrder([FromBody] OrderCreateDto _order)
        {
            var order = _orderActions.CreateOrderAction(_order);
            if (order == null) return BadRequest();
            return Ok(order);
        }

        [HttpPut("{_orderId}/status")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult UpdateOrderStatus(int _orderId, [FromBody] OrderStatus _status)
        {
            var order = _orderActions.UpdateOrderStatusAction(_orderId, _status);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpDelete("{_orderId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteOrder(int _orderId)
        {
            var result = _orderActions.DeleteOrderAction(_orderId);
            if (!result) return NotFound();
            return NoContent();
        }



    }
}