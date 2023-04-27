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
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IPersonaRepository _personaRepository;

        public TelefonoController()
        {
            _telefonoRepository = new TelefonoRepository();
            _personaRepository = new PersonaRepository();
        }

        // GET: Telefono
        public async Task<IActionResult> Index()
        {
            return View( _telefonoRepository.GetAll());
        }

        // GET: Telefono/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = _telefonoRepository.GetByNum(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefono/Create
        public IActionResult Create()
        {
            ViewData["Duenio"] = new SelectList(_personaRepository.GetAll(), "Cc", "Cc");
            return View();
        }

        // POST: Telefono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            Console.WriteLine("Create Telefono");
            Persona p = _personaRepository.GetByCC(telefono.Duenio);
            if(p == null)
            {
                Console.WriteLine("Persona not found");
                return NotFound();
            }


            p.Telefonos.Add(telefono);
            _personaRepository.Update(p);

            //_telefonoRepository.Insert(telefono);
            _telefonoRepository.Save();
            _personaRepository.Save();

             return RedirectToAction(nameof(Index));
        }

        // GET: Telefono/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = _telefonoRepository.GetByNum(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["Duenio"] = new SelectList(_personaRepository.GetAll(), "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _telefonoRepository.Update(telefono);
                _telefonoRepository.Save();
                   
                return RedirectToAction(nameof(Index));
            }
            ViewData["Duenio"] = new SelectList(_personaRepository.GetAll(), "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = _telefonoRepository.GetByNum(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           
            var telefono = _telefonoRepository.GetByNum(id);
            if (telefono != null)
            {
                _telefonoRepository.Delete(id);
            }
            
            _telefonoRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
