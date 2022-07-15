#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exercise_4.Data;
using Exercise_4.Models;

namespace Exercise_4.Controllers
{
    public class StudentHistoriesController : Controller
    {
        private readonly Exercise_4Context _context;

        public StudentHistoriesController(Exercise_4Context context)
        {
            _context = context;
        }

        // GET: StudentHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentHistory.ToListAsync());
        }

        // GET: StudentHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHistory = await _context.StudentHistory
                .FirstOrDefaultAsync(m => m.StudentHistoryId == id);
            if (studentHistory == null)
            {
                return NotFound();
            }

            return View(studentHistory);
        }

        // GET: StudentHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentHistoryId,StudentId,FirstName,LastName,City,State,Zip,ActionTaken,Username,Today")] StudentHistory studentHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentHistory);
        }

        // GET: StudentHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHistory = await _context.StudentHistory.FindAsync(id);
            if (studentHistory == null)
            {
                return NotFound();
            }
            return View(studentHistory);
        }

        // POST: StudentHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentHistoryId,StudentId,FirstName,LastName,City,State,Zip,ActionTaken,Username,Today")] StudentHistory studentHistory)
        {
            if (id != studentHistory.StudentHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentHistoryExists(studentHistory.StudentHistoryId))
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
            return View(studentHistory);
        }

        // GET: StudentHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHistory = await _context.StudentHistory
                .FirstOrDefaultAsync(m => m.StudentHistoryId == id);
            if (studentHistory == null)
            {
                return NotFound();
            }

            return View(studentHistory);
        }

        // POST: StudentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentHistory = await _context.StudentHistory.FindAsync(id);
            _context.StudentHistory.Remove(studentHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentHistoryExists(int id)
        {
            return _context.StudentHistory.Any(e => e.StudentHistoryId == id);
        }
    }
}
