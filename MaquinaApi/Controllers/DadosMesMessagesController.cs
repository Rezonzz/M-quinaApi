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
    public class DadosMesMessagesController : ControllerBase
    {
        private readonly DadosMesMessagesContext _context;

        public DadosMesMessagesController(DadosMesMessagesContext context)
        {
            _context = context;
        }

        // GET: api/DadosMesMessages
        [Route("/DadosMesMessages/GetDadosMesMessages")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosMesMessages>>> GetDadosMesMessages()
        {
          if (_context.DadosMesMessages == null)
          {
              return NotFound();
          }
            return await _context.DadosMesMessages.ToListAsync();
        }

        // GET: api/DadosMesMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DadosMesMessages>> GetDadosMesMessages(long id)
        {
          if (_context.DadosMesMessages == null)
          {
              return NotFound();
          }
            var dadosMesMessages = await _context.DadosMesMessages.FindAsync(id);

            if (dadosMesMessages == null)
            {
                return NotFound();
            }

            return dadosMesMessages;
        }

        // PUT: api/DadosMesMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDadosMesMessages(long id, DadosMesMessages dadosMesMessages)
        {
            if (id != dadosMesMessages.Id)
            {
                return BadRequest();
            }

            _context.Entry(dadosMesMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosMesMessagesExists(id))
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

        // POST: api/DadosMesMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("/DadosMesMessages/PostDadosMesMessages")]
        [HttpPost]
        public async Task<ActionResult<List<DadosMesMessages>>> PostDadosMesMessages(List<DadosMesMessages> dadosMesMessagesList)
        {
            if (_context.DadosMesMessages == null)
            {
                return Problem("Entity set 'DadosMesMessagesContext.DadosMesMessages' is null.");
            }

            foreach (var dadosMesMessages in dadosMesMessagesList)
            {
                _context.DadosMesMessages.Add(dadosMesMessages);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosMesMessages", dadosMesMessagesList);
        }

        [HttpPost("/DadosMesMessages/PostDadosMesMessages/{id}")]
        public async Task<ActionResult<DadosMesMessages>> PostDadosMesMessages(int id, List<DadosMesMessages> dadosMesMessagesList)
        {
            // Verificar se todos os objetos na lista têm o mesmo ID
            if (dadosMesMessagesList.Any(d => d.Id != id))
            {
                return BadRequest();
            }

            // Verificar se algum dos objetos com o ID especificado já existe
            bool exists = await _context.DadosMesMessages.AnyAsync(d => d.Id == id);

            if (exists)
            {
                return Conflict(); // Retorna um status de conflito se algum objeto já existe
            }

            _context.DadosMesMessages.AddRange(dadosMesMessagesList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosMesMessages", new { id = id }, dadosMesMessagesList);
        }

        // DELETE: api/DadosMesMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDadosMesMessages(long id)
        {
            if (_context.DadosMesMessages == null)
            {
                return NotFound();
            }
            var dadosMesMessages = await _context.DadosMesMessages.FindAsync(id);
            if (dadosMesMessages == null)
            {
                return NotFound();
            }

            _context.DadosMesMessages.Remove(dadosMesMessages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DadosMesMessagesExists(long id)
        {
            return (_context.DadosMesMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
