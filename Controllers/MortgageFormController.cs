using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finance101.Data;
using Finance101.Models;
using Finance101.Services;


namespace Finance101.Controllers
{
    public class MortgageFormController : Controller
    {
        private readonly Finance101Context _context;
        private readonly DailyInterestRateService _dailyInterestRateService;

        public MortgageFormController(Finance101Context context, DailyInterestRateService dailyInterestRateService)
        {
            _context = context;
            _dailyInterestRateService = dailyInterestRateService;
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
                try
                {
                    var existingMortageForm = await _context.MortgageForm.FindAsync(mortgageForm.Id);

                    if (existingMortageForm != null)
                    {
                        //if an existing mortgage form is found with the same ID,update it
                        existingMortageForm.OutstandingMortgageBalance = mortgageForm.OutstandingMortgageBalance;
                        existingMortageForm.RepaymentTerm = mortgageForm.RepaymentTerm;
                        existingMortageForm.CurrentInterestRate = mortgageForm.CurrentInterestRate;
                        existingMortageForm.CurrentMonthlyPayment = mortgageForm.CurrentMonthlyPayment;
                    }
                    else
                    {
                        //if no existing mortgage form is found with the same ID,add a new one
                        _context.Add(mortgageForm);
                    }

                    await _context.SaveChangesAsync();


                    //call method to calculate and save dialy interest rate
                    decimal dailyInterestRate = await _dailyInterestRateService.CalculateDailyInterestRate();

                    if (existingMortageForm != null)
                    {
                        // If updating an existing MortgageForm, update its DailyInterestRate
                        existingMortageForm.DailyInterestRate = dailyInterestRate;
                    }
                    else
                    {
                        // If adding a new MortgageForm, update its DailyInterestRate
                        mortgageForm.DailyInterestRate = dailyInterestRate;
                    }

                    // Save changes to the database to update the DailyInterestRate property
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

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

                    //call method to calculate and save dialy interest rate
                    decimal dailyInterestRate = await _dailyInterestRateService.CalculateDailyInterestRate();
                    mortgageForm.DailyInterestRate = dailyInterestRate;
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
