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
    public class MessageMeController : ControllerBase
    {
        private readonly DataContext _context;

        public MessageMeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var getMessages = await _context.MessageMe.ToListAsync();
            return Ok(getMessages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var getMessage = await _context.MessageMe.SingleOrDefaultAsync(m => m.Id == id);
            return Ok(getMessage);
        }

        //POST /api/messageMe
        [HttpPost]
        public async Task<IActionResult> SendMessage(messageMe messageme)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _context.AddAsync(messageme);
            await _context.SaveChangesAsync();

            return Ok(201);
        }

        // PUT /api/messageMe/1
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(int id, messageMe messageme)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var messageMeInDb = await _context.MessageMe.SingleOrDefaultAsync(c => c.Id == id);
            if (messageMeInDb == null)
                return NoContent();

            _context.SaveChanges();
            return Ok();
        }


        // Delete /api/messageMe/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var messageMeInDb = await _context.MessageMe.SingleOrDefaultAsync(c => c.Id == id);
            if (messageMeInDb == null)
                return NoContent();

            _context.MessageMe.Remove(messageMeInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}