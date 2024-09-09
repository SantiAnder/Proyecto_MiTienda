using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders_BackEnd.Data;
using Orders_Shared.Entities;

namespace Orders_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsyncCountries()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsyncCountry(int id)
        {
            var pais = await _context.Countries.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyncCountry(Country pais)
        {
            _context.Add(pais);
            await _context.SaveChangesAsync();
            return Ok(pais);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsyncCountrie(Country pais)
        {
            _context.Update(pais);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncCountrie(int id)
        {
            var pais = await _context.Countries.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            _context.Remove(pais);
            await _context.SaveChangesAsync();
            return Ok("Se eliminó el País.");
        }
    }
}