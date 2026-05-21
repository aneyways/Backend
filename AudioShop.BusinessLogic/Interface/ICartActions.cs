using AudioShop.Domains.Models.Cart;
using AudioShop.Domains.Entities.Cart;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ICartActions
    {
        public CartResponseDto GetCartByUserIdAction(int _userId);

        public CartResponseDto PostItemToCartAction(int _userId, CartItemDto _item);

        public CartResponseDto DeleteCartItemAction(int _userId, int _itemId);

        public bool ClearCartAction(int _userId);
    }
}