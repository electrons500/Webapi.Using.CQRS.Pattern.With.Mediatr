using System;
using System.Collections.Generic;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal Price { get; set; }
}
