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
    public class TblMaestrosController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TblMaestrosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/TblMaestros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMaestro>>> GetMaestros()
        {
            return await _context.Maestros.ToListAsync();
        }

        // GET: api/TblMaestros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMaestro>> GetTblMaestro(int id)
        {
            var tblMaestro = await _context.Maestros.FindAsync(id);

            if (tblMaestro == null)
            {
                return NotFound();
            }

            return tblMaestro;
        }

        // PUT: api/TblMaestros/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMaestro(int id, TblMaestro tblMaestro)
        {
            if (id != tblMaestro.IdMaestro)
            {
                return BadRequest();
            }

            _context.Entry(tblMaestro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMaestroExists(id))
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

        // POST: api/TblMaestros
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblMaestro>> PostTblMaestro(TblMaestro tblMaestro)
        {
            _context.Maestros.Add(tblMaestro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMaestro", new { id = tblMaestro.IdMaestro }, tblMaestro);
        }

        // DELETE: api/TblMaestros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMaestro>> DeleteTblMaestro(int id)
        {
            var tblMaestro = await _context.Maestros.FindAsync(id);
            if (tblMaestro == null)
            {
                return NotFound();
            }

            _context.Maestros.Remove(tblMaestro);
            await _context.SaveChangesAsync();

            return tblMaestro;
        }

        private bool TblMaestroExists(int id)
        {
            return _context.Maestros.Any(e => e.IdMaestro == id);
        }
    }
}
