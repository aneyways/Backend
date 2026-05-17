using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Enums.Order;
using AudioShop.Domains.Models.Order;
using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Enums.Order;
using AudioShop.Domains.Models.Order;
using AudioShop.Domains.Models.Product;

namespace AudioShop.BusinessLogic.Functions
{
    public class OrderFlow : OrderActions, IOrderActions
    {
        public List<OrderResponseDto> GetAllOrdersOfUserAction(int _userId)
        {
            var orders = ExecuteGetAllOrdersOfUserAction(_userId);
            List<OrderResponseDto> ordersDto = new List<OrderResponseDto>();
            foreach (var order in orders)
            {
                ordersDto.Add(new OrderResponseDto()
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    Items = order.Items,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                });
            }
            return ordersDto;
        }

        public OrderResponseDto CreateOrderAction(OrderCreateDto _order)
        {
            var order = ExecuteCreateOrderAction(_order);
            if (order == null) return null;
            return new OrderResponseDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = order.Items,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
            };
        }

        public OrderResponseDto UpdateOrderStatusAction(int _orderId, OrderStatus _status)
        {
            var order = ExecuteUpdateOrderStatusAction(_orderId, _status);
            if (order == null) return null;
            return new OrderResponseDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = order.Items,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
            };
        }

        public bool DeleteOrderAction(int _orderId)
        {
            return ExecuteDeleteOrderAction(_orderId);
        }
    }
}