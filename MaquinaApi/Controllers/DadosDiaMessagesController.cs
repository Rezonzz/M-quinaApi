﻿using System;
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
    public class DadosDiaMessagesController : ControllerBase
    {
        private readonly DadosDiaMessagesContext _context;

        public DadosDiaMessagesController(DadosDiaMessagesContext context)
        {
            _context = context;
        }

        // GET: api/DadosDiaMessages
        [Route("/DadosDiaMessages/GetDadosDiaMessages")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosDiaMessages>>> GetDadosDiaMessages()
        {
          if (_context.DadosDiaMessages == null)
          {
              return NotFound();
          }
            return await _context.DadosDiaMessages.ToListAsync();
        }

        // GET: api/DadosDiaMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DadosDiaMessages>> GetDadosDiaMessages(long id)
        {
          if (_context.DadosDiaMessages == null)
          {
              return NotFound();
          }
            var dadosDiaMessages = await _context.DadosDiaMessages.FindAsync(id);

            if (dadosDiaMessages == null)
            {
                return NotFound();
            }

            return dadosDiaMessages;
        }

        // PUT: api/DadosDiaMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDadosDiaMessages(long id, DadosDiaMessages dadosDiaMessages)
        {
            if (id != dadosDiaMessages.Id)
            {
                return BadRequest();
            }

            _context.Entry(dadosDiaMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosDiaMessagesExists(id))
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

        // POST: api/DadosDiaMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/DadosDiaMessages/PostDadosDiaMessages")]
        [HttpPost]
        public async Task<ActionResult<List<DadosDiaMessages>>> PostDadosDiaMessages(List<DadosDiaMessages> dadosDiaMessagesList)
        {
            if (_context.DadosDiaMessages == null)
            {
                return Problem("Entity set 'DadosDiaMessagesContext.DadosDiaMessages' is null.");
            }

            foreach (var dadosDiaMessages in dadosDiaMessagesList)
            {
                _context.DadosDiaMessages.Add(dadosDiaMessages);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosDiaMessages", dadosDiaMessagesList);
        }

        [HttpPost("/DadosDiaMessages/PostDadosDiaMessages/{id}")]
        public async Task<ActionResult<DadosDiaMessages>> PostDadosDiaMessages(int id, List<DadosDiaMessages> dadosDiaMessagesList)
        {
            // Verificar se todos os objetos na lista têm o mesmo ID
            if (dadosDiaMessagesList.Any(d => d.Id != id))
            {
                return BadRequest();
            }

            // Verificar se algum dos objetos com o ID especificado já existe
            bool exists = await _context.DadosDiaMessages.AnyAsync(d => d.Id == id);

            if (exists)
            {
                return Conflict(); // Retorna um status de conflito se algum objeto já existe
            }

            _context.DadosDiaMessages.AddRange(dadosDiaMessagesList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosDiaMessages", new { id = id }, dadosDiaMessagesList);
        }

        // DELETE: api/DadosDiaMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDadosDiaMessages(long id)
        {
            if (_context.DadosDiaMessages == null)
            {
                return NotFound();
            }
            var dadosDiaMessages = await _context.DadosDiaMessages.FindAsync(id);
            if (dadosDiaMessages == null)
            {
                return NotFound();
            }

            _context.DadosDiaMessages.Remove(dadosDiaMessages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DadosDiaMessagesExists(long id)
        {
            return (_context.DadosDiaMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
