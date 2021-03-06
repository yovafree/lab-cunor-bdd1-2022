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
    public class ColaboradorController : ControllerBase
    {
        private readonly CunorContext _context;

        public ColaboradorController(CunorContext context)
        {
            _context = context;
        }

        // GET: api/Colaborador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
            return await _context.Colaboradors.ToListAsync();
        }

        // GET: api/Colaborador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(string id)
        {
            var colaborador = await _context.Colaboradors.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        // PUT: api/Colaborador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborador(Guid id, Colaborador colaborador)
        {
            if (id != colaborador.CodColaborador)
            {
                return BadRequest();
            }

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaborador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
            _context.Colaboradors.Add(colaborador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ColaboradorExists(colaborador.CodColaborador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetColaborador", new { id = colaborador.CodColaborador }, colaborador);
        }

        // DELETE: api/Colaborador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(string id)
        {
            var colaborador = await _context.Colaboradors.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaboradors.Remove(colaborador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboradorExists(Guid id)
        {
            return _context.Colaboradors.Any(e => e.CodColaborador == id);
        }
    }
}
