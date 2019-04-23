using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Portfolio
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortfolioModel.ToListAsync());
        }

        // GET: Portfolio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioModel = await _context.PortfolioModel
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (portfolioModel == null)
            {
                return NotFound();
            }

            return View(portfolioModel);
        }

        // GET: Portfolio/Create
		[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectDesc,ProjectTech,ProjectRole,ProjectDate,DataEdited,ProjectAccolade,ProjectImage,ProjectUrl1,ProjectUrl2")] PortfolioModel portfolioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioModel);
        }

		// GET: Portfolio/Edit/5
		[Authorize]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioModel = await _context.PortfolioModel.FindAsync(id);
            if (portfolioModel == null)
            {
                return NotFound();
            }
            return View(portfolioModel);
        }

        // POST: Portfolio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectDesc,ProjectTech,ProjectRole,ProjectDate,DataEdited,ProjectAccolade,ProjectImage,ProjectUrl1,ProjectUrl2")] PortfolioModel portfolioModel)
        {
            if (id != portfolioModel.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioModelExists(portfolioModel.ProjectId))
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
            return View(portfolioModel);
        }

		// GET: Portfolio/Delete/5
		[Authorize]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioModel = await _context.PortfolioModel
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (portfolioModel == null)
            {
                return NotFound();
            }

            return View(portfolioModel);
        }

        // POST: Portfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioModel = await _context.PortfolioModel.FindAsync(id);
            _context.PortfolioModel.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioModelExists(int id)
        {
            return _context.PortfolioModel.Any(e => e.ProjectId == id);
        }
    }
}
