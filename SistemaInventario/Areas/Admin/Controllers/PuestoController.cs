using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Utilidades;
using System.Collections.Specialized;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PuestoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public PuestoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        //metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            Puesto puesto = new Puesto();
            if (id == null)
            {
                //creamos un nuevo registro
                puesto.Estado = true;
                return View(puesto);
            }
            puesto = await _unidadTrabajo.Puesto.Obtener(id.GetValueOrDefault());
            if (puesto == null)
            {
                return NotFound();
            }
            return View(puesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                if (puesto.Id == 0)
                {
                    await _unidadTrabajo.Puesto.Agregar(puesto);
                    TempData[DS.Exitosa] = "La Puesto se Creo con Exito";
                }
                else
                {
                    _unidadTrabajo.Puesto.Actualizar(puesto);
                    TempData[DS.Exitosa] = "La Puesto se Actualizo con Exito";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al Grabar la Puesto";
            return View(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var puestoDB = await _unidadTrabajo.Puesto.Obtener(id);
            if (puestoDB == null)
            {
                return Json(new { success = false, message = "Error al Borrar el Registro en la Base de Datos" });
            }
            _unidadTrabajo.Puesto.Remover(puestoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Puesto Eliminada con Exito" });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Puesto.ObtenerTodos();
            return Json(new { data = todos });
        }




        #endregion
    }
}
