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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.CustomerId)
                .Include(o => o.ShippingAddressId)
                .Include(o => o.ItemId)
                .FirstOrDefaultAsync(m => m.OrderNumber == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        // GET: Orders/Create
        public IActionResult Create(int id)

        {
            Order order = new Order();
            var item = id;

            var plant = _context.Items.Where(p => p.ItemId == id).SingleOrDefault();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers
                .Where(c => c.IdentityUserId == userId)
                .Include(c => c.BillingAddress)
                .Include(c => c.ShippingAddress)
                .Include(c => c.Payment)
                .FirstOrDefault();
            order.Customer = customer;  
            order.ItemId = plant.ItemId;
            order.CustomerId = customer.CustomerId;
            order.ShippingAddressId = customer.ShippingAddress.AddressId;


            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber");
            ViewBag.ItemName = plant.ItemName;
            ViewBag.ItemPrice = plant.UnitPrice;

            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            order.Customer = null;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).Include(c => c.ShippingAddress).FirstOrDefault();
            order.ShippingAddressId = _context.Addresses.Where(c => c.AddressId == customer.ShippingAddress.AddressId).SingleOrDefault().AddressId;
            order.Item = _context.Items.Where(i => i.ItemId == order.ItemId).SingleOrDefault();
            if (ModelState.IsValid)

            {               
                _context.Add(order);
                await _context.SaveChangesAsync();
                return View("Details",order);
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "CreditCardNumber", "CreditCardNumber");
            ViewData["ShippingAddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            return View("Details", order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", order.ItemId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderNumber,OrderDate,ShippingAddressId,ShippingOption,ItemId,CustomerId")] Order order)
        {
            if (id != order.OrderNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderNumber))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", order.ItemId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .FirstOrDefaultAsync(m => m.OrderNumber == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderNumber == id);
        }
    }
}
