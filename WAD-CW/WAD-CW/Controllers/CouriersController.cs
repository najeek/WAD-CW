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
    public class CouriersController : Controller
    {
        private readonly IRepository<Courier> _courierRepo;

        public CouriersController(IRepository<Courier> courierRepo)
        {
            _courierRepo = courierRepo;
        }

        // GET: Couriers
        public async Task<IActionResult> Index()
        {
            return View(await _courierRepo.GetAllAsync());
        }

        // GET: Couriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courier = await _courierRepo.GetByIdAsync(id.Value);
            if (courier == null)
            {
                return NotFound();
            }

            return View(courier);
        }

        // GET: Couriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Couriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,PhoneNum")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                await _courierRepo.CreateAsync(courier);

                return RedirectToAction(nameof(Index));
            }
            return View(courier);
        }

        // GET: Couriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courier = await _courierRepo.GetByIdAsync(id.Value);
            if (courier == null)
            {
                return NotFound();
            }
            return View(courier);
        }

        // POST: Couriers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PhoneNum")] Courier courier)
        {
            if (id != courier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _courierRepo.UpdateAsync(courier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_courierRepo.Exists(courier.Id))
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
            return View(courier);
        }

        // GET: Couriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courier = await _courierRepo.GetByIdAsync(id.Value);
            if (courier == null)
            {
                return NotFound();
            }

            return View(courier);
        }

        // POST: Couriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courierRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
