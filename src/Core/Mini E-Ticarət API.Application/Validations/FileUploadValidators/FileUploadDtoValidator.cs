using FluentValidation;
using Mini_E_Ticarət_API.Application.DTOs.FileUploadDtos;

namespace Mini_E_Ticarət_API.Application.Validations.FileUploadValidators;

public class FileUploadDtoValidator : AbstractValidator<FileUploadDto>
{
    public FileUploadDtoValidator()
    {
        RuleFor(x => x.File)
        .NotEmpty()
            .WithMessage("You have to upload at least 1 fille")
        .Must(file => file.Length > 0).WithMessage("File cannot be empty")
        .Must(file => file.Length <= 3L * 1024 * 1024 * 1024)  
            .WithMessage("The file size cannot exceed 3GB");
    }
}
