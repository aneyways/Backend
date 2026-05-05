using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.Order;

namespace AudioShop.BusinessLogic.Core.Order
{
    public class OrderAction
    {
        protected List<OrderDto> GetAllOrdersAction()
        {




            return new List<OrderDto>();
        }


        protected OrderDto GetOrderByIdAction(int id)
        {



            return new OrderDto();
        }

        protected ResponceAction CreateOrderAction(OrderDto order)
        {


            return new ResponceAction();
        }


        protected ResponceMsg UpdateOrderAction(OrderDto order)
        {
            return new ResponceMsg();
        }


        protected ResponceMsg DeleteOrderAction(int id)
        {

            return new ResponceMsg();
        }

    }
}
