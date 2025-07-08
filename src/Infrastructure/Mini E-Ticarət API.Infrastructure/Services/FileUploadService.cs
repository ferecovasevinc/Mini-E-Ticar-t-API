using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Mini_E_Ticarət_API.Application.Abstracts.Services;

namespace Mini_E_Ticarət_API.Infrastructure.Services;

public class FileUploadService : IFileUploadService
{
    private  IWebHostEnvironment _env { get; }
    public FileUploadService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileName = GetUniqueFileName(uploadsFolder, file.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/uploads/{fileName}";
    }


    private string GetUniqueFileName(string uploadsFolderPath, string originalFileName)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
        var fileExtension = Path.GetExtension(originalFileName);
        var fileName = fileNameWithoutExtension + fileExtension;
        var counter = 1;

        while (File.Exists(Path.Combine(uploadsFolderPath, fileName)))
        {
            fileName = $"{fileNameWithoutExtension}({counter}){fileExtension}";
            counter++;
        }

        return fileName;
    }
}
