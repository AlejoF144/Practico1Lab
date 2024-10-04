using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico1LabFinal.Models;

namespace Practico1LabFinal.Controllers
{
    public class GeneroModelsController : Controller
    {
        private readonly AppDbContext _context;

        public GeneroModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GeneroModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Generos.ToListAsync());
        }

        // GET: GeneroModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generoModel == null)
            {
                return NotFound();
            }

            return View(generoModel);
        }

        // GET: GeneroModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneroModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] GeneroModel generoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generoModel);
        }

        // GET: GeneroModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos.FindAsync(id);
            if (generoModel == null)
            {
                return NotFound();
            }
            return View(generoModel);
        }

        // POST: GeneroModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] GeneroModel generoModel)
        {
            if (id != generoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroModelExists(generoModel.Id))
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
            return View(generoModel);
        }

        // GET: GeneroModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generoModel == null)
            {
                return NotFound();
            }

            return View(generoModel);
        }

        // POST: GeneroModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generoModel = await _context.Generos.FindAsync(id);
            if (generoModel != null)
            {
                _context.Generos.Remove(generoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroModelExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }
    }
}
