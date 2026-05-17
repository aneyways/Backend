using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Cart;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.BusinessLogic.Core
{
    public class CartActions
    {
        public CartData ExecuteGetCartByUserIdAction(int _userId)
        {
            using (var db = new AppDbContext())
            {
                return db.CartDatas
                            .Include(c => c.Items)
                                .ThenInclude(i => i.Product)
                            .FirstOrDefault(c => c.UserId == _userId);
            }
        }

        public CartItemData ExecutePostItemToCartAction(int _userId, CartItemData _item)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.CartDatas.FirstOrDefault(c => c.UserId == _userId);
                if (cart == null) return null;

                cart.Items.Add(_item);
                db.SaveChanges();

                return _item;
            }
        }

        public bool ExecuteClearCartAction(int _userId)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.CartDatas.FirstOrDefault(c => c.UserId == _userId);
                if (cart == null) return false;

                cart.Items.Clear();
                cart.TotalPrice = 0;

                db.SaveChanges();
                return true;
            }
        }
        public CartData ExecuteDeleteCartItemAction(int _userId, int _itemId)
        {
            using (var db = new AppDbContext())
            {
                var cart = db.CartDatas.FirstOrDefault(c => c.UserId == _userId);

                if (cart == null) return null;

                var item = cart.Items.FirstOrDefault(i => i.Id == _itemId);
                if (item == null) return null;

                cart.Items.Remove(item);
                db.SaveChanges();

                return cart;
                //var item = cart.Items.FirstOrDefault(i => i.Id == _itemId);
                //if (item == null) return null;
                //cart.Items.Remove(item);
                //return cart;
            }
        }

    }
}