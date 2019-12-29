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
    public class TblEstadosController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TblEstadosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/TblEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEstado>>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        // GET: api/TblEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEstado>> GetTblEstado(int id)
        {
            var tblEstado = await _context.Estados.FindAsync(id);

            if (tblEstado == null)
            {
                return NotFound();
            }

            return tblEstado;
        }

        // PUT: api/TblEstados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEstado(int id, TblEstado tblEstado)
        {
            if (id != tblEstado.IdEstado)
            {
                return BadRequest();
            }

            _context.Entry(tblEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEstadoExists(id))
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

        // POST: api/TblEstados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblEstado>> PostTblEstado(TblEstado tblEstado)
        {
            _context.Estados.Add(tblEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEstado", new { id = tblEstado.IdEstado }, tblEstado);
        }

        // DELETE: api/TblEstados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEstado>> DeleteTblEstado(int id)
        {
            var tblEstado = await _context.Estados.FindAsync(id);
            if (tblEstado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(tblEstado);
            await _context.SaveChangesAsync();

            return tblEstado;
        }

        private bool TblEstadoExists(int id)
        {
            return _context.Estados.Any(e => e.IdEstado == id);
        }
    }
}
