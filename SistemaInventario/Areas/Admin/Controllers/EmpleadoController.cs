using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Modelos.ViewModels;
using SistemaInventario.Utilidades;
using System.Collections.Specialized;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpleadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmpleadoController(IUnidadTrabajo unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                Empleado = new Empleado(),
                LugarLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Lugar"),
                PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto")
            };

            if(id == null)
            {
                //Crear un Empleado Nuevos
                return View(empleadoVM);
            }
            else
            {
                //Actualizar un Empleado Existente
                empleadoVM.Empleado = await _unidadTrabajo.Empleado
                    .Obtener(id.GetValueOrDefault());
                if(empleadoVM.Empleado == null)
                {
                    return NotFound();
                }
                return View(empleadoVM);
            }
        }





        #region API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EmpleadoVM empleadoVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRooPath = _webHostEnvironment.WebRootPath;
                if (empleadoVM.Empleado.Id == 0)
                {
                    //Crear un nuevo Empleado
                    string upload = webRooPath;
                    await _unidadTrabajo.Empleado.Agregar(empleadoVM.Empleado);
                }
                else
                {
                    //actiaulizar el empleado
                    var objEmpleado = await _unidadTrabajo.Empleado.ObtenerPrimero(p => p.Id == empleadoVM.Empleado.Id, isTracking: false);
                    _unidadTrabajo.Empleado.Actualizar(empleadoVM.Empleado);
                }
                TempData[DS.Exitosa] = "Empleado Registrado";
                await _unidadTrabajo.Guardar();
                return View("Index");
            }//si el Model State es falso
            empleadoVM.LugarLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Lugar");
            empleadoVM.PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto");
            return View(empleadoVM);
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Empleado.ObtenerTodos(incluirPropiedades:"Lugar,Puesto");
            return Json(new {data = todos});
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var empleadoDB = await _unidadTrabajo.Empleado.Obtener(id);
            if (empleadoDB == null)
            {
                return Json(new { success = false, message = "Error al Borrar el Registro en la Base de Datos" });
            }

            _unidadTrabajo.Empleado.Remover(empleadoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "empleado Eliminado con Exito" });
            
 
        
        }

        #endregion
    }
}
