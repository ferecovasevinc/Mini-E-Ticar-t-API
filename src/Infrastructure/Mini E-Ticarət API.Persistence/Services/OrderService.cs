using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.OrderDtos;
using Mini_E_Ticarət_API.Application.Shared;
using Mini_E_Ticarət_API.Domain.Entities;
using System.Net;

namespace Mini_E_Ticarət_API.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<BaseResponse<string>> CreateAsync(OrderCreateDto dto)
    {
        Order order = new()
        {
            Name = dto.Name,
            BuyerId = dto.BuyerId,
            OrderDate = dto.OrderDate,
            TotalPrice = dto.TotalPrice,
            Status = "Pending"
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangeAsync();

        return new BaseResponse<string>("Order created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<List<OrderListDto>>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAll().ToListAsync();

        var dtos = orders.Select(o => new OrderListDto
        {
            Id = o.Id,
            Name = o.Name,
            BuyerId = o.BuyerId,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
            Status = o.Status
        }).ToList();

        return new BaseResponse<List<OrderListDto>>("Orders fetched", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<OrderListDto>> GetByIdAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            return new BaseResponse<OrderListDto>("Order not found", null, HttpStatusCode.NotFound);

        var dto = new OrderListDto
        {
            Id = order.Id,
            Name = order.Name,
            BuyerId = order.BuyerId,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Status = order.Status
        };

        return new BaseResponse<OrderListDto>("Order fetched", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> UpdateAsync(OrderUpdateDto dto)
    {
        var order = await _orderRepository.GetByIdAsync(dto.Id);
        if (order == null)
            return new BaseResponse<string>("Order not found", null, HttpStatusCode.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Status))
            order.Status = dto.Status;

        await _orderRepository.SaveChangeAsync();
        return new BaseResponse<string>("Order updated", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            return new BaseResponse<string>("Order not found", null, HttpStatusCode.NotFound);

        _orderRepository.Delete(order);
        await _orderRepository.SaveChangeAsync();

        return new BaseResponse<string>("Order deleted", HttpStatusCode.OK);
    }
}
