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
    public class PeliculaModelsController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculaModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PeliculaModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Peliculas.Include(p => p.Genero);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PeliculaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaModel = await _context.Peliculas
                .Include(p => p.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peliculaModel == null)
            {
                return NotFound();
            }

            return View(peliculaModel);
        }

        // GET: PeliculaModels/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id");
            return View();
        }

        // POST: PeliculaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GeneroId,Titulo,FechaEstreno,Portada,Trailer,Resumen")] PeliculaModel peliculaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peliculaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", peliculaModel.GeneroId);
            return View(peliculaModel);
        }

        // GET: PeliculaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaModel = await _context.Peliculas.FindAsync(id);
            if (peliculaModel == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", peliculaModel.GeneroId);
            return View(peliculaModel);
        }

        // POST: PeliculaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GeneroId,Titulo,FechaEstreno,Portada,Trailer,Resumen")] PeliculaModel peliculaModel)
        {
            if (id != peliculaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaModelExists(peliculaModel.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", peliculaModel.GeneroId);
            return View(peliculaModel);
        }

        // GET: PeliculaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaModel = await _context.Peliculas
                .Include(p => p.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peliculaModel == null)
            {
                return NotFound();
            }

            return View(peliculaModel);
        }

        // POST: PeliculaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculaModel = await _context.Peliculas.FindAsync(id);
            if (peliculaModel != null)
            {
                _context.Peliculas.Remove(peliculaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaModelExists(int id)
        {
            return _context.Peliculas.Any(e => e.Id == id);
        }
    }
}
