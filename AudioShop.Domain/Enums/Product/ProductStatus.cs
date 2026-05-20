using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.Domains.Enums.Product
{
    public enum ProductStatus
    {
        Unknown = 0,
        Active = 1,
        Inactive = 2,
        Discontinued = 3,
        SoldOut = 4,
        OutOfStock = 5,
        PreOrder = 6
    }
}
