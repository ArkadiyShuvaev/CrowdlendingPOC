using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            _context = context;
        }

        // GET: api/Bids
        [HttpGet]
        public IEnumerable<Bid> GetBids()
        {
            return _context.Bids;
        }

        // GET: api/Bids/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bid = await _context.Bids.FindAsync(id);

            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

       
        // POST: api/Bids
        [HttpPost("PostBid")]
        public async Task<IActionResult> PostBid([FromBody] LoanRequestCreationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var currentRequestorId = 100; // TODO retrieve currentRequestorId from the ControllerContext

            var doesBidExist = _context.Bids.Any(b => b.InvestorId == currentRequestorId && b.LoanRequestId == vm.LoanRequestId);
            if(doesBidExist)
            {
                return BadRequest("Bid already exits");
            }

            var newBid = new Bid
            {
                Amount = vm.CurrentInvestorAmount,
                LoanRequestId = vm.LoanRequestId,
                InvestorId = currentRequestorId
            };
            _context.Bids.Add(newBid);

            await _context.SaveChangesAsync(); // Todo Add exception handling 

            return CreatedAtAction("GetBid", new { id = newBid.Id });
        }

        // DELETE: api/Bids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();

            return Ok(bid);
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.Id == id);
        }
    }
}