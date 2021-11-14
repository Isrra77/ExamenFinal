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
    public class TblStatusController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblStatusController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblStatus>>> GetTblStatuses()
        {
            return await _context.TblStatuses.ToListAsync();
        }

        // GET: api/TblStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblStatus>> GetTblStatus(int id)
        {
            var tblStatus = await _context.TblStatuses.FindAsync(id);

            if (tblStatus == null)
            {
                return NotFound();
            }

            return tblStatus;
        }

        // PUT: api/TblStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblStatus(int id, TblStatus tblStatus)
        {
            if (id != tblStatus.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(tblStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblStatusExists(id))
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

        // POST: api/TblStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblStatus>> PostTblStatus(TblStatus tblStatus)
        {
            _context.TblStatuses.Add(tblStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblStatus", new { id = tblStatus.StatusId }, tblStatus);
        }

        // DELETE: api/TblStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblStatus>> DeleteTblStatus(int id)
        {
            var tblStatus = await _context.TblStatuses.FindAsync(id);
            if (tblStatus == null)
            {
                return NotFound();
            }

            _context.TblStatuses.Remove(tblStatus);
            await _context.SaveChangesAsync();

            return tblStatus;
        }

        private bool TblStatusExists(int id)
        {
            return _context.TblStatuses.Any(e => e.StatusId == id);
        }
    }
}
