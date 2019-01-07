using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdlendingPOC.Data;
using CrowdlendingPOC.Models;
using CrowdlendingPOC.ViewModels;

namespace CrowdlendingPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BidsController(ApplicationDbContext context)
        {
            // TODO inject IBidRepository or IBidService instead of ApplicationDbContext to purpose of the unit testing
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Bid> GetBids()
        {
            return _context.Bids;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBid([FromRoute] int id)
        {
            if (id <= 0) return BadRequest(nameof(id));

            var bid = await _context.Bids.FindAsync(id).ConfigureAwait(false);

            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

        [HttpPost("PostBid")]
        public async Task<IActionResult> PostBid([FromBody] LoanRequestCreationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentRequestorId = 100; // TODO retrieve currentRequestorId from the ControllerContext

            var doesBidExist = _context.Bids.Any(b => b.InvestorId == currentRequestorId
                                    && b.LoanRequestId == vm.LoanRequestId);
            if(doesBidExist)
            {
                return BadRequest($"Bid for the '{vm.LoanRequestId}' loanId already exists and cannot be created");
            }

            var newBid = new Bid
            {
                Amount = vm.CurrentInvestorProposal,
                LoanRequestId = vm.LoanRequestId,
                InvestorId = currentRequestorId
            };
            await _context.Bids.AddAsync(newBid).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetBid", new { id = newBid.Id });
        }

        [HttpDelete("DeleteBidByLoanRequestId/{loanRequestId}")]
        public async Task<IActionResult> DeleteBidByLoanRequestId([FromRoute] int loanRequestId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentRequestorId = 100; // TODO retrieve currentRequestorId from the ControllerContext
            var bid = _context.Bids.FirstOrDefault(b => b.LoanRequestId == loanRequestId && b.InvestorId == currentRequestorId);
            if (bid == null)
            {
                return NotFound();
            }

            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();

            return Ok(bid);
        }

    }
}
