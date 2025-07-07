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

        // GET: api/Favourite
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _favouriteService.GetAllAsync();
            return StatusCode((int)response.StatusCode, response);
        }

        // GET: api/Favourite/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var response = await _favouriteService.GetByUserIdAsync(userId);
            return StatusCode((int)response.StatusCode, response);
        }

        // POST: api/Favourite
        [HttpPost]
        [Authorize]  
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] FavouriteCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _favouriteService.CreateAsync(dto);
            return StatusCode((int)response.StatusCode, response);
        }

        // PUT: api/Favourite/{id}
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] FavouriteUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _favouriteService.UpdateAsync(id, dto);
            return StatusCode((int)response.StatusCode, response);
        }

        // DELETE: api/Favourite/{id}
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _favouriteService.DeleteAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
