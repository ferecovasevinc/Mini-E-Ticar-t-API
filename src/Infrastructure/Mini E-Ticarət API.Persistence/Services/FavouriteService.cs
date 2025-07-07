using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Application.Shared;
using Mini_E_Ticarət_API.Domain.Entities;
using System.Net;

namespace Mini_E_Ticarət_API.Persistence.Services;

public class FavouriteService : IFavouriteService
{
    private readonly IFavouriteRepository _favouriteRepository;

    public FavouriteService(IFavouriteRepository favouriteRepository)
    {
        _favouriteRepository = favouriteRepository;
    }

    public async Task<BaseResponse<List<FavouriteListDto>>> GetAllAsync()
    {
        var favourites = await _favouriteRepository.GetAll().ToListAsync();

        var dto = favourites.Select(f => new FavouriteListDto
        {
            Id = f.Id,
            Name = f.Name,
            AppUserId = f.AppUserId,
            ProductId = f.ProductId
        }).ToList();

        return new("List fetched", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<FavouriteListDto>>> GetByUserIdAsync(Guid userId)
    {
        var data = await _favouriteRepository.GetFavouritesByUserIdAsync(userId);
        var dto = data.Select(f => new FavouriteListDto
        {
            Id = f.Id,
            Name = f.Name,
            AppUserId = f.AppUserId,
            ProductId = f.ProductId
        }).ToList();

        return new("User's favourites", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> CreateAsync(FavouriteCreateDto dto)
    {
        var favourite = new Favourite
        {
            Name = dto.Name,
            AppUserId = dto.AppUserId,
            ProductId = dto.ProductId
        };

        await _favouriteRepository.AddAsync(favourite);
        await _favouriteRepository.SaveChangeAsync();
        return new("Created successfully", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> UpdateAsync(Guid id, FavouriteUpdateDto dto)
    {
        var favourite = await _favouriteRepository.GetByIdAsync(id);
        if (favourite == null)
            return new BaseResponse<string>("Favourite not found", null, HttpStatusCode.NotFound);

        favourite.Name = dto.Name;

        _favouriteRepository.Update(favourite);
        await _favouriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Updated successfully", null, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var favourite = await _favouriteRepository.GetByIdAsync(id);
        if (favourite == null)
            return new BaseResponse<string>("Favourite not found", null, HttpStatusCode.NotFound);

        _favouriteRepository.Delete(favourite);
        await _favouriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Deleted successfully", null, HttpStatusCode.OK);
    }

}
