using Microsoft.AspNetCore.Http;

namespace Mini_E_Ticarət_API.Application.Abstracts.Services;

public interface IFileUploadService
{
    Task<string> UploadAsync(IFormFile file);
}
