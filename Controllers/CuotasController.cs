using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackClub.DataContext;
using BackClub.Models;

namespace BackClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public CuotasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/Cuotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuota>>> Getcuotas()
        {
            return await _context.cuotas.ToListAsync();
        }

        // GET: api/Cuotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuota>> GetCuota(int id)
        {
            var cuota = await _context.cuotas.FindAsync(id);

            if (cuota == null)
            {
                return NotFound();
            }

            return cuota;
        }

        // PUT: api/Cuotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuota(int id, Cuota cuota)
        {
            if (id != cuota.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuotaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cuotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuota>> PostCuota(Cuota cuota)
        {
            _context.cuotas.Add(cuota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuota", new { id = cuota.Id }, cuota);
        }

        // DELETE: api/Cuotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuota(int id)
        {
            var cuota = await _context.cuotas.FindAsync(id);
            if (cuota == null)
            {
                return NotFound();
            }

            _context.cuotas.Remove(cuota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuotaExists(int id)
        {
            return _context.cuotas.Any(e => e.Id == id);
        }
    }
}
