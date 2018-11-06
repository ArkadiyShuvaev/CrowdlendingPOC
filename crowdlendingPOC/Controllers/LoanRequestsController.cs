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
            // TODO inject ILoanRequestsRepository or ILoanRequestsService instead of ApplicationDbContext to purpose of the unit testing
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<LoanRequestViewModel> GetLoanRequest()
        {
            //TODO Add Exception Handling

            //FillInIfEmpty();
            var currentUserId = 100; // TODO retrieve currentUserId from the ControllerContext

            var result = _context.LoanRequests
                .Where(i => !i.IsWithdrawn)
                .Select(i => new LoanRequestViewModel
                {
                    Id = i.Id,
                    AmountRequest = i.AmountRequest,
                    CreditSeekerId = i.CreditSeekerId,
                    CreditSeekerName = "CreditSeeker " + i.Id, // TODO Get the name of seeker from db by ID
                    CurrencyId = i.CurrencyId,
                    Currency = "EUR", // TODO Get the name of seeker from db by CurrencyId
                    Purpose = i.Purpose,
                    InterestRate = i.InterestRate,
                    RepaymentEndDate = i.RepaymentEndDate.ToString("yyyy-MM-dd"), // TODO use client locale
                    RepaymentStartDate = i.RepaymentStartDate.ToString("yyyy-MM-dd")
                }).ToList();

            var maxInterestRate = result.Max(i => i.InterestRate);

            result.ForEach(r =>
            {
                var bid = _context.Bids.FirstOrDefault(b => b.LoanRequestId == r.Id && b.InvestorId == currentUserId);
                if (bid != null)
                {
                    r.CurrentInvestorAmount = bid.Amount;
                }
                r.IsInterestRateAttractive = r.InterestRate > (maxInterestRate * 0.9M);
            });

            return result;            
        }

        private void FillInIfEmpty()
        {
            if (!_context.LoanRequests.Any())
            {
                var items = new List<LoanRequest> {
                            new LoanRequest
                            {
                                //Id = 1,
                                ActiveTo = DateTime.MaxValue,
                                AmountRequest = 1000,
                                InterestRate = 0.99M,
                                IsWithdrawn = false,
                                Purpose = "Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.",
                                RepaymentEndDate = DateTime.Now.AddDays(3000),
                                RepaymentStartDate = DateTime.Now.AddDays(10)
                            },
                            new LoanRequest
                            {
                                //Id = 2,
                                ActiveTo = DateTime.Now,
                                AmountRequest = 1.99M,
                                InterestRate = 28.00M,
                                IsWithdrawn = false,
                                Purpose = "Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.",
                                RepaymentEndDate = DateTime.Now.AddDays(20),
                                RepaymentStartDate = DateTime.Now.AddDays(2)
                            },
                            new LoanRequest
                            {
                                //Id = 3,
                                ActiveTo = DateTime.Now.AddDays(2),
                                AmountRequest = 1000000.99M,
                                InterestRate = 0.01M,
                                IsWithdrawn = false,
                                Purpose = "Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.",
                                RepaymentEndDate = DateTime.Now.AddDays(20),
                                RepaymentStartDate = DateTime.Now.AddDays(2)
                            },
                            new LoanRequest
                            {
                                //Id = 4,
                                ActiveTo = DateTime.Now.AddDays(-1),
                                AmountRequest = 1.99M,
                                InterestRate = 30.00M,
                                IsWithdrawn = false,
                                Purpose = "Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.",
                                RepaymentEndDate = DateTime.Now.AddDays(20),
                                RepaymentStartDate = DateTime.Now.AddDays(2)
                            },
                            new LoanRequest
                            {
                                //Id = 5,
                                ActiveTo = DateTime.Now.AddDays(-1),
                                AmountRequest = 1.99M,
                                InterestRate = 12.50M,
                                IsWithdrawn = false,
                                Purpose = "Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.",
                                RepaymentEndDate = DateTime.Now.AddDays(20),
                                RepaymentStartDate = DateTime.Now.AddDays(2)
                            }
                        };


                _context.LoanRequests.AddRange(items);
                _context.SaveChanges();

            }


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

        
        private bool LoanRequestExists(int id)
        {
            return _context.LoanRequests.Any(e => e.Id == id);
        }
    }
}