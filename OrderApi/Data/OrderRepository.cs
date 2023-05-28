using Microsoft.EntityFrameworkCore;
using OrderApi.Models;

namespace OrderApi.Data;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public IEnumerable<OrderApi.Models.Order> GetOrders()
    {
        return _context.Orders.Include(order => order.Lines).ToList();
    }

    public OrderApi.Models.Order? GetOrderById(Guid id)
    {
        return _context.Orders.Where(order => order.Id == id).Include(order => order.Lines).FirstOrDefault();
    }

    public void CreateOrder(OrderApi.Models.Order order)
    {
        _context.Orders.Add(order);
    }

    public void DeleteOrder(OrderApi.Models.Order order)
    {
        _context.Entry(order).State = EntityState.Deleted;
    }

    public void UpdateOrder(OrderApi.Models.Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool IsDeleted(Order order)
    {
        return _context.Entry(order).State is EntityState.Deleted;
    }
}