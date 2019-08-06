﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem_CodeFirst.Models;

namespace StudentManagementSystem_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        #region define context
        private readonly StudentManagementSystemContext _context;

        public HomeController(StudentManagementSystemContext context)
        {
            _context = context;
        }
        #endregion

        #region Routing Methods

        //Error handling page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var studentContext = _context.Students.Include(s => s.Diploma)
                                                    .Include(s => s.Address);
            return View(await studentContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["DiplomaSelectionList"] = new SelectList(_context.Diploma, "DiplomaId", "Name");
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Diploma)
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.AdminNo == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Address)
                .SingleOrDefaultAsync(s => s.AdminNo == id);

            if (student == null)
            {
                return NotFound();
            }

            ViewData["DiplomaSelectionList"] = new SelectList(_context.Diploma, "DiplomaId", "Name", student.DiplomaId);
            return View(student);
        }
        #endregion

        #region Form handling Methods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("AdminNo,Name,Dob,Gender,ContactNumber,DiplomaId,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //return to create form if model invalid
                ViewData["DiplomaSelectionList"] = new SelectList(_context.Diploma, "DiplomaId", "DiplomaId", student.DiplomaId);
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            [Bind("AdminNo,Name,Dob,Gender,ContactNumber,DiplomaId,Address")] Student student)
        {
            if (id != student.AdminNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.AdminNo))
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
            else
            {
                ViewData["DiplomaSelectionList"] = new SelectList(_context.Diploma, "DiplomaId", "DiplomaId", student.DiplomaId);
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var student = await _context.Students
                                    .FirstOrDefaultAsync(s => s.AdminNo == id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddModules(string id, string[] StudentModules)
        {
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteModules(string id, string[] StudentModules)
        {
            return RedirectToAction(nameof(Details), new { id = id });
        }
        #endregion

        #region Other helper methods
        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.AdminNo == id);
        }
        #endregion
    }
}

