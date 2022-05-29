using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webservise2022.Models;

namespace Webservise2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaitingItemsController : ControllerBase
    {
        private readonly RaitingContext _context;

        public RaitingItemsController(RaitingContext context)
        {
            _context = context;
        }

        // GET: api/RaitingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaitingItem>>> GetRaitingItems()
        {
          if (_context.RaitingItems == null)
          {
              return NotFound();
          }
            return await _context.RaitingItems.ToListAsync();
        }

        // GET: api/RaitingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaitingItem>> GetRaitingItem(long id)
        {
          if (_context.RaitingItems == null)
          {
              return NotFound();
          }
            var raitingItem = await _context.RaitingItems.FindAsync(id);

            if (raitingItem == null)
            {
                return NotFound();
            }

            return raitingItem;
        }

        // PUT: api/RaitingItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaitingItem(long id, RaitingItem raitingItem)
        {
            if (id != raitingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(raitingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaitingItemExists(id))
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

        // POST: api/RaitingItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaitingItem>> PostRaitingItem(RaitingItem raitingItem)
        {
            _context.RaitingItems.Add(raitingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaitingItem), new { id = raitingItem.Id }, raitingItem);

        }

        // DELETE: api/RaitingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaitingItem(long id)
        {
            if (_context.RaitingItems == null)
            {
                return NotFound();
            }
            var raitingItem = await _context.RaitingItems.FindAsync(id);
            if (raitingItem == null)
            {
                return NotFound();
            }

            _context.RaitingItems.Remove(raitingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaitingItemExists(long id)
        {
            return (_context.RaitingItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
