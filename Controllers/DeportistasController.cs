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
    public class DeportistasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public DeportistasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/Deportistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deportista>>> Getdeportistas()
        {
            return await _context.deportistas.ToListAsync();
        }

        // GET: api/Deportistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deportista>> GetDeportista(int id)
        {
            var deportista = await _context.deportistas.FindAsync(id);

            if (deportista == null)
            {
                return NotFound();
            }

            return deportista;
        }

        // PUT: api/Deportistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeportista(int id, Deportista deportista)
        {
            if (id != deportista.Id)
            {
                return BadRequest();
            }

            _context.Entry(deportista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeportistaExists(id))
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

        // POST: api/Deportistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deportista>> PostDeportista(Deportista deportista)
        {
            _context.deportistas.Add(deportista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeportista", new { id = deportista.Id }, deportista);
        }

        // DELETE: api/Deportistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeportista(int id)
        {
            var deportista = await _context.deportistas.FindAsync(id);
            if (deportista == null)
            {
                return NotFound();
            }

            _context.deportistas.Remove(deportista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeportistaExists(int id)
        {
            return _context.deportistas.Any(e => e.Id == id);
        }
    }
}
