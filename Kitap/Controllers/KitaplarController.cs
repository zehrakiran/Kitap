﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kitap.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Kitap.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KitapContext _context;

        public KitaplarController(KitapContext context)
        {
            _context = context;
        }

        // GET: Kitaplar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Kitaplar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // GET: Kitaplar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kitaplar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KitapAdi,KitapSayfaSayisi,Ozet,YazarAdi,Image")] Kitaplar kitaplar)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(kitaplar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View(kitaplar);
        }

        // GET: Kitaplar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Courses.FindAsync(id);
            if (kitaplar == null)
            {
                return NotFound();
            }
            return View(kitaplar);
        }

        // POST: Kitaplar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapAdi,KitapSayfaSayisi,Ozet,YazarAdi,Image")] Kitaplar kitaplar)
        {
            if (id != kitaplar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitaplar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitaplarExists(kitaplar.Id))
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
            return View(kitaplar);
        }

        // GET: Kitaplar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // POST: Kitaplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitaplar = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(kitaplar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitaplarExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
