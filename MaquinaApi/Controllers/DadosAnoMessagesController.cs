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
    public class DadosAnoMessagesController : ControllerBase
    {
        private readonly DadosAnoMessagesContext _context;

        public DadosAnoMessagesController(DadosAnoMessagesContext context)
        {
            _context = context;
        }

        // GET: api/DadosAnoMessages
        [Route("/DadosAnoMessages/GetDadosAnoMessages")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosAnoMessages>>> GetDadosAnoMessages()
        {
          if (_context.DadosAnoMessages == null)
          {
              return NotFound();
          }
            return await _context.DadosAnoMessages.ToListAsync();
        }

        // GET: api/DadosAnoMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DadosAnoMessages>> GetDadosAnoMessages(long id)
        {
          if (_context.DadosAnoMessages == null)
          {
              return NotFound();
          }
            var dadosAnoMessages = await _context.DadosAnoMessages.FindAsync(id);

            if (dadosAnoMessages == null)
            {
                return NotFound();
            }

            return dadosAnoMessages;
        }

        // PUT: api/DadosAnoMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDadosAnoMessages(long id, DadosAnoMessages dadosAnoMessages)
        {
            if (id != dadosAnoMessages.Id)
            {
                return BadRequest();
            }

            _context.Entry(dadosAnoMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosAnoMessagesExists(id))
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

        // POST: api/DadosAnoMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/DadosAnoMessages/PostDadosAnoMessages")]
        [HttpPost]
        public async Task<ActionResult<DadosAnoMessages>> PostDadosAnoMessages(DadosAnoMessages dadosAnoMessages)
        {
          if (_context.DadosAnoMessages == null)
          {
              return Problem("Entity set 'DadosAnoMessagesContext.DadosAnoMessages'  is null.");
          }
            _context.DadosAnoMessages.Add(dadosAnoMessages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosAnoMessages", new { id = dadosAnoMessages.Id }, dadosAnoMessages);
        }

        // DELETE: api/DadosAnoMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDadosAnoMessages(long id)
        {
            if (_context.DadosAnoMessages == null)
            {
                return NotFound();
            }
            var dadosAnoMessages = await _context.DadosAnoMessages.FindAsync(id);
            if (dadosAnoMessages == null)
            {
                return NotFound();
            }

            _context.DadosAnoMessages.Remove(dadosAnoMessages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DadosAnoMessagesExists(long id)
        {
            return (_context.DadosAnoMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
