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
    public class TblCatedraticoesController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblCatedraticoesController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblCatedraticoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCatedratico>>> GetTblCatedraticos()
        {
            return await _context.TblCatedraticos.ToListAsync();
        }
        // GET: api/TblCatedraticoes
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<TblCatedratico>>> GetTblCatedraticosActivo()
        {
            var tblCatedraticoActivo = await _context.TblCatedraticos.Where(TblCatedratico => TblCatedratico.CatStatus=="Activo").ToListAsync();
            return tblCatedraticoActivo;
        }
        // GET: api/TblCatedraticoes
        [HttpGet("aprobados")]
        public async Task<ActionResult<IEnumerable<TblStatus>>> GetTblCatedraticosAprobado()
        {
            var tblCatedraticoAprobado = await _context.TblStatuses.Where(TblCatedratico => TblCatedratico.Status== "Aprobado").ToListAsync();
            return tblCatedraticoAprobado;
        }
        // GET: api/TblCatedraticoes
        [HttpGet("reprobados")]
        public async Task<ActionResult<IEnumerable<TblStatus>>> GetTblCatedraticosReprobado()
        {
            var tblCatedraticoReprobado = await _context.TblStatuses.Where(TblCatedratico => TblCatedratico.Status == "Reprobado").ToListAsync();
            return tblCatedraticoReprobado;
        }

        // GET: api/TblCatedraticoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatedratico>> GetTblCatedratico(int id)
        {
            var tblCatedratico = await _context.TblCatedraticos.FindAsync(id);

            if (tblCatedratico == null)
            {
                return NotFound();
            }

            return tblCatedratico;
        }

        // PUT: api/TblCatedraticoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCatedratico(int id, TblCatedratico tblCatedratico)
        {
            if (id != tblCatedratico.CatId)
            {
                return BadRequest();
            }

            _context.Entry(tblCatedratico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCatedraticoExists(id))
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

        // POST: api/TblCatedraticoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCatedratico>> PostTblCatedratico(TblCatedratico tblCatedratico)
        {
            _context.TblCatedraticos.Add(tblCatedratico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCatedratico", new { id = tblCatedratico.CatId }, tblCatedratico);
        }

        // DELETE: api/TblCatedraticoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCatedratico>> DeleteTblCatedratico(int id)
        {
            TblCatedratico catedratico = _context.TblCatedraticos.Where(catedratico => catedratico.CatId == id).FirstOrDefault();
            catedratico.CatStatus = "Inactivo";
            await _context.SaveChangesAsync();
            return catedratico;
        }

        private bool TblCatedraticoExists(int id)
        {
            return _context.TblCatedraticos.Any(e => e.CatId == id);
        }
    }
}
