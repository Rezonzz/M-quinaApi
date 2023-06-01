using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaquinaApi.Models;

namespace MaquinaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsBoxesController : ControllerBase
    {
        private readonly CoinsBoxContext _context;

        public CoinsBoxesController(CoinsBoxContext context)
        {
            _context = context;
        }

        // GET: api/CoinsBoxes
        [Route("/Coins/GetCoinsBox")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoinsBox>>> GetCoinsBox()
        {
          if (_context.CoinsBox == null)
          {
              return NotFound();
          }
            return await _context.CoinsBox.ToListAsync();
        }

        // GET: api/CoinsBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoinsBox>> GetCoinsBox(long id)
        {
          if (_context.CoinsBox == null)
          {
              return NotFound();
          }
            var coinsBox = await _context.CoinsBox.FindAsync(id);

            if (coinsBox == null)
            {
                return NotFound();
            }

            return coinsBox;
        }

        // PUT: api/CoinsBoxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoinsBox(long id, CoinsBox coinsBox)
        {
            if (id != coinsBox.Id)
            {
                return BadRequest();
            }

            _context.Entry(coinsBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinsBoxExists(id))
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

        // POST: api/CoinsBoxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/Coins/PostCoinsBox")]
        [HttpPost]
        public async Task<ActionResult<List<CoinsBox>>> PostCoinsBox(List<CoinsBox> coinsBoxList)
        {
            if (_context.CoinsBox == null)
            {
                return Problem("Entity set 'CoinsBoxContext.CoinsBox' is null.");
            }

            foreach (var coinsBox in coinsBoxList)
            {
                _context.CoinsBox.Add(coinsBox);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoinsBox", coinsBoxList);
        }


        // DELETE: api/CoinsBoxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoinsBox(long id)
        {
            if (_context.CoinsBox == null)
            {
                return NotFound();
            }
            var coinsBox = await _context.CoinsBox.FindAsync(id);
            if (coinsBox == null)
            {
                return NotFound();
            }

            _context.CoinsBox.Remove(coinsBox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoinsBoxExists(long id)
        {
            return (_context.CoinsBox?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
