using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITest.DBContext;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly WebAPIDBContext _context;

        public ToDoListsController(WebAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ToDoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoLists>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/ToDoLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoLists>> GetToDoLists(string id)
        {
            var toDoLists = await _context.ToDoItems.FindAsync(id);

            if (toDoLists == null)
            {
                return NotFound();
            }

            return toDoLists;
        }

        // PUT: api/ToDoLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoLists(string id, ToDoLists toDoLists)
        {
            if (id != toDoLists.id)
            {
                return BadRequest();
            }

            _context.Entry(toDoLists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListsExists(id))
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

        // POST: api/ToDoLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ToDoLists>> PostToDoLists(ToDoLists toDoLists)
        {
            _context.ToDoItems.Add(toDoLists);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToDoListsExists(toDoLists.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetToDoLists", new { id = toDoLists.id }, toDoLists);
        }

        // DELETE: api/ToDoLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoLists>> DeleteToDoLists(string id)
        {
            var toDoLists = await _context.ToDoItems.FindAsync(id);
            if (toDoLists == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoLists);
            await _context.SaveChangesAsync();

            return toDoLists;
        }

        private bool ToDoListsExists(string id)
        {
            return _context.ToDoItems.Any(e => e.id == id);
        }
    }
}
