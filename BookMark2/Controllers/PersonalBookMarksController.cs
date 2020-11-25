using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMark2.Data;
using BookMark2.Models;

namespace BookMark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalBookMarksController : ControllerBase
    {
        private readonly BookMark2Context _context;

        public PersonalBookMarksController(BookMark2Context context)
        {
            _context = context;
        }

        // GET: api/PersonalBookMarks
        [HttpGet]
        [Route("/api/PersonalBookMarks")] // read all the data from the PersonalBookMark table
        public async Task<ActionResult<IEnumerable<PersonalBookMark>>> GetPersonalBookMark()
        {
            return await _context.PersonalBookMark.ToListAsync();
        }

        // GET: api/PersonalBookMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalBookMark>> GetPersonalBookMark(int id)
        {
            var personalBookMark = await _context.PersonalBookMark.FindAsync(id);

            if (personalBookMark == null)
            {
                return NotFound();
            }

            return personalBookMark;
        }

        // PUT: api/PersonalBookMarks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalBookMark(int id, PersonalBookMark personalBookMark)
        {
            if (id != personalBookMark.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalBookMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalBookMarkExists(id))
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

        [HttpPut]
        [Route("/api/UpdatePersonalBookMarks")] // update data with a specific id into the PersonalBookMark table
        public async Task<ActionResult<PersonalBookMark>> UpdatePersonalBookMark([FromBody] PersonalBookMark personalBookMark)
        {
            _context.Update(personalBookMark);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPersonalBookMark", new { id = personalBookMark.Id }, personalBookMark);
        }

        // POST: api/PersonalBookMarks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("/api/AddPersonalBookMarks")] // add data into the PersonalBookMark table
        public async Task<ActionResult<PersonalBookMark>> PostPersonalBookMark(PersonalBookMark personalBookMark)
        {
            _context.PersonalBookMark.Add(personalBookMark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalBookMark", new { id = personalBookMark.Id }, personalBookMark);
        }

        // DELETE: api/PersonalBookMarks/5
        [HttpDelete("{id}")]
        [Route("/api/DeletePersonalBookMarks/{id}")] // delete data with a specific id from the PersonalBookMark table
        public async Task<ActionResult<PersonalBookMark>> DeletePersonalBookMark(int id)
        {
            var personalBookMark = await _context.PersonalBookMark.FindAsync(id);
            if (personalBookMark == null)
            {
                return NotFound();
            }

            _context.PersonalBookMark.Remove(personalBookMark);
            await _context.SaveChangesAsync();

            return personalBookMark;
        }

        private bool PersonalBookMarkExists(int id)
        {
            return _context.PersonalBookMark.Any(e => e.Id == id);
        }
    }
}
