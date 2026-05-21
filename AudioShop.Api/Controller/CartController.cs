using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private ICartActions _cartActions;
        public CartController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _cartActions = _bl.GetCartActions();
        }

        [HttpGet("{_userId}")] //get cart by user id
        [Authorize]
        public IActionResult GetCartByUserId(int _userId)
        {
            var _cart = _cartActions.GetCartByUserIdAction(_userId);
            if (_cart == null) return NotFound();

            return Ok(_cart);
        }

        [HttpPost("{_userId}/items")]
        [Authorize]
        public IActionResult PostItemToCart(int _userId, [FromBody] CartItemDto _item)
        {
            var _cart = _cartActions.PostItemToCartAction(_userId, _item);
            if (_cart == null) return BadRequest();
            return Ok(_cart);
        }

        [HttpDelete("{_userId}/items/{_itemId}")]
        [Authorize]
        public IActionResult DeleteCartItem(int _userId, int _itemId)
        {
            var _cart = _cartActions.DeleteCartItemAction(_userId, _itemId);
            if (_cart == null) return NotFound();
            return Ok(_cart);
        }

        [HttpDelete("{_userId}")]
        [Authorize]
        public IActionResult ClearCart(int _userId)
        {
            var result = _cartActions.ClearCartAction(_userId);
            if (!result) return NotFound();
            return Ok();
        }

    }
}