using AudioShop.BusinessLogic.Core;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Models.Cart;
using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Models.Cart;

namespace AudioShop.BusinessLogic.Functions
{
    public class CartFlow : CartActions, ICartAction
    {
        public CartResponseDto GetCartByUserIdAction(int _userId)
        {
            var cart = ExecuteGetCartByUserIdAction(_userId);

            if (cart == null) return null;
            CartResponseDto cartDto = new CartResponseDto()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items,
                Status = cart.Status,

            };

            return cartDto;
        }

        public CartResponseDto PostItemToCartAction(int _userId, CartItemDto _item)
        {
            var cartItem = new CartItemData
            {
                ProductId = _item.ProductId,
                Quantity = _item.Quantity,
                UnitPrice = _item.UnitPrice,
                TotalPrice = _item.Quantity * _item.UnitPrice
            };

            var saved = ExecutePostItemToCartAction(_userId, cartItem);
            if (saved == null) return null;

            var cart = ExecuteGetCartByUserIdAction(_userId);
            return new CartResponseDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items,
                Status = cart.Status,
            };
        }

        public CartResponseDto DeleteCartItemAction(int _userId, int _itemId)
        {
            var cart = ExecuteDeleteCartItemAction(_userId, _itemId);
            if (cart == null) return null;

            return new CartResponseDto()

            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items,
                Status = cart.Status,
            };
        }

        public bool ClearCartAction(int _userId)
        {
            return ExecuteClearCartAction(_userId);
        }

    }
}