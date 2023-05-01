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
    public class EstudioController : Controller
    {

        private readonly IEstudioRepository _context;

        public EstudioController()
        {
            _context = new EstudioRepository();
        }

        public async Task<IActionResult> Index()
        {
            return View(_context.GetAll());
        }

        // GET: Estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Insert(estudio);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                Console.WriteLine("Not idProf given");
                return NotFound();
            }

            var estudio = _context.GetByKeys(id);
            if (estudio == null)
            {
                Console.WriteLine("estudio Not found");
                return NotFound();
            }

            return View(estudio);
        }




    }
}
