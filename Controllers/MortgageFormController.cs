using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finance101.Data;
using Finance101.Models;

namespace Finance101.Controllers
{
    public class MortgageFormController : Controller
    {
        private readonly Finance101Context _context;

        public MortgageFormController(Finance101Context context)
        {
            _context = context;
        }

        // GET: MortgageForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.MortgageForm.ToListAsync());
        }

        // GET: MortgageForm/MortgageInfo/5
        public async Task<IActionResult> MortgageInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgageForm = await _context.MortgageForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mortgageForm == null)
            {
                return NotFound();
            }

            return View(mortgageForm);
        }

        // GET: MortgageForm/SubmitForm
        public IActionResult SubmitForm()
        {
            return View();
        }

        // POST: MortgageForm/SubmitForm
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitForm([Bind("Id,OutstandingMortgageBalance,RepaymentTerm,CurrentInterestRate,CurrentMonthlyPayment")] MortgageForm mortgageForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mortgageForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mortgageForm);
        }

        // GET: MortgageForm/EditMortgageInfo/5
        public async Task<IActionResult> EditMortgageInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgageForm = await _context.MortgageForm.FindAsync(id);
            if (mortgageForm == null)
            {
                return NotFound();
            }
            return View(mortgageForm);
        }

        // POST: MortgageForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMortgageInfo(int id, [Bind("Id,OutstandingMortgageBalance,RepaymentTerm,CurrentInterestRate,CurrentMonthlyPayment")] MortgageForm mortgageForm)
        {
            if (id != mortgageForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mortgageForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MortgageFormExists(mortgageForm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mortgageForm);
        }

        // GET: MortgageForm/Delete/5
        public async Task<IActionResult> DeleteMortgageDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgageForm = await _context.MortgageForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mortgageForm == null)
            {
                return NotFound();
            }

            return View(mortgageForm);
        }

        // POST: MortgageForm/DeleteMortgageDetails/5
        [HttpPost, ActionName("DeleteMortgageDetails")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mortgageForm = await _context.MortgageForm.FindAsync(id);
            if (mortgageForm != null)
            {
                _context.MortgageForm.Remove(mortgageForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MortgageFormExists(int id)
        {
            return _context.MortgageForm.Any(e => e.Id == id);
        }
    }
}
