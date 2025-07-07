using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.FavouriteDtos;
using Mini_E_Ticarət_API.Application.Shared;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpGet("favourites")]
        [Authorize(Policy = Permissions.Favourite.GetAll)]
        [ProducesResponseType(typeof(BaseResponse<List<FavouriteListDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _favouriteService.GetAllAsync();
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost("{id}/favorite")]
        [Authorize(Policy = Permissions.Favourite.Create)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] FavouriteCreateDto dto)
        {
            var result = await _favouriteService.CreateAsync(dto);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete("{id}/favorite")]
        [Authorize(Policy = Permissions.Favourite.Delete)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _favouriteService.DeleteAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
