using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.RoleDtos;
using Mini_E_Ticarət_API.Application.Shared.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private IRoleService _roleService { get; }
    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }


    // GET: api/<RolesController>
    [HttpGet("permissions")]
    public IActionResult GetAllPermissions()
    {
        var permissions = PermissionHelper.GetAllPermissions();
        return Ok(permissions);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleCreateDto dto)
    {
        var result = await _roleService.CreateRole(dto);
        return StatusCode((int)result.StatusCode,result);
    }
}   