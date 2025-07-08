using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.OrderProductDtos;
using Mini_E_Ticarət_API.Application.Shared;
using Mini_E_Ticarət_API.Domain.Entities;
using System.Net;
using Microsoft.EntityFrameworkCore;


namespace Mini_E_Ticarət_API.Persistence.Services;

public class OrderProductService : IOrderProductService
{
    private readonly IOrderProductRepository _repo;

    public OrderProductService(IOrderProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<BaseResponse<string>> CreateAsync(OrderProductCreateDto dto)
    {
        OrderProduct entity = new()
        {
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Price = dto.Price
        };

        await _repo.AddAsync(entity);
        await _repo.SaveChangeAsync();

        return new BaseResponse<string>("Created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> UpdateAsync(OrderProductUpdateDto dto)
    {
        var entity = await _repo.GetByIdAsync(dto.Id);
        if (entity == null)
            return new BaseResponse<string>("Not Found", null, HttpStatusCode.NotFound);

        entity.Quantity = dto.Quantity;
        entity.Price = dto.Price;

        await _repo.SaveChangeAsync();

        return new BaseResponse<string>("Updated", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
            return new BaseResponse<string>("Not Found", null, HttpStatusCode.NotFound);

        _repo.Delete(entity);
        await _repo.SaveChangeAsync();

        return new BaseResponse<string>("Deleted", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<OrderProductListDto>>> GetAllAsync()
    {
        var list = await _repo.GetAll().ToListAsync();
        var dtoList = list.Select(x => new OrderProductListDto
        {
            Id = x.Id,
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            Price = x.Price
        }).ToList();

        return new BaseResponse<List<OrderProductListDto>>("Fetched", dtoList, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<OrderProductListDto>> GetByIdAsync(Guid id)
    {
        var x = await _repo.GetByIdAsync(id);
        if (x == null)
            return new BaseResponse<OrderProductListDto>("Not Found", null, HttpStatusCode.NotFound);

        var dto = new OrderProductListDto
        {
            Id = x.Id,
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            Price = x.Price
        };

        return new BaseResponse<OrderProductListDto>("Fetched", dto, HttpStatusCode.OK);
    }
}

