using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uxapi.Data;
using uxapi.Models;

namespace uxapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortsController : ControllerBase
    {
        private readonly DataContext _context;

        public PortsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ports
        [HttpGet]
        public IEnumerable<Portfolio> GetPortfolio()
        {
            return _context.Portfolio;
        }

        // GET: api/Ports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var portfolio = await _context.Portfolio.FindAsync(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // PUT: api/Ports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolio([FromRoute] int id, [FromBody] Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != portfolio.Id)
            {
                return BadRequest();
            }

            _context.Entry(portfolio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
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

        // POST: api/Ports
        [HttpPost]
        public async Task<IActionResult> PostPortfolio([FromBody] Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Portfolio.Add(portfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolio", new { id = portfolio.Id }, portfolio);
        }

        // DELETE: api/Ports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            _context.Portfolio.Remove(portfolio);
            await _context.SaveChangesAsync();

            return Ok(portfolio);
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolio.Any(e => e.Id == id);
        }
    }
}