using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Ticarət_API.Application.Abstracts.Services;
using Mini_E_Ticarət_API.Application.DTOs.FileUploadDtos;

namespace Mini_E_Ticarət_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileUploadsController : ControllerBase
{
    private IFileUploadService _fileUploadService {  get; }
    public FileUploadsController(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }


    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] FileUploadDto dto)
    {
        var fileUrl = await _fileUploadService.UploadAsync(dto.File);
        return Ok(new { FileUrl = fileUrl });
    }
}
