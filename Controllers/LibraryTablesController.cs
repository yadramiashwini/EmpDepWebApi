using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpDepWebApi.Models;
using EmpDepWebApi.DTO;

namespace EmpDepWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryTablesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public LibraryTablesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/LibraryTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryTable>>> GetLibraryTables()
        {
            return await _context.LibraryTables.ToListAsync();
        }

        // GET: api/LibraryTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryTable>> GetLibraryTable(int id)
        {
            var libraryTable = await _context.LibraryTables.FindAsync(id);

            if (libraryTable == null)
            {
                return NotFound();
            }

            return libraryTable;
        }

        // PUT: api/LibraryTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibraryTable(int id, LibraryTable libraryTable)
        {
            if (id != libraryTable.LibraryId)
            {
                return BadRequest();
            }

            _context.Entry(libraryTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryTableExists(id))
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

        // POST: api/LibraryTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibraryTable>> PostLibraryTable(LibraryDTO LibrDTO)
        {
            LibraryTable libraryTable = new LibraryTable();    
            libraryTable.LibraryId = LibrDTO.LibraryId;
            libraryTable.Bookname = LibrDTO.Bookname;
         
            _context.LibraryTables.Add(libraryTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibraryTableExists(libraryTable.LibraryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibraryTable", new { id = libraryTable.LibraryId }, libraryTable);
        }

        // DELETE: api/LibraryTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryTable(int id)
        {
            var libraryTable = await _context.LibraryTables.FindAsync(id);
            if (libraryTable == null)
            {
                return NotFound();
            }

            _context.LibraryTables.Remove(libraryTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryTableExists(int id)
        {
            return _context.LibraryTables.Any(e => e.LibraryId == id);
        }
    }
}
