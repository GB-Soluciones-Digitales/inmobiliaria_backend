using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConfiguracionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var config = await _context.Configuraciones.FirstOrDefaultAsync();
            if (config == null)
            {
                return Ok(new Configuracion());
            }
            return Ok(config);
        }

        [HttpPost] 
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Configuracion dto)
        {
            var config = await _context.Configuraciones.FirstOrDefaultAsync();
            if (config == null)
            {
                config = new Configuracion();
                _context.Configuraciones.Add(config);
            }

            config.HeroTitulo = dto.HeroTitulo;
            config.HeroSubtitulo = dto.HeroSubtitulo;
            config.HeroImagenUrl = dto.HeroImagenUrl;

            config.HeroTitulo2 = dto.HeroTitulo2;
            config.HeroSubtitulo2 = dto.HeroSubtitulo2;
            config.HeroImagenUrl2 = dto.HeroImagenUrl2;

            await _context.SaveChangesAsync();
            return Ok(config);
        }
    }
}
