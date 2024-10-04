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
    public class ActorModelsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ActorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actores.ToListAsync());
        }

        // GET: ActorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorModel == null)
            {
                return NotFound();
            }

            return View(actorModel);
        }

        // GET: ActorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaNacimiento,Foto")] ActorModel actorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorModel);
        }

        // GET: ActorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actores.FindAsync(id);
            if (actorModel == null)
            {
                return NotFound();
            }
            return View(actorModel);
        }

        // POST: ActorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaNacimiento,Foto")] ActorModel actorModel)
        {
            if (id != actorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorModelExists(actorModel.Id))
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
            return View(actorModel);
        }

        // GET: ActorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorModel == null)
            {
                return NotFound();
            }

            return View(actorModel);
        }

        // POST: ActorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorModel = await _context.Actores.FindAsync(id);
            if (actorModel != null)
            {
                _context.Actores.Remove(actorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorModelExists(int id)
        {
            return _context.Actores.Any(e => e.Id == id);
        }
    }
}
