using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Inmobiliaria.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Infrastructure.Services
{
    public class CloudinaryService : IFotoService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> SubirFotoAsync(IFormFile archivo, bool esHero = false)
        {
            if (archivo.Length == 0) return string.Empty;

            using var stream = archivo.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(archivo.FileName, stream),
                Folder = esHero ? "inmobiliaria_hero" : "inmobiliaria_casas"
            };

            if (esHero)
            {
                uploadParams.Transformation = new Transformation()
                    .Width(1920).Height(1080).Crop("fill").Gravity("auto").Quality("auto").FetchFormat("webp");
            }
            else
            {
                uploadParams.Transformation = new Transformation()
                    .Width(800).Height(500).Crop("fill").Gravity("auto").Quality("80");
            }

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }

        public async Task BorrarFotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
