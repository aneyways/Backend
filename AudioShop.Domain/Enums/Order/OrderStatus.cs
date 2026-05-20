using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.Domains.Enums.Order
{
    public enum OrderStatus
    {
        Unknown = 0,
        Pending = 1, //ожидает оплаты
        Confirmed = 2,  //оплата получена, заказ подтвержден
        Processing = 3, // сборка на складе
        Shipped = 4, // в пути
        Delivered = 5,
        Cancelled = 6,
        Returned = 7
    }
}