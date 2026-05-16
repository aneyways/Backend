using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Enums;
using AudioShop.Domains.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IOrderActions
    {
        public List<OrderInfoDto> GetAllOrdersAction();
        public List<OrderInfoDto> GetUserOrdersByIdAction(int userId);

        public OrderInfoDto? GetOrderByIdAction(int id);

        public OrderInfoDto? UpdateOrderStatusAction(int id, OrderStatus newStatus);

        public OrderInfoDto CreateOrderAction(OrderCreateDto order);
    }
}