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
    public class TblAlumnosController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TblAlumnosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/TblAlumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAlumno>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        // GET: api/TblAlumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAlumno>> GetTblAlumno(int id)
        {
            var tblAlumno = await _context.Alumnos.FindAsync(id);

            if (tblAlumno == null)
            {
                return NotFound();
            }

            return tblAlumno;
        }

        // PUT: api/TblAlumnos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAlumno(int id, TblAlumno tblAlumno)
        {
            if (id != tblAlumno.IdAlumno)
            {
                return BadRequest();
            }

            _context.Entry(tblAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAlumnoExists(id))
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

        // POST: api/TblAlumnos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblAlumno>> PostTblAlumno(TblAlumno tblAlumno)
        {
            _context.Alumnos.Add(tblAlumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAlumno", new { id = tblAlumno.IdAlumno }, tblAlumno);
        }

        // DELETE: api/TblAlumnos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAlumno>> DeleteTblAlumno(int id)
        {
            var tblAlumno = await _context.Alumnos.FindAsync(id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(tblAlumno);
            await _context.SaveChangesAsync();

            return tblAlumno;
        }

        private bool TblAlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.IdAlumno == id);
        }
    }
}
