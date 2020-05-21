﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_LMS.Data;
using Social_LMS.Models;

namespace Social_LMS.Controllers
{
    public class AuthorizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authorizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authorization.ToListAsync());
        }

        // GET: Authorizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorization = await _context.Authorization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorization == null)
            {
                return NotFound();
            }

            return View(authorization);
        }

        // GET: Authorizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authorizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassCreate,ClassDelete,ClassEdit")] Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorization);
        }

        // GET: Authorizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorization = await _context.Authorization.FindAsync(id);
            if (authorization == null)
            {
                return NotFound();
            }
            return View(authorization);
        }

        // POST: Authorizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassCreate,ClassDelete,ClassEdit")] Authorization authorization)
        {
            if (id != authorization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorizationExists(authorization.Id))
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
            return View(authorization);
        }

        // GET: Authorizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorization = await _context.Authorization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorization == null)
            {
                return NotFound();
            }

            return View(authorization);
        }

        // POST: Authorizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorization = await _context.Authorization.FindAsync(id);
            _context.Authorization.Remove(authorization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorizationExists(int id)
        {
            return _context.Authorization.Any(e => e.Id == id);
        }
    }
}
