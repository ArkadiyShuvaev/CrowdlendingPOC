using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdlendingPOC.Models;
using CrowdlendingPOC.Data;
using CrowdlendingPOC.ViewModels;
using System;

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
        public IEnumerable<LoanRequestViewModel> GetLoanRequest()
        {
            var result = _context.LoanRequests
                .Where(i => !i.IsWithdrawn)
                .Select(i => new LoanRequestViewModel
                {
                    Id = i.Id,
                    AmountRequest = i.AmountRequest,
                    CreditSeekerId = i.CreditSeekerId,
                    CreditSeekerName = "CreditSeeker", // TODO Get the name of seeker from db by ID
                    CurrencyId = i.CurrencyId,
                    Currency = "EUR", // TODO Get the name of seeker from db by CurrencyId
                    Purpose = i.Purpose,
                    InterestRate = i.InterestRate,
                    RepaymentEndDate = i.RepaymentEndDate,
                    RepaymentStartDate = i.RepaymentStartDate
                });
            var r = new LoanRequestViewModel
            {
                Id = 1,
                AmountRequest = 10.12M,
                CreditSeekerId = 101,
                CreditSeekerName = "CreditSeeker", // TODO Get the name of seeker from db by ID
                CurrencyId = 22,
                Currency = "EUR", // TODO Get the name of seeker from db by CurrencyId
                Purpose = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec luctus, neque at accumsan consequat, urna diam imperdiet nulla, sed cursus leo elit in magna. Morbi dui tellus, tincidunt ac viverra a, blandit id sapien. Sed laoreet semper lacus non sagittis. Vestibulum elementum gravida tellus at porttitor. Vestibulum ut consequat mi. In sodales eros sed maximus dictum. Mauris efficitur velit ut finibus suscipit. Proin rutrum dui a nisl aliquam, vitae iaculis dolor efficitur. Suspendisse sapien tortor, eleifend sed lacus at, ornare gravida tortor. Vestibulum sollicitudin, enim a sodales accumsan, lectus nibh suscipit tellus, vel mattis orci lorem eu odio.",
                InterestRate = 0.9M,
                RepaymentEndDate = DateTime.Now,
                RepaymentStartDate = DateTime.Now
            };
            return new List<LoanRequestViewModel> { r, r, r, r, r, r, r, r,r};
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