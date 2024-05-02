using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiegoCorrea.Data;
using DiegoCorrea.Models;

namespace DiegoCorrea.Controllers
{
    public class DCorreasController : Controller
    {
        private readonly DiegoCorreaContext _context;

        public DCorreasController(DiegoCorreaContext context)
        {
            _context = context;
        }

        // GET: DCorreas
        public async Task<IActionResult> Index()
        {
            var diegoCorreaContext = _context.DCorrea.Include(d => d.Carrera);
            return View(await diegoCorreaContext.ToListAsync());
        }

        // GET: DCorreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCorrea = await _context.DCorrea
                .Include(d => d.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dCorrea == null)
            {
                return NotFound();
            }

            return View(dCorrea);
        }

        // GET: DCorreas/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "NombreCarrera");
            return View();
        }

        // POST: DCorreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NumHijos,Salario,Ciudad,Activo,FechaNacimiento,CarreraId")] DCorrea dCorrea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dCorrea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "NombreCarrera", dCorrea.CarreraId);
            return View(dCorrea);
        }

        // GET: DCorreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCorrea = await _context.DCorrea.FindAsync(id);
            if (dCorrea == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "NombreCarrera", dCorrea.CarreraId);
            return View(dCorrea);
        }

        // POST: DCorreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NumHijos,Salario,Ciudad,Activo,FechaNacimiento,CarreraId")] DCorrea dCorrea)
        {
            if (id != dCorrea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dCorrea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DCorreaExists(dCorrea.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "NombreCarrera", dCorrea.CarreraId);
            return View(dCorrea);
        }

        // GET: DCorreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCorrea = await _context.DCorrea
                .Include(d => d.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dCorrea == null)
            {
                return NotFound();
            }

            return View(dCorrea);
        }

        // POST: DCorreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dCorrea = await _context.DCorrea.FindAsync(id);
            if (dCorrea != null)
            {
                _context.DCorrea.Remove(dCorrea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DCorreaExists(int id)
        {
            return _context.DCorrea.Any(e => e.Id == id);
        }
    }
}
