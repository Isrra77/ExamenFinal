using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenFinal.Models;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCursoesController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblCursoesController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblCursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCurso>>> GetTblCursos()
        {
            return await _context.TblCursos.ToListAsync();
        }

        // GET: api/TblCursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCurso>> GetTblCurso(int id)
        {
            var tblCurso = await _context.TblCursos.FindAsync(id);

            if (tblCurso == null)
            {
                return NotFound();
            }

            return tblCurso;
        }

        // PUT: api/TblCursoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCurso(int id, TblCurso tblCurso)
        {
            if (id != tblCurso.CursoId)
            {
                return BadRequest();
            }

            _context.Entry(tblCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCursoExists(id))
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

        // POST: api/TblCursoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCurso>> PostTblCurso(TblCurso tblCurso)
        {
            _context.TblCursos.Add(tblCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCurso", new { id = tblCurso.CursoId }, tblCurso);
        }

        // DELETE: api/TblCursoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCurso>> DeleteTblCurso(int id)
        {
            var tblCurso = await _context.TblCursos.FindAsync(id);
            if (tblCurso == null)
            {
                return NotFound();
            }

            _context.TblCursos.Remove(tblCurso);
            await _context.SaveChangesAsync();

            return tblCurso;
        }

        private bool TblCursoExists(int id)
        {
            return _context.TblCursos.Any(e => e.CursoId == id);
        }
    }
}
