using Microsoft.AspNetCore.Http;

namespace Mini_E_Ticarət_API.Application.DTOs.FileUploadDtos;

public class FileUploadDto
{
    public IFormFile File { get; set; } = null!;
}
