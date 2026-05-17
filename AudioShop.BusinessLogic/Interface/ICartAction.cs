using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Models.Cart;

namespace AudioShop.BusinessLogic.Interfaces
{
    public interface ICartAction
    {
        public CartResponseDto GetCartByUserIdAction(int _userId);

        public CartResponseDto PostItemToCartAction(int _userId, CartItemData _item);

        public CartResponseDto DeleteCartItemAction(int _userId, int _itemId);

        public bool ClearCartAction(int _userId);
    }
}