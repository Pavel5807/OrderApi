using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class Line
{
    public System.Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public System.Guid OrderId { get; set; }
}