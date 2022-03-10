using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cunor.api.Models;

namespace cunor.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly CunorContext _context;

        public PuestosController(CunorContext context)
        {
            _context = context;
        }

        // GET: api/Puestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuesto()
        {
            return await _context.Puestos.ToListAsync();
        }

        // GET: api/Puestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(string id)
        {
            var puesto = await _context.Puestos.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return puesto;
        }

        // PUT: api/Puestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(string id, Puesto puesto)
        {
            if (String.IsNullOrEmpty(puesto.CodPuesto.ToString()))
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PuestoExists(puesto.CodPuesto.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPuesto", new { id = puesto.CodPuesto }, puesto);
        }

        // DELETE: api/Puestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(string id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuestoExists(string id)
        {
            return _context.Puestos.Any(e => e.CodPuesto.ToString() == id);
        }
    }
}
