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
    public class PeliculaActorModelsController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculaActorModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PeliculaActorModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PeliculasActores.Include(p => p.Pelicula);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PeliculaActorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActorModel = await _context.PeliculasActores
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaActorModel == null)
            {
                return NotFound();
            }

            return View(peliculaActorModel);
        }

        // GET: PeliculaActorModels/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id");
            return View();
        }

        // POST: PeliculaActorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeliculaId,PersonaId")] PeliculaActorModel peliculaActorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peliculaActorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActorModel.PeliculaId);
            return View(peliculaActorModel);
        }

        // GET: PeliculaActorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActorModel = await _context.PeliculasActores.FindAsync(id);
            if (peliculaActorModel == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActorModel.PeliculaId);
            return View(peliculaActorModel);
        }

        // POST: PeliculaActorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeliculaId,PersonaId")] PeliculaActorModel peliculaActorModel)
        {
            if (id != peliculaActorModel.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculaActorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaActorModelExists(peliculaActorModel.PeliculaId))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActorModel.PeliculaId);
            return View(peliculaActorModel);
        }

        // GET: PeliculaActorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActorModel = await _context.PeliculasActores
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaActorModel == null)
            {
                return NotFound();
            }

            return View(peliculaActorModel);
        }

        // POST: PeliculaActorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculaActorModel = await _context.PeliculasActores.FindAsync(id);
            if (peliculaActorModel != null)
            {
                _context.PeliculasActores.Remove(peliculaActorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaActorModelExists(int id)
        {
            return _context.PeliculasActores.Any(e => e.PeliculaId == id);
        }
    }
}
