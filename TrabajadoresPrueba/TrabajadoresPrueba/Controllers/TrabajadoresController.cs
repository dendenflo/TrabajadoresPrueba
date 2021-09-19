using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Entidades;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrabajadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.PR_TRABA.FromSqlRaw("EXEC dbo.PR_TRABA").ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            //Combo Tipo Documento
            var listaTipoDocumento = new List<Combo>();
            listaTipoDocumento.Add(new Combo { codigo = "DNI", descripcion = "DNI" });
            listaTipoDocumento.Add(new Combo { codigo = "CXE", descripcion = "Carnet de Extranjeria" });
            listaTipoDocumento.Add(new Combo { codigo = "", descripcion = " --Seleccione-- " });

            ViewData["codigo"] = new SelectList(listaTipoDocumento.OrderBy(s => s.descripcion), "codigo", "descripcion");

            //Combo Departamentos
            var listaDepartamentos = _context.Departamento.ToList();
            listaDepartamentos.Add(new Departamento { Id = 0, NombreDepartamento = " --Selecccione-- " });
            ViewData["Departamentos"] = new SelectList(listaDepartamentos.OrderBy(t => t.Id), "Id", "NombreDepartamento");

            //Combo Provincias
            var listaProvincias = new List<Provincia>();
            listaProvincias.Add(new Provincia { Id = 0, NombreProvincia = " --Cargando-- " });
            ViewData["Provincias"] = new SelectList(listaProvincias.OrderBy(x => x.Id), "Id", "NombreProvincia");

            //Combo Distritos
            var listaDistritos = new List<Distrito>();
            listaDistritos.Add(new Distrito { Id = 0, NombreDistrito = " --Cargando-- " });
            ViewData["Distritos"] = new SelectList(listaDistritos.OrderBy(z => z.Id), "Id", "NombreDistrito");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView(trabajadores);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //Combo Tipo Documento
            var listaTipoDocumento = new List<Combo>();
            listaTipoDocumento.Add(new Combo { codigo = "DNI", descripcion = "DNI" });
            listaTipoDocumento.Add(new Combo { codigo = "CXE", descripcion = "Carnet de Extranjeria" });
            listaTipoDocumento.Add(new Combo { codigo = "000", descripcion = " --Seleccione-- " });

            ViewData["codigo"] = new SelectList(listaTipoDocumento.OrderBy(s => s.descripcion), "codigo", "descripcion");

            //Combo Departamentos
            var listaDepartamentos = _context.Departamento.ToList();
            listaDepartamentos.Add(new Departamento { Id = 0, NombreDepartamento = " --Selecccione-- " });
            ViewData["Departamentos"] = new SelectList(listaDepartamentos.OrderBy(t => t.Id), "Id", "NombreDepartamento");

            //Combo Provincias
            var listaProvincias = _context.Provincia.ToList();
            listaProvincias.Add(new Provincia { Id = 0, NombreProvincia = " --Selecccione-- " });
            ViewData["Provincias"] = new SelectList(listaProvincias.OrderBy(x => x.Id), "Id", "NombreProvincia");

            //Combo Distritos
            var listaDistritos = _context.Distrito.ToList();
            listaDistritos.Add(new Distrito { Id = 0, NombreDistrito = " --Selecccione-- " });
            ViewData["Distritos"] = new SelectList(listaDistritos.OrderBy(z => z.Id), "Id", "NombreDistrito");

            var trabajadores = await _context.Trabajadores.FindAsync(id);
            if (trabajadores == null)
            {
                return NotFound();
            }
            return PartialView(trabajadores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trabajadores trabajadores)
        {
            if (id != trabajadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(trabajadores);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Trabajadores.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult listaProvincias(string idDepartamento)
        {
            //listado de provincias que sean del departamento igual al parametro
            var listProvincias = _context.Provincia.Where(t => t.IdDepartamento.Equals(int.Parse(idDepartamento))).ToList();
            listProvincias.Add(new Provincia { Id = 0, NombreProvincia = " --Selecccione-- " });

            return Json(listProvincias.OrderBy(m => m.Id));
        }

        public IActionResult listaDistritos(string idProvincia)
        {
            //listado de Distritos que sean del departamento igual al parametro
            var listDistritos = _context.Distrito.Where(t => t.IdProvincia.Equals(int.Parse(idProvincia))).ToList();
            listDistritos.Add(new Distrito { Id = 0, NombreDistrito = " --Selecccione-- " });

            return Json(listDistritos.OrderBy(m => m.Id));
        }
    }
}