using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Porsche.Application.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Application.Services;

public class FileService : IFileService
{
    const string folderName = "Images";

    public async Task<PhotoEntity> UploadImage(IFormFile file)
    {
        try
        {
            string homeDirectory = Directory.GetCurrentDirectory();
            string pathToSave = Path.Combine(homeDirectory, "Images");
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().Split(new[] { '.' });
            var newFileName = new string(Guid.NewGuid() + "." + fileName.Last());
            var fullPath = Path.Combine(pathToSave, newFileName);
            var dbPath = Path.Combine(folderName, newFileName);
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new PhotoEntity()
            {
                FileName = fileName.ToString(),
                Path = pathToSave
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}