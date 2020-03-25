using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGEWebsite.Data;
using SAGEWebsite.Models;

namespace SAGEWebsite.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.BillingAddress).Include(c => c.Payment).Include(c => c.ShippingAddress).Include(c => c.Survey);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.Payment)
                .Include(c => c.ShippingAddress)
                .Include(c => c.Survey)
                .Where(m => m.IdentityUserId == userId).FirstOrDefault();
            if(userId == null)
            {
                return RedirectToPage("_Layout");
            }

            if (customer == null)
            {
                return View("Create");
            }

            return View("Details",customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {

            ViewData["BillingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber");
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyId");
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return View("Details",customer);
            }
            ViewData["BillingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.BillingAddressId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber", customer.PaymentId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.ShippingAddressId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyId", customer.SurveyId);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            return View("Details",customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.Payment)
                .Include(c => c.ShippingAddress)
                .Include(c => c.Survey)
                .Where(m => m.IdentityUserId == userId).FirstOrDefault();


            ViewData["BillingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.BillingAddressId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber", customer.PaymentId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.ShippingAddressId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyId", customer.SurveyId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["BillingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.BillingAddressId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber", customer.PaymentId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.ShippingAddressId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyId", customer.SurveyId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.Payment)
                .Include(c => c.ShippingAddress)
                .Include(c => c.Survey)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
