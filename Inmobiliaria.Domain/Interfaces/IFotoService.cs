using Microsoft.AspNetCore.Http;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IFotoService
    {
        Task<string> SubirFotoAsync(IFormFile archivo, bool esHero = false);
        Task BorrarFotoAsync(string publicId); 
    }
}