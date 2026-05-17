using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.Domains.Enums.Order
{
    public enum OrderStatus
    {
        New,
        Processing,
        Delivered,
        Cancelled,
    }
}