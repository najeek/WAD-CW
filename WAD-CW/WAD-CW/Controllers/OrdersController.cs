using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAD_CW.DAL;
using WAD_CW.DAL.Repositories;
using WAD_CW.Models;

namespace WAD_CW.DAL.DBO.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Courier> _courierRepo;

        public OrdersController(IRepository<Order> orderRepo, 
                                IRepository<Courier> courierRepo)
        {
            _orderRepo = orderRepo;
            _courierRepo = courierRepo;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
        
            return View(await _orderRepo.GetAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepo.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CourierId"] = new SelectList(await _courierRepo.GetAllAsync(), "Id", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderGetTime,ClientName,ClientPhone,ClientAddress,Priority,Weight,CourierId")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepo.CreateAsync(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourierId"] = new SelectList(await _courierRepo.GetAllAsync(), "Id", "FullName", order.CourierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepo.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CourierId"] = new SelectList(await _courierRepo.GetAllAsync(), "Id", "FullName", order.CourierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderGetTime,ClientName,ClientPhone,ClientAddress,Priority,Weight,CourierId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderRepo.UpdateAsync(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_orderRepo.Exists(order.Id))
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
            ViewData["CourierId"] = new SelectList(await _courierRepo.GetAllAsync(), "Id", "FullName", order.CourierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepo.GetByIdAsync(id.Value);
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
            await _orderRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
