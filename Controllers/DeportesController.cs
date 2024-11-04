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
    public class DeportesController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public DeportesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/Deportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deporte>>> Getdeportes()
        {
            return await _context.deportes.ToListAsync();
        }

        // GET: api/Deportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deporte>> GetDeporte(int id)
        {
            var deporte = await _context.deportes.FindAsync(id);

            if (deporte == null)
            {
                return NotFound();
            }

            return deporte;
        }

        // PUT: api/Deportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeporte(int id, Deporte deporte)
        {
            if (id != deporte.Id)
            {
                return BadRequest();
            }

            _context.Entry(deporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeporteExists(id))
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

        // POST: api/Deportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deporte>> PostDeporte(Deporte deporte)
        {
            _context.deportes.Add(deporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeporte", new { id = deporte.Id }, deporte);
        }

        // DELETE: api/Deportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeporte(int id)
        {
            var deporte = await _context.deportes.FindAsync(id);
            if (deporte == null)
            {
                return NotFound();
            }

            _context.deportes.Remove(deporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeporteExists(int id)
        {
            return _context.deportes.Any(e => e.Id == id);
        }
    }
}
