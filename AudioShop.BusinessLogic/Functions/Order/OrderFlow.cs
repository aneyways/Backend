using AudioShop.BusinessLogic.Core.Order;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Base;
using AudioShop .Domains.Models.Order;

namespace AudioShop .BusinessLogic.Functions.Order
{
    public class OrderFlow : OrderAction, IOrderAction
    {

        public List<OrderDto> GetAllOrders()
        {
            return GetAllOrdersAction();
        }

        public OrderDto GetOrderItem(int id)
        {
            return GetOrderByIdAction(id);
        }

        public ResponceAction CreateOrder(OrderDto order)
        {
            return CreateOrderAction(order);
        }

        public ResponceMsg UpdateOrder(OrderDto order)
        {
            return UpdateOrderAction(order);
        }

        public ResponceMsg DeleteOrder(int id)
        {
            return DeleteOrderAction(id);
        }
    }
}
