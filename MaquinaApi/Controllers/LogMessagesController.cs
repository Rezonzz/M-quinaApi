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
    public class LogMessagesController : ControllerBase
    {
        private readonly LogMessagesContext _context;

        public LogMessagesController(LogMessagesContext context)
        {
            _context = context;
        }

        // GET: api/LogMessages
        [Route("/LogMessages/GetLogMessages")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogMessages>>> GetLogMessages()
        {
          if (_context.LogMessages == null)
          {
              return NotFound();
          }
            return await _context.LogMessages.ToListAsync();
        }

        // GET: api/LogMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogMessages>> GetLogMessages(long id)
        {
          if (_context.LogMessages == null)
          {
              return NotFound();
          }
            var logMessages = await _context.LogMessages.FindAsync(id);

            if (logMessages == null)
            {
                return NotFound();
            }

            return logMessages;
        }

        // PUT: api/LogMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogMessages(long id, LogMessages logMessages)
        {
            if (id != logMessages.Id)
            {
                return BadRequest();
            }

            _context.Entry(logMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogMessagesExists(id))
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

        // POST: api/LogMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/LogMessages/PostLogMessages")]
        [HttpPost]
        public async Task<ActionResult<LogMessages>> PostLogMessages(LogMessages logMessages)
        {
          if (_context.LogMessages == null)
          {
              return Problem("Entity set 'LogMessagesContext.LogMessages'  is null.");
          }
            _context.LogMessages.Add(logMessages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogMessages", new { id = logMessages.Id }, logMessages);
        }

        // DELETE: api/LogMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogMessages(long id)
        {
            if (_context.LogMessages == null)
            {
                return NotFound();
            }
            var logMessages = await _context.LogMessages.FindAsync(id);
            if (logMessages == null)
            {
                return NotFound();
            }

            _context.LogMessages.Remove(logMessages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogMessagesExists(long id)
        {
            return (_context.LogMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
