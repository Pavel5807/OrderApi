using OrderApi.Models;

namespace OrderApi.Data;

public interface IOrderRepository
{
    IEnumerable<Order> GetOrders();
    Order? GetOrderById(Guid id);
    void CreateOrder(Order order);
    void DeleteOrder(Order order);
    void UpdateOrder(Order order);
    void Save();
    
    bool IsDeleted(Order order);
}
