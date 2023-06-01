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
    public class DrinksController : ControllerBase
    {
        private readonly DrinksContext _context;

        public DrinksController(DrinksContext context)
        {
            _context = context;
        }

        // GET: api/Drinks
        [Route("/Drinks/GetDrinks")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drinks>>> GetDrinks()
        {
          if (_context.Drinks == null)
          {
              return NotFound();
          }
            return await _context.Drinks.ToListAsync();
        }

        // GET: api/Drinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drinks>> GetDrinks(long id)
        {
          if (_context.Drinks == null)
          {
              return NotFound();
          }
            var drinks = await _context.Drinks.FindAsync(id);

            if (drinks == null)
            {
                return NotFound();
            }

            return drinks;
        }

        // PUT: api/Drinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinks(long id, Drinks drinks)
        {
            if (id != drinks.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinksExists(id))
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

        // POST: api/Drinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/Drinks/PostDrinks")]
        [HttpPost]
        public async Task<ActionResult<List<Drinks>>> PostDrinks(List<Drinks> drinksList)
        {
            if (_context.Drinks == null)
            {
                return Problem("Entity set 'DrinksContext.Drinks' is null.");
            }

            foreach (var drinks in drinksList)
            {
                _context.Drinks.Add(drinks);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinks", drinksList);
        }

        // DELETE: api/Drinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinks(long id)
        {
            if (_context.Drinks == null)
            {
                return NotFound();
            }
            var drinks = await _context.Drinks.FindAsync(id);
            if (drinks == null)
            {
                return NotFound();
            }

            _context.Drinks.Remove(drinks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinksExists(long id)
        {
            return (_context.Drinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
