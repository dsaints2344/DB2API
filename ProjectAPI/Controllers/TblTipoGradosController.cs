using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblTipoGradosController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TblTipoGradosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/TblTipoGrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTipoGrado>>> GetTipoGrados()
        {
            return await _context.TipoGrados.ToListAsync();
        }

        // GET: api/TblTipoGrados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTipoGrado>> GetTblTipoGrado(int id)
        {
            var tblTipoGrado = await _context.TipoGrados.FindAsync(id);

            if (tblTipoGrado == null)
            {
                return NotFound();
            }

            return tblTipoGrado;
        }

        // PUT: api/TblTipoGrados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTipoGrado(int id, TblTipoGrado tblTipoGrado)
        {
            if (id != tblTipoGrado.IdTipoGrado)
            {
                return BadRequest();
            }

            _context.Entry(tblTipoGrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTipoGradoExists(id))
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

        // POST: api/TblTipoGrados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblTipoGrado>> PostTblTipoGrado(TblTipoGrado tblTipoGrado)
        {
            _context.TipoGrados.Add(tblTipoGrado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTipoGrado", new { id = tblTipoGrado.IdTipoGrado }, tblTipoGrado);
        }

        // DELETE: api/TblTipoGrados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTipoGrado>> DeleteTblTipoGrado(int id)
        {
            var tblTipoGrado = await _context.TipoGrados.FindAsync(id);
            if (tblTipoGrado == null)
            {
                return NotFound();
            }

            _context.TipoGrados.Remove(tblTipoGrado);
            await _context.SaveChangesAsync();

            return tblTipoGrado;
        }

        private bool TblTipoGradoExists(int id)
        {
            return _context.TipoGrados.Any(e => e.IdTipoGrado == id);
        }
    }
}
