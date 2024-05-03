using Microsoft.AspNetCore.Http;
using Porsche.Domain.Entities;

namespace Porsche.Application.Abstractions;

public interface IFileService
{
    Task<PhotoEntity> UploadImage(IFormFile file);
}