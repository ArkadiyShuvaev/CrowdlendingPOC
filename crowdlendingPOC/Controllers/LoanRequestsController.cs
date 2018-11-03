using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdlendingPOC.Models;
using CrowdlendingPOC.Data;

namespace CrowdlendingPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanRequests
        [HttpGet]
        public IEnumerable<LoanRequest> GetLoanRequest()
        {
            return _context.LoanRequests;
        }

        // GET: api/LoanRequests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanRequest = await _context.LoanRequests.FindAsync(id);

            if (loanRequest == null)
            {
                return NotFound();
            }

            return Ok(loanRequest);
        }

        // PUT: api/LoanRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanRequest([FromRoute] int id, [FromBody] LoanRequest loanRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loanRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanRequestExists(id))
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

        // POST: api/LoanRequests
        [HttpPost]
        public async Task<IActionResult> PostLoanRequest([FromBody] LoanRequest loanRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LoanRequests.Add(loanRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanRequest", new { id = loanRequest.Id }, loanRequest);
        }

        // DELETE: api/LoanRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanRequest = await _context.LoanRequests.FindAsync(id);
            if (loanRequest == null)
            {
                return NotFound();
            }

            _context.LoanRequests.Remove(loanRequest);
            await _context.SaveChangesAsync();

            return Ok(loanRequest);
        }

        private bool LoanRequestExists(int id)
        {
            return _context.LoanRequests.Any(e => e.Id == id);
        }
    }
}