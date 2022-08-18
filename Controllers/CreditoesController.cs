using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreditosMicroAgroAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CreditosMicroAgroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "empleado_solicitante")]

    public class CreditoesController : ControllerBase
    {
        private readonly CreditosMicroAgroContext _context;

        public CreditoesController(CreditosMicroAgroContext context)
        {
            _context = context;
        }

        // GET: api/Creditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetCreditos()
        {
          if (_context.Creditos == null)
          {
              return NotFound();
          }
            return await _context.Creditos.ToListAsync();
        }

        // GET: api/Creditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetCredito(long id)
        {
          if (_context.Creditos == null)
          {
              return NotFound();
          }
            var credito = await _context.Creditos.FindAsync(id);

            if (credito == null)
            {
                return NotFound();
            }

            return credito;
        }

        // PUT: api/Creditoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "empleado_autorizador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredito(long id, Loan credito)
        {
            if (id != credito.Id)
            {
                return BadRequest();
            }

            _context.Entry(credito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditoExists(id))
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

        // POST: api/Creditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostCredito(Loan credito)
        {
          if (_context.Creditos == null)
          {
              return Problem("Entity set 'CreditosMicroAgroContext.Creditos'  is null.");
          }
            _context.Creditos.Add(credito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { id = credito.Id }, credito);
        }

        // DELETE: api/Creditoes/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

        public async Task<IActionResult> DeleteCredito(long id)
        {
            if (_context.Creditos == null)
            {
                return NotFound();
            }
            var credito = await _context.Creditos.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }

            _context.Creditos.Remove(credito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditoExists(long id)
        {
            return (_context.Creditos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
