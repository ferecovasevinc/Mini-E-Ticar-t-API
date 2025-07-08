using Microsoft.EntityFrameworkCore;
using Mini_E_Ticarət_API.Application.Abstracts.Repositories;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.ReviewDtos;
using Mini_E_Ticarət_API.Application.Shared;
using Mini_E_Ticarət_API.Domain.Entities;
using System.Net;

namespace Mini_E_Ticarət_API.Persistence.Services;

public class ReviewService : IReviewService
{
    private IReviewRepository _reviewRepo { get; }

    public ReviewService(IReviewRepository reviewRepo)
    {
        _reviewRepo = reviewRepo;
    }

    public async Task<BaseResponse<string>> CreateAsync(ReviewCreateDto dto, Guid userId)
    {
        Review review = new()
        {
            Comment = dto.Comment,
            Rating = dto.Rating,
            ProductId = dto.ProductId,
            AppUserId = userId
        };

        await _reviewRepo.AddAsync(review);
        await _reviewRepo.SaveChangeAsync();

        return new BaseResponse<string>("Review created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> UpdateAsync(ReviewUpdateDto dto, Guid userId)
    {
        var review = await _reviewRepo.GetByIdAsync(dto.Id);
        if (review == null || review.AppUserId != userId)
            return new BaseResponse<string>("Not found or unauthorized", null, HttpStatusCode.Forbidden);

        review.Comment = dto.Comment;
        review.Rating = dto.Rating;

        await _reviewRepo.SaveChangeAsync();

        return new BaseResponse<string>("Review updated", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id, Guid userId)
    {
        var review = await _reviewRepo.GetByIdAsync(id);
        if (review == null || review.AppUserId != userId)
            return new BaseResponse<string>("Not found or unauthorized", null, HttpStatusCode.Forbidden);

        _reviewRepo.Delete(review);
        await _reviewRepo.SaveChangeAsync();

        return new BaseResponse<string>("Review deleted", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<ReviewListDto>>> GetByProductIdAsync(Guid productId)
    {
        var reviews = await _reviewRepo.GetAll()
            .Where(x => x.ProductId == productId)
            .ToListAsync();

        var dtoList = reviews.Select(r => new ReviewListDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            ProductId = r.ProductId,
            AppUserId = r.AppUserId
        }).ToList();

        return new BaseResponse<List<ReviewListDto>>("Fetched", dtoList, HttpStatusCode.OK);
    }
}
