using Microsoft.AspNetCore.Mvc;
using OrderApi.Data;
using OrderApi.Models;

namespace OrderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var order = _repository.GetOrderById(id);

        if (order is null)
        {
            return NotFound();
        }

        if (_repository.IsDeleted(order))
        {
            return BadRequest();
        }

        _repository.DeleteOrder(order);
        _repository.Save();

        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.GetOrders());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var order = _repository.GetOrderById(id);

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Order newOrder)
    {
        var order = _repository.GetOrderById(newOrder.Id);
        
        if (order is not null)
        {
            return BadRequest();
        }

        _repository.CreateOrder(newOrder);
        _repository.Save();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] EditOrder editOrder)
    {
        var order = _repository.GetOrderById(id);

        if (order is null)
        {
            return NotFound();
        }

        order.Status = editOrder.Status;
        order.Lines.Clear();
        order.Lines.AddRange(editOrder.Lines);
        _repository.Save();

        return Ok();
    }
}