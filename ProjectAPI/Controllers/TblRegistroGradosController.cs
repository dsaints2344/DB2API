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
    public class TblRegistroGradosController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TblRegistroGradosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/TblRegistroGrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRegistroGrado>>> GetRegistroGrados()
        {
            return await _context.RegistroGrados.ToListAsync();
        }

        // GET: api/TblRegistroGrados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRegistroGrado>> GetTblRegistroGrado(int id)
        {
            var tblRegistroGrado = await _context.RegistroGrados.FindAsync(id);

            if (tblRegistroGrado == null)
            {
                return NotFound();
            }

            return tblRegistroGrado;
        }

        // PUT: api/TblRegistroGrados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRegistroGrado(int id, TblRegistroGrado tblRegistroGrado)
        {
            if (id != tblRegistroGrado.IdRegistroGrado)
            {
                return BadRequest();
            }

            _context.Entry(tblRegistroGrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRegistroGradoExists(id))
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

        // POST: api/TblRegistroGrados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblRegistroGrado>> PostTblRegistroGrado(TblRegistroGrado tblRegistroGrado)
        {
            _context.RegistroGrados.Add(tblRegistroGrado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRegistroGrado", new { id = tblRegistroGrado.IdRegistroGrado }, tblRegistroGrado);
        }

        // DELETE: api/TblRegistroGrados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblRegistroGrado>> DeleteTblRegistroGrado(int id)
        {
            var tblRegistroGrado = await _context.RegistroGrados.FindAsync(id);
            if (tblRegistroGrado == null)
            {
                return NotFound();
            }

            _context.RegistroGrados.Remove(tblRegistroGrado);
            await _context.SaveChangesAsync();

            return tblRegistroGrado;
        }

        private bool TblRegistroGradoExists(int id)
        {
            return _context.RegistroGrados.Any(e => e.IdRegistroGrado == id);
        }
    }
}
