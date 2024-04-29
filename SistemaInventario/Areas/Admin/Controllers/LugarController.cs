using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Utilidades;
using System.Collections.Specialized;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LugarController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public LugarController(IUnidadTrabajo unidadTrabajo)
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
            Lugar lugar = new Lugar();
            if (id == null)
            {
                //creamos un nuevo registro
                lugar.Estado = true;
                return View(lugar);
            }
            lugar = await _unidadTrabajo.Lugar.Obtener(id.GetValueOrDefault());
            if (lugar == null)
            {
                return NotFound();
            }
            return View(lugar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                if (lugar.Id == 0)
                {
                    await _unidadTrabajo.Lugar.Agregar(lugar);
                    TempData[DS.Exitosa] = "La Area se Creo con Exito";
                }
                else
                {
                    _unidadTrabajo.Lugar.Actualizar(lugar);
                    TempData[DS.Exitosa] = "La Area se Actualizo con Exito";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al Grabar la Area";
            return View(lugar);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var lugarDB = await _unidadTrabajo.Lugar.Obtener(id);
            if (lugarDB == null)
            {
                return Json(new { success = false, message = "Error al Borrar el Registro en la Base de Datos" });
            }
            _unidadTrabajo.Lugar.Remover(lugarDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Area Eliminada con Exito" });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Lugar.ObtenerTodos();
            return Json(new { data = todos });
        }




        #endregion
    }
}
