using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Models.Cart;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ICartActions
    {
        CartDto? GetCartAction();
        CartDto? AddItemToCartAction(CartItemDto item);
        CartDto? UpdateCartItemAction(int itemId, CartItemDto item);
        bool DeleteCartItemAction(int itemId);
        bool ClearCartAction();

    }
}