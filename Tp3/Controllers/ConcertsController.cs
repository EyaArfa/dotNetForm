using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;
using Tp3.Models;
using Microsoft.EntityFrameworkCore;

namespace Tp3.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ILogger<ConcertsController> _logger;
        private readonly InventoryContext _db;

        public ConcertsController(ILogger<ConcertsController> logger, InventoryContext db)
        {
            _db = db;
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {

            var result = await _db.Concerts.ToListAsync();

            return View(result);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Concerts contact)
        {
            if (ModelState.IsValid)
            {
                _db.Concerts.Add(contact);
                await _db.SaveChangesAsync();
                TempData["success"] = "Création effectuée avec succès";
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contact = await _db.Concerts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }


            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

       
        public async Task<IActionResult> Edit(Concerts contact, int id)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Concerts.Update(contact);
                await _db.SaveChangesAsync();
                TempData["success"] = "Mise à jour effectuée avec succès";
                return RedirectToAction("Index");
            }
            return View(contact);
        }
       

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contact = await _db.Concerts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _db.Concerts.Remove(contact);
            await _db.SaveChangesAsync();
            TempData["success"] = "Suppresson effectué avec succès";
            return RedirectToAction("Index");



        }

    }
}
