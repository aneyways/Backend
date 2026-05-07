using AudioShop.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Api.Controller
{
    [Route("api/order")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private IOrderAction _order;

        public OrderController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _order = bl.GetOrderActions();
        }

        public IActionResult GetAllOrders()
        {
            var orders = _order.GetAllOrdersAction();
            return Ok(orders);
        }

    }
}