using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.Order;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IOrderAction
    {
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderItem(int id);
        ResponceAction CreateOrder(OrderDto order);
        ResponceMsg UpdateOrder(OrderDto order);
        ResponceMsg DeleteOrder(int id);
    }
} 

