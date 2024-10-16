using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _21100602_EP.Data;
using _21100602_EP.Entities;

namespace _21100602_EP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly Parcial2024221100602Context _context;

        public JobOffersController(Parcial2024221100602Context context)
        {
            _context = context;
        }

        // GET: api/JobOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOffer>>> GetJobOffer()
        {
            return await _context.JobOffer.ToListAsync();
        }

        // GET: api/JobOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return jobOffer;
        }

        // PUT: api/JobOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOffer(int id, JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
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

        // POST: api/JobOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobOffer>> PostJobOffer(JobOffer jobOffer)
        {
            _context.JobOffer.Add(jobOffer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobOfferExists(jobOffer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobOffer", new { id = jobOffer.Id }, jobOffer);
        }

        // DELETE: api/JobOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffer.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffer.Any(e => e.Id == id);
        }
    }
}
