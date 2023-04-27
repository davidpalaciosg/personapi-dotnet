using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interface;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repository;

namespace personapi_dotnet.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _context;

        //Constructor
        public PersonasController()
        {
            _context = new PersonaRepository();
        }
        /*
        public PersonasController(IPersonaRepository context)
        {
            _context = context;
        }
        */

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(_context.GetAll());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? cc)
        {
            if (cc == null)
            {
                return NotFound();
            }

            var persona = _context.GetByCC((int)cc);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Insert(persona);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? cc)
        {
            if (cc == null)
            {
                return NotFound();
            }
            var persona = _context.GetByCC((int)cc);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int cc, [Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (cc != persona.Cc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(persona);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? cc)
        {
            if (cc == null)
            {
                return NotFound();
            }

            var persona = _context.GetByCC((int)cc);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? cc)
        {
            _context.Delete((int)cc);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
