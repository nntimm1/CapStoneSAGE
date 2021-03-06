﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGEWebsite.Data;

namespace SAGEWebsite.Models
{
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(o => o.ItemName).Include(s => s.ItemImage).Include(s => s.UnitPrice).Include(s => s.StyleType)
                .Include(s => s.HomeType).Include(s => s.LifeType);
            return View(await _context.Surveys.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details()
        {
            SurveyItems si = new SurveyItems();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.Payment)
                .Include(c => c.ShippingAddress)
                .Include(c => c.Survey)
                .Where(m => m.IdentityUserId == userId).FirstOrDefault();

            var custSurvey = await _context.Surveys.FirstOrDefaultAsync(s => s.SurveyId == customer.SurveyId);
            si.Survey = custSurvey;

            var item = _context.Items.Where(h => h.StyleType == si.Survey.StyleType).Where(h => h.HomeType == si.Survey.HomeType).Where(h => h.LifeType == si.Survey.LifeType).FirstOrDefault();

            var custItems = _context.Items.SingleOrDefault(j => j.ItemId == item.ItemId);
            si.Item = custItems;
            
            if (custSurvey == null)
            {
                return NotFound();
            }

            return View("Details",si);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
                .Where(c => c.IdentityUserId == userId)
                .Include(a => a.BillingAddress)
                .Include(s => s.ShippingAddress)
                .Include(p => p.Payment)
                .FirstOrDefault();
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyItems surveyItems, Survey survey)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
              .Include(a => a.Survey)
              .Include(a => a.BillingAddress)
              .Include(s => s.ShippingAddress)
              .Include(p => p.Payment)
              .Where(c => c.IdentityUserId == userId)
              .FirstOrDefault();


            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return View("Details",surveyItems);
            }
            return View();
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }
            var customer = _context.Customers
                .Include(a => a.Survey)
                .Include(a => a.BillingAddress)
                .Include(s => s.ShippingAddress)
                .Include(p => p.Payment)
                .Where(c => c.IdentityUserId == userId)
                .FirstOrDefault();

            ViewData["BillingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.BillingAddressId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber", customer.PaymentId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.ShippingAddressId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyId", customer.SurveyId);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            return View();
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Survey survey)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
                  .Include(a => a.Survey)
                  .Include(a => a.BillingAddress)
                  .Include(s => s.ShippingAddress)
                  .Include(p => p.Payment)
                  .Where(c => c.IdentityUserId == userId)
                  .FirstOrDefault();
            customer.IdentityUserId = userId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.SurveyId))
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
            return RedirectToAction("Details", customer);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys
                .FirstOrDefaultAsync(m => m.SurveyId == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.SurveyId == id);
        }
    }
}
