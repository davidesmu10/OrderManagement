using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<OrderDto>> GetAll()
    {
        var orders = await _repo.GetAllAsync();

        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            CustomerName = o.CustomerName,
            TotalAmount = o.TotalAmount
        });
    }

    public async Task<OrderDto?> GetById(int id)
    {
        var o = await _repo.GetByIdAsync(id);
        if (o == null) return null;

        return new OrderDto
        {
            Id = o.Id,
            CustomerName = o.CustomerName,
            TotalAmount = o.TotalAmount
        };
    }

    public async Task Create(CreateOrderDto dto)
    {
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            Items = dto.Items.Select(i => new OrderItem
            {
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList()
        };

        order.TotalAmount = order.Items.Sum(x => x.Price * x.Quantity);

        await _repo.AddAsync(order);
    }

    public async Task Delete(int id)
    {
        await _repo.DeleteAsync(id);
    }
}