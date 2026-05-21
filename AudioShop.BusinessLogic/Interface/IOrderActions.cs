using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Enums.Order;
using AudioShop.Domains.Models.Order;
using AudioShop.Domains.Entities.Order;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IOrderActions
    {
        public List<OrderResponseDto> GetAllOrdersOfUserAction(int _userId);
        public OrderResponseDto CreateOrderAction(OrderCreateDto _order);
        public OrderResponseDto UpdateOrderStatusAction(int _orderId, OrderStatus _status);
        public bool DeleteOrderAction(int _orderId);

    }
}