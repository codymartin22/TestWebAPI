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
    public class CityInfoesController : ControllerBase
    {
        private readonly WebAPIDBContext _context;

        public CityInfoesController(WebAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/CityInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityInfo>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/CityInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityInfo>> GetCityInfo(int id)
        {
            var cityInfo = await _context.Cities.FindAsync(id);

            if (cityInfo == null)
            {
                return NotFound();
            }

            return cityInfo;
        }
        // GET: api/CityInfoes/5
        [HttpGet("GetWithCityID/{CityID}")]
        public async Task<ActionResult<CityInfo>> GetCityInfowithCityID(int CityID)
        {
            var cityInfo = await _context.Cities.FirstOrDefaultAsync(opt => opt.CityID == CityID);

            if (cityInfo == null)
            {
                return NotFound();
            }

            return cityInfo;
        }

        // PUT: api/CityInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityInfo(int id, CityInfo cityInfo)
        {
            if (id != cityInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityInfoExists(id))
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

        // POST: api/CityInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CityInfo>> PostCityInfo(CityInfo cityInfo)
        {
            _context.Cities.Add(cityInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityInfo", new { id = cityInfo.Id }, cityInfo);
        }

        // DELETE: api/CityInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CityInfo>> DeleteCityInfo(int id)
        {
            var cityInfo = await _context.Cities.FindAsync(id);
            if (cityInfo == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cityInfo);
            await _context.SaveChangesAsync();

            return cityInfo;
        }

        private bool CityInfoExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
