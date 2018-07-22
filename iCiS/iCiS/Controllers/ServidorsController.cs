using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iCiS.Models;

namespace iCiS.Controllers
{
    public class ServidorsController : Controller
    {
        private readonly iCiSContext _context;

        public ServidorsController(iCiSContext context)
        {
            _context = context;
        }

        // GET: Servidors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servidor.ToListAsync());
        }

        // GET: Servidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // GET: Servidors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Sistema_operativo,Fecha_captura")] Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servidor);
        }

        // GET: Servidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor.SingleOrDefaultAsync(m => m.ID == id);
            if (servidor == null)
            {
                return NotFound();
            }
            return View(servidor);
        }

        // POST: Servidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Sistema_operativo,Fecha_captura")] Servidor servidor)
        {
            if (id != servidor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServidorExists(servidor.ID))
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
            return View(servidor);
        }

        // GET: Servidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // POST: Servidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servidor = await _context.Servidor.SingleOrDefaultAsync(m => m.ID == id);
            _context.Servidor.Remove(servidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServidorExists(int id)
        {
            return _context.Servidor.Any(e => e.ID == id);
        }
    }
}
